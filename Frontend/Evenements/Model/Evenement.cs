namespace Frontend.Evenements.Model
{
    public partial class Evenement
    {
        public long Id { get; set; }
        public string? Nom { get; set; }
        public string? Description { get; set; }
        public DateTime? Datedebut { get; set; }
        public DateTime? Datefin { get; set; }
    }
}
