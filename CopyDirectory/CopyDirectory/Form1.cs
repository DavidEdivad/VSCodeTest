using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CopyDirectory
{
    public partial class Form1 : Form
    {
        public CD cd = null;
        
        public Form1()
        {
            InitializeComponent();

            cd = new CD();
            cd.OnCopyItemReached += new CD.dgEventRaiser(a_AddtToListBox);            
        }
                
        private void btnCopy_Click(object sender, EventArgs e)
        {
            if ((txtSource.Text != string.Empty) && (txtDestination.Text != string.Empty))
            {
                try
                {
                    cd.CopyDirectory(txtSource.Text, txtDestination.Text);

                    MessageBox.Show("I have done!");
                }
                catch (Exception Ex)
                {
                    Console.Error.WriteLine(Ex.Message);
                }

            }
            else
            {
                MessageBox.Show("No input");
            }
        }


        public void a_AddtToListBox(string item)
        {
            this.listBox1.Items.Add(item);
            this.listBox1.Refresh();

           
        }

    }

}

