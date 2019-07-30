using System;
using System.Collections.Generic;
using System.Linq;
using Owin;


namespace ARSCommunicationService
{
    public partial class Startup
    {
        public static string PublicClientId { get; private set; }
        public void ConfigureAuth(IAppBuilder app)
        {
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            ConfigureAuth(app);
           
        }
    }
}
