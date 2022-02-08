using System;

namespace ObserverPattern
{
    class DownloadObserver : IObserver
    {
        public void Update(ISubject subject)
        {
            Console.WriteLine("Reaccionando al cambio de estatus");
        }
    }
}
