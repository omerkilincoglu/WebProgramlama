using B201210597.Models.Domain;
using B201210597.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace B201210597.Controllers
{


	[Route("api/[controller]")]
	[ApiController]
	public class ApiDepartmentController : ControllerBase
	{
		private readonly DatabaseContext _db;

		public ApiDepartmentController(DatabaseContext db)
		{
			_db = db;
		}

		//DatabaseContext k = new DatabaseContext();

		// GET: api/<ApiDepartmentController>
		[HttpGet]
		public List<Department> Get()
		{
			return _db.Departments.ToList();
		}
			
		// GET api/<ApiDepartmentController>/5
		[HttpGet("{id}")]
		public Department Get(int id)
		{

			var y= _db.Departments.FirstOrDefault(x=>x.DepartmentId==id);

			return y;
		}

		// POST api/<ApiDepartmentController>
		[HttpPost]
		public void Post([FromBody] Department y)
		{
			_db.Departments.Add(y);
			_db.SaveChanges();


		}

		// PUT api/<ApiDepartmentController>/5
		[HttpPut("{id}")]
		public IActionResult Put(int id, [FromBody] Department y)
		{
			var y1=_db.Departments.FirstOrDefault(x=>x.DepartmentId==id);
			if(y1 !=null)
			{
				return NotFound();
			}
			else
			{
				
				y1.DepartmentName=y.DepartmentName;
				_db.Update(y1);
				_db.SaveChanges();
				return Ok();
			}
		}
       
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var departmentToDelete = _db.Departments.FirstOrDefault(s => s.DepartmentId == id);
            if (departmentToDelete == null)
            {
                return NotFound();
            }
            else
            {
                _db.Remove(departmentToDelete);
                _db.SaveChanges();
                return Ok();
            }
        }

    }

}
