using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Huseyin_Gurkan_CAKIR_FinalProjesi_2
{
    class Tree
    {
        public int root;
        public Tree Left;
        public Tree Right;

        public Tree(int root)
        {
            this.root = root;
            Left = null;
            Right = null;
        }
    }

    class MyTree
    {
        public Tree root1;
        public MyTree()
        {
            root1 = null;
        }

        public Tree NewRoot(int root)
        {
            root1 = new Tree(root);
            return root1;
        }
        public Tree Insert(Tree root1, int root)
        {

            if (root1 != null)
            {
                if (root < root1.root)
                {
                   root1.Left = Insert(root1.Left, root);
                }
                else if (root > root1.root)
                {
                    root1.Right = Insert(root1.Right, root);
                }
                else
                {
                   System.Windows.Forms.MessageBox.Show($"Değer {root} zaten mevcut. Tekrar eklenmedi.");
                }
            }
            else
            {
                root1 = NewRoot(root);
            }
            return root1;
        }

        public Tree TreeDelete(Tree root1, int value)
        {
            if (root1 == null)
            {
                System.Windows.Forms.MessageBox.Show($"Silinmek istenen değer {value} bulunamadı.");
                return root1;
            }
            if (value < root1.root)
            {
                root1.Left = TreeDelete(root1.Left, value);
            }
            else if (value > root1.root)
            {
                root1.Right = TreeDelete(root1.Right, value);
            }
            else
            {
                if (root1.Left == null)
                {
                    return root1.Right;
                }
                if (root1.Right == null)
                {
                    return root1.Left;
                }
                root1.root = MinValue(root1.Right);
                root1.Right = TreeDelete(root1.Right, root1.root);
            }
            return root1;
        }

        private int MinValue(Tree root)
        {
            int minValue = root.root;
            while (root.Left != null)
            {
                minValue = root.Left.root;
                root = root.Left;
            }
            return minValue;
        }

        public int TreeSearch(Tree node, int value, int level)
        {
            if (node == null)
            {
                return -1;
            }

            if (node.root == value)
            {
                return level;
            }
            int leftLevel = TreeSearch(node.Left, value, level + 1);
            if (leftLevel != -1)
            {
                return leftLevel;
            }
            return TreeSearch(node.Right, value, level + 1);
        }

        public List<int> PreOrder(Tree root)
        {
            List<int> preor = new List<int>();
            if (root == null)
            {
                return preor;
            }
            preor.Add(root.root);
            preor.AddRange(PreOrder(root.Left));
            preor.AddRange(PreOrder(root.Right));

            return preor;
        }

        public List<int> InOrder(Tree root)
        {
            List<int> inor = new List<int>();
            if (root == null)
            {
                return inor;
            }
            inor.AddRange(InOrder(root.Left));
            inor.Add(root.root);
            inor.AddRange(InOrder(root.Right));

            return inor;
        }

        public List<int> PostOrder(Tree root)
        {
            List<int> postor = new List<int>();
            if (root == null)
            {
                return postor;
            }
            postor.AddRange(PostOrder(root.Left));
            postor.AddRange(PostOrder(root.Right));
            postor.Add(root.root);

            return postor;
        }

        public int RootSize(Tree root1)
        {
            if (root1 == null)
            {
                return 0;
            }
            else
            {
                return RootSize(root1.Left) + 1 + RootSize(root1.Right);
            }
        }

        public int RootHeight(Tree root1)
        {
            if (root1 == null)
            {
                return 0;
            }
            else
            {
                int l, r;
                l = RootHeight(root1.Left);
                r = RootHeight(root1.Right);

                if (l > r)
                {
                    return l + 1;
                }
                else
                {
                    return r + 1;
                }
            }
        }

        public int LeafCount(Tree root1)
        {
            if (root1 == null)
            {
                return 0;
            }
            if (root1.Left == null && root1.Right == null)
            {
                return 1;
            }
            return LeafCount(root1.Left) + LeafCount(root1.Right);
        }

        public void PrintTree(Tree node, int level, int indent, TextBox textBox)
        {
            if (node != null)
            {
                PrintTree(node.Right, level + 1, indent + 4, textBox);
                string nodeRepresentation = new string(' ', indent) + node.root;
                if (textBox.Lines.Length > 0 && !textBox.Lines.Last().EndsWith(Environment.NewLine))
                {
                    textBox.AppendText(Environment.NewLine);
                }
                textBox.AppendText(nodeRepresentation);
                textBox.AppendText("    ");
                PrintTree(node.Left, level + 1, indent + 4, textBox);
            }
        }
    }
}
