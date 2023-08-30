namespace CarValetAPI2.Data.Settings
{
    public class MongoDbSettings
    {
        public string? Host { get; set; }
        public int Port { get; set; }
        public string? User { get; set; }
        public string? Password { get; set; }

        public string ConnectionString
        {
            get
            {
                return $"mongodb://{Host}:{Port}";
            }
        }

        public string DatabaseName
        {
            get
            {
                return "CarValetAPI";
            }
        }
    }
}