using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace ShoeStore.Data.Product
{
    public static class Image
    {
        public static int InsertImage(int pProductId, string pImageUrl, string pImagePreviewPath, string pCaption,
                                      bool pIsTitle, string pImageName,int pSize)
        {
            int lresult;
            lresult = 0;

            SqlConnection lConnection = new SqlConnection();
            lConnection.ConnectionString = ShoeStoreDB.GetConnectionString();  

            SqlCommand lcommand = new SqlCommand("InsertImage", lConnection);
            lcommand.CommandType = CommandType.StoredProcedure;

            lcommand.Parameters.Add(new SqlParameter(@"ImageUrl", SqlDbType.NVarChar, 255));
            lcommand.Parameters[@"ImageUrl"].Value = pImageUrl;

            lcommand.Parameters.Add(new SqlParameter(@"imagePreviewPath", SqlDbType.NVarChar, 255));
            lcommand.Parameters[@"imagePreviewPath"].Value = pImagePreviewPath;

            lcommand.Parameters.Add(new SqlParameter(@"CreationDate", SqlDbType.SmallDateTime));
            lcommand.Parameters[@"CreationDate"].Value = DateTime.Now;

            lcommand.Parameters.Add(new SqlParameter(@"Caption", SqlDbType.NVarChar, 255));
            lcommand.Parameters[@"Caption"].Value = pCaption;

            lcommand.Parameters.Add(new SqlParameter(@"istitle", SqlDbType.Bit));
            lcommand.Parameters[@"istitle"].Value = pIsTitle;

            lcommand.Parameters.Add(new SqlParameter(@"imageName", SqlDbType.NVarChar, 255));
            lcommand.Parameters[@"imageName"].Value = pImageName;

            lcommand.Parameters.Add(new SqlParameter(@"productId", SqlDbType.Int));
            lcommand.Parameters[@"productId"].Value = pProductId;

            lcommand.Parameters.Add(new SqlParameter(@"NewImageId", SqlDbType.Int));
            lcommand.Parameters[@"NewImageId"].Direction = ParameterDirection.Output;
            try
            {
                lConnection.Open();
                lcommand.ExecuteNonQuery();
                lresult = (int)lcommand.Parameters[@"NewImageId"].Value;
            }
            catch (Exception ex) { }
            finally
            {
                if (lConnection.State == ConnectionState.Open)
                {
                    lConnection.Close();
                }
            }

            return lresult;
        }

    }
}
