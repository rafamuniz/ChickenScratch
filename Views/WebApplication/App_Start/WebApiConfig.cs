﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;
using System.Web.Mvc;

namespace WebApplication
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "ControllerAndAction",
                routeTemplate: "api/{controller}/{action}"
            //, defaults: new { id = UrlParameter.Optional, action = "AddSomething" }
            );

            config.Routes.MapHttpRoute(
              name: "ControllerAndActionAndId"
              , routeTemplate: "api/{controller}/{action}/{Id}"
              , defaults: new { id = RouteParameter.Optional }
          );

            config.Routes.MapHttpRoute(
             name: "ControllerAndActionAndString"
             , routeTemplate: "api/{controller}/{action}/{strokes}"
             , defaults: new { strokes = RouteParameter.Optional }
         );
        }
    }
}
