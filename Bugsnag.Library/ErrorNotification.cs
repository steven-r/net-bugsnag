using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Bugsnag.Library
{
    [DataContract]
    public class ErrorNotification
    {
        public ErrorNotification()
        {
            NotiferData = new Notifier();
        }

        /// <summary>
        /// The API Key associated with the project. Informs Bugsnag which project 
        /// has generated this error.
        /// </summary>
        [DataMember(Name="apiKey")]
        public string Api_Key
        {
            get;
            set;
        }

        /// <summary>
        /// This object describes the notifier itself. These properties are used 
        /// within Bugsnag to track error rates from a notifier.
        /// </summary>
        [DataMember(Name="notifier")]
        public Notifier NotiferData
        {
            get;
            set;
        }


        /// <summary>
        /// An object containing any further data you wish to attach to this error
        /// event. This should contain one or more objects, with each object being
        /// displayed in its own tab on the event details on the Bugsnag website.
        /// (Optional).
        /// </summary>
        [DataMember(Name="metaData")]
        public object MetaData
        {
            get;
            set;
        }
    }
}
