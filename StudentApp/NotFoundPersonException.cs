using System;
using System.Collections.Generic;
using System.Text;

namespace StudentApp
{
    class NotFoundPersonException: Exception
    {
        /// <summary>
        /// Персона не найдена
        /// </summary>
        /// <param name="message"></param>
        public NotFoundPersonException(string message) : base(message) { }
    }
}
