# Firedump
## Fast, light MySql backup and scheduler.
-------
![tag](https://img.shields.io/badge/Language-CSharp-green)
![tag](https://img.shields.io/badge/Using-SQLite-green)
![tag](https://img.shields.io/badge/Backups-blue)
![tag](https://img.shields.io/badge/FTP-blue)
![tag](https://img.shields.io/badge/Scheduler-WindowsService-blue)
![tag](https://img.shields.io/badge/Compatible-MySQL-red)
![tag](https://img.shields.io/badge/Compatible-MariaDB-red)

Firedump is a lightweight backup manager for mysql and mariadb databases written in C# .NET. It has a plethora of backup configuration options. 
It is able to create incremental backup dumps from the log files for mysql. Offers high compression and encryption options for backup files. Capable
of saving to multiple output locations locally or with ftp/sftp. Can take snapshots of live databases using the single transaction option without
disrupting use. An automatic update scheduler service for windows is under development. 

<br>
<img src="https://github.com/CsPeitch/Firedump/blob/master/icons/pic1.PNG?raw=true" width="600" />
<br>
<img src="https://github.com/CsPeitch/Firedump/blob/master/icons/pic2.PNG?raw=true" width="600" />
<br>
<img src="https://github.com/CsPeitch/Firedump/blob/master/icons/pic5.PNG?raw=true" width="600" />
<br>
<img src="https://github.com/CsPeitch/Firedump/blob/master/icons/pic3.PNG?raw=true" width="600" />
<br>
<img src="https://github.com/CsPeitch/Firedump/blob/master/icons/pic6.PNG?raw=true" width="600" />
<br>
<img src="https://github.com/CsPeitch/Firedump/blob/master/icons/pic8.PNG?raw=true" width="600" />
<br>
<img src="https://github.com/CsPeitch/Firedump/blob/master/icons/pic4.PNG?raw=true" width="600" />

## LICENSE
MIT License

Copyright (c) 2019 Chrysovalantis Pitsas

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
