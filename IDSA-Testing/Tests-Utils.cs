using Icarus_Drone_Service_Application.Services;

namespace IDSA_Testing
{
    [TestClass]
    public sealed class Tests_Utils
    {
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

            Assert.AreEqual("Hello world!", result);
        }

        [TestMethod]
        public void ToSentenceCase_Typical3()
        {
            var testString = "Hello World!";
            var result = Utils.ToSentenceCase(testString);

            Assert.AreEqual("Hello world!", result);
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
            var testString = "3X4MPLE Text!";
            var result = Utils.ToSentenceCase(testString);

            Assert.AreEqual("3x4mple text!", result);
        }

        [TestMethod]
        public void ToSentenceCase_Edge3()
        {
            var testString = "T";
            var result = Utils.ToSentenceCase(testString);

            Assert.AreEqual("T", result);
        }

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
    }
}
