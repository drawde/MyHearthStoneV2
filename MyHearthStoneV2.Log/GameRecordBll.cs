using MyHearthStoneV2.DAL;
using MyHearthStoneV2.DAL.Impl;
using MyHearthStoneV2.Model;

namespace MyHearthStoneV2.Log
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
