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
        public static BinaryNode Root;
        public BinaryNode CurrentNode = Root;

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

            public int CountHeight()
            {
              return CounterHeight(Root);
            }


        private int CounterHeight(BinaryNode Node)
        {

            if(Node == null)
            {
                return 0;
            }
            else
            {

            int CounterLeft = CounterHeight(Node.LeftNode);
            int CounterRight = CounterHeight(Node.RightNode);
            
            
                if(CounterLeft > CounterRight)
                {
                    return(CounterLeft + 1);
                }
                else
                {
                    return(CounterRight +1);
                }


            }

        }



        //----------------CountHeight----::END::----------------------------------------------------------------------------------------------


        //----------------RemoveNode----::Start::----------------------------------------------------------------------------------------------

        public void RemoveNode(int DataForRemove)
        {
            BinaryNode Parrent = null;// Parent Node for each Iteration

            Looking(Root, Parrent, DataForRemove);
        }


        private void Looking(BinaryNode CurrentNode, BinaryNode Parrent, int DataForRemove)
        {



             if(CurrentNode.LeftNode != null && CurrentNode.RightNode != null && CurrentNode.Data == DataForRemove)//---If Node for delete is with 2 childs
             {
                DeleteNodeWithTwoChilds(CurrentNode, Parrent);//Delete Node with 2 childs Metheod
             }





            else if(CurrentNode.LeftNode == null && CurrentNode.RightNode == null && CurrentNode.Data == DataForRemove)//---If Node for delete is Lief "If-Lief"
            {
                DeleteLief(CurrentNode, Parrent);//Delete Lief
            }


            else if( (CurrentNode.LeftNode == null || CurrentNode.RightNode == null) && CurrentNode.Data == DataForRemove)//---If Node for delete is Node with 1 child
            {
                DeleteNodeWithOneChild(CurrentNode, Parrent);//Delete Node with 1 Child Method
            }


            else if(Parrent == null && CurrentNode.Data == DataForRemove)//---If Node for delete is Root
            {
                DeletingRoot(CurrentNode, Parrent);//Delete Root Method
            }


           

            else if(CurrentNode.Data > DataForRemove && CurrentNode.LeftNode != null )//Left Traverse
            {
                Parrent = CurrentNode; //Make Parrent = Current Node "Before you traverse so you allways know the previeous Node"
                Looking(CurrentNode.LeftNode, Parrent, DataForRemove);
            }

            else if (CurrentNode.Data < DataForRemove && CurrentNode.RightNode != null)//Right Traverse
            {
                Parrent = CurrentNode; //Make Parrent = Current Node "Before you traverse so you allways know the previeous Node"
                Looking(CurrentNode.RightNode, Parrent, DataForRemove);
            }

          
            else 
            {
                Console.WriteLine("No Such Value For Deleting");
            }


        }


        //-------DELETING-LIEF---::START::-------------------------------
        private void DeleteLief(BinaryNode NodeForDelete, BinaryNode Parrent)
        {
            if(Parrent.LeftNode.Data == NodeForDelete.Data)//--If Left Leaf of Parrent
            {
                Parrent.LeftNode = null;
            }
            else//---If right Leaf of Parrent
            {
                Parrent.RightNode = null;
            }
        }
        //-------DELETING-LIEF---::END::-------------------------------
        
            


        //-------DELETING-Node-With 1 Child---::START::-------------------------------
        private void DeleteNodeWithOneChild(BinaryNode NodeForDelete, BinaryNode Parrent)
        {

            if(NodeForDelete.LeftNode != null)
            {

                if(Parrent.RightNode.Data == NodeForDelete.Data)
                {
                    Parrent.RightNode = NodeForDelete.LeftNode;
                }
                else
                {
                    Parrent.LeftNode = NodeForDelete.LeftNode;
                }

            }


            else
            {

                if (Parrent.RightNode.Data == NodeForDelete.Data)
                {
                    Parrent.RightNode = NodeForDelete.RightNode;
                }
                else
                {
                    Parrent.LeftNode = NodeForDelete.RightNode;
                }

            }

        }
        //-------DELETING-Node-With 1 Child---::END::-------------------------------



        //-------DELETING-Node-With 2 Childs---::START::-------------------------------
        private void DeleteNodeWithTwoChilds(BinaryNode NodeForDelete, BinaryNode Parrent)
        {
            BinaryNode Helper = CurrentNode.LeftNode;

            while (Helper.RightNode != null)
            {
                Helper = Helper.RightNode;
            }

            CurrentNode = Helper.RightNode;xsads
        }
        //-------DELETING-Node-With 1 Childs---::END::-------------------------------




       //-------DELETING-Root---::START::-------------------------------
        private void DeletingRoot(BinaryNode NodeForDelete, BinaryNode Parrent)
        {
            if(Root.LeftNode == null)//---If Root Lef Sub Tree is Null
            {
                Root = Root.RightNode;
            }
            else if(Root.RightNode == null)//---If Root Right Sub Tree is Null
            {
                Root = Root.LeftNode;
            }

            else if(Root.LeftNode != null && Root.RightNode != null)//---If Both Right and Left Subtrees are Not Null
            {
                BinaryNode Helper = Root.RightNode;//--Helper

                while (Helper.LeftNode != null)
                {
                    Helper = Helper.LeftNode;//--Finding the smallest Value in the Right Sub Tree so we can insert the Left Sub Tree after it 
                }

                               
                Helper.LeftNode = Root.LeftNode;
                Root = Root.RightNode;
            }
        }


        //-------DELETING-Root---::End::-------------------------------






        //----------------RemoveNode----::END::----------------------------------------------------------------------------------------------




        //--Delete Node


    }
}







