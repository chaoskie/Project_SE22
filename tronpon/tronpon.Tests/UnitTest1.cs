using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tronpon_Classes;

namespace tronpon.Tests
{
    [TestClass]
    public class UnitTest1
    {
        public void Test_Hashing()
        {
            string SendThis = "WachtwoordHash";
            string Hashed = PasswordHash.CreateHash(SendThis);
            Assert.AreNotEqual(SendThis, Hashed, string.Format("Raw wachtwoord ({0}) is gelijk aan Hashedwachtwoord ({1})", SendThis, Hashed));

            SendThis = string.Empty;
            Hashed = PasswordHash.CreateHash(SendThis);
            Assert.AreNotEqual(SendThis, Hashed, string.Format("Raw wachtwoord ({0}) is gelijk aan Hashedwachtwoord ({1})", SendThis, Hashed));
        }

        [TestMethod]
        public void Hashing_Uniek()
        {
            string SendThis = "WachtwoordHash";
            string Hashed_A = PasswordHash.CreateHash(SendThis);
            string Hashed_B = PasswordHash.CreateHash(SendThis);

            Assert.AreNotEqual(Hashed_A, Hashed_B, string.Format("Gehashed wachtenwoorden met identieke start ({0}) zijn gelijk.", SendThis));
        }

        [TestMethod]
        public void Login_Hash()
        {
            string SendThis = "WachtwoordHash";
            string RegisterPass = PasswordHash.CreateHash(SendThis);
            Assert.IsTrue(PasswordHash.ValidatePassword(SendThis, RegisterPass), "Login simulatie was niet succesvol.");
        }
    }
}
