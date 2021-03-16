using System;
using System.Collections.Generic;
using System.Text;
using TheMerchant.Model;

namespace TheMerchant.DesignPatterns.Observer
{
    public interface ISubscriber
    {
        bool OnTime(Timestamp ts);

        void Update();
    }
}
