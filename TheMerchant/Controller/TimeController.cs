using System;
using System.Collections.Generic;
using System.Text;
using TheMerchant.Service;
using TheMerchant.Model;
using TheMerchant.DesignPatterns.Observer;

namespace TheMerchant.Controller
{
    public class TimeController : ITimestampSubscribtion
    {
        public TimestampService Service { get; }
        private IList<ITimestampSubscriber> _subscribers;


        public TimeController(TimestampService service)
        {
            Service = service;
            _subscribers = new List<ITimestampSubscriber>();
        }

        public void AddDay(Timestamp ts, int day = 1)
        {
            Service.AddDay(ts, day);
            Notify(ts);
        }

        public void AddHour(Timestamp ts, int hour = 1)
        {
            Service.AddHour(ts, hour);
            Notify(ts);
        }

        public void AddMinute(Timestamp ts, int minute)
        {
            Service.AddMinute(ts, minute);
            Notify(ts);
        }

        public void AddSubscriber(ITimestampSubscriber subscriber)
        {
            _subscribers.Add(subscriber);
        }

        public void RemoveSubscriber(ITimestampSubscriber subscriber)
        {
            _subscribers.Remove(subscriber);
        }

        public void Notify(Timestamp ts)
        {
            for(int i = 0; i < _subscribers.Count; i++)
            {
                if (_subscribers[i].OnTime(ts))
                {
                    _subscribers[i].Update();
                    RemoveSubscriber(_subscribers[i]);
                    i--;
                }
            }
        }

        
    }
}
