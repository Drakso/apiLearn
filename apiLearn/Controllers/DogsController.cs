using apiLearn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace apiLearn.Controllers
{
    public class DogsController : ApiController
    {
		List<Dog> dogsDb = new List<Dog>()
		{
			new Dog {Name = "Fido", Age = 3, Race = "Husky"},
			new Dog {Name = "Dasy", Age = 2, Race = "Poodle"},
			new Dog {Name = "Rex", Age = 4, Race = "German Shepherd"}
		};

        // GET: api/Dogs
        public IEnumerable<Dog> Get()
        {
			return dogsDb;
        }

        // GET: api/Dogs/5
        public HttpResponseMessage Get(int id)
        {
			var entity = dogsDb[id];
			if(entity != null)
			{
				// Return response with status code 200(Ok) and the model with the id entered
				return Request.CreateResponse(HttpStatusCode.OK, entity);
			}
			else
			{
				// If no item is found, return response with status code 404(not found) and a meaningfull message
				return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Dog with Id: " + id.ToString() + " was not found in our super awesome Database");
			}
        }

        // POST: api/Dogs
        public HttpResponseMessage Post([FromBody]Dog dog)
        {
			try
			{
				dogsDb.Add(dog);
				// We create a response. The response here returns a status code 201(Created) and we return the model saved
				var responseMessage = Request.CreateResponse(HttpStatusCode.Created, dog);
				// We also return the Uri to the newly created object
				responseMessage.Headers.Location = new Uri(Request.RequestUri + (dogsDb.Count - 1).ToString());
				return responseMessage;
			}
			catch (Exception ex) {
				// We create error response in case of an exception. We return status code 400(Bad request) and the exception
				return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
			}
			
        }

        // PUT: api/Dogs/5
        public HttpResponseMessage Put(int id, [FromBody]Dog dog)
        {
			try
			{
				if (dogsDb[id] == null)
				{
					// If no item is found, return response with status code 404(not found) and a meaningfull message
					return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Dog with Id: " + id.ToString() + " was not found in our super awesome Database");
				}
				else
				{
					dogsDb[id].Age = dog.Age;
					dogsDb[id].Name = dog.Name;
					dogsDb[id].Race = dog.Race;

					// If the item was successfully deleted, return response with status code 200(OK) and the changed model
					return Request.CreateResponse(HttpStatusCode.OK, dog);
				}
			}
			catch (Exception ex)
			{
				// We create error response in case of an exception. We return status code 400(Bad request) and the exception
				return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
			}
        }

        // DELETE: api/Dogs/5
        public HttpResponseMessage Delete(int id)
        {
			try
			{
				if (dogsDb[id] == null)
				{
					// If no item is found, return response with status code 404(not found) and a meaningfull message
					return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Dog with Id: " + id.ToString() + " was not found in our super awesome Database");
				}
				else
				{
					dogsDb.RemoveAt(id);
					// If the item was successfully deleted, return response with status code 200(OK)
					return Request.CreateResponse(HttpStatusCode.OK);
				}
			} catch (Exception ex)
			{
				// We create error response in case of an exception. We return status code 400(Bad request) and the exception
				return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
			}


        }
    }
}
