
using System;

namespace ecommerceordermanagementsystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Ürün bilgileri
            int urunKodu1 = 1;
            string urun1 = "Klavye";
            decimal birimFiyatUrun1 = 1500;
            int stokUrun1 = 10;

            int urunKodu2 = 2;
            string urun2 = "Mouse";
            decimal birimFiyatUrun2 = 750;
            int stokUrun2 = 15;

            int urunKodu3 = 3;
            string urun3 = "Monitör";
            decimal birimFiyatUrun3 = 5000;
            int stokUrun3 = 5;

            // Satış bilgileri
            decimal toplamSatisGeliri = 0;
            int basariliSiparisSayisi = 0;
            int basarisizSiparisSayisi = 0;
            int satilanToplamUrunAdedi = 0;
            decimal enYuksekSiparisTutari = 0;

            // Yönetici bilgileri
            int yoneticiSifresi = 1234;
            int girisHakki = 3;
            bool girisBasarili = false;

            // Yönetici giriş sistemi
            for (int i = 1; i <= girisHakki; i++)
            {
                Console.WriteLine("Lütfen yönetici şifresini girin:");
                int kullaniciSifreGirisi = int.Parse(Console.ReadLine());

                if (kullaniciSifreGirisi == yoneticiSifresi)
                {
                    Console.WriteLine("Giriş başarılı!");
                    girisBasarili = true;
                    break;
                }
                else
                {
                    Console.WriteLine($"Yanlış şifre! Kalan hak: {girisHakki - i}");
                }
            }

            if (girisBasarili)
            {
                int sayi;

                do
                {
                    Console.WriteLine("\n===== E-COMMERCE MANAGEMENT SYSTEM =====");
                    Console.WriteLine("1 - Ürünleri Listele");
                    Console.WriteLine("2 - Sipariş Oluştur");
                    Console.WriteLine("3 - Stok Ekle");
                    Console.WriteLine("4 - Satış Raporu");
                    Console.WriteLine("5 - Çıkış");

                    Console.WriteLine("İşlem seçiniz:");
                    sayi = int.Parse(Console.ReadLine());

                    switch (sayi)
                    {
                        case 1:
                            // Ürünleri listeleme
                            Console.WriteLine("\n===== ÜRÜN LİSTESİ =====");

                            Console.WriteLine($"Ürün Kodu: {urunKodu1}");
                            Console.WriteLine($"Ürün Adı: {urun1}");
                            Console.WriteLine($"Birim Fiyat: {birimFiyatUrun1:F2} TL");
                            Console.WriteLine($"Stok: {stokUrun1}");

                            if (stokUrun1 == 0)
                            {
                                Console.WriteLine("Stokta Yok!");
                            }

                            Console.WriteLine("--------------------");

                            Console.WriteLine($"Ürün Kodu: {urunKodu2}");
                            Console.WriteLine($"Ürün Adı: {urun2}");
                            Console.WriteLine($"Birim Fiyat: {birimFiyatUrun2:F2} TL");
                            Console.WriteLine($"Stok: {stokUrun2}");

                            if (stokUrun2 == 0)
                            {
                                Console.WriteLine("Stokta Yok!");
                            }

                            Console.WriteLine("--------------------");

                            Console.WriteLine($"Ürün Kodu: {urunKodu3}");
                            Console.WriteLine($"Ürün Adı: {urun3}");
                            Console.WriteLine($"Birim Fiyat: {birimFiyatUrun3:F2} TL");
                            Console.WriteLine($"Stok: {stokUrun3}");

                            if (stokUrun3 == 0)
                            {
                                Console.WriteLine("Stokta Yok!");
                            }

                            break;

                        case 2:
                            // Sipariş oluşturma
                            Console.WriteLine("\n===== SİPARİŞ OLUŞTURMA =====");

                            Console.WriteLine("Ürün kodunu giriniz:");
                            int musteriUrunKodu = int.Parse(Console.ReadLine());

                            // Ürün kodu doğrulama
                            while (musteriUrunKodu < 1 || musteriUrunKodu > 3)
                            {
                                basarisizSiparisSayisi++;

                                Console.WriteLine("Geçersiz ürün kodu!");
                                Console.WriteLine("Tekrar ürün kodu giriniz:");

                                musteriUrunKodu = int.Parse(Console.ReadLine());
                            }

                            Console.WriteLine("Sipariş adedini giriniz:");
                            int siparisAdedi = int.Parse(Console.ReadLine());

                            string secilenUrun = "";
                            decimal secilenBirimFiyat = 0;
                            int secilenStok = 0;

                            // Seçilen ürünün bilgilerini belirleme
                            if (musteriUrunKodu == urunKodu1)
                            {
                                secilenUrun = urun1;
                                secilenBirimFiyat = birimFiyatUrun1;
                                secilenStok = stokUrun1;
                            }
                            else if (musteriUrunKodu == urunKodu2)
                            {
                                secilenUrun = urun2;
                                secilenBirimFiyat = birimFiyatUrun2;
                                secilenStok = stokUrun2;
                            }
                            else if (musteriUrunKodu == urunKodu3)
                            {
                                secilenUrun = urun3;
                                secilenBirimFiyat = birimFiyatUrun3;
                                secilenStok = stokUrun3;
                            }

                            // Sipariş doğrulama
                            if (siparisAdedi <= 0)
                            {
                                Console.WriteLine("Sipariş adedi pozitif olmalıdır!");
                                basarisizSiparisSayisi++;
                            }
                            else if (siparisAdedi > secilenStok)
                            {
                                Console.WriteLine("Yetersiz stok!");
                                basarisizSiparisSayisi++;
                            }
                            else
                            {
                                decimal tutar = secilenBirimFiyat * siparisAdedi;
                                decimal indirimOrani = 0;
                                decimal kdvOrani = 0.20m;

                                // İndirim oranını belirleme
                                if (tutar < 3000)
                                {
                                    indirimOrani = 0;
                                }
                                else if (tutar < 6000)
                                {
                                    indirimOrani = 0.05m;
                                }
                                else if (tutar < 10000)
                                {
                                    indirimOrani = 0.10m;
                                }
                                else
                                {
                                    indirimOrani = 0.15m;
                                }

                                // Sipariş hesaplamaları
                                decimal indirimTutari = tutar * indirimOrani;
                                decimal indirimliTutar = tutar - indirimTutari;
                                decimal kdvTutari = indirimliTutar * kdvOrani;
                                decimal genelToplam = indirimliTutar + kdvTutari;

                                // Gerçek stokları güncelleme
                                if (musteriUrunKodu == urunKodu1)
                                {
                                    stokUrun1 -= siparisAdedi;
                                }
                                else if (musteriUrunKodu == urunKodu2)
                                {
                                    stokUrun2 -= siparisAdedi;
                                }
                                else
                                {
                                    stokUrun3 -= siparisAdedi;
                                }

                                int kalanStokAdedi = secilenStok - siparisAdedi;

                                // Satış bilgilerini güncelleme
                                toplamSatisGeliri += genelToplam;
                                basariliSiparisSayisi++;
                                satilanToplamUrunAdedi += siparisAdedi;

                                enYuksekSiparisTutari = Math.Max(
                                    enYuksekSiparisTutari, genelToplam);

                                // Sipariş detayları
                                Console.WriteLine("\n===== SİPARİŞ DETAYLARI =====");
                                Console.WriteLine($"Seçilen Ürün: {secilenUrun}");
                                Console.WriteLine($"Birim Fiyat: {secilenBirimFiyat:F2} TL");
                                Console.WriteLine($"Sipariş Adedi: {siparisAdedi}");
                                Console.WriteLine($"Ara Toplam: {tutar:F2} TL");
                                Console.WriteLine($"İndirim Oranı: %{indirimOrani * 100:F0}");
                                Console.WriteLine($"İndirim Tutarı: {indirimTutari:F2} TL");
                                Console.WriteLine($"İndirimli Tutar: {indirimliTutar:F2} TL");
                                Console.WriteLine($"KDV Tutarı: {kdvTutari:F2} TL");
                                Console.WriteLine($"Genel Toplam: {genelToplam:F2} TL");
                                Console.WriteLine($"Kalan Stok: {kalanStokAdedi}");
                                Console.WriteLine("Sipariş başarılı!");
                            }

                            break;

                        case 3:
                            // Stok ekleme
                            Console.WriteLine("\n===== STOK EKLEME =====");

                            Console.WriteLine("Ürün kodunu giriniz:");
                            int stokUrunKodu = int.Parse(Console.ReadLine());

                            Console.WriteLine("Eklenecek stok adedini giriniz:");
                            int eklenecekStok = int.Parse(Console.ReadLine());

                            if (eklenecekStok <= 0)
                            {
                                Console.WriteLine("Stok miktarı pozitif olmalıdır!");
                            }
                            else if (stokUrunKodu == urunKodu1)
                            {
                                stokUrun1 += eklenecekStok;
                                Console.WriteLine($"{urun1} güncel stok: {stokUrun1}");
                            }
                            else if (stokUrunKodu == urunKodu2)
                            {
                                stokUrun2 += eklenecekStok;
                                Console.WriteLine($"{urun2} güncel stok: {stokUrun2}");
                            }
                            else if (stokUrunKodu == urunKodu3)
                            {
                                stokUrun3 += eklenecekStok;
                                Console.WriteLine($"{urun3} güncel stok: {stokUrun3}");
                            }
                            else
                            {
                                Console.WriteLine("Geçersiz ürün kodu!");
                            }

                            break;

                        case 4:
                            // Satış raporu
                            decimal ortalamaSiparisTutari = 0;
                            decimal siparisBasariOrani = 0;

                            int toplamSiparisSayisi =
                                basariliSiparisSayisi + basarisizSiparisSayisi;

                            if (basariliSiparisSayisi > 0)
                            {
                                ortalamaSiparisTutari =
                                    toplamSatisGeliri / basariliSiparisSayisi;
                            }

                            if (toplamSiparisSayisi > 0)
                            {
                                siparisBasariOrani =
                                    (decimal)basariliSiparisSayisi /
                                    toplamSiparisSayisi * 100;
                            }

                            Console.WriteLine("\n===== SATIŞ RAPORU =====");
                            Console.WriteLine($"Toplam Satış Geliri: {toplamSatisGeliri:F2} TL");
                            Console.WriteLine($"Başarılı Sipariş: {basariliSiparisSayisi}");
                            Console.WriteLine($"Başarısız Sipariş: {basarisizSiparisSayisi}");
                            Console.WriteLine($"Satılan Ürün Adedi: {satilanToplamUrunAdedi}");
                            Console.WriteLine($"Ortalama Sipariş Tutarı: {ortalamaSiparisTutari:F2} TL");
                            Console.WriteLine($"En Yüksek Sipariş: {enYuksekSiparisTutari:F2} TL");
                            Console.WriteLine($"Sipariş Başarı Oranı: %{siparisBasariOrani:F2}");

                            break;

                        case 5:
                            Console.WriteLine("Çıkış yapılıyor. İyi günler!");
                            break;

                        default:
                            Console.WriteLine("Geçersiz menü seçimi!");
                            break;
                    }
                }
                while (sayi != 5);
            }
            else
            {
                Console.WriteLine("Giriş hakkınız tükendi.");
            }
        }
    }
}
