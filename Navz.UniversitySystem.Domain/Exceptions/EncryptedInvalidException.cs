using System;

namespace Navz.UniversitySystem.Domain.Exceptions
{
    public class EncryptedInvalidException : Exception
    {
        public EncryptedInvalidException(string PlainText, Exception ex)
            : base($"Encryption \"{PlainText}\" is invalid.", ex)
        {

        }
    }
}
