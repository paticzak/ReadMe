using AutoMapper;
using ReadMe.App_Start;
using ReadMe.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ReadMe
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Mapper.Initialize(c => c.AddProfile<MappingProfile>());
            GlobalConfiguration.Configure(WebApiConfig.Register);
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            GlobalConfiguration.Configuration.Formatters.Remove(GlobalConfiguration.Configuration.Formatters.XmlFormatter);
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Database.SetInitializer<ApplicationDbContext>(null);

            new Smile.License(
            "SMILE LICENSE 9aa6d3c3 c25a9935 1558c92f " +
            "THIS IS AN ACADEMIC LICENSE AND CAN BE USED  " +
            "SOLELY FOR ACADEMIC RESEARCH AND TEACHING, " +
            "AS DEFINED IN THE BAYESFUSION ACADEMIC  " +
            "SOFTWARE LICENSING AGREEMENT. " +
            "Serial #: bqc4bbh4fhqsd6cqb7lrwdrpm " +
            "Issued for: Patrycja Mundzik (p.mundzik@gmail.com) " +
            "Academic institution: Politechnika Bia\u0142ostocka " +
            "Valid until: 2018-06-15 " +
            "Issued by BayesFusion activation server",
            new byte[] {
                0x20,0xe7,0xfe,0x34,0xbc,0x07,0xc4,0x24,0x1e,0xad,0xe2,0xf7,0xec,0x33,0x66,0x60,
                0x9f,0xe3,0x0e,0x5e,0xbb,0x41,0xd0,0x26,0x10,0x26,0xfb,0xf2,0x52,0xa9,0xda,0x67,
                0x89,0x9d,0xfb,0xd7,0x21,0xb5,0x87,0x36,0x23,0x86,0xe0,0x12,0x6c,0xe4,0xa1,0x47,
                0x72,0x4c,0x95,0xb0,0xea,0xe1,0xbf,0xf8,0x2c,0xf3,0x1e,0x5d,0x92,0xa3,0x39,0x60
                }
            );


        }
    }
}
