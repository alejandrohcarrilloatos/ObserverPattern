using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hola Observer pattern!");
            //Console.ReadKey();

            var downloadsObserver = new DownloadObserver();

            var downloadingFileA = new FileDownloadSubject();
            downloadingFileA.Add(downloadsObserver);

            var downloadingFileB = new FileDownloadSubject();
            downloadingFileB.Add(downloadsObserver);

            downloadingFileA.DownloadFile(@"https://phoenixnap.dl.sourceforge.net/project/reactos/ReactOS/0.4.14/", "ReactOS-0.4.14-iso.zip");
            downloadingFileB.DownloadFile(@"https://downloads-global.3cx.com/downloads/debian10iso/", "debian-amd64-netinst-3cx.iso");

            Console.ReadKey();

        }
    }
}
