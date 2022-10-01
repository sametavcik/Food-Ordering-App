using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp23
{
    class Mahalle
    {
        public string mahalleAdi;  //  mahalle adının tutulduğu değişken
        public int teslimatSayisi;  // teslimat sayısının tutulduğu değişken
        public ArrayList siparislerListesi;  

        public Mahalle(string mahalleAdi, int teslimatSayisi)  // parametre olarak mahalle adı ve teslimat sayısını alan constuructor
        {
            this.mahalleAdi = mahalleAdi;  // mahalle adının atanması 
            this.teslimatSayisi = teslimatSayisi;  // teslimat sayısının atanması
            siparislerListesi = new ArrayList();  // siparişler Listesinin oluşturulması
            listeOlustur(teslimatSayisi, siparislerListesi);  // sipariş listesi oluşturup arrayliste atan metod
        }

        public override string ToString()  // mahallenin içeriğini yazdıran metod
        {
            return "Mahalle Adı = " + this.mahalleAdi + " *** " + "Teslimat Sayısı = " + this.teslimatSayisi;
        }

        public void listeOlustur(int teslimatSayisi,ArrayList siparislerListesi)  // siparişler listesi oluşturup arrayliste atan metod
        {
            for(int i = 0; i < teslimatSayisi; i++)
            {
                List<YemekSınıfı> siparisBilgileri = new List<YemekSınıfı>();  // yemek sınıfı nesnelerinden oluşan listenin oluşturulması
                siparislerListesi.Add(siparisBilgileri);  // arrayliste eklenmesi

            }

        }



    }
}
