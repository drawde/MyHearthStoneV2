

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyHearthStoneV2.DAL;
using MyHearthStoneV2.DAL.Impl;
using MyHearthStoneV2.Model;
using MyHearthStoneV2.Common;
using MyHearthStoneV2.Common.Util;
using MyHearthStoneV2.Common.JsonModel;
using MyHearthStoneV2.Common.Enum;

namespace MyHearthStoneV2.BLL
{
    public class GameRecordBll : BaseBLL<HS_GameRecord>
    {
        private IRepository<HS_GameRecord> _repository = new Repository<HS_GameRecord>();
        private GameRecordBll()
        {
        }
        public static GameRecordBll Instance = new GameRecordBll();
        
    }
}
