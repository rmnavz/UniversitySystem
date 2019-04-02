using Navz.UniversitySystem.Common.Security;
using Navz.UniversitySystem.Domain.Exceptions;
using Navz.UniversitySystem.Domain.ValueObjects;
using Xunit;

namespace Navz.UniversitySystem.Domain.Tests.ValueObjects
{
    public class EncryptedTests
    {
        [Fact]
        public void ShouldVerify()
        {
            var password = Encrypted.For("password");

            Assert.True(PasswordHasher.VerifyPassword("password", password.Salt, password.Hash));
        }

        [Fact]
        public void ExplicitConversionFromStringSetsSaltAndHash()
        {
            var password = (Encrypted)"password";

            Assert.True(PasswordHasher.VerifyPassword("password", password.Salt, password.Hash));
        }
    }
}
