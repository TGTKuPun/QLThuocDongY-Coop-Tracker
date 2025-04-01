using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
using System.Data;

namespace BUS
{
    public class BUS_uOrder
    {
        DAL_uOrder dal_uOrder = new DAL_uOrder();

        public List<DTO_uOrder> getProduct()
        {

            DataTable dt = dal_uOrder.getProduct();
            List<DTO_uOrder> productList = new List<DTO_uOrder>();

            foreach (DataRow row in dt.Rows)
            {
                string pid = row["id_thuoc"].ToString();
                string pname = row["ten_thuoc"].ToString();
                int price = Convert.ToInt32(row["gia_thuoc"]); 
                string unit = row["donvitinh"].ToString();
                float quantity = Convert.ToSingle(row["soluong"]); 

                DTO_uOrder product = new DTO_uOrder(pid, pname, price, unit, quantity);
                productList.Add(product);
            }

            return productList;
        }
    }
}
