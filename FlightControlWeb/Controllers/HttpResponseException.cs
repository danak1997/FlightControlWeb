﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace FlightControlWeb.Controllers
{
    public class HttpResponseException : Exception
    {
        public int Status { get; set; } = 500;
        //public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.InternalServerError;

        public object Value { get; set; }
    }
}
