using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace practica13.coll
{
    public partial class Form1 : Form
    {
        private DataGridViewColumn dataGridViewColumn1 = null;
        private DataGridViewColumn dataGridViewColumn2 = null;
        private DataGridViewColumn dataGridViewColumn3 = null;
        IList<Student> studentList = new List<Student>();
        public Form1()
        {
            InitializeComponent();
            initDataGridView();
        }
        private void initDataGridView()
        {
            dataGridView1.DataSource = null;
            dataGridView1.Columns.Add(getDataGridViewColumn1());
            dataGridView1.Columns.Add(getDataGridViewColumn2());
            dataGridView1.Columns.Add(getDataGridViewColumn3());
            dataGridView1.AutoResizeColumns();
        }
        private DataGridViewColumn getDataGridViewColumn1()
        {
            if (dataGridViewColumn1 == null)
            {
                dataGridViewColumn1 = new DataGridViewTextBoxColumn();
                dataGridViewColumn1.Name = "";
                dataGridViewColumn1.HeaderText = "Name";
                dataGridViewColumn1.ValueType = typeof(string);
                dataGridViewColumn1.Width = dataGridView1.Width / 3;
            }
            return dataGridViewColumn1;
        }
        private DataGridViewColumn getDataGridViewColumn2()
        {
            if (dataGridViewColumn2 == null)
            {
                dataGridViewColumn2 = new DataGridViewTextBoxColumn();
                dataGridViewColumn2.Name = "";
                dataGridViewColumn2.HeaderText = "Surname";
                dataGridViewColumn2.ValueType = typeof(string);
                dataGridViewColumn2.Width = dataGridView1.Width / 3;
            }
            return dataGridViewColumn2;
        }
        private DataGridViewColumn getDataGridViewColumn3()
        {
            if (dataGridViewColumn3 == null)
            {
                dataGridViewColumn3 = new DataGridViewTextBoxColumn();
                dataGridViewColumn3.Name = "";
                dataGridViewColumn3.HeaderText = "Book name";
                dataGridViewColumn3.ValueType = typeof(string);
                dataGridViewColumn3.Width = dataGridView1.Width / 3;
            }
            return dataGridViewColumn3;
        }
        private void addStudent(string name, string surname, int bookName)
        {
            Student S = new Student();
            S.Set(name, surname, bookName);
            studentList.Add(S);
            showListInGrid();
        }
        private void deleteStudent(int elementIndex)
        {
            studentList.RemoveAt(elementIndex);
            showListInGrid();
        }
        private void RemoveStudent(string name,string surname,int bookName ,int elementIndex)
        {
            Student s = new Student();
            s.Set(name,surname,bookName);
            studentList.RemoveAt(elementIndex);
            studentList.Insert(elementIndex,s);
            showListInGrid();
        }
        private void showListInGrid()
        {
            dataGridView1.Rows.Clear();
            foreach (Student s in studentList)
            {
                DataGridViewRow row = new DataGridViewRow();
                DataGridViewTextBoxCell cell1 = new DataGridViewTextBoxCell();
                DataGridViewTextBoxCell cell2 = new DataGridViewTextBoxCell();
                DataGridViewTextBoxCell cell3 = new DataGridViewTextBoxCell();
                cell1.ValueType = typeof(string);
                cell1.Value = s.getName();
                cell2.ValueType = typeof(string);
                cell2.Value = s.getSurname();
                cell3.ValueType = typeof(int);
                cell3.Value = s.Bookname();
                row.Cells.Add(cell1);
                row.Cells.Add(cell2);
                row.Cells.Add(cell3);
                dataGridView1.Rows.Add(row);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int count = 0;
            foreach(Student s in studentList)
            {
                if (s.getName() == textBox2.Text) count++;
            }
            if (textBox1.Text!="" && textBox2.Text != "" && count == 0)
            {
                addStudent(textBox1.Text, textBox2.Text, Convert.ToInt32(numericUpDown1.Text));
            }else { MessageBox.Show("Error", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);}
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int elementIndex = dataGridView1.SelectedCells[0].RowIndex;
            DialogResult rez = MessageBox.Show("Are you sure?", "delete", MessageBoxButtons.YesNo);
            if (rez == DialogResult.Yes) deleteStudent(elementIndex);
        }

        private void сортироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult rez = MessageBox.Show("Are you sure?", "Sort", MessageBoxButtons.YesNo);
            if (rez == DialogResult.Yes)
            {
                dataGridView1.Sort(dataGridView1.Columns[1], ListSortDirection.Ascending);
            }
        }

        private void редактироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int elementIndex = dataGridView1.SelectedCells[0].RowIndex;
            DialogResult rez = MessageBox.Show("Are you sure?", "redact", MessageBoxButtons.YesNo);
            if (rez == DialogResult.Yes) 
            {
                if (textBox1.Text != "" && textBox2.Text != "") RemoveStudent(textBox1.Text, textBox2.Text, Convert.ToInt32(numericUpDown1.Text), elementIndex);
                else MessageBox.Show("ВВедите данные, пожалйста","error",MessageBoxButtons.YesNo);
            }
        }
    }
   
}
