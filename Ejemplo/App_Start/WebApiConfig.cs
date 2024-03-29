﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Ejemplo.Controllers;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;

namespace Ejemplo
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuración y servicios de Web API
            // Configure Web API para usar solo la autenticación de token de portador.
            config.EnableCors();
            config.SuppressDefaultHostAuthentication();

            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            config.MessageHandlers.Add(new TokenValidationHandler());
            // Rutas de Web API
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
