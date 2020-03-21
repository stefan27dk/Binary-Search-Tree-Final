using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary_Search_Tree_Final
{
        class BinaryNode
        {

        public BinaryNode LeftNode { get; set; }

        public BinaryNode RightNode { get; set; }

        public int Data { get; set; }


        public BinaryNode(int data)
        {
            Data = data;
        }



        //----------------INSERT NODE----------::START::-----------------------------------------------------------------------------------

        public void InsertNode(int InsertedData)
        {

            if (InsertedData < Data)
            {
                if(LeftNode == null)
                {
                    LeftNode = new BinaryNode(InsertedData);//Crates Node when it finds the correct place
                }
                else
                {
                    //Looping - Rekrusion 
                    LeftNode.InsertNode(InsertedData);//Traverse through all nodes till it finds the last node and make the inserted node child
                    //Searching for the coorect place of the Node and when it finds it "Creates the Node - Its the If LeftNode = null"
                }

            }

            else if(InsertedData > Data)//If its bigger than the Data "RIGHT"
            {

                if(RightNode == null)
                {
                    RightNode = new BinaryNode(InsertedData);
                }
                else
                {
                    RightNode.InsertNode(InsertedData);
                }

            }
         
        }

        //----------------INSERT NODE----------::END::-----------------------------------------------------------------------------------



    }




    class BinarySearchTree
    {
        public BinaryNode Root;


        //----------------INSERT INTO TREE----------::START::-----------------------------------------------------------------------------------
        public void InserIntoTree(int DataForInserting)
        {
         

            if(Root == null)
            {

             Root = new BinaryNode(DataForInserting);

            }

            else
            {
                Root.InsertNode(DataForInserting);
            }

        }
        //----------------INSERT INTO TREE----------::END::-----------------------------------------------------------------------------------




        //----------------Traverse--Tree--Display---All--Nodes---PREORDER---::START::-----------------------------------------------------------------

            public void PreOrder()
            {
            PreOrderTraversal(Root);
            }



        private void PreOrderTraversal(BinaryNode Node)
        {
            if(Node != null)
            {
                Console.WriteLine(Node.Data); 

                PreOrderTraversal(Node.LeftNode);
                PreOrderTraversal(Node.RightNode);
            }
        }

        //----------------Traverse--Tree--Display---All--Nodes----PREORDER----::END::-----------------------------------------------------------------




        //----------------Traverse--Tree--Display---All--Nodes----INORDER----::START::-----------------------------------------------------------------

            public void Inorder()
            {

            InorderTraversal(Root);
            
            }


        private void InorderTraversal(BinaryNode Node)
        {
            if(Node !=null)
            {
                InorderTraversal(Node.LeftNode);
                Console.WriteLine(Node.Data);
                InorderTraversal(Node.RightNode);
            }
        }


        //----------------Traverse--Tree--Display---All--Nodes----INORDER----::END::-----------------------------------------------------------------





        //----------------CountNodes----::START::----------------------------------------------------------------------------------------------

        public int CountNodes()
        {
           return NodeCounter(Root);
             
        }


        private int NodeCounter(BinaryNode Node)
        {
     
            int count = 1;

            if (Node.LeftNode != null)
            {
                count += NodeCounter(Node.LeftNode);
            }

            if(Node.RightNode != null)
            {
                count += NodeCounter(Node.RightNode);
            }
            return count;
        }


        //----------------CountNodes----::END::----------------------------------------------------------------------------------------------



        //----------------CountLeaves----::START::----------------------------------------------------------------------------------------------

        public int CountLeaves()
        {
            return LeaveCounter(Root);
        }


        private int LeaveCounter(BinaryNode Node)
        {
            int count = 0;

            if(Node.LeftNode == null & Node.RightNode == null)
            {
                count++;
                //Console.WriteLine(Node.Data);
            }
            else
            {
                if(Node.LeftNode != null)
                {
                    count += LeaveCounter(Node.LeftNode);
                }

                if(Node.RightNode != null)
                {
                    count += LeaveCounter(Node.RightNode);
                }
            }

            return count;
        }

        //----------------CountLeaves----::END::----------------------------------------------------------------------------------------------



        //----------------CountHeight----::Start::----------------------------------------------------------------------------------------------

        // public int CountHeight()
        // {
         



        // }



        //----------------CountHeight----::END::----------------------------------------------------------------------------------------------

        //--Delete Node
        //--Insert into node

    }
}
