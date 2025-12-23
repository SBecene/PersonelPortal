using System.ComponentModel.DataAnnotations;

namespace PersonelPortal.Models
{
    public class Personel
    {
        public int Id { get; set; }

        [Required, MaxLength(80)]
        public string AdSoyad { get; set; } = "";

        [MaxLength(80)]
        public string Unvan { get; set; } = "";

        [MaxLength(80)]
        public string Birim { get; set; } = "";

        [MaxLength(20)]
        public string Telefon { get; set; } = "";
    }
}