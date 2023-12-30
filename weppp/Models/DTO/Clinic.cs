using System.Numerics;
using B201210597.Models.DTO;


namespace B201210597.Models.DTO
{
    
	

   
        public class Clinic
        {
            public int ClinicId { get; set; }
            public string ClinicName { get; set; }

            public int DepartmentId { get; set; }
            public Department Department { get; set; }

            public List<Doctor> Doctors { get; set; }
        public List<Department> Departments { get; internal set; }
    }

  
}
