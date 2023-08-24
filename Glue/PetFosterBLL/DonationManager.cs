using Glue.PetFoster.BLL;
using PetFoster.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetFoster.BLL
{
    public class DonationManager
    {
        public static DataTable ShowDonation(int Limitrow = -1, string Orderby = null)
        {
            DataTable dt = DonationServer.DonationInfo(Limitrow, Orderby);
            //调试用
            Console.WriteLine("开始显示捐款列表");
            return dt;
        }
        //添加捐款信息（未审核）
        public static int Donate(string DID, decimal Amount)
        {
            if (Amount < 0)
            {
                Console.WriteLine("请不要输入负数金额的捐款！");
                return -1;
            }
            else if (Amount > 100000000)
            {
                Console.WriteLine("捐款数额过于巨大，请慎重考虑！");
                return -2;
            }
            DonationServer.TryDonote(DID, Amount);
            return 0;
        }
        public static void ShowDonationAmount(int Limitrow = -1, string Orderby = null)
        {
            DataTable dt = DonationServer.DonationAmount(Limitrow, Orderby);
            //调试用
            foreach (DataColumn column in dt.Columns)
            {
                Console.Write("{0,-15}", column.ColumnName);
            }
            Console.WriteLine();

            foreach (DataRow row in dt.Rows)
            {
                foreach (var item in row.ItemArray)
                {
                    Console.Write("{0,-15}", item);
                }
                Console.WriteLine();
            }
        }
    }
}
