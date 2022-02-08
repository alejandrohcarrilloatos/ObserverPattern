using System;
using System.Collections.Generic;

namespace ObserverPattern
{
    public class Subject : ISubject
    {
        public int State { get; set; } = -0;
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

    }
}
