using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary_Search_Tree_Final
{
    class Program
    {
        static void Main(string[] args)
        {


            BinarySearchTree Tree1 = new BinarySearchTree();

            Tree1.InserIntoTree(10);
            Tree1.InserIntoTree(5);
            Tree1.InserIntoTree(15);
            Tree1.InserIntoTree(20);
            Tree1.InserIntoTree(6);
            Tree1.InserIntoTree(40);
            Tree1.InserIntoTree(2);

            Console.WriteLine("--------------Preorder-----------------");
            Tree1.PreOrder();

            Console.WriteLine("--------------INORDER-----------------");
            Tree1.Inorder();

            Console.WriteLine("--------------CountNodes-----------------");
            Console.WriteLine(Tree1.CountNodes());

            Console.WriteLine("--------------CountLeaves-----------------");
            Console.WriteLine(Tree1.CountLeaves());
            Console.ReadLine();
        }
    }
}
