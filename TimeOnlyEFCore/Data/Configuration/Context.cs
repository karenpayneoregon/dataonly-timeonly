using System.Linq;
using Microsoft.Extensions.Configuration;

// ReSharper disable once CheckNamespace
namespace TimeOnlyEFCore.Data
{
    public partial class Context 
    {
        private static string BuildConnection()
        {

            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true, true)
                .Build();

            var sections =
                configuration.GetSection("database").GetChildren().ToList();

            return
                $"Data Source={sections[1].Value};" +
                $"Initial Catalog={sections[0].Value};" +
                $"Integrated Security={sections[2].Value}";

        }
    }
}
