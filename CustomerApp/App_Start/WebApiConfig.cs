using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web.Http;

namespace CustomerApp
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);


            config.Routes.MapHttpRoute(
              name: "DefaultCustomerRoute",
              routeTemplate: "api/customers",
              defaults: new { controller = "Customers", action = "Get" }
          );

            config.Routes.MapHttpRoute(
                name: "CustomerRoute",
                routeTemplate: "api/customers/{customerid}",
                defaults: new { controller = "Customers", action = "GetCustomer" }
            );

            config.Routes.MapHttpRoute(
               name: "CustomerOrdersRoute",
               routeTemplate: "api/customers/{customerid}/orders",
               defaults: new { controller = "Customers", action = "GetOrdersByCostumer" }
           );

            config.Routes.MapHttpRoute(
               name: "CustomerOrdersDetailRoute",
               routeTemplate: "api/customers/{customerid}/orders/{orderid}",
               defaults: new { controller = "Customers", action = "GetOrdersDetailByCostumer" }
           );   

            config.Routes.MapHttpRoute(
              name: "CustomerDeleteRoute",
              routeTemplate: "api/customers/{customerid}/delete",
              defaults: new { controller = "Customers", action = "DeleteCustomer" }
          );

            //Handle the output format json or xml
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.MediaTypeMappings.Add(
                new QueryStringMapping("type", "json", new MediaTypeHeaderValue("application/json")));

            GlobalConfiguration.Configuration.Formatters.XmlFormatter.MediaTypeMappings.Add(
                new QueryStringMapping("type", "xml", new MediaTypeHeaderValue("application/xml")));

           
            // Quite los comentarios de la siguiente línea de código para habilitar la compatibilidad de consultas para las acciones con un tipo de valor devuelto IQueryable o IQueryable<T>.
            // Para evitar el procesamiento de consultas inesperadas o malintencionadas, use la configuración de validación en QueryableAttribute para validar las consultas entrantes.
            // Para obtener más información, visite http://go.microsoft.com/fwlink/?LinkId=279712.
            //config.EnableQuerySupport();

            // Para deshabilitar el seguimiento en la aplicación, incluya un comentario o quite la siguiente línea de código
            // Para obtener más información, consulte: http://www.asp.net/web-api
            config.EnableSystemDiagnosticsTracing();
        }
    }
}
