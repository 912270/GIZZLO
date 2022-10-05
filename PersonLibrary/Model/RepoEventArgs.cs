using System;
using System.Collections.Generic;
using System.Text;

namespace PersonLibrary.Model
{
    public class RepoEventArgs
    {
        public string Message { get; }

        public RepoEventArgs(string message)
        {
            Message = message;
        }
    }
}
