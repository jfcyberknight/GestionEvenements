using System.ComponentModel.DataAnnotations;

namespace Frontend.Evenements.Model
{
    public class Evenement
    {
        public long Id { get; set; }

        [Required(ErrorMessage ="Le nom est requis.")]
        [StringLength(32, ErrorMessage = "32 caractères maximum pour le nom.")]
        public string? Nom { get; set; }

        [Required(ErrorMessage = "La description est requise.")]
        [StringLength(255, ErrorMessage = "255 caractères maximum pour la description.")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "La date de début est requise.")]
        public DateTime? Datedebut { get; set; }

        [Required(ErrorMessage = "La date de fin est requise.")]
        public DateTime? Datefin { get; set; }
    }
}
