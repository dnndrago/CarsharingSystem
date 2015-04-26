using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(CarsharingSystem.WebServices.Startup))]

namespace CarsharingSystem.WebServices
{

    using System.Data.Entity;

    using CarsharingSystem.Data;
    using CarsharingSystem.Data.Migrations;

    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>());
            ConfigureAuth(app);
        }
    }
}
