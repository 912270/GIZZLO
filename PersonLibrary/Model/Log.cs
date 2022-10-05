using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PersonLibrary.Model
{
    public static class Log
    {
        public static void Info(RepoEventArgs e)
        {
            var path = @"Log.txt";
            var log = string.Format("Info: {0} {1}{2}", DateTime.Now.ToString("O"), e.Message, Environment.NewLine);
            File.AppendAllText(path, log);
        }
    }
}
