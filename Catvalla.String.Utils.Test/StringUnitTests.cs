using System;
using Catvalla.String.Utils;

namespace Catvalla.String.Utils.Test
{
    public class StringUnitTests
    {
        [Fact]
        public void RegularReplaceTest()
        {
            string s = "This is a test string";
            string testVal = s.ReplaceIgnoreCase("TEST", "quail");

            Assert.Equal("This is a quail string", testVal);
        }

        [Fact]
        public void MutipleReplaceTest()
        {
            string s = "This is a test of IS string";
            string testVal = s.ReplaceIgnoreCase("is", "quail");

            Assert.Equal("Thquail quail a test of quail string", testVal);
        }

        [Fact]
        public void MutipleReplaceTestDuplicate()
        {
            string s = "SSSSSSSS";
            string testVal = s.ReplaceIgnoreCase("s", "QQQ");

            Assert.Equal("QQQQQQQQQQQQQQQQQQQQQQQQ", testVal);
        }

        [Fact]
        public void FindAndReplaceAreSame()
        {
            string s = "SSSSSSSS";
            string testVal = s.ReplaceIgnoreCase("s", "S");

            Assert.Equal("SSSSSSSS", testVal);
        }

        [Fact]
        public void RegularRemoveTest()
        {
            string s = "This is a test string";
            string testVal = s.RemoveIgnoreCase("TEST");

            Assert.Equal("This is a  string", testVal);
        }

        [Fact]
        public void MutipleRemoveTest()
        {
            string s = "This is a test of IS string";
            string testVal = s.RemoveIgnoreCase("is");

            Assert.Equal("Th  a test of  string", testVal);
        }

        [Fact]
        public void MutipleRemoveTestDuplicate()
        {
            string s = "SSSSSSSS";
            string testVal = s.RemoveIgnoreCase("s");

            Assert.Equal(string.Empty, testVal);
        }

        [Fact]
        public void MutipleRemoveTestDuplicate2()
        {
            string s = "SSSSqSSSS";
            string testVal = s.RemoveIgnoreCase("s");

            Assert.Equal("q", testVal);
        }

        [Fact]
        public void MutipleRemoveTestDuplicate3()
        {
            string s = "SSSSqSSSS";
            string testVal = s.RemoveIgnoreCase("q");

            Assert.Equal("SSSSSSSS", testVal);
        }
    }
}
