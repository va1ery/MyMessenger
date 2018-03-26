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


namespace Messenger
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            
        }
       

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox3.Parent = pictureBox1;
            pictureBox4.Parent = pictureBox1;
            passwordText.ForeColor = Color.LightGray;
            NameText.ForeColor = Color.LightGray;                 
        }


        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            this.Capture = false;
            Message n = Message.Create(this.Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
            this.WndProc(ref n);

        }

        bool max = true;
        private bool clicked = false;

        private void userControl11_Click(object sender, EventArgs e)
        {
            if (max == true) { WindowState = FormWindowState.Maximized; max = false; }
            else 
            { WindowState = FormWindowState.Normal; max = true; }

        }


        private void userControl11_MouseEnter(object sender, EventArgs e)
        {
            userControl11.BackColor = Color.FromArgb(211, 211, 211);
        }

        private void userControl11_MouseLeave(object sender, EventArgs e)
        {
            userControl11.BackColor = Color.WhiteSmoke;
        }


        private void NameText_Enter(object sender, EventArgs e)
        {
            if (NameText.Text == "Login")
            {
                NameText.Text = "";
                NameText.ForeColor = Color.WhiteSmoke;
            }
        }

        private void NameText_Leave(object sender, EventArgs e)
        {
            if (NameText.Text == "")
            {
                NameText.Text = "Login";
                NameText.ForeColor = Color.LightGray;
            }
        }

        private void passwordText_Enter(object sender, EventArgs e)
        {

            if (passwordText.Text == "Password")
            {
                passwordText.Text = "";
                passwordText.ForeColor = Color.WhiteSmoke;
                passwordText.PasswordChar = '●';
            }
            

        }

        private void passwordText_Leave(object sender, EventArgs e)
        {

            if (passwordText.Text == "")
            {
                passwordText.Text = "Password";              
                passwordText.ForeColor = Color.LightGray;
                passwordText.PasswordChar = '\0';
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox5.Focus();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            pictureBox5.Focus();
        }

        private void customImageButton2_MouseEnter(object sender, EventArgs e)
        {
            customImageButton3.Visible = true;
        }

        private void customImageButton2_MouseLeave(object sender, EventArgs e)
        {
            customImageButton3.Visible = false;
        }

        private void label2_MouseEnter(object sender, EventArgs e)
        {       
    
            if (clicked == true)
            {
                label2.Font = new Font("Microsoft Sans", 14, FontStyle.Underline);
            }
            else { label2.Font = new Font("Microsoft Sans",14, FontStyle.Regular);}


        }

        private void label2_Click(object sender, EventArgs e)
        {
            SingUp singUp = new SingUp();
            singUp.Show();
            this.Hide();

            label2.Font = new Font(label2.Font.Name, label2.Font.SizeInPoints, FontStyle.Underline);
            clicked = true;

            if (WindowState == FormWindowState.Maximized)           
                SingUp.ActiveForm.WindowState = FormWindowState.Maximized;
            
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            if(clicked == true)
            { 
            label2.Font = new Font("Microsoft Sans", 11, FontStyle.Underline);
            }
            else { label2.Font = new Font("Microsoft Sans", 11); }
        }

        private void customImageButton2_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;//Свернуть окно
        }

        private void pictureBox5_MouseEnter(object sender, EventArgs e)
        {
            pictureBox5.BackColor = Color.FromArgb(211, 211, 211);
        }

        private void pictureBox5_MouseLeave(object sender, EventArgs e)
        {
            pictureBox5.BackColor = Color.WhiteSmoke;
        }
       
        private void Login_Move(object sender, EventArgs e)
        {
          
        }

        
        public void Login_SizeChanged(object sender, EventArgs e)
        {
          
        }

        public string nam = "";
        public string TEST = "";

        private void label3_Click(object sender, EventArgs e)
        {
            int login = 0;

            using (SqlConnection con = new SqlConnection(Properties.Settings.Default.Mess))

            {

                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT Count(*) FROM Users WHERE Email='" + NameText.Text + "' and Password='" + passwordText.Text + "'";
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    login = Convert.ToInt32(read[0]);
                }
                con.Close();

            }
            if (login == 1)
            {
                /*-----------------------------------------------------------------------------*/
                using (SqlConnection con = new SqlConnection(Properties.Settings.Default.Mess))
                {
                    con.Open();
                    SqlCommand cmd1 = con.CreateCommand();
                    cmd1.CommandText = "SELECT id FROM Users WHERE Email='" + NameText.Text + "' ";
                    SqlDataReader rader1 = cmd1.ExecuteReader();
                    while (rader1.Read())
                    {
                        TEST = rader1["id"].ToString();
                    }
                    con.Close();

                    con.Open();
                    SqlCommand cmd2 = con.CreateCommand();
                    cmd2.CommandText = "SELECT FirstName FROM Users WHERE id = '" + TEST + "' ";
                    SqlDataReader rader2 = cmd2.ExecuteReader();
                    while (rader2.Read())
                    {
                        nam = rader2["FirstName"].ToString();
                    }

                    con.Close();

                }
                /*-----------------------------------------------------------------------------*/

                BigShaq1 BigShaq1 = new BigShaq1(this);
                BigShaq1.Show();
                this.Hide();
            }
            else
                MessageBox.Show("Не правильный логин или пароль");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }
    }

}
