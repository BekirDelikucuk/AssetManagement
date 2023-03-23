using AssetManagement.Common;
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
using System.Windows.Forms.VisualStyles;


namespace AssetManagement.UI
{
    public partial class FrmNewRecord : Form
    {
        BrandModelDTO dto = null;
        GetBrandComboBoxDAL dal = new GetBrandComboBoxDAL();
        public FrmNewRecord()
        {
            InitializeComponent();
        }

        private void FrmNewRecord_Load(object sender, EventArgs e)
        {
            dto = new BrandModelDTO();
            dal = new GetBrandComboBoxDAL(cmbBrand, cmbModel, cmbOrderType, cmbCurrency, cmbCurrentCurrency);
            dal.Select(dto);
        }

        private void rjToggleButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (rjToggleButton1.Checked == false)
            {
                txtBarcode.Enabled = true;
                txtAmount.Enabled = false;
                txtCurrency.Enabled = false;
            }
            else
            {
                txtBarcode.Enabled = false;
                txtAmount.Enabled = true;
                txtCurrency.Enabled = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidationComboBox() && DTPValidation() && TxtCheck())
            {
                AssetDAL dal = new AssetDAL();
                InsertAssetDTO dto = null;

                dal.Insert(dto = new InsertAssetDTO
                {
                    Asset = new AssetDTO
                    {
                        hasBarcode = rjToggleButton1.Checked,
                        Cost = Convert.ToDecimal(txtCost.Text),
                        Guarantee = Convert.ToBoolean(cmbGuarantee.SelectedIndex),
                        CompanyID = 2,
                        Description = cmbBrand.Text,

                    },
                    AssetType = new AssetTypeDTO
                    {
                        Description = cmbOrderType.Text,
                    },
                    AssetOwner = new AssetOwnerDTO
                    {
                         StartDate=dtpEntryAsset.Value,
                         EndDate=dtpRetiredAsset.Value,
                    },
                    Brand = new BrandModelDTO
                    {
                        Description = cmbBrand.Text,
                        Model = cmbModel.Text
                    },
                    Currency = new CurrencyDTO
                    {
                        Description = cmbCurrency.Text
                    }
                });

                MessageBox.Show("Ürün Başarıyla eklendi");


            }
            else
            {
                MessageBox.Show("lütfen gerekli alanları doldurunuz");
            }

        }

        private bool ValidationComboBox()
        {
            return cmbBrand.ComboboxControl() && cmbOrderType.ComboboxControl() &&
                cmbCurrentCurrency.ComboboxControl() && cmbCurrency.ComboboxControl()
                && cmbModel.ComboboxControl() && cmbModel.ComboboxControl() &&
                cmbGuarantee.ComboboxControl();
        }
        public bool DTPValidation()
        {
            return InputExtension.ValidateDateRange(dtpEntryAsset.Value.Date, dtpRetiredAsset.Value.Date);
        }
        public bool TxtCheck()
        {
            return txtCost.Text.IsValidEmptyNumeric() && txtCosts.Text.IsValidEmptyNumeric() && txtExplanation.Text.IsValidEmptyNumeric();
        }

        private void cmbBrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            dto = new BrandModelDTO();
            dto.Description= cmbBrand.SelectedItem.ToString(); 
            ComboBoxListDAL cmb=new ComboBoxListDAL();
            cmbModel.Items.Clear();
            cmbModel.Text = string.Empty;
            cmb.Select(dto);
            cmb.SetCombo(cmbModel);
           
        }
    }
}
