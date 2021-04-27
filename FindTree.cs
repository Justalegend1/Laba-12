using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab12Var4
{
    public class FindTree
    {
        public class AVLTreeNode<TNode> : IComparable<TNode> where TNode : IComparable
        {
            AVLTree<TNode> _tree;

            AVLTreeNode<TNode> _left;  
            AVLTreeNode<TNode> _right;

            public static void ShowTree(Point<Organization> p, int l)
            {
                if (p != null)
                {
                    ShowTree(p.left, l + 7);
                    for (int i = 0; i < l; i++)
                        Console.Write(" ");
                    Console.WriteLine(p);
                    ShowTree(p.right, l + 7);
                }
            }
            #region Конструктор
            public AVLTreeNode(TNode value, AVLTreeNode<TNode> parent, AVLTree<TNode> tree)
            {
                Value = value;
                Parent = parent;
                _tree = tree;
            }
            #endregion

            #region Свойства 
            public AVLTreeNode<TNode> Left
            {
                get
                {
                    return _left;
                }

                internal set
                {
                    _left = value;

                    if (_left != null)
                    {
                        _left.Parent = this;  
                    }
                }
            }

            public AVLTreeNode<TNode> Right
            {
                get
                {
                    return _right;
                }

                internal set
                {
                    _right = value;

                    if (_right != null)
                    {
                        _right.Parent = this; 
                    }
                }
            }

            

            public AVLTreeNode<TNode> Parent
            {
                get;
                internal set;
            }

            

            public TNode Value
            {
                get;
                private set;
            }

            
            #endregion

            #region CompareTo
            public int CompareTo(TNode other)
            {
                return Value.CompareTo(other);
            }
            #endregion

            #region Balance

            internal void Balance()
            {
                if (State == TreeState.RightHeavy)
                {
                    if (Right != null && Right.BalanceFactor < 0)
                    {
                        LeftRightRotation();
                    }

                    else
                    {
                        LeftRotation();
                    }
                }
                else if (State == TreeState.LeftHeavy)
                {
                    if (Left != null && Left.BalanceFactor > 0)
                    {
                        RightLeftRotation();
                    }
                    else
                    {
                        RightRotation();
                    }
                }
            }
            private int MaxChildHeight(AVLTreeNode<TNode> node)
            {
                if (node != null)
                {
                    return 1 + Math.Max(MaxChildHeight(node.Left), MaxChildHeight(node.Right));
                }

                return 0;
            }

            private int LeftHeight
            {
                get
                {
                    return MaxChildHeight(Left);
                }
            }

            private int RightHeight
            {
                get
                {
                    return MaxChildHeight(Right);
                }
            }

            private TreeState State
            {
                get
                {
                    if (LeftHeight - RightHeight > 1)
                    {
                        return TreeState.LeftHeavy;
                    }

                    if (RightHeight - LeftHeight > 1)
                    {
                        return TreeState.RightHeavy;
                    }

                    return TreeState.Balanced;
                }
            }


            private int BalanceFactor
            {
                get
                {
                    return RightHeight - LeftHeight;
                }
            }

            enum TreeState
            {
                Balanced,
                LeftHeavy,
                RightHeavy,
            }

            #endregion

            #region LeftRotation

            private void LeftRotation()
            {

               

                
                AVLTreeNode<TNode> newRoot = Right;
                ReplaceRoot(newRoot);

                
                Right = newRoot.Left;
               
                newRoot.Left = this;
            }

            #endregion

            #region RightRotation

            private void RightRotation()
            {
                
                AVLTreeNode<TNode> newRoot = Left;
                ReplaceRoot(newRoot);

                
                Left = newRoot.Right;

                
                newRoot.Right = this;
            }

            #endregion

            #region LeftRightRotation

            private void LeftRightRotation()
            {
                Right.RightRotation();
                LeftRotation();
            }
            #endregion

            #region RightLeftRotation

            private void RightLeftRotation()
            {
                Left.LeftRotation();
                RightRotation();
            }
            #endregion

            #region Перемещение корня

            private void ReplaceRoot(AVLTreeNode<TNode> newRoot)
            {
                if (this.Parent != null)
                {
                    if (this.Parent.Left == this)
                    {
                        this.Parent.Left = newRoot;
                    }
                    else if (this.Parent.Right == this)
                    {
                        this.Parent.Right = newRoot;
                    }
                }
                else
                {
                    _tree.Head = newRoot;
                }

                newRoot.Parent = this.Parent;
                this.Parent = newRoot;
            }

            #endregion

        }



        public class AVLTree<T> : IEnumerable<T> where T : IComparable

        {
            

            public AVLTreeNode<T> Head
            {
                get;
                internal set;
            }

            #region Количество узлов дерева
            public int Count
            {
                get;
                private set;
            }
            #endregion

            #region Метод Add

           

            public void Add(T value)
            {
                
                if (Head == null)
                {
                    Head = new AVLTreeNode<T>(value, null, this);
                }

               

                else
                {
                    AddTo(Head, value);
                }

                Count++;
            }

            

            private void AddTo(AVLTreeNode<T> node, T value)
            {
                   

                if (value.CompareTo(node.Value) < 0)
                {
                    

                    if (node.Left == null)
                    {
                        node.Left = new AVLTreeNode<T>(value, node, this);
                    }

                    else
                    {
                       
                        AddTo(node.Left, value);
                    }
                }
               

                else
                {
                   
                    if (node.Right == null)
                    {
                        node.Right = new AVLTreeNode<T>(value, node, this);
                    }
                    else
                    {
                       
                        AddTo(node.Right, value);
                    }
                }
               
            }

            #endregion

            #region Метод Contains

            public bool Contains(T value)
            {
                return Find(value) != null;
            }

           

            private AVLTreeNode<T> Find(T value)
            {

                AVLTreeNode<T> current = Head; 

               
                while (current != null)
                {
                    int result = current.CompareTo(value); 

                    if (result > 0)
                    {
                       
                        current = current.Left;
                    }
                    else if (result < 0)
                    {
                       
                        current = current.Right;
                    }
                    else
                    {
                      
                        break;
                    }
                }
                return current;
            }


            #endregion

            #region Метод Remove

            public bool Remove(T value)
            {
                AVLTreeNode<T> current;
                current = Find(value); 

                if (current == null)
                {
                    return false;
                }

                AVLTreeNode<T> treeToBalance = current.Parent; 
                Count--;                                       

                

                if (current.Right == null) 
                {
                    if (current.Parent == null) 
                    {
                        Head = current.Left;    

                        if (Head != null)
                        {
                            Head.Parent = null; 
                        }
                    }
                    else 
                    {
                        int result = current.Parent.CompareTo(current.Value);

                        if (result > 0)
                        {
                            

                            current.Parent.Left = current.Left;
                        }
                        else if (result < 0)
                        {

                                      

                            current.Parent.Right = current.Left;
                        }
                    }
                }

               

                else if (current.Right.Left == null) 
                {
                    current.Right.Left = current.Left;

                    if (current.Parent == null)
                    {
                        Head = current.Right;

                        if (Head != null)
                        {
                            Head.Parent = null;
                        }
                    }
                    else
                    {
                        int result = current.Parent.CompareTo(current.Value);
                        if (result > 0)
                        {
                                  

                            current.Parent.Left = current.Right;
                        }

                        else if (result < 0)
                        {
                                  

                            current.Parent.Right = current.Right;
                        }
                    }
                }

              
                else
                {
                    

                    AVLTreeNode<T> leftmost = current.Right.Left;

                    while (leftmost.Left != null)
                    {
                        leftmost = leftmost.Left;
                    }

                   

                    leftmost.Parent.Left = leftmost.Right;

                   
                    leftmost.Left = current.Left;
                    leftmost.Right = current.Right;

                    if (current.Parent == null)
                    {
                        Head = leftmost;

                        if (Head != null)
                        {
                            Head.Parent = null;
                        }
                    }
                    else
                    {
                        int result = current.Parent.CompareTo(current.Value);

                        if (result > 0)
                        {
                                        

                            current.Parent.Left = leftmost;
                        }
                        else if (result < 0)
                        {
                             

                            current.Parent.Right = leftmost;
                        }
                    }
                }

                if (treeToBalance != null)
                {
                    treeToBalance.Balance();
                }

                else
                {
                    if (Head != null)
                    {
                        Head.Balance();
                    }
                }

                return true;

            }

            #endregion

            #region Метод Clear

            public void Clear()
            {
                Head = null; // удаление дерева
                Count = 0;
            }

            #endregion

            #region Итераторы

            public IEnumerator<T> InOrderTraversal()
            {

               

                if (Head != null) 
                {

                    Stack<AVLTreeNode<T>> stack = new Stack<AVLTreeNode<T>>();
                    AVLTreeNode<T> current = Head;

                   

                    bool goLeftNext = true;

                    
                    stack.Push(current);

                    while (stack.Count > 0)
                    {
                       
                        if (goLeftNext)
                        {
                            

                            while (current.Left != null)
                            {
                                stack.Push(current);
                                current = current.Left;
                            }
                        }

                        yield return current.Value;

                       

                        if (current.Right != null)
                        {
                            current = current.Right;

                           

                            goLeftNext = true;
                        }
                        else
                        {
                            

                            current = stack.Pop();
                            goLeftNext = false;
                        }
                    }
                }
            }

            public IEnumerator<T> GetEnumerator()
            {
                return InOrderTraversal();
            }

            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            {

                return GetEnumerator();

            }

            #endregion


        }
    }
}
