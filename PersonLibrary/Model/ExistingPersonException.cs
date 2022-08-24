using System;
using System.Collections.Generic;
using System.Text;

namespace PersonLibrary.Model
{
    class ExistingPersonException: Exception
    {
        /// <summary>
        /// Персона уже существует
        /// </summary>
        /// <param name="message"></param>
        public ExistingPersonException(string message = "Пользователь уже существует") : base(message) { }
    }
}
