using System;
using System.Collections.Generic;
using System.Net;


namespace ObserverPattern
{
    internal class FileDownloadSubject : ISubject
    {
        public bool DownloadDone { get; set; } = false;
        private List<IObserver> _observadores = new List<IObserver>();
        public void Add(IObserver observer)
        {
            Console.WriteLine("Subject: Agregando un observer.");
            this._observadores.Add(observer);
        }

        public void Remove(IObserver observer)
        {
            this._observadores.Remove(observer);
            Console.WriteLine("Subject: observer Removido.");
        }

        public void Notify()
        {
            Console.WriteLine("Subject: Notificar a los observers...");
            foreach (var observer in _observadores)
            {
                observer.Update(this);
            }
        }

        public void DownloadFile(string remoteUri, string fileName = "" )
        {
            Console.WriteLine("\nSubject: Bajando un archivo.");
            //this.DownloadDone = false;

            /////////////
            ///
            //string remoteUri = "https://phoenixnap.dl.sourceforge.net/project/reactos/ReactOS/0.4.14/";
            //string fileName = "ReactOS-0.4.14-iso.zip", strUri = null;
            //string remoteUri = "http://www.contoso.com/library/homepage/images/";
            //string fileName = "ms-banner.gif",
            string strUri = null;
            string localPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            // Create a new WebClient instance.
            WebClient myWebClient = new WebClient();
            // Concatenate the domain with the Web resource filename.
            strUri = remoteUri + fileName;
            Console.WriteLine("Downloading File \"{0}\" from \"{1}\" .......\n\n", fileName, strUri);
            // Download the Web resource and save it into the current filesystem folder.
            myWebClient.DownloadFile(strUri, fileName);
            Console.WriteLine("Successfully Downloaded File \"{0}\" from \"{1}\"", fileName, strUri);
            Console.WriteLine("\nDownloaded file saved in the following file system folder:\n\t" + localPath);
            ///

            this.DownloadDone = true;

            Console.WriteLine("Subject: El download ha terminado: " + this.DownloadDone);
            this.Notify();
        }

    }
}
