using Microsoft.Owin;
using Owin;
using System.Data.Entity;
using MySql.Data.Entity;

[assembly: OwinStartupAttribute(typeof(InvestingMVC.Startup))]
namespace InvestingMVC
{
    public partial class Startup
    {
        internal static MySqlContext gSqlContext;
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            DbConfiguration.SetConfiguration(new MySqlEFConfiguration());

            gSqlContext = new MySqlContext();
        }
    }
}
