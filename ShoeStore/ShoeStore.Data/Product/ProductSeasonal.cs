using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace ShoeStore.Data.Product
{
    /// <summary>
    /// CRUD for Season table
    /// </summary>
    public static class ProductSeasonal
    {
        /// <summary>
        /// a list of all the materials
        /// </summary>
        /// <returns>data set</returns>
        public static DataSet GetSeason()
        {
            DataSet dataSet = new DataSet();

            SqlConnection lConnection = new SqlConnection();
            lConnection.ConnectionString = ShoeStoreDB.GetConnectionString();

            string lCommandString = @"SELECT ID,Name FROM SeasonalType";

            SqlDataAdapter adapter = new SqlDataAdapter(lCommandString, lConnection);

            try
            {                  
                adapter.Fill(dataSet, "SeasonalType");
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
        /// Remove the selected season
        /// </summary>
        /// <param name="pSeasonId">id selected records</param>
        /// <returns>successful changes</returns>
        public static bool DeleteSeasonal(int pSeasonId)
        {
            bool lResult = false;

            SqlConnection lConnection = new SqlConnection();
            lConnection.ConnectionString = ShoeStoreDB.GetConnectionString();
            string lSqlCommandstring = @"DELETE FROM SeasonalType WHERE ID = @ID";
            SqlCommand lCommand = new SqlCommand(lSqlCommandstring, lConnection);
            lCommand.Parameters.AddWithValue("@ID", pSeasonId);

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
        /// update record in database
        /// </summary>
        /// <param name="pId">id</param>
        /// <param name="pSeasonalName">name</param>
        /// <returns>successful changes</returns>
        public static bool UpdateSeasonalType(int pId, string pSeasonalName)
        {
            bool lResult = false;

            SqlConnection lConnection = new SqlConnection();
            lConnection.ConnectionString = ShoeStoreDB.GetConnectionString();

            string lCommandText = @"UPDATE SeasonalType
                                         SET Name = @Name                                            
                                        WHERE  ID = @ID";

            SqlCommand lCommand = new SqlCommand();
            lCommand.CommandText = lCommandText;
            lCommand.Connection = lConnection;

            lCommand.Parameters.Add(new SqlParameter(@"Name", SqlDbType.NVarChar, 250));
            lCommand.Parameters[@"Name"].Value = pSeasonalName;

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
        public static bool CreateNewSeason(string pSeasonName)
        {
            bool lResult = false;

            SqlConnection lConnection = new SqlConnection();
            lConnection.ConnectionString = ShoeStoreDB.GetConnectionString();

            string lCommandText = @"INSERT INTO SeasonalType( Name )
                                            VALUES ( @Name )";

            SqlCommand lCommand = new SqlCommand();
            lCommand.CommandText = lCommandText;
            lCommand.Connection = lConnection;

            lCommand.Parameters.Add(new SqlParameter(@"Name", SqlDbType.NVarChar, 250));
            lCommand.Parameters[@"Name"].Value = pSeasonName;

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
    }
}
