using B201210597.Models.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using B201210597.Models.DTO;
using Microsoft.CodeAnalysis;

namespace B201210597.Controllers


{
    [Authorize(Roles = "admin")]

    public class DepartmentsController : Controller
    {

        private readonly DatabaseContext _db;

        Uri baseURL =new Uri("https://localhost:44305/api");
        private readonly HttpClient _client;
		public DepartmentsController()
        {
            _client= new HttpClient();
			_client.BaseAddress = baseURL;
        }

        [HttpGet]

		public IActionResult Index()
		{
			List<Department> DepartmentList=new List<Department>();
			HttpResponseMessage Respons = _client.GetAsync(_client.BaseAddress + "/Departments/Get").Result;
			if (Respons.IsSuccessStatusCode)
			{

				String results = Respons.Content.ReadAsStringAsync().Result;
				DepartmentList = JsonConvert.DeserializeObject<List< Department>>(results);

			}

			return View(DepartmentList);

			//DataTable dt = new DataTable();


			//using (var client = new HttpClient())
			//{
			//	client.BaseAddress = new Uri(baseURL);
			//	client.DefaultRequestHeaders.Accept.Clear();
			//	client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


				

				
			//	else
			//	{
			//		Console.WriteLine("Error API");
			//	}

			//}

			
		}
		public IActionResult cikis()
        {

            return RedirectToAction("Logout", "UserAuthentication");
        }
        
    }
}



