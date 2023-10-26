using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ir.news.xsean.Controllers
{
	[Route("api/edit")]
	[ApiController]
	public class updateController : ControllerBase
	{
		private dbcontext _context;
		public updateController(dbcontext context)
		{
			_context = context;
		}
		// GET: api/<ValuesController>
		[HttpGet]
		public async Task<string> Get()
		{
			_context.Database.Migrate();
			return "OK";

		}

		// GET api/<ValuesController>/5
		//[HttpGet("{id}")]
		//public string Get(int id)
		//{
		//    return "value";
		//}

		// POST api/<ValuesController>
		//[HttpPost]
		//public void Post([FromBody] string value)
		//{
		//}

		// PUT api/<ValuesController>/5
		//[HttpPut("{id}")]
		//public void Put(int id, [FromBody] string value)
		//{
		//}

		// DELETE api/<ValuesController>/5
		//[HttpDelete("{id}")]
		//public void Delete(int id)
		//{
		//}
	}
}
/*
     List<newss> newss = _context.newss.Where(p => p.titleimg == null).ToList();
			foreach (var NEW in newss)
			{
				_context.Remove(_context.newsfi.Where(P => P.url == NEW.url).First());
				_context.Remove(_context.urlscros.Where(P => P.url == NEW.url).First());
				_context.Remove(NEW);
				var ca = _context.catgories.Where(P => P.Name == NEW.CatgoryName).First();
				ca.count = ca.count - 1;
				_context.catgories.Update(ca);
				await _context.SaveChangesAsync();
				Console.WriteLine("ok");
			}
			var cat = _context.catgories.ToList();
			List<catgory> li = new List<catgory>();
			foreach (var c in cat)
			{

				string.Join("", c.Name.Split("  ", StringSplitOptions.RemoveEmptyEntries));
				catgory catgory = new catgory()
				{
					count = c.count
				,
					Name = string.Join("", c.Name.Split("  ", StringSplitOptions.RemoveEmptyEntries)),
					Newsses = c.Newsses

				};

				_context.Add(catgory);
				await _context.SaveChangesAsync();
				foreach (var n in _context.newss.Where(p => p.CatgoryName == c.Name).ToList())
				{
					n.Catgory = catgory;
					_context.Update(n);
					await _context.SaveChangesAsync();
				}
				foreach (var x in _context.newsfi.Where(p => p.CatgoryName == c.Name).ToList())
				{
					x.Catgory = catgory;
					_context.Update(x);
					await _context.SaveChangesAsync();
				}
				Console.WriteLine("ook");

			}

			foreach (var c in cat)
			{
				_context.Remove(c);
				await _context.SaveChangesAsync();
			}
 */