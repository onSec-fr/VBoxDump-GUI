# VBoxDump-GUI
![](https://github.com/onSec-fr/VBoxDump-GUI/blob/master/Images/vboxgui.png?raw=true)

#### A simple tool to create a RAM Dump from a running VirtualBox instance.

[TOC]

------------

#### Why ?
For forensic purposes it is sometimes necessary to generate a memory dump from a VM snapshot. It is also something that is regularly encountered in CTF.

On linux, that is quite easy to do, using *vboxmanage* and *objdump*. 
For those who (like me) also like to work on **Windows**, there's no native way to do it.

**VBoxDump-GUI** offers a quick and easy way  to generate a **RAM dump** from any running VirtualBox VMs. And because we're lazy, let's use a **GUI** !
#### Features
- User-friendly GUI.
- Lists running VMs on the host.
- Automatically retrieves the RAM section and create a standard raw file.
- Supports all VM guest platforms.

#### Demo
![](https://github.com/onSec-fr/VBoxDump-GUI/blob/master/Images/demo.gif?raw=true)

#### Run
##### Prerequisite
- Arch: x64
- OS: Windows 7, Windows 8, Windows 10
- .NET Core 3 Runtime : https://dotnet.microsoft.com/download/dotnet-core/current/runtime

##### Release
- <a id="raw-url" href="https://github.com/onSec-fr/VBoxDump-GUI/blob/master/Release/vboxdumpgui-0.1-release.zip?raw=true">**Download release**</a>
- Launch`VBoxDumpGUI.exe`

##### Build
Alternatively you can build from source : `dotnet publish {path_to_solution} -c Release -r win-x64 --output {path_to_destination}`

#### The future
If there's interest in this project, I'd like to include forensic analysis capabilities (password extraction, dump files, dump process, etc).
