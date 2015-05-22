using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp_cf_ef_kitapevi_1
{
    public class vt_islemleri
    {
        vt_yapisi verikaynak = new vt_yapisi();
        uye yeni_uye;
        kitap yeni_kitap;
        kitaptur yeni_kitapturu;
        public string Msjlar;
        //construction (yapılandırıcı)
        // ilk oluşturulurken, kullancağım listeleri,
        //tablolardan dolduruyorum        
        public vt_islemleri()
        {
            verikaynak.kitaplar.ToList();
            verikaynak.uyeler.ToList();
            verikaynak.kitapturleri.ToList();            
        }
        //veritabanındaki kitapturu bilgilerini diger bilesenlere servis eden metot
        public ObservableCollection<kitaptur> kitapturuListesi()
        {
            return verikaynak.kitapturleri.Local;
        }
        //veritabanındaki kitap bilgilerini diger bilesenlere servis eden metot
        public ObservableCollection<kitap> kitapListesi()
        {
            return verikaynak.kitaplar.Local;
        }
        //veritabanındaki uye bilgilerini diger bilesenlere servis eden metot
        public ObservableCollection<uye> uyeListesi()
        {
            return verikaynak.uyeler.Local;
        }
        //YENİ KAYITLARIN EKLENDİĞİ KISIM
        public void yenikitapEkle(kitap yeni)
        {
            verikaynak.kitaplar.Add(yeni);
            Guncelle();
        }
        public void yenikitapturuEkle(kitaptur yeni)
        {
            verikaynak.kitapturleri.Add(yeni);
            Guncelle();
        }
        public void yeniuyeEkle(uye yeni)
        {
            verikaynak.uyeler.Add(yeni);
            Guncelle();
        }
        //KAYITLARIN SİLİNDİĞİ KISIM
        public void kitapSil(kitap kayit)
        {
            verikaynak.kitaplar.Remove(kayit);
            Guncelle();
        }
        public void kitapturuSil(kitaptur kayit)
        {
            verikaynak.kitapturleri.Remove(kayit);
            Guncelle();
        }
        public void uyeSil(uye kayit)
        {
            verikaynak.uyeler.Remove(kayit);
            Guncelle();
        }
        //KİTAP ve UYE TABLOLARININ İLİŞKİSİ
        public ObservableCollection<Object> kitap_uye_listesi()
        {
            var istenen_kayitlar = (from k in verikaynak.kitaplar
                                    from u in k.uyeler
                                    select new { kitapad = k.kitapad, ad = u.uyead, soyad = u.uyesoyad }).ToList();
            return new ObservableCollection<object>(istenen_kayitlar);
        }
        public ObservableCollection<Object> uye_kitap_listesi()
        {
            var istenen_kayitlar = (from u in verikaynak.uyeler
                                    from k in u.kitaplar
                                    select new { ad = u.uyead, soyad = u.uyesoyad, kitapad = k.kitapad }).ToList();
            return new ObservableCollection<object>(istenen_kayitlar);
        }
        //KAYITLARIN GUNCELENDİĞİ ANA KISIM
        public void Guncelle() 
        {
            try
            { 
                verikaynak.SaveChanges();
            }
            catch(DbEntityValidationException e)
            {
                List<DbValidationError> hatalar = e.EntityValidationErrors.First().ValidationErrors.ToList();
                string HataMsj = "";
                foreach (DbValidationError hata in hatalar)
                {
                    HataMsj += hata.ErrorMessage + "\n";                    
                }
                Msjlar = HataMsj;//oluşan hata mesajlarını toplayarak diger sınıfdan ulaşılan Msj değişkenine aktarıyorum...
            }

        }
    }
}
