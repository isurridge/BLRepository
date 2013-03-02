using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using LearningTreatz;
using System.Web.Http;

namespace LearningTreatz
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterOpenAuth();

            RouteTable.Routes.MapHttpRoute(name: "DefaultApi",
                routeTemplate: "api/{controller}/{term}",
                defaults: new { term = System.Web.Http.RouteParameter.Optional }
            );



/*
            RouteTable.Routes.MapPageRoute("",
                "SalesReportSummary/{year}",
                "~/sales.aspx");

            RouteTable.Routes.MapPageRoute("SalesRoute",
                "SalesReport/{locale}/{year}",
                "~/sales.aspx");

            RouteTable.Routes.MapPageRoute("ExpensesRoute",
                "ExpenseReport/{locale}/{year}/{*extrainfo}",
                "~/expenses.aspx", true,
                new RouteValueDictionary { 
                { "locale", "US" }, 
                { "year", DateTime.Now.Year.ToString() } },
                new RouteValueDictionary { 
                { "locale", "[a-z]{2}" }, 
                { "year", @"\d{4}" } });

 */
           // Routing allows for SEO friendly URLs such as aspnet101.com/category/routing/ 
            //to be used instead of a URL such as aspnet101.com/category.aspx?categoryid=8 .

            RouteTable.Routes.MapPageRoute(
                "SpeakerRoute",  //Name of the Route (can be anyuthting)
                "MembersOnly/AddSpeaker/{category}", // URL with parameters
                "~/AddSpeaker.aspx"); //Page which will handles and process the request


        }











        void Application_End(object sender, EventArgs e)
        {
            //  Code that runs on application shutdown

        }

        void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs

        }
    }
}
