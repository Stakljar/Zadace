using System;
using System.Collections.Generic;
using System.Text;

namespace Class_Library
{
   public class TvException : Exception
    {
        public string Title
        {
            get; private set;
        }
        public TvException()
        {

        }
        public TvException(string message) : base(message)
        {

        }
        public TvException(string message, string title) : base(message)
        {
            Title = title;
        }
        public TvException(string message, Exception innerException) : base(message, innerException)
        {

        }
        public TvException(string message, Exception innerException, string title) : base(message, innerException)
        {
            Title = title;
        }
    }
}
