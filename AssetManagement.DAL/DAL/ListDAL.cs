﻿using AssetManagement.DAL.Repositories;
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
    public class ListDAL : ISelect<SelectDTO>
    {
        ListView listView;
        public ListDAL(ListView view)
        {
            this.listView = view;
        }

        MyProvider provider = null;
        public void Select(SelectDTO state)
        {
            provider = new MyProvider("select a.ID ,a.IsBarcode as [Barkod] ,at.Description, a.Cost,bm.Description as [Brand],bm.Model as [Model]\r\nfrom Asset a\r\njoin  BrandModel bm on a.BrandModelID=bm.ID\r\njoin AssetType at on at.ID=a.AssetTypeID");

            SqlDataReader rdr = provider.ExecuteReader();
            if (rdr.HasRows)
            {

                while (rdr.Read())
                {
                    ListViewItem item = new ListViewItem(rdr["ID"].ToString());
                    item.SubItems.Add(rdr["Barkod"].ToString());
                    item.SubItems.Add(rdr["Description"].ToString());
                    item.SubItems.Add(rdr["Cost"].ToString());
                    item.SubItems.Add(rdr["Brand"].ToString());
                    item.SubItems.Add(rdr["Model"].ToString());

                    listView.Items.Add(item);

                }
            }
        }
    }
}
