using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Net.Http.Headers;

namespace apiLearn
{
/*
	// Custom Json Formatter that will handle requests from browser and return Json instead of Xml to the browser
	public class BrowserJsonFormatter : JsonMediaTypeFormatter
	{
		public BrowserJsonFormatter()
		{
			// This will return Json to a browser
			this.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
		}

		// Even if we return Json to the browser, the browser still says in the header content-type "text/html"
		// This override makes sure that it writes application/json
		public override void SetDefaultContentHeaders(Type type, HttpContentHeaders headers, MediaTypeHeaderValue mediaType)
		{
			base.SetDefaultContentHeaders(type, headers, mediaType);
			headers.ContentType = new MediaTypeHeaderValue("application/json");
		}
	}
*/

    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
			// Add our custom formatter for opening Json in browser
			/* config.Formatters.Add(new BrowserJsonFormatter()); */
			// Remove a formater so the application only support JSON
			config.Formatters.Remove(config.Formatters.XmlFormatter);

			// All JSON requests will be indented and camelCase
			config.Formatters.JsonFormatter.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
			config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }
    }
}
