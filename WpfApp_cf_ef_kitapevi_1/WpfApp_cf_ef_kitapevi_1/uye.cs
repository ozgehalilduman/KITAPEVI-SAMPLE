using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WpfApp_cf_ef_kitapevi_1
{
    public class uye
    {
        [Key]
        public int uyeID { get; set; }
        [Required(ErrorMessage = "Uyenin adı mutlaka Girilmelidir.")]
        public string uyead { get; set; }

        [Required(ErrorMessage = "Uyenin soyadı mutlaka Girilmelidir.")]
        public string uyesoyad { get; set; }

        [Required(ErrorMessage = "Uyenin maili mutlaka Girilmelidir.")]
        public string uyemail { get; set; }

        [Required(ErrorMessage = "Uyenin telefonu mutlaka Girilmelidir.")]
        public string uyetel { get; set; }
        
        //Hareket alanlari
        public virtual List<kitap> kitaplar { get; set; }
    }
}
