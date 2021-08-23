using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NEXOSWEB.Models.Responses
{
    public class AuthticationResponse
    {
        public bool succeeded { get; set; }
        public string message { get; set; }
        public object errors { get; set; }
        public Data data { get; set; }
        public class Data
        {
            public string id { get; set; }
            public string userName { get; set; }
            public string email { get; set; }
            public List<string> roles { get; set; }
            public bool isVerified { get; set; }
            public string jwToken { get; set; }
            public string refreshToken { get; set; }
        }

    }
}
