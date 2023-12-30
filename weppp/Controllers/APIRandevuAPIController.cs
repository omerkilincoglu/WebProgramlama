using B201210597.Models.Domain;
using B201210597.Models.DTO;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace B201210597.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class APIRandevuAPIController : ControllerBase
	{
		private readonly DatabaseContext _db;

		public APIRandevuAPIController(DatabaseContext db)
		{
			_db = db;
		}

		// GET: api/<APIRandevuAPIController>
		[HttpGet]
		public List<Appointment> Get()
		{
			return _db.Appointments.ToList();
		}
		// GET api/<APIRandevuAPIController>/5
		[HttpGet("{id}")]
		public Appointment Get(int id)
		{

			var y = _db.Appointments.FirstOrDefault(x => x.AppointmentId== id);

			return y;
		}

		// POST api/<APIRandevuAPIController>
		[HttpPost]
		public void Post([FromBody] Appointment y)
		{
			_db.Appointments.Add(y);
			_db.SaveChanges();


		}
		
		// PUT api/<APIRandevuAPIController>/5
		[HttpPut("{id}")]
		public IActionResult Put(int id, [FromBody] Appointment y)
		{
			var y1 = _db.Appointments.FirstOrDefault(x => x.AppointmentId == id);
			if (y1 != null)
			{
				return NotFound();
			}
			else
			{

				y1.AppointmentDateTime = y.AppointmentDateTime;
				y1.Kullanici = y.Kullanici;
				y1.KullaniciId = y.KullaniciId;
				y1.DoctorId = y.DoctorId;
				y1.Doctor = y.Doctor;

				_db.Update(y1);
				_db.SaveChanges();
				return Ok();
			}
		}

		// DELETE api/<APIRandevuAPIController>/5
		[HttpDelete("{id}")]
		public ActionResult Delete(int id)
		{
			var y1 = _db.Appointments.FirstOrDefault(s => s.AppointmentId== id);
			if (y1 != null)
			{
				return NotFound();
			}
			else
			{

				_db.Remove(y1);
				_db.SaveChanges();
				return Ok();
			}
		}
	}
















//    BESSAM ALSHEHABI, [29.12.2023 14:41]
//using Microsoft.AspNetCore.Mvc;
//using System.Collections.Generic;

//[ApiController]
//    [Route("api/doctors")]
//    public class DoctorsController : ControllerBase
//    {
//        private static List<Doctor> _doctors = new List<Doctor>();

//        [HttpGet]
//        public ActionResult<IEnumerable<Doctor>> GetDoctors()
//        {
//            return Ok(_doctors);
//        }

//        [HttpGet("{id}")]
//        public ActionResult<Doctor> GetDoctor(int id)
//        {
//            var doctor = _doctors.FirstOrDefault(d => d.Id == id);

//            if (doctor == null)
//            {
//                return NotFound();
//            }

//            return Ok(doctor);
//        }

//        [HttpPost]
//        public ActionResult<Doctor> CreateDoctor(Doctor doctor)
//        {
//            // Simulate database insertion
//            doctor.Id = _doctors.Count + 1;
//            _doctors.Add(doctor);

//            return CreatedAtAction(nameof(GetDoctor), new { id = doctor.Id }, doctor);
//        }

//        [HttpPut("{id}")]
//        public IActionResult UpdateDoctor(int id, Doctor updatedDoctor)
//        {
//            var existingDoctor = _doctors.FirstOrDefault(d => d.Id == id);

//            if (existingDoctor == null)
//            {
//                return NotFound();
//            }

//            // Update properties of existingDoctor with values from updatedDoctor
//            existingDoctor.Name = updatedDoctor.Name;
//            existingDoctor.Specialty = updatedDoctor.Specialty;

//            return NoContent();
//        }
//    }

//    public class Doctor
//    {
//        public int Id { get; set; }
//        public string Name { get; set; }
//        public string Specialty { get; set; }
//    }

//    BESSAM ALSHEHABI, [29.12.2023 14:42]
//using Microsoft.AspNetCore.Mvc;
//using System.Collections.Generic;
//using System.Linq;

//[ApiController]
//    [Route("api/doctors")]
//    public class DoctorsController : ControllerBase
//    {
//        private static List<Doctor> _doctors = new List<Doctor>();

//        // Other methods (GET, POST, PUT) can be here...

//        [HttpDelete("{id}")]
//        public IActionResult DeleteDoctor(int id)
//        {
//            var doctor = _doctors.FirstOrDefault(d => d.Id == id);

//            if (doctor == null)
//            {
//                return NotFound();
//            }

//            _doctors.Remove(doctor);

//            return NoContent();
//        }
//    }

//    public class Doctor
//    {
//        public int Id { get; set; }
//        public string Name { get; set; }
//        public string Specialty { get; set; }
//    }




}
