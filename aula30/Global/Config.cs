namespace aula30.Global
{
    public class Config
    {
        // variaveis estaticas as credencias de banco
        public static string dbHost = string.Empty;
        public static string dbPort = string.Empty;
        public static string dbUser = string.Empty;
        public static string dbName = string.Empty;
        public static string dbPass = string.Empty;

        // metodo para leitura do arquivo de configuracao

        public void LoadConfigurations()
        {
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json").Build();

            try
            {
                dbHost = config.GetValue<string>("Database:DBHost");
                dbPort = config.GetValue<string>("Database:DBPort");
                dbUser = config.GetValue<string>("Database:DBUser");
                dbName = config.GetValue<string>("Database:DBName");
                dbPass = config.GetValue<string>("Database:DBPass");
            }
            catch (Exception ex)
            {

                throw;
            }
        }


    }
}
