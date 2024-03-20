using System.ComponentModel.DataAnnotations;

namespace UdemyNET7Learn.Models
{
    public class KitapTuru
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Ad Alanı boş olamaz")]
        [MaxLength(25)]
        public string TurAdi { get; set; }

    }
}
