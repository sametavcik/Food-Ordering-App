using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp23
{
    class YemekSınıfı
    {
        public string yemekAdi;  // yemek adının tutulduğu değişken
        public int yemekAdedi;  // yemeğin adedinin tutulduğu değişken
        public  double birimFiyati;
        public YemekSınıfı(string yemekAdi, int yemekAdedi,int birimFiyati)  // parametre olarak yemek adı ve yemek adedini alan constuructor
        {
            this.yemekAdi = yemekAdi;  // yemek adının atanması
            this.yemekAdedi = yemekAdedi;  // yemek adedinin atanması
            this.birimFiyati = birimFiyati;

        }


        public override string ToString()  // nesnenin bilgilerini yazdıran metod
        {
            return "Yemek Adı = " + this.yemekAdi + " ** " + "Yemek Adedi =" + " " + this.yemekAdedi + " ** " + this.birimFiyati;
        }
    }
}
