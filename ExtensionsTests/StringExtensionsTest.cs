using Extensions;
using NUnit.Framework;
using System;

namespace ExtensionsTests
{
    [TestFixture]
    public class StringExtensionsTest
    {
        [TestCase(null, ExpectedResult = false, Description = "WHEN text is null THEN method should return false")]
        [TestCase("", ExpectedResult = false, Description = "WHEN text is empty THEN method should return false")]
        [TestCase("192.168.0.0", ExpectedResult = true, Description = "WHEN text is correct IPv4 address THEN method should return true")]
        [TestCase("355.255.255.255", ExpectedResult = false, Description = "WHEN text is incorrect IPv4 address THEN method should return false")]
        public bool IsValidIpv4_WhenCalled_ShouldReturnExpectedResult(string text)
        {
            // act and assert
            return text.IsValidIpv4();
        }

        [TestCase(null, ExpectedResult = false, Description = "WHEN text is null THEN method should return false")]
        [TestCase("", ExpectedResult = false, Description = "WHEN text is empty THEN method should return false")]
        [TestCase("2001:db8::1428:57ab", ExpectedResult = true, Description = "WHEN text is correct IPv4 address THEN method should return true")]
        [TestCase("2001:0db8:0:0::1428:57ab", ExpectedResult = true, Description = "WHEN text is correct IPv4 address THEN method should return true")]
        [TestCase("2001:db8::1428:57ab", ExpectedResult = true, Description = "WHEN text is correct IPv4 address THEN method should return true")]
        [TestCase("355.255.255.255", ExpectedResult = false, Description = "WHEN text is incorrect IPv4 address THEN method should return false")]
        public bool IsValidIpv6_WhenCalled_ShouldReturnExpectedResult(string text)
        {
            // act and assert
            return text.IsValidIpv6();
        }

        [TestCase(null, ExpectedResult = false, Description = "WHEN text is null THEN method should return false")]
        [TestCase("", ExpectedResult = false, Description = "WHEN text is empty THEN method should return false")]
        [TestCase("test@test.com", ExpectedResult = true, Description = "WHEN text is correct email address THEN method should return true")]
        [TestCase("testtest.com", ExpectedResult = false, Description = "WHEN text is incorrect email address THEN method should return false")]
        public bool IsEmail_WhenCalled_ShouldReturnExpectedResult(string text)
        {
            // act and assert
            return text.IsEmail();
        }

        [TestCase(null, ExpectedResult = "", Description = "WHEN text is null THEN method should return empty string")]
        [TestCase("", ExpectedResult = "", Description = "WHEN text is empty THEN method should return empty string")]
        [TestCase("abc", ExpectedResult = "abc", Description = "WHEN text is not empty THEN method should return provided string")]
        public string EmptyStringIfNull_WhenCalled_ShouldReturnExpectedResult(string text)
        {
            // act and assert
            return text.EmptyStringIfNull();
        }

        [TestCase(null, ExpectedResult = true, Description = "WHEN text is null THEN should return true")]
        [TestCase("", ExpectedResult = false, Description = "WHEN text is empty THEN should return false")]
        [TestCase("abc", ExpectedResult = false, Description = "WHEN text is not empty THEN should return false")]
        public bool IsNull_WhenCalled_ShouldReturnExpectedValue(string text)
        {
            // act and assert
            return text.IsNull();
        }

        [TestCase(null, ExpectedResult = true, Description = "WHEN text is null THEN should return true")]
        [TestCase("", ExpectedResult = true, Description = "WHEN text is empty THEN should return true")]
        [TestCase("abc", ExpectedResult = false, Description = "WHEN text is not empty THEN should return false")]
        public bool IsNullOrEmpty_WhenCalled_ShouldReturnExpectedValue(string text)
        {
            // act and assert
            return text.IsNullOrEmpty();
        }

        [TestCase(null, ExpectedResult = false, Description = "WHEN text is null THEN should return false")]
        [TestCase("", ExpectedResult = false, Description = "WHEN text is empty THEN should return false")]
        [TestCase("aaa", ExpectedResult = false, Description = "WHEN text contains only characters THEN should return false")]
        [TestCase("11a", ExpectedResult = false, Description = "WHEN text contains at least one letter THEN should return false")]
        [TestCase("2147483647", ExpectedResult = true, Description = "WHEN text is max value of int THEN should return true")]
        [TestCase("-2147483647", ExpectedResult = true, Description = "WHEN text is max value of int THEN should return true")]
        [TestCase("-21-47483647", ExpectedResult = false, Description = "WHEN text is not number THEN should return false")]
        public bool IsNumeric_WhenCalled_ShouldReturnExpectedValue(string text)
        {
            // act and assert
            return text.IsNumeric();
        }

