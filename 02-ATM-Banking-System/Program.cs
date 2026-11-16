using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace atmapplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string kullaniciAdi = "Emre";
            int pinKodu = 1234;
            decimal mevcutBakiye = 15000;
            decimal günlükParaCekmeLimiti = 5000;
            decimal transferKomisyonOrani = 2m / 100m;

            Console.WriteLine("===== ATM BANKAMATİK SİSTEMİ =====");
            Console.WriteLine("Lütfen PIN kodu giriniz: ");
            int kullaniciPinGirisi = int.Parse(Console.ReadLine());

            if (pinKodu == kullaniciPinGirisi)
            {
                Console.WriteLine("Giriş Başarılı!");
                Console.WriteLine("Hoş geldiniz, Emre.");
                Console.WriteLine("===== ATM ANA MENÜ =====\n1.Bakiye Sorgulama\n2-Para Yatırma\n3-Para Çekme\n4-Para Transferi\n5-Çıkış");
                Console.WriteLine("Lütfen yapmak istediğiniz işlemi temsil eden sayıyı giriniz.");
                int sayi = int.Parse(Console.ReadLine());

                switch (sayi)
                {
                    case 1:
                        Console.WriteLine($"Hesap Sahibi: {kullaniciAdi}\nMevcut Bakiye: {mevcutBakiye:F2}");
                        break;
                    case 2:
                        Console.WriteLine("Yatıracağınız tutarı giriniz: ");
                        decimal yatirilacakTutar = decimal.Parse(Console.ReadLine());
                        if (yatirilacakTutar > 0)
                        {
                            mevcutBakiye += yatirilacakTutar;
                            Console.WriteLine($"Güncel Bakiyeniz: {mevcutBakiye:F2}");
                        }
                        else
                        {
                            Console.WriteLine("Geçerli bir bakiye girin.");
                        }
                        break;
                    case 3:
                        Console.WriteLine("Çekeceğiniz tutarı giriniz: ");
                        decimal cekilecekTutar = decimal.Parse(Console.ReadLine());
                        if (cekilecekTutar > 0 && cekilecekTutar <= günlükParaCekmeLimiti && cekilecekTutar <= mevcutBakiye)
                        {
                            mevcutBakiye -= cekilecekTutar;
                            Console.WriteLine($"Güncel Bakiyeniz: {mevcutBakiye:F2}");
                        }
                        else
                        {
                            Console.WriteLine("Geçerli bir bakiye girin.");
                        }
                        break;
                    case 4:
                        Console.WriteLine("Transfer edeceğiniz tutarı giriniz: ");
                        decimal transferTutari = decimal.Parse(Console.ReadLine());
                        decimal komisyonTutari = transferTutari * transferKomisyonOrani;
                        decimal toplamKesinti = transferTutari + komisyonTutari;

                        if (transferTutari > 0 && toplamKesinti <= mevcutBakiye)
                        {
                            mevcutBakiye -= toplamKesinti;
                            Console.WriteLine($"Mevcut Bakiye: {mevcutBakiye:F2}");
                        }
                        else
                        {
                            Console.WriteLine("Lütfen geçerli bir tutar giriniz.");
                        }
                        break;
                    case 5:
                        Console.WriteLine("Çıkış Yapılıyor..");
                        break;
                    default:
                        Console.WriteLine("Geçersiz seçim.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("PIN kodunu hatalı girdiniz!");
            }
        }
    }
}
