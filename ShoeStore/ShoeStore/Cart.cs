using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace ShoeStore
{
    public class Cart
    {
        private List<CurrentCart> lineCollection = new List<CurrentCart>();

        public void AddItem(int pProductId, int pQuantity)
        {
            CurrentCart line = lineCollection
                .Where(p => p.ProductId == pProductId).FirstOrDefault();

            if (line == null)
            {   //если данный товар не присутствует в корзине
 
                 DataSet ldataSet = ShoeStore.Data.Product.Product.GetProductValueToCart(pProductId);

                 string lproductname = ldataSet.Tables[0].Rows[0].ItemArray[0].ToString();
                 string lmanufacturename = ldataSet.Tables[0].Rows[0].ItemArray[1].ToString();
                 string country = ldataSet.Tables[0].Rows[0].ItemArray[2].ToString();
                 decimal lcost = Convert.ToDecimal(ldataSet.Tables[0].Rows[0].ItemArray[3].ToString());
                lineCollection.Add(new CurrentCart
                {
                    ProductId = pProductId,
                    Quantity = pQuantity,
                    ProductName = lproductname,
                    Manufacture = lmanufacturename,
                    Country = country  ,
                    Cost = lcost
                });
            }
            else
            {
                //уже в корзине обновить количество
                line.Quantity += pQuantity; 
            }
        }

        public void RemoveItem(int pProductId)
        {
            lineCollection.RemoveAll(l => l.ProductId == pProductId);
        }

        public void Clear()
        {
            lineCollection.Clear();
        }

        public IEnumerable<CurrentCart> Lines
        {
            get { return lineCollection; }
        }

        public int TotalProducts()
        {
            int total = 0;

            foreach (var item in lineCollection)
            {
                total += item.Quantity;
            }

            return total;

        }
        public decimal ComputeToValue()
        {
            decimal result = 0;
            if (lineCollection.Count() > 0)
            {
                foreach (var item in lineCollection)
                {
                    decimal productValue = ShoeStore.Data.Product.Product.ComputeProductsValue(item.ProductId);
                    result += productValue * item.Quantity;
                }
            }
            return result;
        }
    }

}