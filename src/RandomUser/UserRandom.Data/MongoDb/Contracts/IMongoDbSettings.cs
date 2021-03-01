using System;
using System.Collections.Generic;
using System.Text;

namespace UserRandom.Data.MongoDb.Contracts
{
    public interface IMongoDbSettings
    {
        public string DatabaseName { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
    }
}
