using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Huseyin_Gurkan_CAKIR_FinalProjesi_2
{
    public partial class Form1 : Form
    {
        private MyTree tree = new MyTree();
        public Form1()
        {
            InitializeComponent();
        }

        private void ekle_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int Root))
            {
                tree.root1 = tree.Insert(tree.root1, Root);
                textBox1.Clear();
                label1.Visible = true;
            }
            else
            {
                MessageBox.Show("Lütfen geçerli bir sayı girin.");
            }
        }

        private void sil_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox2.Text, out int Root))
            {
                tree.root1 = tree.TreeDelete(tree.root1, Root);
                textBox2.Clear();
                label2.Visible = true;
            }
            else
            { 
                MessageBox.Show("Lütfen geçerli bir sayı girin.");
            }
        }

        private void bul_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox3.Text, out int Root))
            {
                int height = tree.RootHeight(tree.root1) + 1;
                MessageBox.Show($"Düğüm: {Root} düzeyi: {height}");
                textBox3.Clear();
            }
            else
            {
                MessageBox.Show("Lütfen geçerli bir sayı girin.");
            }
        }

        private void bilgi_Click(object sender, EventArgs e)
        {
            List<int> preorderList = tree.PreOrder(tree.root1);
            textBox4.Text = string.Join(", ", preorderList);
            List<int> inorderList = tree.InOrder(tree.root1);
            textBox5.Text = string.Join(", ", inorderList);
            List<int> postorderList = tree.PostOrder(tree.root1);
            textBox6.Text = string.Join(", ", postorderList);

            textBox7.Text = tree.RootSize(tree.root1).ToString();
            textBox8.Text = tree.RootHeight(tree.root1).ToString();
            textBox9.Text = tree.LeafCount(tree.root1).ToString();
        }

        private void dugum_Click(object sender, EventArgs e)
        {
            //treeView1.Nodes.Clear();
            //List<string> treenode = new List<string>();
            //tree.TreeNODE(treenode, tree.root1);
            //foreach (string noder in treenode)
            //{
            //    treeView1.Nodes.Add(noder);
            //}

            textBox10.Clear();
            tree.PrintTree(tree.root1, 0, textBox10);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Visible = false;
            label2.Visible = false;
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            label1.Visible = false;
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            label2.Visible = false;
        }
    }
}
