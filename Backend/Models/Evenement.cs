namespace Backend.Models
{
    public class Evenement
    {
        public int Id { get; set; } 
        public string Nom { get; set; }
        public string? Description { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
    }
}
