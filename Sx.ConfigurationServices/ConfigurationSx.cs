using Microsoft.Extensions.Configuration;

namespace Sx.ConfigurationServices
{
    public class ConfigurationSx : IConfigurationSx
    {
        public String Url { get; private set; }

        public ConfigurationSx() 
        {
            this.Init();
        }

        private void Init()
        {
            IConfiguration configuration = new ConfigurationBuilder()
                                .SetBasePath(Directory.GetCurrentDirectory())
                                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                                .Build();

            this.Url = configuration["AppSettings:NbpUrl"];
        }
    }
}