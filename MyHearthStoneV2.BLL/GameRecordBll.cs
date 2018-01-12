using System;
using System.Collections.Generic;
using System.Linq;
using MyHearthStoneV2.DAL;
using MyHearthStoneV2.DAL.Impl;
using MyHearthStoneV2.Model;
using MyHearthStoneV2.ShortCodeBll;

namespace MyHearthStoneV2.BLL
{
    public class GameRecordBll : BaseBLL<HS_GameRecord>
    {
        private IRepository<HS_GameRecord> _repository = new Repository<HS_GameRecord>();
        private GameRecordBll()
        {
        }
        public static GameRecordBll Instance = new GameRecordBll();

        public List<HS_GameRecord> GetGameRecord(string gameCode,int pageSize,int pageNo)
        {
            return _repository.Get(c => c.GameCode == gameCode, "ID", pageNo, pageSize, false).Result.Items.ToList();
        }
    }
}
