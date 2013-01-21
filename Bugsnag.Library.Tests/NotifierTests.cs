using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceStack.Text;

namespace Bugsnag.Library.Tests
{
    [TestClass]
    public class NotifierTests
    {
        [TestMethod]
        public void TestServiceStackSerialization()
        {
            ErrorNotification test = new ErrorNotification()
            {
                Api_Key = "Thistest",
            };

            string teststring2 = test.SerializeToString();
        }
    }
}
