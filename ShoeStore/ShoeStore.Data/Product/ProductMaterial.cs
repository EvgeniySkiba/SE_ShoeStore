using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace ShoeStore.Data.Product
{
    public static class ProductMaterial
    {
        /// <summary>
        /// получение списка всех материалов
        /// </summary>
        /// <returns></returns>
        public static DataSet GetMaterial()
        {
            DataSet dataSet = new DataSet();
           
            SqlConnection lConnection = new SqlConnection();
            lConnection.ConnectionString = ShoeStoreDB.GetConnectionString();

            string lCommandString = @"SELECT ID,MaterialType FROM MaterialType";

            // Создаем и настраиваем экземпляр класса SqlDataAdapter
            SqlDataAdapter adapter = new SqlDataAdapter(lCommandString, lConnection);

            try
            {
                // lconnection.Open();
                adapter.Fill(dataSet, "MaterialType");
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

        public static bool DeleteMaterial(int pMaterialId)
        {
            bool lResult = false;

            SqlConnection lConnection = new SqlConnection();
            lConnection.ConnectionString = ShoeStoreDB.GetConnectionString();
            string lSqlCommandstring = @"DELETE FROM MaterialType WHERE ID = @ID";
            SqlCommand lCommand = new SqlCommand(lSqlCommandstring, lConnection);
            lCommand.Parameters.AddWithValue("@ID", pMaterialId);

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
        /// обновление записи в БД
        /// </summary>
        /// <param name="pId"></param>
        /// <param name="pMaterial"></param>
        /// <returns></returns>
        public static int UpdateMaterial(int pId, string pMaterial)
        {
            int lResult = 0;

            SqlConnection lConnection = new SqlConnection();
            lConnection.ConnectionString = ShoeStoreDB.GetConnectionString();

            string lCommandText = @"UPDATE MaterialType
                                         SET MaterialType = @MaterialType                                            
                                        WHERE  ID = @ID";

            SqlCommand lCommand = new SqlCommand();
            lCommand.CommandText = lCommandText;
            lCommand.Connection = lConnection;

            lCommand.Parameters.Add(new SqlParameter(@"MaterialType", SqlDbType.NVarChar, 250));
            lCommand.Parameters[@"MaterialType"].Value = pMaterial; 

            lCommand.Parameters.Add(new SqlParameter(@"ID", SqlDbType.Int));
            lCommand.Parameters[@"ID"].Value = pId;


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
        /// создание новой записи 
        /// </summary>
        /// <param name="pMaterialName">название материала</param>

        public static bool CreateNewMaterial(string pMaterialName)
        {
            bool lResult = false;

            SqlConnection lConnection = new SqlConnection();
            lConnection.ConnectionString = ShoeStoreDB.GetConnectionString();

            string lCommandText = @"INSERT INTO MaterialType( MaterialType )
                                            VALUES ( @MaterialType )";



            SqlCommand lCommand = new SqlCommand();
            lCommand.CommandText = lCommandText;
            lCommand.Connection = lConnection;

            lCommand.Parameters.Add(new SqlParameter(@"MaterialType", SqlDbType.NVarChar, 250));
            lCommand.Parameters[@"MaterialType"].Value = pMaterialName;  

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
