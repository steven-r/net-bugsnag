using System;
using Bugsnag.Library.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceStack.Text;
using System.Collections.Generic;
using System.Net;
using System.IO;
using System.Text;

namespace Bugsnag.Library.Tests
{
    [TestClass]
    public class NotifierTests
    {
        // [TestMethod]
        public void TestServiceStackSerialization()
        {

            try
            {
                throw new ArgumentException("This is a test exception");
            }
            catch(System.Exception ex)
            {
                //  Our list of events:
                List<Event> events = new List<Event>();

                //  Our list of exceptions:
                List<Bugsnag.Library.Data.Exception> exceptions = new List<Bugsnag.Library.Data.Exception>();

                //  Our list of stacktrace lines:
                List<Stacktrace> stacktraces = new List<Stacktrace>();

                //  Add our stacktrace lines:
                stacktraces.Add(new Stacktrace()
                    {
                        File = "currentfile",
                        InProject = true,
                        LineNumber = 54,
                        Method = ex.TargetSite.Name
                    });

                //  Add a new exception:
                exceptions.Add(new Bugsnag.Library.Data.Exception()
                {
                    ErrorClass = ex.TargetSite.Name,
                    Message = ex.Message,
                    Stacktrace = stacktraces
                });

                //  Add a new event:
                events.Add(new Event
                {
                    UserId = "esparza.dan@gmail.com",
                    Context = "TestServiceStackSerialization",
                    Exceptions = exceptions
                });

                //  Create our error notification:
                ErrorNotification test = new ErrorNotification()
                {
                    Api_Key = "USE_YOUR_API_KEY",
                    Events = events
                };

                //  Serialize to JSON:
                string teststring2 = test.SerializeToString();

                //  Create a byte array:
                byte[] byteArray = Encoding.UTF8.GetBytes(teststring2);

                //  Post JSON to server:
                var request = WebRequest.CreateHttp("https://notify.bugsnag.com");
                request.Method = WebRequestMethods.Http.Post;
                request.ContentType = "application/json";
                request.ContentLength = byteArray.Length;

                Stream dataStream = request.GetRequestStream();
                dataStream.Write(byteArray, 0, byteArray.Length);
                dataStream.Close();

                //  Get the response.  See https://bugsnag.com/docs/notifier-api for response codes
                var response = request.GetResponse();
            }
        }
    }
}
