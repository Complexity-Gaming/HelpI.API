﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpI.API.Domain.Models.Session
{
    public class IndividualSession
    {
        public int Id { get; set; }
        public SessionCalification Calification { get; set; }
        public SessionDetails Details { get; set; }

    }
}