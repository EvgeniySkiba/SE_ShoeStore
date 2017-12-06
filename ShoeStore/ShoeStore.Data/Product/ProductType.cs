using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace ShoeStore.Data.Product
{
    public static class ProductType
    {
        public static DataSet GetTypes()
        {
            DataSet dataSet = new DataSet();

            SqlConnection lConnection = new SqlConnection();
            lConnection.ConnectionString = ShoeStoreDB.GetConnectionString();

            string lCommandString = @"SELECT ID,TypeItem FROM TypeItem";

            // Создаем и настраиваем экземпляр класса SqlDataAdapter
            SqlDataAdapter adapter = new SqlDataAdapter(lCommandString, lConnection);

            try
            {
                adapter.Fill(dataSet);
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
        /// inser new color value to db 
        /// </summary>
        /// <param name="pColor">color name</param>
        /// <returns></returns>
        public static bool AddType(string pTypeName)
        {
            bool result = false;

            SqlConnection lConnection = new SqlConnection();
            lConnection.ConnectionString = ShoeStoreDB.GetConnectionString();
            string lSqlCommandstring = @"INSERT INTO TypeItem VALUES(@TypeName)";

            SqlCommand lCommand = new SqlCommand(lSqlCommandstring, lConnection);
            lCommand.Parameters.AddWithValue("@TypeName", pTypeName);

            try
            {
                lConnection.Open();
                lCommand.ExecuteNonQuery();
                result = true;
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

            return result;
        }

        /// <summary>
        /// delete colors from db
        /// </summary>
        /// <param name="pColor">id color for deleting</param>
        /// <returns></returns>
        public static int DeleteType(int ptypeId)
        {
            int lResult = 0;

            SqlConnection lConnection = new SqlConnection();
            lConnection.ConnectionString = ShoeStoreDB.GetConnectionString();
            string lSqlCommandstring = @"DELETE FROM TypeItem WHERE ID = @ID";
            SqlCommand lCommand = new SqlCommand(lSqlCommandstring, lConnection);
            lCommand.Parameters.AddWithValue("@ID", ptypeId);

            try
            {
                lConnection.Open();
                lCommand.ExecuteNonQuery();
                lResult = 0;
            }
            catch (SqlException exc)
            {
                lResult = 2;
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
        /// delete colors from db
        /// </summary>
        /// <param name="pColor">id color for deleting</param>
        /// <returns></returns>
        public static bool EditType(int pColorId, string ptype)
        {
            bool lResult = false;

            SqlConnection lConnection = new SqlConnection();
            lConnection.ConnectionString = ShoeStoreDB.GetConnectionString();
            string lSqlCommandstring = @"UPDATE TypeItem SET TypeItem = @TypeItem WHERE ID=@ID";
            SqlCommand lCommand = new SqlCommand(lSqlCommandstring, lConnection);

            lCommand.Parameters.Add(new SqlParameter(@"ID", SqlDbType.Int));
            lCommand.Parameters[@"ID"].Value = pColorId;

            lCommand.Parameters.Add(new SqlParameter(@"TypeItem", SqlDbType.NVarChar, 255));
            lCommand.Parameters[@"TypeItem"].Value = ptype;

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
    }
}
