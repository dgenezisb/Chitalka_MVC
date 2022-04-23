using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace BaseData
{
    public partial class Form1 : Form
    {
        private SqlConnection sqlConnection = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Book"].ConnectionString);

            sqlConnection.Open();
        }

        //private static void PutImageBinaryInDb(int id, int bid, string iFile, string bFile)
        //{
        //    // конвертация изображения в байты
        //    byte[] imageData = null;
        //    FileInfo fInfo = new FileInfo(iFile);
        //    long numBytes = fInfo.Length;
        //    FileStream fStream = new FileStream(iFile, FileMode.Open, FileAccess.Read);
        //    BinaryReader br = new BinaryReader(fStream);
        //    imageData = br.ReadBytes((int)numBytes);

        //    byte[] imageData2 = null;
        //    FileInfo fInfo2 = new FileInfo(bFile);
        //    long numBytes2 = fInfo2.Length;
        //    FileStream fStream2 = new FileStream(bFile, FileMode.Open, FileAccess.Read);
        //    BinaryReader br2 = new BinaryReader(fStream2);
        //    imageData2 = br2.ReadBytes((int)numBytes2);

        //    // получение расширения файла изображения не забыв удалить точку перед расширением
        //    string iImageExtension = (Path.GetExtension(iFile)).Replace(".", "").ToLower();
        //    string iImageExtension2 = (Path.GetExtension(bFile)).Replace(".", "").ToLower();

        //    // запись изображения в БД
        //    using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Book"].ConnectionString)) // строка подключения к БД
        //    {
        //        string commandText = $"INSERT INTO Image(Id, bookid, smallimg, bigimg, s_format, b_format) VALUES(@Id, @bookid, @smallimg, @bigimg, @s_format, @b_format)";// запрос на вставку
        //        SqlCommand command = new SqlCommand(commandText, sqlConnection);
        //        command.Parameters.AddWithValue("@Id", id);
        //        command.Parameters.AddWithValue("@bookid", bid);
        //        command.Parameters.AddWithValue("@smallimg", (object)imageData); // записываем само изображение
        //        command.Parameters.AddWithValue("@s_format", iImageExtension);
        //        command.Parameters.AddWithValue("@bigimg", (object)imageData2); // записываем само изображение
        //        command.Parameters.AddWithValue("@b_format", iImageExtension2);

        //        sqlConnection.Open();
        //        command.ExecuteNonQuery();
        //        sqlConnection.Close();
        //    }
        //}

        //void PutImageBinaryInDb2(int id, string Name, string Biogr, string iFile, int bookid)
        //{
        //    byte[] imageData = null;
        //    if (iFile != null)
        //    { // конвертация изображения в байты

        //        FileInfo fInfo = new FileInfo(iFile);
        //        long numBytes = fInfo.Length;
        //        FileStream fStream = new FileStream(iFile, FileMode.Open, FileAccess.Read);
        //        BinaryReader br = new BinaryReader(fStream);
        //        imageData = br.ReadBytes((int)numBytes);
        //    }

        //    string iImageExtension = (Path.GetExtension(iFile)).Replace(".", "").ToLower();

        //    using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Book"].ConnectionString)) // строка подключения к БД
        //    {
        //        string commandText = $"INSERT INTO Author(Id, Name, Biogr, photo, bookid, p_format) VALUES(@Id, @Name, @Biogr, @photo, @bookid, @p_format)";// запрос на вставку
        //        SqlCommand command = new SqlCommand(commandText, sqlConnection);
        //        command.Parameters.AddWithValue("@Id", id);
        //        command.Parameters.AddWithValue("@Name", Name);
        //        command.Parameters.AddWithValue("@photo", (object)imageData); // записываем само изображение
        //        command.Parameters.AddWithValue("@p_format", iImageExtension);
        //        command.Parameters.AddWithValue("@Biogr", Biogr); // записываем само изображение
        //        command.Parameters.AddWithValue("@bookid", bookid);

        //        sqlConnection.Open();
        //        command.ExecuteNonQuery();
        //        sqlConnection.Close();
        //    }
        //}

        private void button1_Click(object sender, EventArgs e)
        {
            //PutImageBinaryInDb(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text), textBox3.Text, textBox4.Text); 

            using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Book"].ConnectionString)) // строка подключения к БД
            {
                string commandText = $"INSERT INTO Image(Id, bookid, smallimg, bigimg) VALUES(@Id, @bookid, @smallimg, @bigimg)";// запрос на вставку
                SqlCommand command = new SqlCommand(commandText, sqlConnection);
                command.Parameters.AddWithValue("@Id", Convert.ToInt32(textBox1.Text));
                command.Parameters.AddWithValue("@bookid", Convert.ToInt32(textBox2.Text));
                command.Parameters.AddWithValue("@smallimg", Convert.ToString(textBox3.Text));
                //command.Parameters.AddWithValue("@s_format", iImageExtension);
                command.Parameters.AddWithValue("@bigimg", Convert.ToString(textBox4.Text));
                //command.Parameters.AddWithValue("@b_format", iImageExtension2);

                sqlConnection.Open();
                command.ExecuteNonQuery();
                sqlConnection.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Book"].ConnectionString)) // строка подключения к БД
            {
                string commandText = $"INSERT INTO Books(Id, Name, authorid, countryid, centid, descr, quote, text, visiable) VALUES(@Id, @Name, @authorid, @countryid, @centid, @descr, @quote, @text, @visiable)";// запрос на вставку
                SqlCommand command = new SqlCommand(commandText, sqlConnection);
                command.Parameters.AddWithValue("@Id", Convert.ToInt32(textBox5.Text));
                command.Parameters.AddWithValue("@Name", textBox6.Text);
                command.Parameters.AddWithValue("@descr", textBox13.Text);
                command.Parameters.AddWithValue("@quote", textBox8.Text);
                command.Parameters.AddWithValue("@text", textBox9.Text);
                command.Parameters.AddWithValue("@visiable", Convert.ToInt32(textBox10.Text));
                command.Parameters.AddWithValue("@authorid", Convert.ToInt32(textBox18.Text));
                command.Parameters.AddWithValue("@countryid", Convert.ToInt32(textBox24.Text)); 
                command.Parameters.AddWithValue("@centid", Convert.ToInt32(textBox21.Text));

                sqlConnection.Open();
                command.ExecuteNonQuery();
                sqlConnection.Close();
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //PutImageBinaryInDb2(Convert.ToInt32(textBox11.Text), textBox12.Text, textBox13.Text, textBox14.Text, Convert.ToInt32(textBox15.Text));

            using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Book"].ConnectionString)) // строка подключения к БД
            {
                string commandText = $"INSERT INTO Author(Id, Name, Biogr, countryid) VALUES(@Id, @Name, @Biogr, @countryid)";// запрос на вставку
                SqlCommand command = new SqlCommand(commandText, sqlConnection);
                command.Parameters.AddWithValue("@Id", Convert.ToInt32(textBox11.Text));
                command.Parameters.AddWithValue("@Name", textBox12.Text);
                command.Parameters.AddWithValue("@Biogr", textBox7.Text); 
                command.Parameters.AddWithValue("@countryid", Convert.ToInt32(textBox15.Text));

                sqlConnection.Open();
                command.ExecuteNonQuery();
                sqlConnection.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Book"].ConnectionString)) // строка подключения к БД
            {
                string commandText = $"INSERT INTO Genre(Id, Name) VALUES(@Id, @Name)";// запрос на вставку
                SqlCommand command = new SqlCommand(commandText, sqlConnection);
                command.Parameters.AddWithValue("@Id", Convert.ToInt32(textBox16.Text));
                command.Parameters.AddWithValue("@Name", textBox17.Text);

                sqlConnection.Open();
                command.ExecuteNonQuery();
                sqlConnection.Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Book"].ConnectionString)) // строка подключения к БД
            {
                string commandText = $"INSERT INTO Centuary(Id, Name) VALUES(@Id, @Name)";
                SqlCommand command = new SqlCommand(commandText, sqlConnection);
                command.Parameters.AddWithValue("@Id", Convert.ToInt32(textBox19.Text));
                command.Parameters.AddWithValue("@Name", textBox20.Text);

                sqlConnection.Open();
                command.ExecuteNonQuery();
                sqlConnection.Close();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Book"].ConnectionString)) // строка подключения к БД
            {
                string commandText = $"INSERT INTO Country(Id, Name) VALUES(@Id, @Name)";
                SqlCommand command = new SqlCommand(commandText, sqlConnection);
                command.Parameters.AddWithValue("@Id", Convert.ToInt32(textBox22.Text));
                command.Parameters.AddWithValue("@Name", textBox23.Text);

                sqlConnection.Open();
                command.ExecuteNonQuery();
                sqlConnection.Close();
            }
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Book"].ConnectionString)) // строка подключения к БД
            {
                string commandText = $"INSERT INTO Image2(Id, authorid, bigimg) VALUES(@Id, @authorid, @bigimg)";// запрос на вставку
                SqlCommand command = new SqlCommand(commandText, sqlConnection);
                command.Parameters.AddWithValue("@Id", Convert.ToInt32(textBox14.Text));
                command.Parameters.AddWithValue("@bigimg", Convert.ToString(textBox27.Text));
                //command.Parameters.AddWithValue("@s_format", iImageExtension);
                command.Parameters.AddWithValue("@authorid", Convert.ToString(textBox28.Text));
                //command.Parameters.AddWithValue("@b_format", iImageExtension2);

                sqlConnection.Open();
                command.ExecuteNonQuery();
                sqlConnection.Close();
            }
        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox20_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Book"].ConnectionString)) // строка подключения к БД
            {
                string commandText = $"INSERT INTO MGenre(Id, bookid, genreid) VALUES(@Id, @bookid, @genreid)";// запрос на вставку
                SqlCommand command = new SqlCommand(commandText, sqlConnection);
                command.Parameters.AddWithValue("@Id", Convert.ToInt32(textBox25.Text));
                command.Parameters.AddWithValue("@bookid", Convert.ToInt32(textBox26.Text));
                command.Parameters.AddWithValue("@genreid", Convert.ToInt32(textBox29.Text));

                sqlConnection.Open();
                command.ExecuteNonQuery();
                sqlConnection.Close();
            }
        }
    }
}
