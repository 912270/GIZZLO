using System;
using System.Collections.Generic;
using System.Text;

namespace PersonLibrary.Model
{
    class NotFoundPersonException: Exception
    {
        /// <summary>
        /// Персона не найдена
        /// </summary>
        /// <param name="message"></param>
        public NotFoundPersonException(string message = "Пользователя не существует") : base(message) { }
    }
}
