using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace ShoeStore.Data.Product
{
    public static class Review
    {
        public static DataSet GetReviewForProduct(int pProductId)
        {
            DataSet ldataSet = new DataSet();

            SqlConnection lconnection = new SqlConnection();
            lconnection.ConnectionString = ShoeStoreDB.GetConnectionString();

            SqlCommand lcommand = new SqlCommand("GetRiviewById", lconnection);
            lcommand.CommandType = System.Data.CommandType.StoredProcedure;


            lcommand.Parameters.Add(new SqlParameter(@"ProductId", SqlDbType.Int));
            lcommand.Parameters[@"ProductId"].Value = pProductId;

            SqlDataAdapter ladapter = new SqlDataAdapter(lcommand);

            try
            {
                //lconnection.Open();                
                ladapter.Fill(ldataSet);
            }
            catch (SqlException ex)
            {

            }
            catch (Exception ex)
            {

            }

            finally
            {
                if (lconnection.State == ConnectionState.Open)
                {
                    lconnection.Close();
                }
            }
            return ldataSet;
        }

    }

}
