using B201210597.Models.Domain;
using B201210597.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;

namespace B201210597.Controllers
{
    [Authorize(Roles = "admin")]

    public class CallDepartmenAPIController : Controller
	{

        private readonly DatabaseContext _db;

        public CallDepartmenAPIController(DatabaseContext db)
        {
            _db = db;
        }


        public async Task<IActionResult> Index()
        {
            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
            };

            var client = new HttpClient(handler);
            var response = await client.GetAsync("https://localhost:7286/api/ApiDepartment");

            List<Department> Departments = new List<Department>();
            //var response = await client.GetAsync("https://localhost:7286/api/ApiDepartment");
            var jsonResponse = await response.Content.ReadAsStringAsync();
            Departments = JsonConvert.DeserializeObject<List<Department>>(jsonResponse);


            return View(Departments);
        }



        [HttpGet]
        
                public ActionResult<IEnumerable<Department>> GetDeoartmas()
                {
                    return Ok(_db.Departments);
                }
        [HttpGet("{id}")]
        public ActionResult<Department> GetDepartman(int id)
        {
            var x = _db.Departments.FirstOrDefault(d => d.DepartmentId == id);

            if (x == null)
            {
                return NotFound();
            }

            return Ok(x);
        }

        public IActionResult Create()
        {
            
            
            return View();

        }

        public IActionResult Delete()
        {


            return View();

        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Department obj)
        {
            //if (obj.Name == obj.DisplayOrder.ToString())
            //{
            //    ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name.");
            //}
            //   if (ModelState.IsValid)

            _db.Departments.Add(obj);
            _db.SaveChanges();
            TempData["success"] = "Departman created successfully";
            return RedirectToAction("Index");


        }
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _db.Departments.Find(id);
            //var categoryFromDbFirst = _db.Categories.FirstOrDefault(u=>u.Id==id);
            //var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }

            return View(categoryFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Department obj)
        {
            //if (obj.Name == obj.DisplayOrder.ToString())
            //{
            //    ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name.");
            //}

            _db.Departments.Update(obj);
            _db.SaveChanges();
            TempData["success"] = "Departman updated successfully";
            return RedirectToAction("Index");

        }




        //public ActionResult<Department> CreateDoctor(Department d)
        //{
        //    // Simulate database insertion
        //    d.DepartmentId = _db.Count + 1;
        //    _db.Departments.Add(d);

        //    return CreatedAtAction(nameof(GetDoctor), new { id = doctor.Id }, doctor);
        //}

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var x = _db.Departments.FirstOrDefault(d => d.DepartmentId == id);

            if (x== null)
            {
                return NotFound();
            }

            _db.Departments.Remove(x);

            return NoContent();
        }

        

        public IActionResult cikis()
        {
            return RedirectToAction("Logout", "UserAuthentication");
        }

    }
}











































