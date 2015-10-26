﻿// ****************************************************************************
// 
// Copyright (C) 2014-2015 TautCony (TautCony@vcb-s.com)
// 
// This program is free software; you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation; either version 2 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program; if not, write to the Free Software
// Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA
// 
// ****************************************************************************
using System.Xml;

namespace ChapterTool
{
    class matroskaInfo
    {
        public XmlDocument result;
        public matroskaInfo(string path, string program = "mkvextract.exe")
        {
            result = new XmlDocument();
            string arg = "chapters \"" + path + "\"";
            string xmlresult = runMkvextract(arg, program);
            result.LoadXml(xmlresult);
        }
        static string runMkvextract(string arguments,string program)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.StartInfo.FileName = program;
            process.StartInfo.Arguments = arguments;
            // 禁用操作系统外壳程序
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.Start();

            string output = process.StandardOutput.ReadToEnd();

            process.WaitForExit();
            process.Close();
            return output;
        }

    }
}
