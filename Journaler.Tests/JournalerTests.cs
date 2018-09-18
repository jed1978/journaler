using System;
using System.IO;
using Xunit;

namespace Journaler.Tests
{
    public class JournalerTests
    {
        [Fact]
        public void Test_Append_Success()
        {
            using (var target = new JournalWriter("Journal.log"))
            {
                target.Append("sss");
            }

            Assert.True(File.Exists("Journal.log"));
        }
    }
}