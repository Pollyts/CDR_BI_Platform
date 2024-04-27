using System;

namespace CDR_BI_Platform.Extentions
{
    public class ClientException : Exception
    {
        public ClientException()
        {
        }

        public ClientException(string message)
            : base(message)
        {
        }
    }
}
