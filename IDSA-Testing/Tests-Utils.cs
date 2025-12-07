using Icarus_Drone_Service_Application.Services;

namespace IDSA_Testing
{
    [TestClass]
    public sealed class Tests_Utils
    {
        // ToSentenceCase Tests

        [TestMethod]
        public void ToSentenceCase_Typical1()
        {
            var testString = "hello world!";
            var result = Utils.ToSentenceCase(testString);

            Assert.AreEqual("Hello world!", result);
        }

        [TestMethod]
        public void ToSentenceCase_Typical2()
        {
            var testString = "HELLO WORLD!";
            var result = Utils.ToSentenceCase(testString);

            Assert.AreEqual("HELLO WORLD!", result);
        }

        [TestMethod]
        public void ToSentenceCase_Typical3()
        {
            var testString = "Hello World!";
            var result = Utils.ToSentenceCase(testString);

            Assert.AreEqual("Hello World!", result);
        }

        [TestMethod]
        public void ToSentenceCase_Typical4()
        {
            var testString = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. " +
                "Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown" +
                " printer took a galley of type and scrambled it to make a type specimen book. It has survived " +
                "not only five centuries, but also the leap into electronic typesetting, remaining essentially " +
                "unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem " +
                "Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including " +
                "versions of Lorem Ipsum.";
            var result = Utils.ToSentenceCase(testString);

            Assert.AreEqual("Lorem Ipsum is simply dummy text of the printing and typesetting industry. " +
                "Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown" +
                " printer took a galley of type and scrambled it to make a type specimen book. It has survived " +
                "not only five centuries, but also the leap into electronic typesetting, remaining essentially " +
                "unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem " +
                "Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including " +
                "versions of Lorem Ipsum.", result);
        }



        [TestMethod]
        public void ToSentenceCase_Edge1()
        {
            var testString = "";
            var result = Utils.ToSentenceCase(testString);

            Assert.AreEqual("", result);
        }

        [TestMethod]
        public void ToSentenceCase_Edge2()
        {
            var testString = "3x4MPLE Text!";
            var result = Utils.ToSentenceCase(testString);

            Assert.AreEqual("3x4MPLE Text!", result);
        }

        [TestMethod]
        public void ToSentenceCase_Edge3()
        {
            var testString = "T";
            var result = Utils.ToSentenceCase(testString);

            Assert.AreEqual("T", result);
        }

        // ToTitleCase Tests

        [TestMethod]
        public void ToTitleCase_Typical1()
        {
            var testString = "hello world!";
            var result = Utils.ToTitleCase(testString);

            Assert.AreEqual("Hello World!", result);
        }

        [TestMethod]
        public void ToTitleCase_Typical2()
        {
            var testString = "HELLO WORLD!";
            var result = Utils.ToTitleCase(testString);

            Assert.AreEqual("Hello World!", result);
        }

        [TestMethod]
        public void ToTitleCase_Typical3()
        {
            var testString = "Hello World!";
            var result = Utils.ToTitleCase(testString);

            Assert.AreEqual("Hello World!", result);
        }

        [TestMethod]
        public void ToTitleCase_Typical4()
        {
            var testString = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. " +
                "Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an " +
                "unknown printer took a galley of type and scrambled it to make a type specimen book.";
            var result = Utils.ToTitleCase(testString);

            Assert.AreEqual("Lorem Ipsum Is Simply Dummy Text Of The Printing And Typesetting Industry. " +
                "Lorem Ipsum Has Been The Industry's Standard Dummy Text Ever Since The 1500s, When An " +
                "Unknown Printer Took A Galley Of Type And Scrambled It To Make A Type Specimen Book.", result);
        }



        [TestMethod]
        public void ToTitleCase_Edge1()
        {
            var testString = "";
            var result = Utils.ToTitleCase(testString);

            Assert.AreEqual("", result);
        }

        [TestMethod]
        public void ToTitleCase_Edge2()
        {
            var testString = "3X4MPLE Text!";
            var result = Utils.ToTitleCase(testString);

            Assert.AreEqual("3x4mple Text!", result);
        }

        [TestMethod]
        public void ToTitleCase_Edge3()
        {
            var testString = "T";
            var result = Utils.ToTitleCase(testString);

            Assert.AreEqual("T", result);
        }

        // LimitDecimalPlace Tests

        [TestMethod]
        public void LimitDecimalPlace_Typical1()
        {
            double input = 3.14159;
            int limit = 2;
            var result = Utils.LimitDecimalPlace(input, limit);

            Assert.AreEqual(3.14, result);
        }

        [TestMethod]
        public void LimitDecimalPlace_Typical2()
        {
            double input = 123.456789;
            int limit = 4;
            var result = Utils.LimitDecimalPlace(input, limit);

            Assert.AreEqual(123.4567, result);
        }

        [TestMethod]
        public void LimitDecimalPlace_Typical3()
        {
            double input = 0.98765;
            int limit = 3;
            var result = Utils.LimitDecimalPlace(input, limit);

            Assert.AreEqual(0.987, result);
        }



        [TestMethod]
        public void LimitDecimalPlace_Edge1()
        {
            double input = 42;
            int limit = 2;
            var result = Utils.LimitDecimalPlace(input, limit);

            Assert.AreEqual(42, result);
        }

        [TestMethod]
        public void LimitDecimalPlace_Edge2()
        {
            double input = 3.14159;
            int limit = 0;
            var result = Utils.LimitDecimalPlace(input, limit);

            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void LimitDecimalPlace_Edge3()
        {
            double input = -2.71828;
            int limit = 2;
            var result = Utils.LimitDecimalPlace(input, limit);

            Assert.AreEqual(-2.71, result);
        }
    }
}
