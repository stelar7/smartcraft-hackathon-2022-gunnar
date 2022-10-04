﻿namespace backend.Models
{
    public class DataBaseSettings : IDatabaseSettings
    {
        public string ConnectionString { get; set; }

        public string DatabaseName { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
    }
}
