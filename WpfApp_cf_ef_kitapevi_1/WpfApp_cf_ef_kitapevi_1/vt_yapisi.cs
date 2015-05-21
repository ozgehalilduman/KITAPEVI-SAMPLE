using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace WpfApp_cf_ef_kitapevi_1
{
    public class vt_yapisi:DbContext
    {
        public DbSet<kitap> kitaplar { get; set; }
        public DbSet<kitaptur> kitapturleri { get; set; }
        public DbSet<uye> uyeler { get; set; }
    }
}
