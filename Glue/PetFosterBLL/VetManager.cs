﻿using PetFoster.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetFoster.BLL
{
    public class VetManager
    {
        public static DataTable ShowVetProfile(int Limitrow=-1,string Orderby=null)
        {
            DataTable dt=VetServer.VetInfo(Limitrow,Orderby);
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
            return dt;  //交给连接层转换并返回给前端
        }
        public static DataTable ShowVetProfileForUser(int Limitrow = -1, string Orderby = null)
        {
            DataTable dt = VetServer.VetInfoForApmt(Limitrow, Orderby);
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
            return dt;  //交给连接层转换并返回给前端
        }
        //获取医生照片
        public static byte[] GetPic(string VID) {
            byte[] img=VetServer.GetPortrait(VID).portrait;
            return img;
        }
        //
        public static void SalaryManage(string VID,double sal)
        {
            if (sal < 2000 || sal > 15000)
                Console.WriteLine("工资太高或太低！");
            PetFoster.Model.Vet vet=VetServer.GetVet(VID);
            VetServer.UpdateVet(vet.vet_name, sal, vet.phone_number, vet.working_start_hr, vet.working_start_min, vet.working_end_hr, vet.working_end_min);

        }
        //
        public static void LabourManage(string VID, DateTime dtstart,DateTime dtend)
        {
            if (dtstart.Hour<=8 ||dtend.Hour>=10||dtend.Hour-dtstart.Hour>8)
                Console.WriteLine("违反《劳动法》！");
            PetFoster.Model.Vet vet = VetServer.GetVet(VID);
            VetServer.UpdateVet(vet.vet_name, vet.salary, vet.phone_number, dtstart.Hour, dtstart.Minute, dtend.Hour, dtend.Minute);
        }
    }
}
