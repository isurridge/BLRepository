using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace LearningTreatz
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254726
        public static void RegisterBundles(BundleCollection bundles)
        {


            bundles.Add(new ScriptBundle("~/Scripts/MobileJs").Include(
                "~/Scripts/jquery-1.8.0.js",
                "~/Scripts/jquery-ui-1.8.23.js",
                "~/Scripts/jquery.mobile-1.1.1.js"));

            bundles.Add(new StyleBundle("~/Content/MobileCss").Include(
                "~/Content/themes/base/jquery.ui.core.css",
                "~/Content/themes/base/jquery.ui.autocomplete.css",
                "~/Content/jquery.mobile.structure-1.1.1.css",
                "~/Content/jquery.mobile.theme-1.1.1.css",
                "~/Content/jquery.mobile-1.1.1.css"));


            bundles.Add(new ScriptBundle("~/bundles/WebFormsJs").Include(
                  "~/Scripts/WebForms/WebForms.js",
                  "~/Scripts/WebForms/WebUIValidation.js",
                  "~/Scripts/WebForms/MenuStandards.js",
                  "~/Scripts/WebForms/Focus.js",
                  "~/Scripts/WebForms/GridView.js",
                  "~/Scripts/WebForms/DetailsView.js",
                  "~/Scripts/WebForms/TreeView.js",
                  "~/Scripts/WebForms/WebParts.js"));

            bundles.Add(new ScriptBundle("~/bundles/MsAjaxJs").Include(
                "~/Scripts/WebForms/MsAjax/MicrosoftAjax.js",
                "~/Scripts/WebForms/MsAjax/MicrosoftAjaxApplicationServices.js",
                "~/Scripts/WebForms/MsAjax/MicrosoftAjaxTimer.js",
                "~/Scripts/WebForms/MsAjax/MicrosoftAjaxWebForms.js"));

            // Use the Development version of Modernizr to develop with and learn from. Then, when you’re
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/modernizr-*"));
        }
    }
}