using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
            Tree1.InserIntoTree(41);
            Tree1.InserIntoTree(42);
            Tree1.InserIntoTree(3);
            Tree1.InserIntoTree(2);
            Tree1.InserIntoTree(60);
            Tree1.InserIntoTree(50);
            Tree1.InserIntoTree(100);
            Tree1.InserIntoTree(1);
            Tree1.InserIntoTree(36);
            Tree1.InserIntoTree(24);
            Tree1.InserIntoTree(26);
            Tree1.InserIntoTree(57);
            Tree1.InserIntoTree(14);
            Tree1.InserIntoTree(101);
            Tree1.InserIntoTree(16);
            Tree1.InserIntoTree(18);
            Tree1.InserIntoTree(75);
            Tree1.InserIntoTree(96);
            Tree1.InserIntoTree(38);
            Tree1.InserIntoTree(74);
            Tree1.InserIntoTree(33);
            Tree1.InserIntoTree(55);
            Tree1.InserIntoTree(22);
            Tree1.InserIntoTree(88);
            Tree1.InserIntoTree(27);
            Tree1.InserIntoTree(32);
            Tree1.InserIntoTree(39);
            Tree1.InserIntoTree(49);
            Tree1.InserIntoTree(94);
            Tree1.InserIntoTree(73);
            Tree1.InserIntoTree(63);

            Console.WriteLine("--------------Preorder-----------------");
            Tree1.PreOrder();

            Console.WriteLine("--------------INORDER-----------------");
            Tree1.Inorder();

            Console.WriteLine("--------------CountNodes-----------------");
            Console.WriteLine(Tree1.CountNodes());

            Console.WriteLine("--------------CountLeaves-----------------");
            Console.WriteLine(Tree1.CountLeaves());

            Console.WriteLine("--------------CountHeight-----------------");
            Console.WriteLine(Tree1.CountHeight());



            Console.WriteLine("------------Before--Delete-----------------");
            Tree1.Inorder();
            Console.WriteLine("--------------Delete-----------------");
            Tree1.RemoveNode(57);
            Tree1.Inorder();



           


            Console.ReadLine();
        }
    }
}
