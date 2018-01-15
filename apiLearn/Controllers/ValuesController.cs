using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace apiLearn.Controllers
{
	// A very simple controller for exchanging values
	public class ValuesController : ApiController
	{
		List<string> strings = new List<string>()
		{
			"BobCat",
			"TomCat",
			"KittyCat"
		};

		// GET api/values
		public IEnumerable<string> Get()
		{
			return strings;
		}

		// GET api/values/5
		public string Get(int id)
		{
			return strings[id];
		}

		// POST api/values
		public void Post([FromBody]string value)
		{
			strings.Add(value);
		}

		// PUT api/values
		public void Put(int id, [FromBody]string value)
		{
			strings[id] = value;
		}

		// DELETE api/values
		public void Delete(int id)
		{
			strings.RemoveAt(id);
		}
	}
}
