using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace ShoeStore.Data.Product
{
    public static class Product
    {

        public static int CreateProduct(int pColorId, int pSizeId, int pSexId, int pMaterialTypeId,
            int pManufactureId, int pSeasonId, int pTypeId, string pName, decimal pCost, string pCode, 
            string pDescription)
        {
            int lresult = 0;

            SqlConnection lConnection = new SqlConnection();
            lConnection.ConnectionString = ShoeStoreDB.GetConnectionString();

            SqlCommand lCommand = new SqlCommand("CreateProduct", lConnection);
            lCommand.CommandType = System.Data.CommandType.StoredProcedure;


            lCommand.Parameters.Add(new SqlParameter(@"Name", SqlDbType.NVarChar, 255));
            lCommand.Parameters[@"Name"].Value = pName;

            lCommand.Parameters.Add(new SqlParameter(@"ColorId", SqlDbType.Int));
            lCommand.Parameters[@"ColorId"].Value = pColorId;

            lCommand.Parameters.Add(new SqlParameter(@"SizeId", SqlDbType.Int));
            lCommand.Parameters[@"SizeId"].Value = pSizeId;

            lCommand.Parameters.Add(new SqlParameter(@"SexId", SqlDbType.Int));
            lCommand.Parameters[@"SexId"].Value = pSexId;

            lCommand.Parameters.Add(new SqlParameter(@"TypeId", SqlDbType.Int));
            lCommand.Parameters[@"TypeId"].Value = pTypeId;

            lCommand.Parameters.Add(new SqlParameter(@"MaterialTypeID", SqlDbType.Int));
            lCommand.Parameters[@"MaterialTypeID"].Value = pMaterialTypeId;

            lCommand.Parameters.Add(new SqlParameter(@"ManufactureID", SqlDbType.Int));
            lCommand.Parameters[@"ManufactureID"].Value = pManufactureId;

            lCommand.Parameters.Add(new SqlParameter(@"SeasonId", SqlDbType.Int));
            lCommand.Parameters[@"SeasonId"].Value = pSeasonId;

            lCommand.Parameters.Add(new SqlParameter(@"cost", SqlDbType.Decimal));
            lCommand.Parameters[@"cost"].Value = pCost;

            lCommand.Parameters.Add(new SqlParameter(@"DescriptionText", SqlDbType.NText));
            lCommand.Parameters[@"DescriptionText"].Value = pDescription;

            lCommand.Parameters.Add(new SqlParameter(@"Code", SqlDbType.NVarChar, 255));
            lCommand.Parameters[@"Code"].Value = pCode;

            //lCommand.Parameters.Add(new SqlParameter(@"CountItem", SqlDbType.Int));
            //lCommand.Parameters[@"CountItem"].Value = pcount;

            lCommand.Parameters.Add(new SqlParameter(@"NewProductId", SqlDbType.Int));
            lCommand.Parameters[@"NewProductId"].Direction = ParameterDirection.Output;
            try
            {
                lConnection.Open();
                lCommand.ExecuteNonQuery();
                lresult = (int)lCommand.Parameters[@"NewProductId"].Value;
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

        public static string GetProductTitleImage(int pProductId)
        {
            string lresult = string.Empty;

            SqlConnection lConnection = new SqlConnection();
            lConnection.ConnectionString = ShoeStoreDB.GetConnectionString();

            SqlCommand lCommand = new SqlCommand("GetProductTitleImage", lConnection);
            lCommand.CommandType = System.Data.CommandType.StoredProcedure;


            lCommand.Parameters.Add(new SqlParameter(@"ProductId", SqlDbType.Int));
            lCommand.Parameters[@"ProductId"].Value = pProductId;

            try
            {
                lConnection.Open();
                lresult = (string)lCommand.ExecuteScalar();
                // lresult = (int)lcommand.Parameters[@"NewProductId"].Value;
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

        /// <summary>
        ///  get product by product id 
        /// </summary>
        /// <param name="pId">product id</param>
        public static DataSet GetProductById(int pProductId)
        {
            DataSet ldataSet = new DataSet();

            SqlConnection lconnection = new SqlConnection();
            lconnection.ConnectionString = ShoeStoreDB.GetConnectionString();

            SqlCommand lcommand = new SqlCommand("GetProductsInfoById", lconnection);
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

        public static DataSet GetProductByIdFullInfo(int pProductId)
        {
            DataSet ldataSet = new DataSet();

            SqlConnection lconnection = new SqlConnection();
            lconnection.ConnectionString = ShoeStoreDB.GetConnectionString();

            SqlCommand lcommand = new SqlCommand("GetProductByIdFullInfo", lconnection);
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



        /// <summary>
        /// updated product information
        /// </summary>
        /// <param name="pProduxtId">product id </param>
        /// <param name="pname">name</param>
        /// <param name="pcode">inner code, articul</param>
        /// <param name="pmanufactureId">manufacture id </param>
        /// <param name="pcolorId">color id </param>
        /// <param name="pmaterialId">matrerial id</param>
        /// <param name="psizeId">size id</param>
        /// <param name="psexId">size id</param>
        /// <param name="pseasonId">season id</param>
        /// <param name="typeId">current type id</param>
        /// <param name="pdescriptionId">products description</param>
        /// <param name="pCost">value of goods</param>
        /// <returns></returns>         
        public static bool UpdateProduct(int pProductId, string pname, string pcode, int pmanufactureId,
            int pcolorId, int pmaterialId, int psizeId, int psexId, int pseasonId, int typeId, string pdescription,
            decimal pCost)
        {
            bool lresult = false;

            SqlConnection lconnection = new SqlConnection();
            lconnection.ConnectionString = ShoeStoreDB.GetConnectionString();

            SqlCommand lCommand = new SqlCommand("[UpdateProductById]", lconnection);
            lCommand.CommandType = System.Data.CommandType.StoredProcedure;


            lCommand.Parameters.Add(new SqlParameter(@"name", SqlDbType.NVarChar, 255));
            lCommand.Parameters[@"name"].Value = pname;

            lCommand.Parameters.Add(new SqlParameter(@"Code", SqlDbType.NVarChar, 255));
            lCommand.Parameters[@"Code"].Value = pcode;

            lCommand.Parameters.Add(new SqlParameter(@"manufactureID", SqlDbType.Int));
            lCommand.Parameters[@"manufactureID"].Value = pmanufactureId;

            lCommand.Parameters.Add(new SqlParameter(@"ColorID", SqlDbType.Int));
            lCommand.Parameters[@"ColorID"].Value = pcolorId;

            lCommand.Parameters.Add(new SqlParameter(@"MaterialID", SqlDbType.Int));
            lCommand.Parameters[@"MaterialID"].Value = pmaterialId;

            lCommand.Parameters.Add(new SqlParameter(@"SizeID", SqlDbType.Int));
            lCommand.Parameters[@"SizeID"].Value = psizeId;

            lCommand.Parameters.Add(new SqlParameter(@"SexID", SqlDbType.Int));
            lCommand.Parameters[@"SexID"].Value = psexId;

            lCommand.Parameters.Add(new SqlParameter(@"SesonID", SqlDbType.Int));
            lCommand.Parameters[@"SesonID"].Value = pseasonId;

            lCommand.Parameters.Add(new SqlParameter(@"TypeID", SqlDbType.Int));
            lCommand.Parameters[@"TypeID"].Value = typeId;

            lCommand.Parameters.Add(new SqlParameter(@"Desctiption", SqlDbType.NText));
            lCommand.Parameters[@"Desctiption"].Value = pdescription;

            lCommand.Parameters.Add(new SqlParameter(@"Cost", SqlDbType.Decimal));
            lCommand.Parameters[@"Cost"].Value = pCost;

            //lCommand.Parameters.Add(new SqlParameter(@"Count", SqlDbType.Int));
            //lCommand.Parameters[@"Count"].Value = typeId;

            lCommand.Parameters.Add(new SqlParameter(@"ProductID", SqlDbType.Int));
            lCommand.Parameters[@"ProductID"].Value = pProductId;

            try
            {
                lconnection.Open();
                lCommand.ExecuteNonQuery();
                lresult = true;
            }
            catch (Exception ex) { }
            finally
            {
                if (lconnection.State == ConnectionState.Open)
                {
                    lconnection.Close();
                }
            }
            return lresult;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pProductId"></param>
        /// <returns></returns>
        public static DataSet GetSizeForCurrentProduct(int pProductId)
        {
            DataSet dataSet = new DataSet();

            SqlConnection lConnection = new SqlConnection();
            lConnection.ConnectionString = ShoeStoreDB.GetConnectionString();

            string lCommandString = @"SELECT Size.ID, Size.Size
                                        FROM ProductSize INNER JOIN
                                             Size ON ProductSize.SizeID = Size.ID
                                             AND ProductSize.ProductID = @Productid";

            SqlCommand lCommand = new SqlCommand(lCommandString, lConnection);

            lCommand.Parameters.Add(new SqlParameter(@"Productid", SqlDbType.Int));
            lCommand.Parameters[@"Productid"].Value = pProductId;


            SqlDataAdapter adapter = new SqlDataAdapter(lCommand);

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
        ///  receiving data according to the selected size
        /// </summary>
        /// <param name="pProductId"></param>
        /// <param name="psize"></param>
        /// <returns></returns>
        public static DataSet GetProductBySize(int pProductId, int psize)
        {
            DataSet ldataSet = new DataSet();

            SqlConnection lconnection = new SqlConnection();
            lconnection.ConnectionString = ShoeStoreDB.GetConnectionString();

            SqlCommand lcommand = new SqlCommand("GetProductsInfoById", lconnection);
            lcommand.CommandType = System.Data.CommandType.StoredProcedure;


            lcommand.Parameters.Add(new SqlParameter(@"ProductId", SqlDbType.Int));
            lcommand.Parameters[@"ProductId"].Value = pProductId;

            lcommand.Parameters.Add(new SqlParameter(@"Size", SqlDbType.Int));
            lcommand.Parameters[@"Size"].Value = psize;

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

        /// <summary>
        /// add new rebview for product to data base
        /// </summary>
        /// <param name="pProductId"></param>
        /// <param name="puserName"></param>
        /// <param name="ptext"></param>
        public static bool SetReviewForProduct(int pProductId, string puserName, string ptext)
        {
            //@userName nvarchar(255),@Text nvarChar(max), @productID int 

            bool lresult = false;

            SqlConnection lconnection = new SqlConnection();
            lconnection.ConnectionString = ShoeStoreDB.GetConnectionString();

            SqlCommand lcommand = new SqlCommand("CreateReview", lconnection);
            lcommand.CommandType = System.Data.CommandType.StoredProcedure;


            lcommand.Parameters.Add(new SqlParameter(@"ProductId", SqlDbType.Int));
            lcommand.Parameters[@"ProductId"].Value = pProductId;

            lcommand.Parameters.Add(new SqlParameter(@"Text", SqlDbType.NText));
            lcommand.Parameters[@"Text"].Value = ptext;

            lcommand.Parameters.Add(new SqlParameter(@"userName", SqlDbType.NVarChar, 255));
            lcommand.Parameters[@"userName"].Value = puserName;


            try
            {
                lconnection.Open();
                lcommand.ExecuteNonQuery();
                lresult = true;
                // lresult = (int)lcommand.Parameters[@"NewProductId"].Value;
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

        public static decimal ComputeProductsValue(int productId)
        {
            decimal lresult = 0;

            SqlConnection lconnection = new SqlConnection();
            lconnection.ConnectionString = ShoeStoreDB.GetConnectionString();

            string lcommandText = "select Cost  From product where id  = @ProductId";
            SqlCommand lcommand = new SqlCommand(lcommandText, lconnection);

            lcommand.Parameters.Add(new SqlParameter(@"ProductId", SqlDbType.Int));
            lcommand.Parameters[@"ProductId"].Value = productId;

            try
            {
                lconnection.Open();
                lresult = (decimal)lcommand.ExecuteScalar();
                // lresult = (int)lcommand.Parameters[@"NewProductId"].Value;
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

        public static DataSet GetProductValueToCart(int productId)
        {
            DataSet ldataSet = new DataSet();

            SqlConnection lconnection = new SqlConnection();
            lconnection.ConnectionString = ShoeStoreDB.GetConnectionString();

            string lcommandText = @"SELECT  Product.Name, Manufacture.Name AS ManufactyreName, Manufacture.Country,Product.Cost
                                     FROM   Product INNER JOIN Manufacture ON Product.ManufacturedId = Manufacture.ID
                                    WHERE   Product.ID  = @ProductId";

            SqlCommand lcommand = new SqlCommand(lcommandText, lconnection);

            lcommand.Parameters.Add(new SqlParameter(@"ProductId", SqlDbType.Int));
            lcommand.Parameters[@"ProductId"].Value = productId;

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

        public static bool DeleteProduct(int productId)
        {
            bool lresult = false;

            SqlConnection lconnection = new SqlConnection();
            lconnection.ConnectionString = ShoeStoreDB.GetConnectionString();
          
            SqlCommand lcommand = new SqlCommand("deleteProduct", lconnection);
            lcommand.CommandType = System.Data.CommandType.StoredProcedure;

            lcommand.Parameters.Add(new SqlParameter(@"ProductId", SqlDbType.Int));   
            lcommand.Parameters[@"ProductId"].Value = productId;
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

        public static int GetProductCount(int pProductId,int psizeId)
        {
            int lresult = 0;

            SqlConnection lconnection = new SqlConnection();
            lconnection.ConnectionString = ShoeStoreDB.GetConnectionString();

            SqlCommand lcommand = new SqlCommand("GetProductCount", lconnection);
            lcommand.CommandType = System.Data.CommandType.StoredProcedure;

            lcommand.Parameters.Add(new SqlParameter(@"ProductId", SqlDbType.Int));
            lcommand.Parameters[@"ProductId"].Value = pProductId;

            lcommand.Parameters.Add(new SqlParameter(@"SizeID", SqlDbType.Int));
            lcommand.Parameters[@"SizeID"].Value = psizeId; ;

            try
            {
                lconnection.Open();
                lresult = (int)lcommand.ExecuteScalar();
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


        public static DataSet GetCurrentSize(int productId)
        {
            DataSet lresultDataSet = new DataSet();

          
            // DataTable  dataTable = new DataTable();

            SqlConnection lConnection = new SqlConnection();
            lConnection.ConnectionString = ShoeStoreDB.GetConnectionString();

            string lCommandString = @"SELECT ID,Name,Country,CreationDate,Code,Description FROM Manufacture";

            // Создаем и настраиваем экземпляр класса SqlDataAdapter
            SqlDataAdapter adapter = new SqlDataAdapter(lCommandString, lConnection);

            try
            {
                // lconnection.Open();
                adapter.Fill(lresultDataSet, "Manufacture");
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
        
            return lresultDataSet;
        }

    }
}
