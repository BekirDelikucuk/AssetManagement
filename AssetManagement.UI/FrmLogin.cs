using AssetManagement.DAL.DAL;
using AssetManagement.DTO.DTO;
using AssetManagement.Provider;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace AssetManagement.UI
{
    public partial class FrmLogin : Form
    {
        LoginDTO login = new LoginDTO();
        public FrmLogin()
        {
            InitializeComponent();
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            #region LoginWithNoDAL
            //MyProvider pro = new MyProvider("Select * from Login where UserName='" + txtUserName.Text + "'And Password='" + txtPassword.Text + "'");
            //SqlDataReader rdr=pro.ExecuteReader();
            //if (rdr.Read())
            //{
            //    MessageBox.Show("Hoşgeldiniz");
            //    FrmNewRecord frm=new FrmNewRecord();
            //    frm.Show();
            //    this.Hide();
            //}
            //else
            //{
            //    MessageBox.Show("Lütfen sistemde olan kullanıcı adı ve şifre ile giriş yapınız");
            //} 
            #endregion

            login.UserName = txtUserName.Text;
            login.Password = txtPassword.Text;
            LoginDAL dal = new LoginDAL();
            dal.Select(login);
            SqlDataReader rdr = dal.provider.ExecuteReader();
            if (rdr.Read())
            {
                MessageBox.Show("Hoşgeldiniz");
                FrmListAsset frm = new FrmListAsset();
                frm.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Lütfen sistemde olan kullanıcı adı ve şifresi ile giriş yapınız");
            }

            ClearField();

        }

        private void ClearField()
        {
            txtPassword.Text = txtUserName.Text = string.Empty;
        }


    }
}
