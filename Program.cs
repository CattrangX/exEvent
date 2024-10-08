using System;

namespace ViduveEvent
{

    public class Publisher
    {
        public event Action<object> event_news;

        public void Send()
        {
            event_news?.Invoke("Co tin moi");
        }
    }

    public class SubscriberA
    {
        public void Sub(Publisher p)
        {
            p.event_news += ReceiverFromPublisher;
        }

        void ReceiverFromPublisher(object data)
        {
            Console.WriteLine("SubscriberA: " + data.ToString());
        }
    }

    public class SubscriberB
    {
        public void Sub(Publisher p)
        {
            p.event_news += ReceiverFromPublisher;
        }

        void ReceiverFromPublisher(object data)
        {
            Console.WriteLine("SubscriberB: " + data.ToString());
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Publisher p = new Publisher();
            SubscriberA sa = new SubscriberA();
            SubscriberB sb = new SubscriberB();

            sa.Sub(p);
            sb.Sub(p);

            p.Send();
        }
    }
}
