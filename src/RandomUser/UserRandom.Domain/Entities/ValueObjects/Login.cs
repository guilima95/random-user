using System;
using System.Collections.Generic;
using System.Text;

namespace UserRandom.Domain.Entities.ValueObjects
{
    public class Login
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public string Md5 { get; set; }
        public string Sha1 { get; set; }
        public string Sha256 { get; set; }
    }
}
