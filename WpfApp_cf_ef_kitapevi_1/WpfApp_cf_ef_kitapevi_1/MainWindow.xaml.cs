using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp_cf_ef_kitapevi_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        vt_islemleri vt = new vt_islemleri();
        kitaptur _kitaptur;
        uye _uye;
        kitap _kitap;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void TabControl_1_Loaded(object sender, RoutedEventArgs e)
        {
            //tabcontrol deki temel gridleri dolduruyorum....
            db_grid_kitaplar.ItemsSource = vt.kitapListesi();
            db_grid_kitapturleri.ItemsSource = vt.kitapturuListesi();
            db_grid_uyeler.ItemsSource = vt.uyeListesi();
            db_grid_sec_kitap.ItemsSource = vt.kitapListesi();
            db_grid_sec_uye.ItemsSource = vt.uyeListesi();
            db_grid_uye_kitap.ItemsSource = vt.uye_kitap_listesi();
            cb_kitaptur.ItemsSource = vt.kitapturuListesi();
            cb_kitap.ItemsSource = vt.kitapListesi();
        }

        //KİTAPTURU İSLEMLERİ
        private void btn_yeni_kitapturu_Click(object sender, RoutedEventArgs e)
        {
            s_panel_kitapturleri.IsEnabled = true;
            s_panel_kitapturleri.Tag = "yeni";
            btn_yeni_kitapturu.IsEnabled = false;
            db_grid_kitapturleri.IsEnabled = false;
            _kitaptur = new kitaptur();
            s_panel_kitapturleri.DataContext = _kitaptur;
            lb_kitapturleri.Content = "YENİ KAYIT";
        }

        private void btn_kitapturu_kaydet_Click(object sender, RoutedEventArgs e)
        {
            s_panel_kitapturleri.IsEnabled = false;
            btn_yeni_kitapturu.IsEnabled = true;
            db_grid_kitapturleri.IsEnabled = true;
            if (s_panel_kitapturleri.Tag.ToString()== "yeni") 
            {
                vt.yenikitapturuEkle(_kitaptur);
                s_panel_kitapturleri.Tag = "";
                lb_kitapturleri.Content = "KAYIT DUZENLE";
            }
            vt.Guncelle();
            if (vt.Msjlar !=null)
            {
                Txtblok_kitapturu_islem_sonucu.Text = vt.Msjlar;
                Txtblok_kitapturu_islem_sonucu.Foreground=Brushes.Red;
            }
            else
            {
                Txtblok_kitapturu_islem_sonucu.Text = "İşleminiz Başarılı";
                Txtblok_kitapturu_islem_sonucu.Foreground = Brushes.Green;
            }
        }
        
        private void btn_kitapturu_iptal_Click(object sender, RoutedEventArgs e)
        {
            s_panel_kitapturleri.IsEnabled = false;
            btn_yeni_kitapturu.IsEnabled = true;
            db_grid_kitapturleri.IsEnabled = true;
        }
        private void btn_kitaptur_duzenle(object sender, RoutedEventArgs e)
        {
            _kitaptur =(kitaptur)db_grid_kitapturleri.SelectedItem;
            s_panel_kitapturleri.DataContext = _kitaptur;
            s_panel_kitapturleri.IsEnabled = true;            
            btn_yeni_kitapturu.IsEnabled = false;
            db_grid_kitapturleri.IsEnabled = false;
            lb_kitapturleri.Content = "KAYIT DUZENLE";

        }
        private void btn_kitaptur_sil(object sender, RoutedEventArgs e)
        {
            _kitaptur =(kitaptur) db_grid_kitapturleri.SelectedItem;
            vt.kitapturuSil(_kitaptur);
            if (vt.Msjlar != null)
            {
                Txtblok_kitapturu_islem_sonucu.Text = vt.Msjlar;
                Txtblok_kitapturu_islem_sonucu.Foreground=Brushes.Red;
            }
            else
            {
                Txtblok_kitapturu_islem_sonucu.Text = "İşleminiz Başarılı";
                Txtblok_kitapturu_islem_sonucu.Foreground=Brushes.Green;
            }
        }
        //UYE İSLEMLERİ
        private void btn_yeni_uye_Click(object sender, RoutedEventArgs e)
        {
            s_panel_uyeler.IsEnabled = true;
            s_panel_uyeler.Tag = "yeni";
            btn_yeni_uye.IsEnabled = false;
            db_grid_uyeler.IsEnabled = false;
            _uye = new uye();
            s_panel_uyeler.DataContext = _uye;
            lb_uyeler.Content = "YENİ KAYIT";
        }

        private void btn_uye_kaydet_Click(object sender, RoutedEventArgs e)
        {
            s_panel_uyeler.IsEnabled = false;
            btn_yeni_uye.IsEnabled = true;
            db_grid_uyeler.IsEnabled = true;
            //kitabı aldığım kısım
            _kitap = (kitap)cb_kitap.SelectedItem;


            if (s_panel_uyeler.Tag.ToString() == "yeni")
            {
                vt.yeniuyeEkle(_uye);
                s_panel_uyeler.Tag = "";
                lb_uyeler.Content = "KAYIT DUZENLE";
                _uye.kitaplar = new List<kitap>();                
            }
            _uye.kitaplar.Add(_kitap);           
            vt.Guncelle();
            if (vt.Msjlar != null)
            {
                Txtblok_uye_islem_sonucu.Text = vt.Msjlar;
                Txtblok_uye_islem_sonucu.Foreground=Brushes.Red;
            }
            else
            {
                Txtblok_uye_islem_sonucu.Text = "İşleminiz Başarılı";
                Txtblok_uye_islem_sonucu.Foreground = Brushes.Green;
            }
        }

        private void btn_uye_iptal_Click(object sender, RoutedEventArgs e)
        {
            s_panel_uyeler.IsEnabled = false;
            btn_yeni_uye.IsEnabled = true;
            db_grid_uyeler.IsEnabled = true;
        }
        private void btn_uye_duzenle(object sender, RoutedEventArgs e)
        {
            _uye = (uye)db_grid_uyeler.SelectedItem;
            s_panel_uyeler.DataContext = _kitaptur;
            s_panel_uyeler.IsEnabled = true;
            btn_yeni_uye.IsEnabled = false;
            db_grid_uyeler.IsEnabled = false;
            lb_uyeler.Content = "KAYIT DUZENLE";

        }
        private void btn_uye_sil(object sender, RoutedEventArgs e)
        {
            _uye = (uye)db_grid_uyeler.SelectedItem;
            vt.uyeSil(_uye);
            if (vt.Msjlar != null)
            {
                Txtblok_uye_islem_sonucu.Text = vt.Msjlar;
                Txtblok_uye_islem_sonucu.Foreground = Brushes.Red;
            }
            else
            {
                Txtblok_uye_islem_sonucu.Text = "İşleminiz Başarılı";
                Txtblok_uye_islem_sonucu.Foreground=Brushes.Green;
            }
        }
        //KİTAP ISLEMLERİ
        private void btn_yeni_kitap_Click(object sender, RoutedEventArgs e)
        {
            s_panel_kitaplar.IsEnabled = true;
            s_panel_kitaplar.Tag = "yeni";
            btn_yeni_kitap.IsEnabled = false;
            db_grid_kitaplar.IsEnabled = false;
            _kitap = new kitap();
            s_panel_kitaplar.DataContext = _kitap;
            lb_kitaplar.Content = "YENİ KAYIT";
        }

        private void btn_kitap_kaydet_Click(object sender, RoutedEventArgs e)
        {
            s_panel_kitaplar.IsEnabled = false;
            btn_yeni_kitap.IsEnabled = true;
            db_grid_kitaplar.IsEnabled = true;
            //kitapturunu aldığım kısım
            _kitaptur = (kitaptur)cb_kitaptur.SelectedItem;
            _kitap.kitaptur = _kitaptur;

            if (s_panel_kitaplar.Tag.ToString() == "yeni")
            {
                vt.yenikitapEkle(_kitap);
                s_panel_kitaplar.Tag = "";
                lb_kitaplar.Content = "KAYIT DUZENLE";
            }

            vt.Guncelle();
            if (vt.Msjlar != null)
            {
                Txtblok_kitap_islem_sonucu.Text = vt.Msjlar;
                Txtblok_kitap_islem_sonucu.Foreground = Brushes.Red;
            }
            else
            {
                Txtblok_kitap_islem_sonucu.Text = "İşleminiz Başarılı";
                Txtblok_kitap_islem_sonucu.Foreground=Brushes.Green;
            }
        }

        private void btn_kitap_iptal_Click(object sender, RoutedEventArgs e)
        {
            s_panel_kitaplar.IsEnabled = false;
            btn_yeni_kitap.IsEnabled = true;
            db_grid_kitaplar.IsEnabled = true;
        }
        private void btn_kitap_duzenle(object sender, RoutedEventArgs e)
        {
            _kitap = (kitap)db_grid_kitaplar.SelectedItem;
            s_panel_kitaplar.DataContext = _kitap;
            s_panel_kitaplar.IsEnabled = true;
            btn_yeni_kitap.IsEnabled = false;
            db_grid_kitaplar.IsEnabled = false;
            lb_kitaplar.Content = "KAYIT DUZENLE";
            //kayitturunu comboboxda gosterdiğim kısım
            cb_kitaptur.SelectedItem = _kitap.kitaptur;
        }
        private void btn_kitap_sil(object sender, RoutedEventArgs e)
        {
            _kitap = (kitap)db_grid_kitaplar.SelectedItem;
            vt.kitapSil(_kitap);
            if (vt.Msjlar != null)
            {
                Txtblok_kitap_islem_sonucu.Text = vt.Msjlar;
                Txtblok_kitap_islem_sonucu.Foreground = Brushes.Red;
            }
            else
            {
                Txtblok_kitap_islem_sonucu.Text = "İşleminiz Başarılı";
                Txtblok_kitap_islem_sonucu.Foreground = Brushes.Green;
            }
        }


        private void TabControl_1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Txtblok_kitap_islem_sonucu.Text = "";
            Txtblok_kitapturu_islem_sonucu.Text = "";
            Txtblok_uye_islem_sonucu.Text = "";
        }

        private void db_grid_sec_uye_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _uye=(uye)db_grid_sec_uye.SelectedItem;
            lbl_sec_uye.Content = _uye.uyead + " " + _uye.uyesoyad;
        }

        private void db_grid_sec_kitap_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           _kitap = (kitap)db_grid_sec_kitap.SelectedItem;
           lbl_sec_kitap.Content = _kitap.kitapad + " (" + _kitap.kitaptur.kitapturisim + ")";
        }

        private void btn_kitapver_Click(object sender, RoutedEventArgs e)
        {
            //sağlam kazık olayı
            if (db_grid_sec_kitap.SelectedItem != null && db_grid_sec_uye.SelectedItem != null)
            {
                MessageBox.Show("İŞLEMİNİZ GERÇEKLEŞTİ");
                _uye.kitaplar.Add(_kitap);
                vt.Guncelle();
                db_grid_uye_kitap.Items.Refresh();
            }
            else
            {
                if (db_grid_sec_kitap.SelectedItem == null) { MessageBox.Show("KİTAP SEÇİLMEMİŞ"); }
                if (db_grid_sec_uye.SelectedItem == null) { MessageBox.Show("UYE SEÇİLMEMİŞ"); }
            }
        }
    }
}

