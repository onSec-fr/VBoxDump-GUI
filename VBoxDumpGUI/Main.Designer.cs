namespace VBoxDumpGUI
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnSetOutputFilePath = new System.Windows.Forms.Button();
            this.btnDump = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtOffset = new System.Windows.Forms.TextBox();
            this.txtSize = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtOutputPath = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnRefreshVms = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtNameVm = new System.Windows.Forms.Label();
            this.txtGuidVm = new System.Windows.Forms.Label();
            this.txtSystemVm = new System.Windows.Forms.Label();
            this.lstVms = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSetPathToVBox = new System.Windows.Forms.Button();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.txtConsole = new System.Windows.Forms.RichTextBox();
            this.panel1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox4);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(586, 449);
            this.panel1.TabIndex = 1;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnSetOutputFilePath);
            this.groupBox4.Controls.Add(this.btnDump);
            this.groupBox4.Controls.Add(this.groupBox5);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.txtOutputPath);
            this.groupBox4.Location = new System.Drawing.Point(11, 262);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(564, 177);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Dump";
            // 
            // btnSetOutputFilePath
            // 
            this.btnSetOutputFilePath.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnSetOutputFilePath.Location = new System.Drawing.Point(484, 39);
            this.btnSetOutputFilePath.Name = "btnSetOutputFilePath";
            this.btnSetOutputFilePath.Size = new System.Drawing.Size(65, 24);
            this.btnSetOutputFilePath.TabIndex = 6;
            this.btnSetOutputFilePath.Text = "...";
            this.btnSetOutputFilePath.UseVisualStyleBackColor = true;
            this.btnSetOutputFilePath.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnDump
            // 
            this.btnDump.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnDump.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnDump.Location = new System.Drawing.Point(353, 98);
            this.btnDump.Name = "btnDump";
            this.btnDump.Size = new System.Drawing.Size(196, 54);
            this.btnDump.TabIndex = 5;
            this.btnDump.Text = "DUMP >";
            this.btnDump.UseVisualStyleBackColor = false;
            this.btnDump.Click += new System.EventHandler(this.btnDump_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Controls.Add(this.txtOffset);
            this.groupBox5.Controls.Add(this.txtSize);
            this.groupBox5.Location = new System.Drawing.Point(14, 78);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(290, 86);
            this.groupBox5.TabIndex = 3;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Details";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label4.Location = new System.Drawing.Point(17, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 15);
            this.label4.TabIndex = 2;
            this.label4.Text = "Memory Size";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label3.Location = new System.Drawing.Point(5, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Memory Offset";
            // 
            // txtOffset
            // 
            this.txtOffset.Location = new System.Drawing.Point(98, 22);
            this.txtOffset.Name = "txtOffset";
            this.txtOffset.ReadOnly = true;
            this.txtOffset.Size = new System.Drawing.Size(178, 23);
            this.txtOffset.TabIndex = 0;
            // 
            // txtSize
            // 
            this.txtSize.Location = new System.Drawing.Point(98, 51);
            this.txtSize.Name = "txtSize";
            this.txtSize.ReadOnly = true;
            this.txtSize.Size = new System.Drawing.Size(178, 23);
            this.txtSize.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label2.Location = new System.Drawing.Point(224, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Output File";
            // 
            // txtOutputPath
            // 
            this.txtOutputPath.Location = new System.Drawing.Point(14, 40);
            this.txtOutputPath.Name = "txtOutputPath";
            this.txtOutputPath.Size = new System.Drawing.Size(464, 23);
            this.txtOutputPath.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnRefreshVms);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.lstVms);
            this.groupBox2.Location = new System.Drawing.Point(11, 83);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(564, 173);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Running VMs";
            // 
            // btnRefreshVms
            // 
            this.btnRefreshVms.ForeColor = System.Drawing.SystemColors.InfoText;
            this.btnRefreshVms.Location = new System.Drawing.Point(14, 22);
            this.btnRefreshVms.Name = "btnRefreshVms";
            this.btnRefreshVms.Size = new System.Drawing.Size(62, 23);
            this.btnRefreshVms.TabIndex = 3;
            this.btnRefreshVms.Text = "Refresh";
            this.btnRefreshVms.UseVisualStyleBackColor = true;
            this.btnRefreshVms.Click += new System.EventHandler(this.btnRefreshVms_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtNameVm);
            this.groupBox3.Controls.Add(this.txtGuidVm);
            this.groupBox3.Controls.Add(this.txtSystemVm);
            this.groupBox3.Location = new System.Drawing.Point(334, 22);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(215, 138);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Infos";
            // 
            // txtNameVm
            // 
            this.txtNameVm.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.txtNameVm.Location = new System.Drawing.Point(6, 19);
            this.txtNameVm.Name = "txtNameVm";
            this.txtNameVm.Size = new System.Drawing.Size(203, 32);
            this.txtNameVm.TabIndex = 1;
            this.txtNameVm.Text = "Name :";
            // 
            // txtGuidVm
            // 
            this.txtGuidVm.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.txtGuidVm.Location = new System.Drawing.Point(6, 51);
            this.txtGuidVm.Name = "txtGuidVm";
            this.txtGuidVm.Size = new System.Drawing.Size(203, 31);
            this.txtGuidVm.TabIndex = 1;
            this.txtGuidVm.Text = "GUID :";
            // 
            // txtSystemVm
            // 
            this.txtSystemVm.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.txtSystemVm.Location = new System.Drawing.Point(6, 82);
            this.txtSystemVm.Name = "txtSystemVm";
            this.txtSystemVm.Size = new System.Drawing.Size(203, 53);
            this.txtSystemVm.TabIndex = 1;
            this.txtSystemVm.Text = "System : ";
            // 
            // lstVms
            // 
            this.lstVms.FormattingEnabled = true;
            this.lstVms.ItemHeight = 15;
            this.lstVms.Items.AddRange(new object[] {
            "None"});
            this.lstVms.Location = new System.Drawing.Point(14, 51);
            this.lstVms.Name = "lstVms";
            this.lstVms.Size = new System.Drawing.Size(314, 109);
            this.lstVms.TabIndex = 0;
            this.lstVms.SelectedIndexChanged += new System.EventHandler(this.lstVms_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnSetPathToVBox);
            this.groupBox1.Controls.Add(this.txtPath);
            this.groupBox1.Location = new System.Drawing.Point(11, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(564, 77);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Configuration";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label1.Location = new System.Drawing.Point(216, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "VirutalBox Directory";
            // 
            // btnSetPathToVBox
            // 
            this.btnSetPathToVBox.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.btnSetPathToVBox.Location = new System.Drawing.Point(484, 39);
            this.btnSetPathToVBox.Name = "btnSetPathToVBox";
            this.btnSetPathToVBox.Size = new System.Drawing.Size(65, 24);
            this.btnSetPathToVBox.TabIndex = 0;
            this.btnSetPathToVBox.Text = "...";
            this.btnSetPathToVBox.UseVisualStyleBackColor = true;
            this.btnSetPathToVBox.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(14, 40);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(464, 23);
            this.txtPath.TabIndex = 1;
            // 
            // txtConsole
            // 
            this.txtConsole.BackColor = System.Drawing.SystemColors.WindowText;
            this.txtConsole.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtConsole.Location = new System.Drawing.Point(604, 12);
            this.txtConsole.Name = "txtConsole";
            this.txtConsole.Size = new System.Drawing.Size(347, 449);
            this.txtConsole.TabIndex = 2;
            this.txtConsole.Text = "";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(961, 471);
            this.Controls.Add(this.txtConsole);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "Main";
            this.Text = "VBoxDump-GUI | v0.1";
            this.Load += new System.EventHandler(this.Main_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Button btnSetPathToVBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox txtConsole;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label txtSystemVm;
        private System.Windows.Forms.Label txtNameVm;
        private System.Windows.Forms.Label txtGuidVm;
        private System.Windows.Forms.ListBox lstVms;
        private System.Windows.Forms.Button btnRefreshVms;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtOffset;
        private System.Windows.Forms.TextBox txtSize;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtOutputPath;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnDump;
        private System.Windows.Forms.Button btnSetOutputFilePath;
    }
}

