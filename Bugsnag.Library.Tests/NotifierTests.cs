﻿using System;
using Bugsnag.Library.Data;
using System.Linq;
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
        [TestMethod]
        public void TestServiceStackSerialization()
        {

            try
            {
                throw new ApplicationException("Throwing an app extension.  You heartless bastard.");
            }
            catch(System.Exception ex)
            {
                //  Our list of events:
                List<Event> events = new List<Event>();

                //  Our list of exceptions:
                List<Bugsnag.Library.Data.Exception> exceptions = new List<Bugsnag.Library.Data.Exception>();

                //  Our list of stacktrace lines:
                var stacktraces = (from item in new System.Diagnostics.StackTrace(ex, true).GetFrames()
                            select new Stacktrace()
                            {
                                File = item.GetFileName(),
                                LineNumber = item.GetFileLineNumber(),
                                Method = item.GetMethod().Name
                            }).ToList();
                  
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
                    Exceptions = exceptions,
                    ReleaseStage = "Development",
                    AppVersion = "1.0.1",
                    ExtraData = new
                    {
                        TelleTubby = new
                        {
                            color = "Yellow",
                            mood = "Mellow"
                        }
                    }
                });

                //  Create our error notification:
                ErrorNotification test = new ErrorNotification()
                {
                    Api_Key = "YOUR_API_KEY",
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