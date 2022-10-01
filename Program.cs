using System;
using System.Collections.Generic;

namespace ConsoleApp23
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] mahalleler = { "Evka 3", "Özkanlar", "Atatürk", "Erzene", "Kazımdirik" };   // mahalle stringi

            Random r = new Random();  // random değişkeni
            Tree agac = new Tree();   // agacın oluşturulması
            agacOlustur(mahalleler, r, agac);   // agacın doldurulması
            agac.AgacYazdir(agac.getRoot());   // agacın yazdırılması
            Console.WriteLine("Agacın derinliği = {0}", agac.maxDüzey);   // agacın derinliğinin yazdırılması
            Console.WriteLine();
            agac.elemanYazdir(agac, "Atatürk");   // ismi verilen mahallenin bilgilerinin yazdırılması
            agac.SiparisSayisiBul(agac.getRoot(), "pilav");   // ismi verilen ürünün kaç adet sipariş verildiğinin bulunması
            Console.WriteLine();
            Console.WriteLine("Toplam siparis edilen pilav sayısı = {0}",agac.siparisSayisi);  
            Console.WriteLine();
            Console.WriteLine("*********Pilavın güncellenmiş fiyatıyla yeni liste*********");
            agac.elemanYazdir(agac, "Atatürk");   // ismi verilen mahallenin yazdırılması
        }

        public static void agacOlustur(string[] mahalleler,Random r,Tree agac)  // agac olusturan metod
        {
            string[] yemekler = { "iskender", "pilav", "dürüm", "türlü", "kokoreç" };  // rastgele yemek isimlerinin tutulduğu dizi
            int[] fiyatlar = { 20, 10, 10, 5, 15 };  // birim fiyatları

            for(int i = 0; i < mahalleler.Length; i++)   
            {
                Mahalle temp = new Mahalle(mahalleler[i], r.Next(5, 10));   // mahalle sınıfının oluşturulması
                for(int j = 0; j < temp.siparislerListesi.Count; j++)   
                {
                    List<YemekSınıfı> b = (List<YemekSınıfı>)temp.siparislerListesi[j]; ;  // mahallenin içindeki yemeksınıfı nesnelerini tutan listenin arraylistten çıkarılması
                    
                    for (int a = 0; a < r.Next(3, 6); a++)
                    {
                        int index = r.Next(0, yemekler.Length);  // bir yemek seçilmesi
                        YemekSınıfı yemek = new YemekSınıfı(yemekler[index], r.Next(1, 8), fiyatlar[index]);  // yemekSınıfı nesnesinin oluşturulması
                        b.Add(yemek);  // ilgili diziye nesnenin atılması

                    }
                }
                agac.insert(temp);  // olusturulan mahallenin agaca eklenmesi
            }

        }





    }
}
