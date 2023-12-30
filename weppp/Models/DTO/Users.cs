namespace B201210597.Models.DTO
{
    public class Kullanici
    {
        public int KullaniciId { get; set; }
        public string KullaniciName { get; set; }
        public string Password { get; set; }
        // Other user information
        public List<Appointment> Appointments { get; set; }

    }
}
