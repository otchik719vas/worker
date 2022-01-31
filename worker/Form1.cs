using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;


namespace worker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "provider=Microsoft.Jet.OleDb.4.0; Data source=worker.mdb";
            OleDbConnection dbConnection = new OleDbConnection(connectionString);

            dbConnection.Open();
            string query = "SELECT * FROM worker";
            OleDbCommand dbCommand = new OleDbCommand(query, dbConnection);
            OleDbDataReader dbReader = dbCommand.ExecuteReader();

            if (dbReader.HasRows == false)
            {

                MessageBox.Show("Данные не найдены!", "Ошибка!");

            }
            else
            {
                while (dbReader.Read())
                {

                    dataGridView1.Rows.Add(dbReader["w_id"], dbReader["fio"], dbReader["spetsialnost"], dbReader["doljnost"], dbReader["date"]);

                }
            }
            dbReader.Close();
            dbConnection.Close();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Application.Exit();

        }

        private void обПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {

            MessageBox.Show("Работу выполнил учащийся группы 181070 БГУИР ИИТ 18107196 Отчик Алексей Геннадьевич", "Внимание!");

        }

        private void button2_Click(object sender, EventArgs e)
        {

            if(dataGridView1.SelectedRows.Count != 1)
            {

                MessageBox.Show("Выберите строку!", "Внимание!");
                return;

            }

            int index = dataGridView1.SelectedRows[0].Index;

            if (dataGridView1.Rows[index].Cells[0].Value == null ||
                dataGridView1.Rows[index].Cells[1].Value == null ||
                dataGridView1.Rows[index].Cells[2].Value == null ||
                dataGridView1.Rows[index].Cells[3].Value == null ||
                dataGridView1.Rows[index].Cells[4].Value == null)

            {

                MessageBox.Show("Не все данные введены!", "Внимание!");
                return;

            }

            string w_id = dataGridView1.Rows[index].Cells[0].Value.ToString();
            string fio = dataGridView1.Rows[index].Cells[1].Value.ToString();
            string spetsialnost = dataGridView1.Rows[index].Cells[2].Value.ToString();
            string doljnost = dataGridView1.Rows[index].Cells[3].Value.ToString();
            string date = dataGridView1.Rows[index].Cells[4].Value.ToString();

            string connectionString = "Provider=Microsoft.Jet.OleDb.4.0; Data source=worker.mdb";
            OleDbConnection dbConnection = new OleDbConnection(connectionString);

            dbConnection.Open();
            string query = "INSERT INTO worker VALUES (" + w_id + ", '" + fio + "', '" + spetsialnost + "', '" + doljnost + "', '" + date + "')";
            OleDbCommand dbCommand = new OleDbCommand(query, dbConnection);

            if (dbCommand.ExecuteNonQuery() != 1)
                MessageBox.Show("Ошибка выполнения запроса!", "Ошибка!");
            else
                MessageBox.Show("Данные добавлены!", "Внимание!");
            dbConnection.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count != 1)
            {
                MessageBox.Show("Выберите строку!", "Внимание!");
                return;
            }
            int index = dataGridView1.SelectedRows[0].Index;

            if (dataGridView1.Rows[index].Cells[0].Value == null ||
                dataGridView1.Rows[index].Cells[1].Value == null ||
                dataGridView1.Rows[index].Cells[2].Value == null ||
                dataGridView1.Rows[index].Cells[3].Value == null ||
                dataGridView1.Rows[index].Cells[4].Value == null)
            {
                MessageBox.Show("Не все данные введены!", "Внимание!");
                return;
            }

            string w_id = dataGridView1.Rows[index].Cells[0].Value.ToString();
            string fio = dataGridView1.Rows[index].Cells[1].Value.ToString();
            string spetsialnost = dataGridView1.Rows[index].Cells[2].Value.ToString();
            string doljnost = dataGridView1.Rows[index].Cells[3].Value.ToString();
            string date = dataGridView1.Rows[index].Cells[4].Value.ToString();

            string connectionString = "Provider=Microsoft.Jet.OleDb.4.0; Data source=worker.mdb";
            OleDbConnection dbConnection = new OleDbConnection(connectionString);

            dbConnection.Open();
            string query = "UPDATE worker SET fio = '" + fio + "',spetsialnost='" + spetsialnost + "',doljnost='" + doljnost + "',date='" + date +"' WHERE w_id = + w_id";
            //string query = "UPDATE worker SET fio = " + fio + ",spetsialnost = " + spetsialnost + ",doljnost=" + doljnost + ",date=" + date + " WHERE w_id" = +w_id;
            OleDbCommand dbCommand = new OleDbCommand(query, dbConnection);

            if (dbCommand.ExecuteNonQuery() == 1)
            {

                MessageBox.Show("Данные изменены!", "Внимание!");

            }
            else
            {
                MessageBox.Show("Ошибка выполнения запроса!", "Ошибка!");
            }

            dbConnection.Close();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 1)
            {
                MessageBox.Show("Выберите строку!", "Внимание!");
                return;
            }
            int index = dataGridView1.SelectedRows[0].Index;

            if (dataGridView1.Rows[index].Cells[0].Value == null)
            {

                MessageBox.Show("Не все данные введены!", "Внимание!");
                return;

            }

            string w_id = dataGridView1.Rows[index].Cells[0].Value.ToString();

            string connectionString = "Provider=Microsoft.Jet.OleDb.4.0; Data source=worker.mdb";
            OleDbConnection dbConnection = new OleDbConnection(connectionString);
            dbConnection.Open();
            string query = "DELETE FROM worker WHERE w_id = " + w_id;
            OleDbCommand dbCommand = new OleDbCommand(query, dbConnection);

            if (dbCommand.ExecuteNonQuery() != 1)
                MessageBox.Show("Ошибка выполнения запроса!", "Ошибка!");
            else
            {

                MessageBox.Show("Данные удалены!", "Внимание!");
                dataGridView1.Rows.RemoveAt(index);

            }

            dbConnection.Close();

        }
    }
}
