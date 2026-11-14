using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dinamiksiparishesaplama
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lütfen ürünün adını girin: ");
            string urunAdi = Console.ReadLine();

            Console.WriteLine("Lütfen ürünün birim fiyatını girin: ");
            decimal birimFiyat = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Lütfen sipariş adedini girin: ");
            int siparisAdedi = int.Parse(Console.ReadLine());

            Console.WriteLine("İndirim oranını giriniz (Yüzde olarak):");
            decimal indirimOrani = decimal.Parse(Console.ReadLine());

            Console.WriteLine("KDV oranını giriniz (Yüzde olarak):");
            decimal kdvOrani = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Kargo ücretini giriniz:");
            decimal kargoUcreti = decimal.Parse(Console.ReadLine());

            decimal indirimsizÜrünToplamı = birimFiyat * siparisAdedi;
            decimal indirimTutarı = indirimsizÜrünToplamı * (indirimOrani / 100);
            decimal indirimliÜrünToplamı = indirimsizÜrünToplamı - indirimTutarı;
            decimal kdvTutarı = indirimliÜrünToplamı * (kdvOrani / 100);
            decimal toplamTutar = indirimliÜrünToplamı + kdvTutarı + kargoUcreti;
            decimal tekUrunSonFiyat = toplamTutar / siparisAdedi;

            Console.WriteLine($"Ürün Toplamı: {indirimsizÜrünToplamı}");
            Console.WriteLine($"İndirim Tutarı: {indirimTutarı}");
            Console.WriteLine($"İndirimli Ürün Toplamı: {indirimliÜrünToplamı}");
            Console.WriteLine($"KDV Tutarı: {kdvTutarı}");
            Console.WriteLine($"Genel Toplam: {toplamTutar}");
            Console.WriteLine($"Ürün Başına Maliyet: {tekUrunSonFiyat:F2}");

            Console.Read();

        }
    }
}
