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
    public class ComboBoxListDAL : ISelect<BrandModelDTO>
    {
        MyProvider provider = null;
        public void Select(BrandModelDTO state)
        {
            provider=new MyProvider("select Model from BrandModel where Description=@ModelName");
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(new SqlParameter("@ModelName", state.Description));
            provider.AddParameter(sqlParameters.ToArray());
        }
        public void SetCombo(ComboBox comboBox)
        {
            SqlDataReader rdr = null;
            rdr = provider.ExecuteReader();
            if (rdr != null)
            {
                while (rdr.Read())
                {

                    comboBox.Items.Add(rdr.GetSqlString(0));
                }
            }
        }
    }
}
