using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalMachine.entry
{
    public class ReplyResult
    {
    }

    public class LoginResult
    {
        public int result { get; set; }
        public string message { get; set; }

        public Object data { get; set; }
    }
}