//          //----------------------If--Deleting-ROOT---------------------------

//            if(NodeForDelete.Data == DataForRemove && NodeForDelete.Data == Root.Data)//---Check if DataForRemove is = Root.Data
//            {
//                if(Root.RightNode.LeftNode==null)//If Root Right child Left child is null insert the Roots Left Child directly
//                {
//                    Root.RightNode.LeftNode = Root.LeftNode;
//                    Root = Root.RightNode;//New root = Root Right
//                }
//                else if(Root.LeftNode != null)//If Root Left Child is not Null Traverse in Roots Right Childs Left Child and insert Roots Left Child with all childrens
//                {
//                    FindLastRootDel(Root.RightNode.LeftNode, Root.LeftNode);
//Root = Root.RightNode;//New root = Root Right
//                }
//                else
//                {
//                    Root = Root.RightNode;//New root = Root Right
//                }

//            }
//            else if (NodeForDelete.Data == DataForRemove)//If data is the same value of the selected node than remove it
//            {

//                if (CurrentNode.Data > DataForRemove)
//                {
//                    if(NodeForDelete.RightNode!=null)
//                    {
//                    CurrentNode.LeftNode = NodeForDelete.RightNode;//Make the cuurent Node right = Deleting node Child
//                        FindLast(NodeForDelete.RightNode, NodeForDelete.LeftNode);
//                    }
//                    else /*if(NodeForDelete.LeftNode!=null)*/
//                    {
//                        CurrentNode.LeftNode = NodeForDelete.LeftNode;
//                    }
//                }

//                else if (CurrentNode.Data<DataForRemove)
//                {
//                    if (NodeForDelete.RightNode != null)
//                    {
//                        CurrentNode.RightNode = NodeForDelete.RightNode; 
//                        FindLast(NodeForDelete.RightNode, NodeForDelete.LeftNode);
//                    }
//                    else
//                    {
//                      CurrentNode.RightNode = NodeForDelete.LeftNode;
//                    }
//                }
//            }

//            else
//            {

//                if (NodeForDelete.Data > DataForRemove)//If Data is samller look left
//                {
//                    CurrentNode = NodeForDelete;//Remeber the Last Node
//                    Looking(NodeForDelete.LeftNode, DataForRemove);
//                }

//                else if (NodeForDelete.Data<DataForRemove)//If its bigger look right
//                {
//                    CurrentNode = NodeForDelete;//Remeber the Last Node
//                    Looking(NodeForDelete.RightNode, DataForRemove);

//                }
//            }

//        }





//        private void FindLast(BinaryNode DeletingNodeRight, BinaryNode DeletingNodeLeft)//Find Last Node Of The deleting right Node in DeletingRight.Left
//{


//    if (DeletingNodeRight.LeftNode != null)
//    {
//        FindLast(DeletingNodeRight.RightNode.LeftNode, DeletingNodeLeft);//Traverse to find the last Node in Left of the Right Node of the Deleting Node
//    }
//    else
//    {
//        DeletingNodeRight.LeftNode = DeletingNodeLeft;//Assign when you find last Node Null
//    }


//}


//private void FindLastRootDel(BinaryNode NewRootLeft, BinaryNode OldRootLeft)//Find Last Node Of The deleting right Node in DeletingRight.Left
//{

//    if (NewRootLeft.LeftNode != null)
//    {
//        FindLast(NewRootLeft.LeftNode, OldRootLeft);//Traverse to find the last Node in Left of the Right Node of the Deleting Node
//    }
//    else
//    {
//        NewRootLeft.LeftNode = OldRootLeft;//Assign when you find last Node Null
//    }

//}
////----------------RemoveNode----::END::----------------------------------------------------------------------------------------------
