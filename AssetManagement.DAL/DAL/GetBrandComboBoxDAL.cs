using AssetManagement.DAL.Repositories;
using AssetManagement.DTO.DTO;
using AssetManagement.Provider;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AssetManagement.DAL.DAL
{
    public class GetBrandComboBoxDAL : ISelect<BrandModelDTO>
    {
        private ComboBox cmbMarka;
        private ComboBox cmbModel;
        private ComboBox cmbUrunTip;
        private ComboBox cmbCurrency;
        private ComboBox cmbCurrentCurrency;
        List<string[]> column = new List<string[]>();

        public GetBrandComboBoxDAL()
        {

        }
        public GetBrandComboBoxDAL(ComboBox cmbMarka, ComboBox cmbModel, ComboBox cmbUrunTip, ComboBox cmbCurrency, ComboBox cmbCurrentCurrency)
        {
            this.cmbMarka = cmbMarka;
            this.cmbModel = cmbModel;
            this.cmbUrunTip = cmbUrunTip;
            this.cmbCurrency = cmbCurrency;
            this.cmbCurrentCurrency = cmbCurrentCurrency;


        }
        public void Select(BrandModelDTO model)
        {
            MyProvider provider = new MyProvider("select * from BrandModel");
            MyProvider provider2 = new MyProvider("select  ID,Description from AssetType ");
            MyProvider provider3 = new MyProvider("select  Description from Currency ");

            SqlDataReader rdr;
            SqlDataReader rdr2;
            SqlDataReader rdr3;


            ComboBox[] box1 = { cmbMarka };
            ComboBox[] box2 = { cmbUrunTip };
            ComboBox[] box3 = { cmbCurrency, cmbCurrentCurrency };
            string[] columns1 = { "Description" };
            string[] columns2 = { "ID", "Description" };
            string[] columns3 = { "Description", "Description" };
            column.Add(columns2);
            rdr = provider.ExecuteReader();
            rdr2 = provider2.ExecuteReader();
            rdr3 = provider3.ExecuteReader();
            FillComboBoxes(rdr, box1, columns1);
            FillComboBoxes(rdr2, box2, columns2);
            FillComboBoxes(rdr3, box3, columns3);
        }
        public void FillComboBoxes(SqlDataReader sqlDataReader, ComboBox[] boxes, string[] columns)
        {
            List<string[]> strings = new List<string[]>();
            strings.Add(columns);

            while (sqlDataReader.Read())
            {

                if (column[0] == strings[0])
                {
                    int id = Convert.ToInt32(sqlDataReader[columns[0]]);
                    IDComboBoxDTO.AssetTypeID.Add(id);
                    boxes[0].Items.Add(sqlDataReader[columns[1]]);

                }

                if (boxes.Length == columns.Length)
                {

                    for (int i = 0; i < boxes.Length; i++)
                    {
                        boxes[i].Items.Add(sqlDataReader[columns[i]]);
                    }
                }
            }
        }

        public void ReadeableData(SqlDataReader sqlDataReader, ComboBox cmbMarka, ComboBox cmbModel)
        {
            while (sqlDataReader.Read())
            {
                cmbModel.Items.Add(sqlDataReader["Model"]);
                cmbMarka.Items.Add(sqlDataReader["Description"]);


            }
        }
    }
}
