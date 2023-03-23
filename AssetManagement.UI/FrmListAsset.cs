using AssetManagement.DAL.DAL;
using AssetManagement.DTO.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AssetManagement.UI
{
    public partial class FrmListAsset : Form
    {
        SelectDTO dto=null;
        public FrmListAsset()
        {
            InitializeComponent();
        }

        private void FrmListAsset_Load(object sender, EventArgs e)
        {
            ListDAL dal = new ListDAL(lstAssetList);
            dal.Select(dto);    
        }

        private void btnNewRecord_Click(object sender, EventArgs e)
        {
            FrmNewRecord frm = new FrmNewRecord();
            frm.Show();
            this.Hide();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            FrmReport frm = new FrmReport();    
            frm.Show();
            this.Hide();
        }
    }
}
