using ELFSharp.ELF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VBoxDumpGUI
{
    public partial class Main : Form
    {
        // Global
        public enum DebugType { Error = 1, Warning = 2, Info = 3, Debug = 4 }
        string appVersion = "0.1";
        string appBuild = "2020.0525";
        string appName = "VBoxDump-GUI";
        string author = "onSec-fr";
        string vboxDirectory = "NOT FOUND";
        string outputFilePath = "UNDEFINED";
        string selectedVmGuid = "";
        long offset = 0;
        long size = 0;
        public Main()
        {
            InitializeComponent();
        }

        // Logging
        private void Output(string txt, DebugType type, bool newline = true)
        {
            string line = "";
            Color color = Color.White;
            if (newline)
                line += Environment.NewLine;
            switch (type)
            {
                case DebugType.Error:
                    color = Color.Red;
                    line += "[X] ";
                    break;
                case DebugType.Warning:
                    color = Color.Yellow;
                    line += "[!] ";
                    break;
                case DebugType.Info:
                    color = Color.White;
                    line += "[i] ";
                    break;
                case DebugType.Debug:
                    color = Color.Green;
                    line += "[+]"; ;
                    break;
            }
            line += txt;
            SetText(line, color, line, newline);
        }
        delegate void SetTextCallback(string text, Color color, string line, bool newline);
        private void SetText(string text, Color color, string line, bool newline)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.txtConsole.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text, color, line, newline });
            }
            else
            {
                this.txtConsole.AppendText(text);
                if(newline == true)
                    this.txtConsole.Select(txtConsole.TextLength - line.Length + 1, line.Length);
                else
                    this.txtConsole.Select(txtConsole.TextLength - line.Length, line.Length);
                this.txtConsole.SelectionColor = color;
            }
        }

        // Launch VBOXManage with args
        private String VBoxManageCmd(String args)
        {
            Process VBoxManage = new Process();
            VBoxManage.StartInfo.CreateNoWindow = true;
            VBoxManage.StartInfo.FileName = vboxDirectory + "VBoxManage.exe";
            VBoxManage.StartInfo.WorkingDirectory = vboxDirectory;
            VBoxManage.StartInfo.Arguments = args;
            VBoxManage.StartInfo.UseShellExecute = false;
            VBoxManage.StartInfo.RedirectStandardOutput = true;
            try
            {
                VBoxManage.Start();
            }
            catch
            {
                Output("VBoxManage could not be started. Please check if it exists and that you are admin.", DebugType.Error);
                return "error_vboxmanage";
            }
            String output = "";
            while (!VBoxManage.StandardOutput.EndOfStream)
            {
                Application.DoEvents();
                output += VBoxManage.StandardOutput.ReadToEnd();
            }
            return output.Trim();
        }

        // Get current running Vms on the host, using vboxmanage
        private List<String> getRunningVms()
        {
            Output("Recovering active vms...", DebugType.Debug);
            var vms = VBoxManageCmd("list runningvms");
            List<String> lstVms = new List<String>();
            if (vms == "error_vboxmanage")
            {
                return lstVms;
            }
            foreach (string line in vms.Split('\n'))
            {
                if (line != "")
                    lstVms.Add(line);
            }
            if (lstVms.Count == 0)
                Output("No running vms found ! Please launch the VM you want to dump and make sure you are using the right user.", DebugType.Warning);
            else
                Output("Vms found.", DebugType.Info);
            return lstVms;
        }

        // Triggered at app start
        private void Main_Load(object sender, EventArgs e)
        {
            // Init
            Output("Application: " + appName, DebugType.Debug, false);
            Output("Version: " + appVersion + "(" + appBuild + ")", DebugType.Debug);
            Output("Author: " + author + "\n", DebugType.Debug);
            btnDump.Enabled = false;
            // Set default output file path
            outputFilePath = Directory.GetCurrentDirectory() + @"\dump.raw";
            txtOutputPath.Text = outputFilePath;
            // Retrieve VirtualBox installation directory
            Output("Trying to find VirtualBox installation directory...", DebugType.Debug);
            string programFiles = Environment.ExpandEnvironmentVariables("%ProgramW6432%");
            string programFilesX86 = Environment.ExpandEnvironmentVariables("%ProgramFiles(x86)%");
            if (Directory.Exists(programFiles + @"\Oracle\VirtualBox\"))
            {
                vboxDirectory = programFiles + @"\Oracle\VirtualBox\";
                Output("Directory found : " + vboxDirectory, DebugType.Info);
                txtPath.Text = vboxDirectory;
                goto AutomatedNextStep;
            }
            else if (Directory.Exists(programFilesX86 + @"\Oracle\VirtualBox\"))
            {
                vboxDirectory = programFilesX86 + @"\Oracle\VirtualBox\";
                Output("Directory found : " + vboxDirectory, DebugType.Info);
                txtPath.Text = vboxDirectory;
                goto AutomatedNextStep;
            }
            else
            {
                Output("VirtualBox installation not found ! Please enter the installation path.", DebugType.Warning);
                txtPath.Text = vboxDirectory;
                goto End;
            }
        // Go to next step if vbox directory is found
        AutomatedNextStep:
            lstVms.Items.Clear();
            foreach (string line in getRunningVms())
            {
                lstVms.Items.Add(line);
            }
            if (lstVms.Items.Count > 0)
            {
                lstVms.SelectedIndex = 0;
            }
        // Go here if vbox directory not found
        End:
            txtPath.Focus();
        }

        // Copy input stream to output file from given offset and size (async)
        public async Task CopyFileSection(string inFile, string outFile, long startPosition, long size)
        {
            using (var inStream = File.OpenRead(inFile))
            using (var outStream = File.OpenWrite(outFile))
            {
                inStream.Seek(startPosition, SeekOrigin.Begin);

                long remaining = size;
                // Process by 1024^2 bytes so it wont use too much memory
                byte[] buffer = new byte[1024 * 1024];

                do
                {
                    int bytesRead = await inStream.ReadAsync(buffer, 0, (int)Math.Min(buffer.Length, remaining));
                    if (bytesRead == 0) { break; }

                    await outStream.WriteAsync(buffer, 0, bytesRead);
                    remaining -= bytesRead;
                }
                while (remaining > 0);
            }
        }

        // Button to change installation directory
        private void button1_Click_1(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();
                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    txtPath.Text = fbd.SelectedPath;
                    vboxDirectory = @txtPath.Text;
                    Output("VBox installation directory changed to : " + vboxDirectory + " by user.", DebugType.Info);
                }
            }
        }

        // Button to refresh vms list
        private void btnRefreshVms_Click(object sender, EventArgs e)
        {
            lstVms.Items.Clear();
            foreach (string line in getRunningVms())
            {
                lstVms.Items.Add(line);
            }
        }

        // Get selected VM informations
        private void lstVms_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstVms.SelectedIndex != -1)
            {
                btnDump.Enabled = true;
                Output("Gathering vm infos...", DebugType.Debug);
                try
                {
                    string vm = lstVms.SelectedItem.ToString();
                    Regex regexName = new Regex("\".*\"");
                    Match matchName = regexName.Match(vm);
                    string name = matchName.Value.Trim('"');
                    Regex regexGuid = new Regex("{.*}");
                    Match matchGuid = regexGuid.Match(vm);
                    string guid = matchGuid.Value;
                    string system = VBoxManageCmd("debugvm " + guid + " osinfo");
                    txtNameVm.Text = "VM : " + name;
                    txtSystemVm.Text = system;
                    txtGuidVm.Text = "GUID : " + guid;
                    selectedVmGuid = guid;
                    Output("OK.", DebugType.Info, false);
                }
                catch
                {
                    Output("Failed", DebugType.Warning, false);
                    selectedVmGuid = "";
                }
            }
        }

        // Button to change output file
        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "image format (*.raw)|*.raw";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtOutputPath.Text = saveFileDialog1.FileName;
                outputFilePath = @txtOutputPath.Text;
                Output("Output file location changed to : " + outputFilePath + " by user.", DebugType.Debug);
            }
        }

        // Button to start dumping process
        private async void btnDump_Click(object sender, EventArgs e)
        {
            bool next = true;
            // Disabled buttons during dumping process
            btnSetPathToVBox.Enabled = false;
            btnSetOutputFilePath.Enabled = false;
            btnDump.Enabled = false;
            lstVms.Enabled = false;
            btnRefreshVms.Enabled = false;
            // 1) Full dump with dumpvmcore
            string pathTemp = Directory.GetCurrentDirectory() + @"\temp.elf";
            // Check if old dump exists and delete it
            if (File.Exists(pathTemp))
            {
                File.Delete(pathTemp);
                Output("Old dump file removed." + pathTemp + "...", DebugType.Info);
            }
            // Dump full vmc with vboxmanage utility
            Output("Dumping vmcore to " + pathTemp + "...", DebugType.Debug);
            await Task.Run(() =>
            {
                if (VBoxManageCmd("debugvm " + selectedVmGuid + " dumpvmcore --filename " + pathTemp) == "error_vboxmanage")
                {
                    Output("Failed.", DebugType.Error, false);
                    next = false;
                }
                else
                {
                    Output("OK.", DebugType.Info, false);
                }
            });
            // 2) Extract offset and size of first load section of elf
            if (next == true)
            {
                Output("Extracting memory section...", DebugType.Debug);
                /* 
                 * 1- Extract only first 1024^2 bytes of the input file. Enough to retrieve segment headers.
                 * 2- Using elfsharp, retrieve offset and size of the first load section.
                 * */
                byte[] FirstPartOfFile = new byte[1024 * 1024];
                using (BinaryReader reader = new BinaryReader(new FileStream(pathTemp, FileMode.Open)))
                {
                    reader.BaseStream.Seek(0, SeekOrigin.Begin);
                    reader.Read(FirstPartOfFile, 0, 1024 * 1024);
                }
                using var inStream = new MemoryStream(FirstPartOfFile);
                var elf = ELFReader.Load<ulong>(inStream, true);
                offset = (long)elf.Segments.FirstOrDefault(segment => segment.Type.ToString() == "Load").Offset;
                size = (long)elf.Segments.FirstOrDefault(segment => segment.Type.ToString() == "Load").Size;
                // Display 
                txtOffset.Text = offset.ToString("X");
                txtSize.Text = size.ToString("X");
                if (txtOffset.Text == "" || txtOffset.Text == "0" || txtSize.Text == "" || txtSize.Text == "0")
                {
                    Output("Failed to extract memory section.", DebugType.Error);
                    next = false;
                }
                else
                {
                    Output("OK.", DebugType.Info, false);
                    Output("Offset found : " + offset.ToString("X"), DebugType.Info);
                    Output("Size found : " + size.ToString("X"), DebugType.Info);
                }
                // Close stream
                inStream.Dispose();
            }
            // 3) Write bytes to the outputfile
            if (next == true)
            {
                // Check if output file name already exist and change it
                if (File.Exists(outputFilePath))
                {
                    if (outputFilePath.Contains(".raw"))
                        outputFilePath = outputFilePath.Remove(outputFilePath.Length - 4) + DateTime.Now.ToString("yyyyMMddHHmmss") + ".raw";
                    else
                        outputFilePath = outputFilePath + DateTime.Now.ToString("yyyyMMddHHmmss");
                    Output("Output file already exists ! Changed path to " + outputFilePath + ".", DebugType.Debug);
                }
                Output("Writing dump file...", DebugType.Info);
                // Copy bytes to outputfile (async)
                try
                {
                    await CopyFileSection(pathTemp, outputFilePath, offset, size);
                    Output("Ram dump saved to " + outputFilePath, DebugType.Info);
                }
                catch
                {
                    Output("Failed to write output dump file!", DebugType.Error);
                }
            }
            // 4) Remove full core dump
            File.Delete(pathTemp);
            Output("Removed core dump file." + pathTemp + ".", DebugType.Debug);
            txtConsole.DeselectAll();
            // Enabled buttons when dumping process completed
            btnSetPathToVBox.Enabled = true;
            btnSetOutputFilePath.Enabled = true;
            btnDump.Enabled = true;
            lstVms.Enabled = true;
            btnRefreshVms.Enabled = true;
        }
    }
}
