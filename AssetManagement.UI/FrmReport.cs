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
    public partial class FrmReport : Form
    {
        AssetDTO dto=null;
        public FrmReport()
        {
            InitializeComponent();
        }

        private void FrmReport_Load(object sender, EventArgs e)
        {
            ReportDAL dal = new ReportDAL(lstAssetList,dtR);
            dal.Select(dto);
        }

        private void btnR_Click(object sender, EventArgs e)
        {
             ReportDAL dal=new ReportDAL(lstAssetList,dtR);
            AssetDTO dto = new AssetDTO();
            dal.Select(dto);
        }
    }
}
