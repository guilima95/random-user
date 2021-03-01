using System;
using System.Collections.Generic;
using System.Text;
using UserRandom.Data.MongoDb.Contracts;

namespace UserRandom.Data.MongoDb
{
    public class MongoDbSettings : IMongoDbSettings
    {
        public string DatabaseName { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public string User { get; set; }
        public string Password { get; set; }


    }
}
