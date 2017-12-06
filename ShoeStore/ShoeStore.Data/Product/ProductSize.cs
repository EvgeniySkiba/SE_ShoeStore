using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace ShoeStore.Data.Product
{
    /// <summary>
    /// CRUD for Size table
    /// </summary> 
    public static class ProductSize
    {

        /// <summary>
        /// a list of all the Size
        /// </summary>
        /// <returns>data set</returns>
        public static DataSet GetSeason()
        {
            DataSet dataSet = new DataSet();

            SqlConnection lConnection = new SqlConnection();
            lConnection.ConnectionString = ShoeStoreDB.GetConnectionString();

            string lCommandString = @"SELECT ID,Size FROM Size";

            SqlDataAdapter adapter = new SqlDataAdapter(lCommandString, lConnection);

            try
            {
                adapter.Fill(dataSet, "Size");
            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (lConnection.State == ConnectionState.Open)
                {
                    lConnection.Close();
                }
            }
            return dataSet;
        }


        /// <summary>
        /// Remove the selected Size
        /// </summary>
        /// <param name="pSeasonId">id selected records</param>
        /// <returns>successful changes</returns>
        public static int DeleteSize(int pSizeId)
        {
            int lResult = 0;

            SqlConnection lConnection = new SqlConnection();
            lConnection.ConnectionString = ShoeStoreDB.GetConnectionString();
            string lSqlCommandstring = @"DELETE FROM Size WHERE ID = @ID";
            SqlCommand lCommand = new SqlCommand(lSqlCommandstring, lConnection);
            lCommand.Parameters.AddWithValue("@ID", pSizeId);

            try
            {
                lConnection.Open();
                lCommand.ExecuteNonQuery();
            }
            catch (SqlException exc)
            {
                lResult = 2;
            }
            catch (Exception ex)
            {
                lResult = 1;
            }
            finally
            {
                if (lConnection.State == ConnectionState.Open)
                {
                    lConnection.Close();
                }
            }

            return lResult;
        }

        /// <summary>
        /// update record in database
        /// </summary>
        /// <param name="pId">id</param>
        /// <param name="pSeasonalName">name</param>
        /// <returns>successful changes</returns>
        public static bool UpdateSize(int pId, string pSize)
        {
            bool lResult = false;

            SqlConnection lConnection = new SqlConnection();
            lConnection.ConnectionString = ShoeStoreDB.GetConnectionString();

            string lCommandText = @"UPDATE Size
                                         SET Size = @Size                                            
                                        WHERE  ID = @ID";

            SqlCommand lCommand = new SqlCommand();
            lCommand.CommandText = lCommandText;
            lCommand.Connection = lConnection;

            lCommand.Parameters.Add(new SqlParameter(@"Size", SqlDbType.NVarChar, 250));
            lCommand.Parameters[@"Size"].Value = pSize;

            lCommand.Parameters.Add(new SqlParameter(@"ID", SqlDbType.Int));
            lCommand.Parameters[@"ID"].Value = pId;


            try
            {
                lConnection.Open();
                lCommand.ExecuteNonQuery();
                lResult = true;
            }
            catch (SqlException exc)
            {

            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (lConnection.State == ConnectionState.Open)
                {
                    lConnection.Close();
                }
            }


            return lResult;
        }

        /// <summary>
        /// create new record
        /// </summary>
        /// <param name="pSeasonName">seson's name</param>
        /// <returns>successful changes</returns>
        public static bool CreateNewSize(string pSize)
        {
            bool lResult = false;

            SqlConnection lConnection = new SqlConnection();
            lConnection.ConnectionString = ShoeStoreDB.GetConnectionString();

            string lCommandText = @"INSERT INTO Size( Size )
                                            VALUES ( @Size )";

            SqlCommand lCommand = new SqlCommand();
            lCommand.CommandText = lCommandText;
            lCommand.Connection = lConnection;

            lCommand.Parameters.Add(new SqlParameter(@"Size", SqlDbType.NVarChar, 250));
            lCommand.Parameters[@"Size"].Value = pSize;

            try
            {
                lConnection.Open();
                lCommand.ExecuteNonQuery();
                lResult = true;
            }
            catch { }
            finally
            {
                if (lConnection.State == ConnectionState.Open)
                {
                    lConnection.Close();
                }
            }

            return lResult;
        }

        /// <summary>
        ////добавление 
        /// </summary>
        /// <param name="pProductId"></param>
        /// <returns></returns>
        public static bool SetProductsSize(int pProductId, int psizeid, int pProductCount)
        {
            bool lresult = false;
            //SetProductsSize
            SqlConnection lconnection = new SqlConnection();
            lconnection.ConnectionString = ShoeStoreDB.GetConnectionString();

            SqlCommand lcommand = new SqlCommand("SetProductsSize", lconnection);
            lcommand.CommandType = System.Data.CommandType.StoredProcedure;

            lcommand.Parameters.Add(new SqlParameter(@"productid", SqlDbType.Int));
            lcommand.Parameters[@"productid"].Value = pProductId;

            lcommand.Parameters.Add(new SqlParameter(@"sizeId", SqlDbType.Int));
            lcommand.Parameters[@"sizeId"].Value = psizeid; ;

            lcommand.Parameters.Add(new SqlParameter(@"count", SqlDbType.Int));
            lcommand.Parameters[@"count"].Value = pProductCount; ;

            try
            {
                lconnection.Open();
                lcommand.ExecuteNonQuery();
                lresult = true;
            }
            catch (SqlException exc)
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

            return lresult;
        }

        public static DataSet GetProductSize(int pProductId)
        {
            DataSet ldataSet = new DataSet();

            SqlConnection lConnection = new SqlConnection();
            lConnection.ConnectionString = ShoeStoreDB.GetConnectionString();

            SqlCommand lCommand = new SqlCommand();
            string lCommandText = @"SELECT Size.*
                                     FROM  ProductSize INNER JOIN
                                            Size ON ProductSize.SizeID = Size.ID
                                WHERE(ProductSize.ProductId = @ProductID)";

            lCommand.CommandText = lCommandText;
            lCommand.Connection = lConnection;


            SqlParameter lparametr = new SqlParameter(@"ProductID", SqlDbType.Int);
            lparametr.Value = pProductId;
            //lCommand.Parameters.Add(new SqlParameter);
            //lCommand.Parameters[@"ProductID"].Value = pProductId;

            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = lCommand;
                
                
                
                ///.CommandText = @"SELECT Size.*
                 /*                    FROM  ProductSize INNER JOIN
                                            Size ON ProductSize.SizeID = Size.ID
                                WHERE(ProductSize.ProductId = @ProductID)";
                  */
            //lCommandText;
            adapter.SelectCommand.Parameters.Add(lparametr);

            try
            {
                adapter.Fill(ldataSet);
            }
            catch (SqlException exc)
            {

            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (lConnection.State == ConnectionState.Open)
                {
                    lConnection.Close();
                }
            }


            return ldataSet;
        }


        public static bool DeleteSizeFromProduct(int pProductId)
        {
            bool lresult = false;
            //SetProductsSize
            SqlConnection lconnection = new SqlConnection();
            lconnection.ConnectionString = ShoeStoreDB.GetConnectionString();

            SqlCommand lcommand = new SqlCommand("DeleteSizeFromProduct", lconnection);
            lcommand.CommandType = System.Data.CommandType.StoredProcedure;

            lcommand.Parameters.Add(new SqlParameter(@"productid", SqlDbType.Int));
            lcommand.Parameters[@"productid"].Value = pProductId;        

            try
            {
                lconnection.Open();
                lcommand.ExecuteNonQuery();
                lresult = true;
            }
            catch (SqlException exc)
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

            return lresult;

        }

        public static DataSet GetCountSize(int pProductId)
        {
            DataSet ldataSet = new DataSet();

            SqlConnection lConnection = new SqlConnection();
            lConnection.ConnectionString = ShoeStoreDB.GetConnectionString();

            SqlCommand lCommand = new SqlCommand();
            string lCommandText = @"select Size.ID, Size.Size, ProductSize.ProductCount
                                     FROM  ProductSize INNER JOIN
                                            Size ON ProductSize.SizeID = Size.ID
                                WHERE(ProductSize.ProductId = @ProductID)";

            lCommand.CommandText = lCommandText;
            lCommand.Connection = lConnection;


            SqlParameter lparametr = new SqlParameter(@"ProductID", SqlDbType.Int);
            lparametr.Value = pProductId;
            //lCommand.Parameters.Add(new SqlParameter);
            //lCommand.Parameters[@"ProductID"].Value = pProductId;

            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = lCommand;



            //.CommandText = @"SELECT Size.*
            /*                    FROM  ProductSize INNER JOIN
                                       Size ON ProductSize.SizeID = Size.ID
                           WHERE(ProductSize.ProductId = @ProductID)";
             */
            //lCommandText;
            adapter.SelectCommand.Parameters.Add(lparametr);

            try
            {
                adapter.Fill(ldataSet);
            }
            catch (SqlException exc)
            {

            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (lConnection.State == ConnectionState.Open)
                {
                    lConnection.Close();
                }
            }


            return ldataSet;
        }

    }
}

