using AssetManagement.DAL.Repositories;
using AssetManagement.DTO.DTO;
using AssetManagement.Provider;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.DAL.DAL
{
    public class AssetDAL : IInsert<InsertAssetDTO>
    {
        SqlTransaction transaction = null;
        MyProvider provider = new MyProvider("select * from Asset");
        public void Insert(InsertAssetDTO state)
        {
            provider.OpenConnection();
            SqlTransaction tran = provider.conn.BeginTransaction();
            try
            {
                provider = new MyProvider("sp_InsertAsset", CommandType.StoredProcedure, transaction);
                List<SqlParameter[]> sqlParameters = new List<SqlParameter[]>();
                List<SqlParameter> sqlParam = new List<SqlParameter>();
                sqlParam.Add(new SqlParameter("@barcode", state.Asset.hasBarcode));
                sqlParam.Add(new SqlParameter("@assetType", state.AssetType.Description));
                sqlParam.Add(new SqlParameter("@startDate", state.AssetOwner.StartDate));
                sqlParam.Add(new SqlParameter("@endDate", state.AssetOwner.EndDate));
                sqlParam.Add(new SqlParameter("@money", state.Asset.Cost));
                sqlParam.Add(new SqlParameter("@brand", state.Brand.Description));
                sqlParam.Add(new SqlParameter("@model", state.Brand.Model));
                sqlParam.Add(new SqlParameter("@cost", state.Currency.Description));
                sqlParam.Add(new SqlParameter("@guarantee", state.Asset.Guarantee));
                sqlParam.Add(new SqlParameter("@companyId", state.Asset.CompanyID));
                sqlParam.Add(new SqlParameter("@retireDate", state.AssetOwner.EndDate));

                sqlParameters.Add(sqlParam.ToArray());
                provider.AddParameter(sqlParameters[0]);
                int affectedRows = provider.ExecuteNonQuery();
                tran.Commit();

            }
            catch (Exception)
            {

                tran.Rollback();
            }
            finally
            {
                provider.CloseConnection();
            }


        }
    }
}
