using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp23
{
    class TreeNode
    {
        public Mahalle data;  // mahalle nesnesi
        public TreeNode leftChild;  // sol çocuğu
        public TreeNode rightChild; // sağ çocuğu
        public void displayNode() { Console.Write(" " + data + " "); }
    }
}
