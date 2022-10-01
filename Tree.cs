using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp23
{
    class Tree
    {
        private TreeNode root;   // ağacın kökü
        public int düzey = -1 ;  // nodun düzeyi
        public int maxDüzey;  // ağacın maximum derinliği
        public int siparisSayisi;  // adı verilen yemeğin kaç defa sipariş edildiği bilgisini tutan değğişken
        public Tree() { root = null; }  // cons

        public TreeNode getRoot()  // agacın kökünü döndüren metod
        { return root; }

        public void insert(Mahalle newdata)   // ağaca alfabetik sıraya göre eleman ekleyen metod
        { 
            TreeNode newNode = new TreeNode();  // node oluşturulması
            newNode.data = newdata;  // nodun gelen noda eşitlenmesi
            if (root == null) // ağacın doluluk kontrolü
                root = newNode;
            else // ağaç boş değilse elemanın eklenmesi
            {
                TreeNode current = root;  
                TreeNode parent;
                while (true)
                {
                    parent = current;
                    if (string.Compare(newdata.mahalleAdi, current.data.mahalleAdi) == -1)  // ad karşılaştırılması
                    {
                        current = current.leftChild;
                        if (current == null)
                        {
                            parent.leftChild = newNode;
                            return;
                        }
                    }
                    else
                    {
                        current = current.rightChild;
                        if (current == null)
                        {
                            parent.rightChild = newNode;
                            return;
                        }
                    }
                } 
            } 
        }

        public void AgacYazdir(TreeNode etkin)   // agacı inorder yazdıran ve ağacın derinliğini bulduran metod
        {
            if (etkin != null)  // nodun doluluk kontrolü
            {
                düzey = düzey + 1;  // nodun düzeyinin arttırılması
                AgacYazdir(etkin.leftChild);  // sol çocuğuna recursive şekilde inilmesi
                Console.WriteLine("**************************************************************************************************");
                Console.WriteLine(etkin.data);  // mahalle bilgilerinin yazdırılması
                Console.WriteLine();
                foreach(List<YemekSınıfı> a in etkin.data.siparislerListesi)
                {
                    Console.WriteLine("**** elemanın siparisleri ****");
  
                    foreach(YemekSınıfı y in a)
                    {
                        Console.WriteLine(y);
                    }
                    Console.WriteLine();
                }

                AgacYazdir(etkin.rightChild); // sağ çocuğun recursive dolaşılması
                if(düzey > maxDüzey)  // nodun düzeyinin maxlık kontrolü
                {
                    maxDüzey = düzey;
                }
                düzey = düzey - 1;  // düzeyin azaltılması
            }
        }

        public void elemanYazdir(Tree agac,string aranan)  //ismi verilen mahallenin siparişler toplamı 150tl ve üzeri ise bilgilerini yazdıran metod
        {
            
            TreeNode temp = agac.find(aranan);  // aranan mahalleyi bulan metod
            if(temp == null)
            {
                Console.WriteLine("eleman bulunamadı");
            }
            Console.WriteLine("********** siparişler toplamı 150'tlden büyük mahalle bilgileri************");
            Console.WriteLine();
            Console.WriteLine("Mahalle adı ={0} ",aranan);
            

            foreach (List<YemekSınıfı> a in temp.data.siparislerListesi)  // mahallenin siparişlernin tek tek dolaşılması
                {
                double totalPara = 0;  // siparişlerin fiyatlarının toplamının tutulduğu değişken
                foreach (YemekSınıfı y in a)
                    {
                        totalPara += (y.birimFiyati * y.yemekAdedi);  // siparişlerin fiyatlarının bulunması ve ilgili değişkene eklenmesi
                    }
                    if (totalPara >= 150)
                    {
                    Console.WriteLine();
                    Console.WriteLine("*** müşteri bilgileri ***");
                    foreach (YemekSınıfı y in a)
                            {
                            
                            Console.WriteLine(y);
                            }
                    }

                }
            
          

        }

        public TreeNode find(string aranan)  // ismi verilen mahallenin bulunması
        {
            TreeNode etkin = root;
            while (etkin.data.mahalleAdi != aranan)
            {
                if (string.Compare(aranan, etkin.data.mahalleAdi) == -1)  // ad karşılaştırılması
                    etkin = etkin.leftChild;
                else
                    etkin = etkin.rightChild;
                if (etkin == null) return null;
            }
             return etkin;
            }

        public void SiparisSayisiBul(TreeNode etkin,string aranan)   // ismi verilen siparisin ağaçta kaç defa sipariş edildiğini bulan metod  
        {
            if (etkin != null)
            {
                SiparisSayisiBul(etkin.leftChild,aranan);  // sol çocuğu recursive dolaşmak
                foreach(List<YemekSınıfı> a in etkin.data.siparislerListesi)  // siparişlerin içinden aranan yemeğin bulunması ve birim fiyatının yuzde 10 düşürülmesi  
                {
                    foreach(YemekSınıfı y in a)
                    {
                        if (y.yemekAdi.Equals(aranan))
                        {
                            siparisSayisi += y.yemekAdedi;
                            y.birimFiyati -= y.birimFiyati * 10 / 100;
                        }
                    }
                }
                SiparisSayisiBul(etkin.rightChild,aranan);  // sağ çocuğu recursive dolaşmak
            }
        }











    }
        }
