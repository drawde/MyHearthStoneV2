using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(MyHearthStoneV2.API.App_Start.Startup))]

namespace MyHearthStoneV2.API.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //app.MapSignalR(); // 启用SignalR
        }
    }
}