        [TestCase("test", ExpectedResult = new byte[] {9,143,107,205,70,33,211,115,202,222,78,131,38,39,180,246}, Description = "WHEN text is not empty THEN should return expected value")]
        [TestCase("computed hash", ExpectedResult = new byte[] {223,135,248,204,181,100,161,150,98,61,197,52,125,246,120,10}, Description = "WHEN text is not empty THEN should return expected value")]
        public byte[] ComputeHash_WhenCalled_ShouldReturnExpectedValue(string text)
        {
            // act and assert
            return text.ComputeHash();
        }

        [TestCase(null, Description = "WHEN text and key are null THEN should throw exception")]
        [TestCase("", Description = "WHEN text is empty THEN should throw exception")]
        public void ComputeHash_WhenKeyIsNullOrEmpty_ThenShouldThrowException(string text)
        {
            // act and assert
            Assert.Throws<ArgumentException>(() => text.ComputeHash());
        }

        [TestCase("test", "key", ExpectedResult = "k+CgYscn0jo=", Description = "WHEN text is not empty THEN should return expected value")]
        [TestCase("encrypt string", "key", ExpectedResult = "pOGluqWzTOGix+cL30TLpA==", Description = "WHEN text is not empty THEN should return expected value")]
        [TestCase("lorem ipsum", "key", ExpectedResult = "tOel3oTW237BTskPGRKDcg==", Description = "WHEN text is not empty THEN should return expected value")]
        [TestCase("test", "keyword", ExpectedResult = "T/m8L3szshU=", Description = "WHEN text is not empty THEN should return expected value")]
        [TestCase("encrypt string", "keyword", ExpectedResult = "cBZ5SoZw/yhWouUNRuTZEg==", Description = "WHEN text is not empty THEN should return expected value")]
        [TestCase("lorem ipsum", "keyword", ExpectedResult = "9YaVAam/JCDwebzrlNsDHw==", Description = "WHEN text is not empty THEN should return expected value")]
        public string Encrypt_WhenCalled_ShouldReturnExpectedValue(string text, string key)
        {
            // act and assert
            return text.Encrypt(key);
        }

        [TestCase("k+CgYscn0jo=", "key", ExpectedResult = "test", Description = "WHEN text is not empty THEN should return expected value")]
        [TestCase("pOGluqWzTOGix+cL30TLpA==", "key", ExpectedResult = "encrypt string", Description = "WHEN text is not empty THEN should return expected value")]
        [TestCase("tOel3oTW237BTskPGRKDcg==", "key", ExpectedResult = "lorem ipsum", Description = "WHEN text is not empty THEN should return expected value")]
        [TestCase("T/m8L3szshU=", "keyword", ExpectedResult = "test", Description = "WHEN text is not empty THEN should return expected value")]
        [TestCase("cBZ5SoZw/yhWouUNRuTZEg==", "keyword", ExpectedResult = "encrypt string", Description = "WHEN text is not empty THEN should return expected value")]
        [TestCase("9YaVAam/JCDwebzrlNsDHw==", "keyword", ExpectedResult = "lorem ipsum", Description = "WHEN text is not empty THEN should return expected value")]
        public string Decrypt_WhenCalled_ShouldReturnExpectedValue(string text, string key)
        {
            // act and assert
            return text.Decrypt(key);
        }

        [TestCase(null, null, Description = "WHEN text and key are null THEN should throw exception")]
        [TestCase("", "abc", Description = "WHEN text is empty THEN should throw exception")]
        [TestCase("abc", "", Description = "WHEN key is empty THEN should throw exception")]
        public void Encrypt_WhenTextOrKeyIsNullOrEmpty_ShouldThrowException(string text, string key)
        {
            // act and assert
            Assert.Throws<ArgumentException>(() => text.Encrypt(key));
        }

        [TestCase(null, null, Description = "WHEN text and key are null THEN should throw exception")]
        [TestCase("", "abc", Description = "WHEN text is empty THEN should throw exception")]
        [TestCase("abc", "", Description = "WHEN key is empty THEN should throw exception")]
        public void Decrypt_WhenTextOrKeyIsNullOrEmpty_ShouldThrowException(string text, string key)
        {
            // act and assert
            Assert.Throws<ArgumentException>(() => text.Decrypt(key));
        }
    }
}
