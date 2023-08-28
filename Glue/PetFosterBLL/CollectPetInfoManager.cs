﻿using Glue.PetFoster.BLL;
using PetFoster.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetFoster.BLL
{
    public class CollectPetInfoManager
    {
        public static DataTable ShowCollectPetInfo(int Limitrow = -1, string Orderby = null)
        {
            DataTable dt = CollectPetInfoServer.CollectPetInfo(Limitrow, Orderby);
            //调试用
            Util.DebugTable(dt);
            return dt;
        }
        public static int GetCollectNums(string PID)
        {
            return CollectPetInfoServer._GetCollectNums(PID);
        }
        public static void GiveACollect(string UID, string PID, bool is_give)
        {
            //调试用
            if (is_give)
            {
                CollectPetInfoServer.InsertCollectPetInfo(UID, PID);
                Console.WriteLine($"{UID} gives a collect to {PID}."); // 输出收藏信息
            }
            else if(!is_give)
            {
                CollectPetInfoServer.DeleteCollectPetInfo(UID, PID);
                Console.WriteLine($"{UID} undo a collect to {PID}."); // 输出收藏信息
            }
            else
            {
                throw new Exception("无效操作");
            }
        }
    }

}
