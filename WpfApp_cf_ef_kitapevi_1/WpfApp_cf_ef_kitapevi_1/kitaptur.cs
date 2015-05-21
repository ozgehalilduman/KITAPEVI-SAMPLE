using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WpfApp_cf_ef_kitapevi_1
{
    public class kitaptur
    {
        [Key]
        public int kitapturID { get; set; }
        [Required(ErrorMessage="Kitap turunun ismi mutlaka Girilmelidir.")]
        public string kitapturisim { get; set; }
        //Hareket alanlari
        public virtual List<kitap> kitaplar{get;set;}
    }
}
