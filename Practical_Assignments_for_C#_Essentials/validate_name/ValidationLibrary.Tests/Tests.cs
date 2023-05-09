using NUnit.Framework;
using System;
using System.Linq;
using System.Reflection;

namespace ValidationLibrary.Tests
{
    [TestFixture]
    public class Tests
    {
        private Type type;
        private Type paramType;
        private string methodName;

        [SetUp]
        public void Initial()
        {
            type = Type.GetType("ValidationLibrary.StringOperation, ValidationLibrary", false, true);
            paramType = typeof(string);
            methodName = "GetValidName";
        }

        #region Reflection
        [Test]
        public void GetValidNameMethod_WithRightSignatureAndParameter_IsExist()
        {
            //arrange
            string parameter = "nameToValidate";

            //act
            var actualMethod = GetMethod(methodName);

            var actualParameter = actualMethod.GetParameters().FirstOrDefault();
            if (actualParameter is null)
            {
                Assert.Fail("GetValidName method doesn't has any parameter");
            }
            if (actualParameter.Name != parameter)
            {
                Assert.Fail("GetValidName method doesn't has parameter of  'nameToValidate' name ");
            }
            if (actualParameter.ParameterType != paramType)
            {
                Assert.Fail("GetValidName method doesn't has parameter of string type ");
            }
        }

        #endregion

        #region Invoke

        [TestCase("hello world 2020year ^rt", 19)]
        [TestCase("<(￣︶￣)> ＼(＾▽＾)／ (o_O)", 2)]
        [TestCase("Dmy$tro   /Ponasenkov", 17)]
        public void GetValidName_WithInputString_ReturnStringOfCorrectLength(string input, int expected_length)
        {
            //act
            var actualMethod = GetMethod(methodName);
            var actualLength = ((string)actualMethod.Invoke(type, new object[] { input })).Length;

            //assert
            Assert.AreEqual(expected_length, actualLength
                , message: "GetValidName return string of incorrect length");
        }

        [TestCase("voLodYmyr KlyCHko", "Volodymyr Klychko")]
        [TestCase("marshall mathers", "Marshall Mathers")]
        [TestCase("Nice Person", "Nice Person")]
        [TestCase("NICK COPELAND", "Nick Copeland")]
        public void GetValidName_ReturnStringInRightRegister(string input, string expected)
        {
            //
            //act 
            var actualMethod = GetMethod(methodName);
            var actual = actualMethod.Invoke(type, new object[] { input });

            //assert
            Assert.AreEqual(expected, actual
                , message: "Case sensitivity logic in GetValidName method works incorrect");

        }

        [TestCase("Jam&es Ac575aster", "James Acaster")]
        [TestCase("(=^･ω･^=) Barnes", "Barnes")]
        [TestCase("Si6-w 123An7ita 67:/ Andersen", "Siw Anita Andersen")]
        public void GetValidName_RemoveAllNonLationSymbols(string input, string expected)
        {
            //
            //act 
            var actualMethod = GetMethod(methodName);
            var actual = actualMethod.Invoke(type, new object[] { input });

            //assert
            Assert.AreEqual(expected, actual
                , message: "GetValidName method doesn't remove non Latin symbols");
        }

        [TestCase("    Carl Bad", "Carl Bad")]
        [TestCase("Rick Flair    ", "Rick Flair")]
        [TestCase("Brock    Dalton", "Brock Dalton")]
        [TestCase("  Hello    World        Man  ", "Hello World Man")]
        public void GetValidName_WithBigWhitespaces_ReturnFormatedString(string input, string expected)
        {
            //act
            var actualMethod = GetMethod(methodName);
            var actual = actualMethod.Invoke(type, new object[] { input });

            //assert
            Assert.AreEqual(expected, actual
                , message: "GetValid method doesn't remove extra whitespaces ");
        }

        [TestCase("o", "O")]
        [TestCase("R", "R")]
        public void GetValidName(string input, string expected)
        {

            //act
            var actualMethod = GetMethod(methodName);
            var actual = ((string)actualMethod.Invoke(type, new object[] { input }));

            //assert
            Assert.AreEqual(expected, actual
                            , message: "GetValidName doesn't return string less or equal to 50 characters");
        }

        #endregion

        #region ExceptionTests
        [Test]
        public void GetValidName_ThrowArgumentException_IfNameToValidateIsNull()
        {
            //arrange
            string input = null;

            //act
            var actualMethod = GetMethod(methodName);
            var act = Assert.Catch(() => actualMethod.Invoke(type, new object[] { input })).InnerException;

            if (act.GetType() != typeof(ArgumentException))
            {
                Assert.Fail("GetValidName should throw ArgumentException in case of NameToValidate is null");
            }
        }

        [TestCase("")]
        public void GetValidName_ThrowArgumentException_IfNameToValidateIsEmptyOrWhiteSpace(string input)
        {
            //act
            var actualMethod = GetMethod(methodName);
            var act = Assert.Catch(() => actualMethod.Invoke(type, new object[] { input })).InnerException;

            //assert
            if (act.GetType() != typeof(ArgumentException))
            {
                Assert.Fail("GetValidName should throw ArgumentException in case of NameToValidate is empty or whitespace ");
            }
        }

        [TestCase("｀、ヽ｀ヽ｀、ヽ(ノ＞＜)ノ ｀、ヽ｀☂ヽ｀、ヽ")]
        [TestCase("888888")]
        [TestCase("?(№№::")]
        public void GetValidName_ThrowArgumentException_IfReturnStringIsEmpty(string input)
        {
            //act
            var actualMethod = GetMethod(methodName);
            var act = Assert.Catch(() => actualMethod.Invoke(type, new object[] { input })).InnerException;

            //assert
            if (act.GetType() != typeof(ArgumentException))
            {
                Assert.Fail("GetValidName should throw ArgumentException in case of return string is null or empty");
            }
        }

        #endregion

        private MethodInfo GetMethod(string name)
        {
            var actualMethod = type.GetMethod(name);
            if (actualMethod is null)
            {
                Assert.Fail("GetValidName method doesn't exist or it's name is incorrect");
            }
            if (actualMethod.ReturnType != typeof(string))
            {
                Assert.Fail("GetValidName method has incorrect type of return value");
            }
            return actualMethod;
        }
    }
}
