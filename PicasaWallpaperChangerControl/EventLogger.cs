using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.IO;
using System.Xml;

namespace Sean_Jones.PicasaWallpaperChangerControl
{
    public class EventLogger
    {
        private string mPath;
        XDocument mLog = null;
        public EventLogger(string path)
        {
            this.mPath = path;
            this.SetupLog();
            this.mLog = null;

           
        }
        public void SetupLog()
        {
            this.mLog = new XDocument();
            if (!File.Exists(this.mPath))
            {
                this.mLog.Add(new XElement("Events"));
               
                this.mLog.Save(this.mPath);
            }
            else
            {
                StreamReader sr = new StreamReader(this.mPath);
                this.mLog = XDocument.Parse(sr.ReadToEnd(), LoadOptions.None);
                sr.Dispose();
                sr = null;

            }
        }

        public void LogEvent(string eventData, string eventSource)
        {
            this.SetupLog();
            XElement root = this.mLog.Element("Events");
            root.Add(new XElement("Event",
                new XElement("Date", XmlConvert.ToString(DateTime.Now,XmlDateTimeSerializationMode.Local)),
                new XElement("Message", eventData),
                new XElement("Source", eventSource)));
            this.mLog.Save(this.mPath);
            this.mLog = null;
        }
    }
}
