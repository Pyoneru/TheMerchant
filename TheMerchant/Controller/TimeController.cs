using System;
using System.Collections.Generic;
using System.Text;
using TheMerchant.Service;

namespace TheMerchant.Controller
{
    public class TimeController
    {
        private TimestampService service;

        public TimeController(TimestampService service)
        {
            this.service = service;
        }
    }
}
