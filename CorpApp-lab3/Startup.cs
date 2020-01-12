using CorpApp_lab3.Models;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CorpApp_lab3.Startup))]
namespace CorpApp_lab3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
