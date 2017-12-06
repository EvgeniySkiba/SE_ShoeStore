using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace ShoeStore.Data.Product
{
    public static class ProductsColor
    {
        public static DataSet GetColors()
        {
            DataSet dataSet = new DataSet();
           
            SqlConnection lConnection = new SqlConnection();
            lConnection.ConnectionString = ShoeStoreDB.GetConnectionString();

            string lCommandString = @"SELECT ID, ColorName FROM ColorType";

            // Создаем и настраиваем экземпляр класса SqlDataAdapter
            SqlDataAdapter adapter = new SqlDataAdapter(lCommandString, lConnection);

            try
            {
                adapter.Fill(dataSet, "ColorType");
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
        public static bool AddColors(string pColor)
        {
            bool result = false;

            SqlConnection lConnection = new SqlConnection();
            lConnection.ConnectionString = ShoeStoreDB.GetConnectionString(); 
            string lSqlCommandstring = @"INSERT INTO ColorType(ColorName)VALUES(@ColorName)";
            SqlCommand lCommand = new SqlCommand(lSqlCommandstring, lConnection);
            lCommand.Parameters.AddWithValue("@ColorName",pColor);
         
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
        public static int DeleteColors(int pColorId)
        {
            int lResult = 0;

            SqlConnection lConnection = new SqlConnection();
            lConnection.ConnectionString = ShoeStoreDB.GetConnectionString();
            string lSqlCommandstring = @"DELETE FROM ColorType WHERE ID = @ID";
            SqlCommand lCommand = new SqlCommand(lSqlCommandstring, lConnection);
            lCommand.Parameters.AddWithValue("@ID", pColorId);

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
        public static bool EditColors(int pColorId,string pcolor)
        {
            bool lResult = false;

            SqlConnection lConnection = new SqlConnection();
            lConnection.ConnectionString = ShoeStoreDB.GetConnectionString();
            string lSqlCommandstring = @"UPDATE ColorType SET ColorName = @ColorName WHERE ID=@ID";            
            SqlCommand lCommand = new SqlCommand(lSqlCommandstring, lConnection);

            lCommand.Parameters.Add(new SqlParameter(@"ID", SqlDbType.Int));
            lCommand.Parameters[@"ID"].Value = pColorId;

            lCommand.Parameters.Add(new SqlParameter(@"ColorName", SqlDbType.NVarChar, 255));
            lCommand.Parameters[@"ColorName"].Value = pcolor;

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
