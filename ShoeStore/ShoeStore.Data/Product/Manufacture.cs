using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace ShoeStore.Data.Product
{
    public static class Manufacture
    {
        /// <summary>
        /// get list current company 
        /// </summary>
        /// <returns></returns>
        public static DataSet GetManufacture()
        {
            DataSet dataSet = new DataSet();
            // DataTable  dataTable = new DataTable();

            SqlConnection lConnection = new SqlConnection();
            lConnection.ConnectionString = ShoeStoreDB.GetConnectionString();

            string lCommandString = @"SELECT ID,Name,Country,CreationDate,Code,Description FROM Manufacture";

            // Создаем и настраиваем экземпляр класса SqlDataAdapter
            SqlDataAdapter adapter = new SqlDataAdapter(lCommandString, lConnection);

            try
            {
                // lconnection.Open();
                adapter.Fill(dataSet, "Manufacture");
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

            DataView dataView = new DataView(dataSet.Tables[0]);
            return dataSet;//.Tables[0];
        }

        /// <summary>
        /// обновление текущего значения для указанного производителя
        /// </summary>
        /// <param name="pId">id</param>
        /// <param name="pCompanyName">Company Name</param>
        /// <param name="pCountry">Country for Manufacture</param>
        /// <param name="pCode">internal manufacturer code</param>
        /// <param name="pCreateDate">date of the founding of the company</param>
        /// <param name="pDecription">Text description of the company</param>
        /// <returns>successful making changes</returns>
        public static bool UpdateManufacture(int pId, string pCompanyName, string pCountry, string pCode, DateTime pCreateDate, string pDecription)
        {
            bool lResult = false;

            SqlConnection lConnection = new SqlConnection();
            lConnection.ConnectionString = ShoeStoreDB.GetConnectionString();

            string lCommandText = @"UPDATE Manufacture
                                         SET Name = @Name
                                            ,Country = @Country
                                            ,CreationDate = @CreationDate
                                            ,Code = @Code
                                            ,Description = @Description
                                        WHERE  ID = @ID";

            SqlCommand lCommand = new SqlCommand();
            lCommand.CommandText = lCommandText;
            lCommand.Connection = lConnection;

            lCommand.Parameters.Add(new SqlParameter(@"Name", SqlDbType.NVarChar, 250));
            lCommand.Parameters[@"Name"].Value = pCompanyName;


            lCommand.Parameters.Add(new SqlParameter(@"Country", SqlDbType.NVarChar, 250));
            lCommand.Parameters[@"Country"].Value = pCountry;
                                                               
            lCommand.Parameters.Add(new SqlParameter(@"CreationDate", SqlDbType.SmallDateTime));
            lCommand.Parameters[@"CreationDate"].Value = pCreateDate;

            lCommand.Parameters.Add(new SqlParameter(@"Code", SqlDbType.NVarChar, 50));
            lCommand.Parameters[@"Code"].Value = pCode;

            lCommand.Parameters.Add(new SqlParameter(@"Description", SqlDbType.NVarChar, 400));
            lCommand.Parameters[@"Description"].Value = pCompanyName;

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
        /// Delete manufacture in database 
        /// </summary>
        /// <param name="pManufactureId">id</param>
        /// <returns>successful making changes</returns>
        public static int DeleteManufacture(int pManufactureId)
        {
            int lResult = 0;

            SqlConnection lConnection = new SqlConnection();
            lConnection.ConnectionString = ShoeStoreDB.GetConnectionString();

            string lCommandString = @"DELETE FROM Manufacture WHERE ID = @ID";

            SqlCommand lCommand = new SqlCommand(lCommandString, lConnection);
            lCommand.Parameters.AddWithValue("@ID", pManufactureId);

            try
            {
                lConnection.Open();
                lCommand.ExecuteNonQuery();
                lResult = 0;
            }
            catch (SqlException exc)
            {
                lResult = 1;
            }
            catch (Exception ex)
            {
                lResult = 2;
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
        /// insert new company to dataBase
        /// </summary>
        /// <param name="pId">id</param>
        /// <param name="pCompanyName">Company Name</param>
        /// <param name="pCountry">Country for Manufacture</param>
        /// <param name="pCode">internal manufacturer code</param>
        /// <param name="pCreateDate">date of the founding of the company</param>
        /// <param name="pDecription">Text description of the company</param>
        /// <returns>successful making changes</returns>
        public static bool CreateNewManufacture(string pCompanyName, string pCountry, string pCode, DateTime pCreateDate, string pDecription)
        {
            bool lResult = false;

            SqlConnection lConnection = new SqlConnection();
            lConnection.ConnectionString = ShoeStoreDB.GetConnectionString();

            string lCommandText = @"INSERT INTO Manufacture
                                                (Name
                                                ,Country
                                                ,CreationDate
                                                ,Code
                                                ,Description)
                                            VALUES
                                                (@Name
                                                ,@Country
                                                ,@CreationDate
                                                ,@Code
                                                ,@Description)";

            SqlCommand lCommand = new SqlCommand();
            lCommand.CommandText = lCommandText;
            lCommand.Connection = lConnection;

            lCommand.Parameters.Add(new SqlParameter(@"Name", SqlDbType.NVarChar, 250));
            lCommand.Parameters[@"Name"].Value = pCompanyName;


            lCommand.Parameters.Add(new SqlParameter(@"Country", SqlDbType.NVarChar, 250));
            lCommand.Parameters[@"Country"].Value = pCountry;


            lCommand.Parameters.Add(new SqlParameter(@"CreationDate", SqlDbType.SmallDateTime));
            lCommand.Parameters[@"CreationDate"].Value = pCreateDate;

            lCommand.Parameters.Add(new SqlParameter(@"Code", SqlDbType.NVarChar, 50));
            lCommand.Parameters[@"Code"].Value = pCode;

            lCommand.Parameters.Add(new SqlParameter(@"Description", SqlDbType.NVarChar, 400));
            lCommand.Parameters[@"Description"].Value = pCompanyName;

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
