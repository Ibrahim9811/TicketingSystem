﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketingSystem.Services.Helper
{
    public class JWT
    {

        public string Key { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public Double DurationInDays { get; set; }
    }
}
