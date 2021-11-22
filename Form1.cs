using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataControls
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                // TODO: This line of code loads data into the 'dbDataSet.tbCountry' table. You can move, or remove it, as needed.
                this.tbCountryTableAdapter.Fill(this.dbDataSet.tbCountry);
                // TODO: This line of code loads data into the 'dbDataSet.tbTeacher' table. You can move, or remove it, as needed.
                this.tbTeacherTableAdapter.Fill(this.dbDataSet.tbTeacher);


            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void isActiveCheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            tbTeacherBindingSource.MoveFirst();
        }

        private void btnPevious_Click(object sender, EventArgs e)
        {
            tbTeacherBindingSource.MovePrevious();

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            tbTeacherBindingSource.MoveNext();
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            tbTeacherBindingSource.MoveLast();
        }
        private void EnableDisableButtons()
        {
            //enable and disable navigation buttons
            if (tbTeacherBindingSource.Position == 0)
            {
                btnFirst.Enabled = false;
                btnPrevious.Enabled = false;
            }
            else
            {
                btnFirst.Enabled = true;
                btnPrevious.Enabled = true;
            }

            if (tbTeacherBindingSource.Position == tbTeacherBindingSource.Count - 1)
            {
                btnLast.Enabled = false;
                btnNext.Enabled = false;
            }
            else
            {
                btnLast.Enabled = true;
                btnNext.Enabled = true;
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (tbTeacherBindingSource.Count > 0)
            {
                if (MessageBox.Show("Sure? " , "Delete" , 
                    MessageBoxButtons.YesNo ) == DialogResult.Yes)
                {
                    tbTeacherBindingSource.RemoveCurrent();
                }
            }
                
            else
                MessageBox.Show("Nothing to delete");
        }

        private void tbTeacherBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            EnableDisableButtons();
        }

        private void tbTeacherBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            SaveData();


        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            SaveData();
        }

        private void SaveData()
        {
            if (this.Validate());
            {
                this.tbTeacherBindingSource.EndEdit();
                try
                {
                    this.tableAdapterManager.UpdateAll(this.dbDataSet);
                    MessageBox.Show("Saved");
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
          
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Validate())
            {
                this.tbTeacherBindingSource.EndEdit();
                if (dbDataSet.HasChanges())
                {
                    if (MessageBox.Show("Save?", "Exit", MessageBoxButtons.YesNo)
                        == DialogResult.Yes)
                    {
                        SaveData();
                    }
                }
            }
            else
                e.Cancel = true;
        }
    }
}
