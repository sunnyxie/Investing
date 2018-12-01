﻿using System.Web;
using System.Web.Optimization;

namespace InvestingMVC
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles (BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //"~/Scripts/jquery-3.3.1.js"));
            //bundles.Add(new ScriptBundle("~/bundles/jquerymin").Include(
            //"~/Scripts/jquery-3.3.1.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/datatables").Include(
                "~/Scripts/DataTables/jquery.dataTables.min.js",
                "~/Scripts/DataTables/dataTables.bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      //"~/Content/bootstrap-lumen.css",
                      "~/Content/Site.css"));

            bundles.Add(new StyleBundle("~/Content/datatables").Include(
                      "~/Content/DataTables/css/dataTables.bootstrap.css"));
        }
    }
}
