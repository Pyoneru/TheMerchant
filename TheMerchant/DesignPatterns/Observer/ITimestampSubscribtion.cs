using System;
using System.Collections.Generic;
using System.Text;
using TheMerchant.Model;

namespace TheMerchant.DesignPatterns.Observer
{
    public interface ISubscribtion
    {
        void AddSubscriber(ISubscriber subscriber);

        void RemoveSubscriver(ISubscriber subscriber);

        void Notify(Timestamp ts);
    }
}
