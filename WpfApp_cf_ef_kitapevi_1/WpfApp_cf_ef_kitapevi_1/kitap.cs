using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WpfApp_cf_ef_kitapevi_1
{
    public class kitap
    {
        [Key]
        public int kitapID { get; set; }
        [Required(ErrorMessage = "Kitabın ismi mutlaka Girilmelidir.")]
        public string kitapad { get; set; }

        [Required(ErrorMessage = "Kitabın yazari mutlaka Girilmelidir.")]
        public string kitapyazar { get; set; }

        [Required(ErrorMessage = "Kitabın basimyili mutlaka Girilmelidir.")]
        public int kitapbasimyili { get; set; }

        [Required(ErrorMessage = "Kitabın sayfa sayisi mutlaka Girilmelidir.")]
        public int kitapsayfasayisi { get; set; }

        [Required(ErrorMessage = "Kitabın stok miktarı mutlaka Girilmelidir.")]
        public int kitapstok { get; set; }
        
        
        //Hareket alanlari
        public virtual kitaptur kitaptur { get; set; }
        //burada bir karar verdim okulda açıkladım    
        //public virtual List<uye> uyeler { get; set; }
    }
}
