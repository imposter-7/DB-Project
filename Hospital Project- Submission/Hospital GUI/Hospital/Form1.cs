using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Hospital
{
    public partial class Form1 : Form
    {
        SqlConnection connection;
        public Form1()
        {
            InitializeComponent();
            connection = new SqlConnection("Data Source=HALA\\HALA;Initial Catalog=Hospital;Integrated Security=True");
           
        }

        
        private void Form1_Load(object sender, EventArgs e)
        {
            connection.Open();
            string sql = "select employeeID As 'ID', Name , DOB as 'Date of birth',salary as 'Salary', days as 'Visiting Days' ,timing as 'Timing' ,shift as 'Shift' ,nurse_rank as 'Nurse Rank' ,job_type as 'Job Type' from Employee ";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset);
            dataGridView1.DataSource = dataset.Tables[0];
            
        }

        void load_data()
        {
            string sql = "select employeeID As 'ID', Name , DOB as 'Date of birth',salary as 'Salary', days as 'Visiting Days' ,timing as 'Timing' ,shift as 'Shift' ,nurse_rank as 'Nurse Rank' ,job_type as 'Job Type' from Employee ";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset);
            dataGridView1.DataSource = dataset.Tables[0];
            

        }


        private void button4_Click(object sender, EventArgs e)
        {

            string sql = "select employeeID As 'ID', Name , DOB as 'Date of birth',salary as 'Salary', days as 'Visiting Days' ,timing as 'Timing' ,shift as 'Shift' ,nurse_rank as 'Nurse Rank' ,job_type as 'Job Type' from Employee ";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset);
            dataGridView1.DataSource = dataset.Tables[0];

        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox5.Enabled = true;
            textBox7.Enabled = true;
            textBox8.Enabled = true;
            textBox9.Enabled = true;
            textBox1.Clear();
            textBox2.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (textBox9.Text.Trim() != "A" && textBox9.Text.Trim() != "a" && textBox9.Text.Trim() != "B" && textBox9.Text.Trim() != "b" && textBox9.Text.Trim() != "C" && textBox9.Text.Trim() != "c" && textBox9.Text.Trim() != "")
                {
                    MessageBox.Show("Shift must be A or B or C ", "Warning", MessageBoxButtons.RetryCancel, MessageBoxIcon.Information);
                }
                else
                {
                    if (textBox5.Text.Trim() != "1" && textBox5.Text.Trim() != "2" && textBox5.Text.Trim() != "3" && textBox5.Text.Trim() != "4" && textBox5.Text.Trim() != "5" && textBox5.Text.Trim() != "")
                    {
                        MessageBox.Show("Nurse rank must be either 1 or 2 or 3 or 4 or 5", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        
                                string sql = " insert into Employee(employeeID,Name,DOB,salary,days,timing,shift,nurse_rank,job_type) values ('" + textBox2.Text + "','" + textBox1.Text + "','" + dateTimePicker1.Value.Date + "','" + textBox4.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + textBox9.Text + "','" + textBox5.Text + "','" + textBox6.Text + "')    ";
                                SqlCommand command = new SqlCommand(sql, connection);

                                command.ExecuteNonQuery();
                            
                       

                    }

                   

                }
                

                load_data();
            }

            catch (System.Data.SqlClient.SqlException sqlexception)
            {
                MessageBox.Show("Employee's ID is already exists", "Warning", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);

            }

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sql =" Delete from Employee where employeeID= '"+textBox2.Text+"' ; ";
            SqlCommand command = new SqlCommand(sql, connection);
            command.ExecuteNonQuery();

            load_data();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            

            if (textBox9.Text.Trim() != "A" && textBox9.Text.Trim() != "a" && textBox9.Text.Trim() != "B" && textBox9.Text.Trim() != "b" && textBox9.Text.Trim() != "C" && textBox9.Text.Trim() != "c" && textBox9.Text.Trim() != "")
            {
                MessageBox.Show("Shift must be A or B or C ", "Warning", MessageBoxButtons.RetryCancel, MessageBoxIcon.Information);
            }
            else
            {
                if (textBox5.Text.Trim() != "1" && textBox5.Text.Trim() != "2" && textBox5.Text.Trim() != "3" && textBox5.Text.Trim() != "4" && textBox5.Text.Trim() != "5" && textBox5.Text.Trim() != "")
                {
                    MessageBox.Show("Nurse rank must be either 1 or 2 or 3 or 4 or 5", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                }

                else
                {
                    
                        string sql = " Update Employee set Name=' " + textBox1.Text + "' , DOB='" + dateTimePicker1.Value.Date + "' , salary='" + textBox4.Text + "', days='" + textBox7.Text + "' , timing='" + textBox8.Text + "' , shift='" + textBox9.Text.Trim() + "', nurse_rank='" + textBox5.Text + "' , job_type='" + textBox6.Text + "' where employeeID='" + textBox2.Text + "' ;";
                        SqlCommand command = new SqlCommand(sql, connection);
                        command.ExecuteNonQuery();

                        load_data();

                    
                    
                }

            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                textBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                textBox2.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                dateTimePicker1.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                textBox6.Text = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();
                textBox4.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                textBox8.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                textBox7.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                textBox9.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
                textBox5.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();

            }

            catch (ArgumentOutOfRangeException exp)
            {
                MessageBox.Show("Please select the whole row", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);

            }

            catch (SqlException exp)
            {
                MessageBox.Show("Please select the whole row", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
          
        }

        private void textBox6_Leave(object sender, EventArgs e)
        {
            if (textBox6.Text.Trim().ToLower() == "doctor")
            {
                textBox5.Clear();
                textBox9.Clear();
                textBox5.Enabled = false;
                textBox9.Enabled = false;
                textBox7.Enabled = true;
                textBox8.Enabled = true;

            }
            else
            {
                if(textBox6.Text.Trim().ToLower() == "nurse")
                {
                    textBox7.Clear();
                    textBox8.Clear();
                    textBox7.Enabled = false;
                    textBox8.Enabled = false;
                    textBox5.Enabled = true;
                    textBox9.Enabled = true;
                }
                else
                {
                    textBox7.Clear();
                    textBox8.Clear();
                    textBox5.Clear();
                    textBox9.Clear();
                    textBox7.Enabled = false;
                    textBox8.Enabled = false;
                    textBox5.Enabled = false;
                    textBox9.Enabled = false;

                }
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
