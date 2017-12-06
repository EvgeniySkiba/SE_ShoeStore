using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;
using System.Data.SqlClient;

namespace ShoeStore.Data
{
    public static class ShoeStoreDB
    {
        private  static string ConnectionString;

        /// <summary>
        /// проверка возможности установки соеденения с БД
        /// </summary>
        /// <returns></returns>
        public  static bool IsCreateConnection()
        {
            bool lResult = false;
            SqlConnection connection = new SqlConnection();
            CreateConnectionString();
            connection.ConnectionString = ShoeStoreDB.ConnectionString;

            try
            {
                connection.Open();
                lResult = true;
            }
            catch (SqlException exc)
            {

            }
                catch(Exception exc){}

            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }

            return lResult;

        }

        public static string GetConnectionString()
        {
            if (string.IsNullOrEmpty(ConnectionString))
            {
                CreateConnectionString();
            }

            return ConnectionString;
        }


        /// <summary>
        /// чтение параметров из текстового файла 
        /// создание строки подключения к БД
        /// </summary>
        private static void CreateConnectionString()
        {
            Uri assemblyUri = new Uri(Assembly.GetExecutingAssembly().CodeBase);
            string filePath = Path.GetDirectoryName(assemblyUri.LocalPath);

            filePath = string.Concat(filePath, "\\", "DataBaseSettings.txt");

            // FileStream fileStream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Read);


            bool error = false;
            try
            {
                StreamReader stream = File.OpenText(filePath);

                if (!error)
                {
                    StringBuilder stringBuilder = new StringBuilder();
                    string read = null;
                    while ((read = stream.ReadLine()) != null)
                    {
                        stringBuilder.Append(read);
                    }

                    stream.Close();

                    ShoeStoreDB.ConnectionString =// @"Data Source=EVGENSE\SQLEXPRESS;Initial Catalog=ShoeStore;Integrated Security=True";
                        stringBuilder.ToString();
                }
                else
                {
                    FileInfo f = new FileInfo(filePath);
                    StreamWriter w = f.CreateText();
                    w.WriteLine("Data Source= SERVER_NAME ;");
                    w.WriteLine("Initial Catalog= DATABASE_NAME;");
                    w.WriteLine("Persist Security Info= True;");
                    w.Write("User ID= USER_NAME;");
                    w.WriteLine("Thanks for your time");
                    w.WriteLine("Password= ES09kiba;");
                    w.Close();
                }
            }
            catch (FileNotFoundException ex)
            {
                error = true;
            }

        }
    }

}
