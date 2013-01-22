using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Bugsnag.Library
{
    /// <summary>
    /// .NET notifier for BugSnag error reporting
    /// </summary>
    public class BugSnag
    {
        /// <summary>
        /// Http based url for reporting errors to BugSnag
        /// </summary>
        private string httpUrl = "http://notify.bugsnag.com";

        /// <summary>
        /// Https based url for reporting errors to BugSnag
        /// </summary>
        private string httpsUrl = "https://notify.bugsnag.com";

        /// <summary>
        /// Creates a bugsnag notifier and sets the API key
        /// </summary>
        /// <param name="apiKey"></param>
        public BugSnag(string apiKey) : this()
        {
            this.apiKey = apiKey;
        }

        /// <summary>
        /// Constructor to set defaults
        /// </summary>
        public BugSnag()
        {
            //  SSL is set to 'off' by default
            useSSL = false;

            //  Release stage defaults to 'production'
            releaseStage = "production";

            //  Notify release stages defaults to just notifying 
            //  for production
            notifyReleaseStages = new List<string>();
            notifyReleaseStages.Add("production");
        }

        /// <summary>
        /// The apiKey for the project
        /// </summary>
        public string apiKey
        {
            get;
            set;
        }

        /// <summary>
        /// The current release stage for the application 
        /// (development/test/production)
        /// </summary>
        public string releaseStage
        {
            get;
            set;
        }

        /// <summary>
        /// A list of release stages that the notifier will capture and send 
        /// errors for. If the current release stage is not in this list, errors 
        /// should not be sent to Bugsnag. 
        /// </summary>
        public List<string> notifyReleaseStages
        {
            get;
            set;
        }

        /// <summary>
        /// If this is true, the plugin should notify Bugsnag using SSL
        /// </summary>
        public bool useSSL
        {
            get;
            set;
        }

        /// <summary>
        /// The version number of the application which generated the error
        /// </summary>
        public string applicationVersion
        {
            get;
            set;
        }

        /// <summary>
        /// The operating system version of the client that the error was 
        /// generated on.
        /// </summary>
        public string OSVersion
        {
            get;
            set;
        }

        /// <summary>
        /// Gathers information for the last error (if any error is available) 
        /// and reports it to BugSnag using information from the application
        /// configuration file and other defaults
        /// </summary>
        public void Notify()
        {
            //  If we're a web application, we can report errors automagically
            if(System.Web.HttpContext.Current != null)
            {
                if(System.Web.HttpContext.Current.AllErrors.Any())
                {

                }
            }

            //  If we're not a web application, we're SOL ATM (call another method)
        }

        /// <summary>
        /// Report a single exception to BugSnag using defaults
        /// </summary>
        /// <param name="ex">The exception to report</param>
        public void Notify(Exception ex) 
        {
            Notify(ex, string.Empty, string.Empty, null);
        }

        /// <summary>
        /// Report a list of exceptions to BugSnag
        /// </summary>
        /// <param name="exList">The list of Exceptions to report</param>
        public void Notify(List<Exception> exList)
        {
            Notify(exList, string.Empty, string.Empty, null);
        }

        /// <summary>
        /// Report an exception to Bugsnag with other per-request or per-session data
        /// </summary>
        /// <param name="ex">The exception to report</param>
        /// <param name="userId">An ID representing the current application's user.  If this isn't set
        /// this defaults to sessionId if available</param>
        /// <param name="context">The context that is currently active in the application</param>
        /// <param name="extraData">Data that will be sent as meta-data along with this error</param>
        public void Notify(Exception ex, string userId, string context, object extraData)
        {

        }

        /// <summary>
        /// Report a list of exceptions to Bugsnag with other per-request or per-session data
        /// </summary>
        /// <param name="exList">The list of exceptions to report</param>
        /// <param name="userId">An ID representing the current application's user.  If this isn't set
        /// this defaults to sessionId if available</param>
        /// <param name="context">The context that is currently active in the application</param>
        /// <param name="extraData">Data that will be sent as meta-data along with every error</param>
        public void Notify(List<Exception> exList, string userId, string context, object extraData)
        {

        }

    }
}
