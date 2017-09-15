using MyHearthStoneV2.DAL;
using MyHearthStoneV2.DAL.Impl;
using MyHearthStoneV2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyHearthStoneV2.Common.Util;
using MyHearthStoneV2.Common.JsonModel;
using MyHearthStoneV2.Common.Enum;

namespace MyHearthStoneV2.BLL
{
    public class GameTableBll : BaseBLL<HS_GameTable>
    {
        private IRepository<HS_GameTable> _repository = new Repository<HS_GameTable>();
        private GameTableBll()
        {
        }
        public static GameTableBll Instance = new GameTableBll();

        public APITextResult AddOrUpdate(HS_GameTable gameTable)
        {
            if (gameTable.CreateUserCode.IsNullOrEmpty() || gameTable.TableName.IsNullOrEmpty())
            {
                return JsonModelResult.PackageFail(OperateResCodeEnum.参数错误);
            }
            if (_repository.Get(c => c.CreateUserCode == gameTable.CreateUserCode && gameTable.ID == 0).Result.TotalItemsCount > 0)
            {
                return JsonModelResult.PackageFail(OperateResCodeEnum.同时只能创建或占用一个游戏房间);
            }
            if (gameTable.ID > 0)
            {
                gameTable.AddTime = _repository.GetByKey(gameTable.ID).Result.AddTime;
                _repository.Update(gameTable);
            }
            else
            {
                gameTable.PlayerUserCode = "";
                gameTable.AddTime = DateTime.Now;
                _repository.Insert(gameTable);
            }
            return JsonModelResult.PackageSuccess();
        }

        /// <summary>
        /// 占座儿
        /// </summary>
        /// <param name="gameTableID"></param>
        /// <param name="userCode"></param>
        /// <returns></returns>
        public APITextResult ZhanZuoer(int gameTableID, string userCode)
        {
            if (gameTableID < 1 || userCode.IsNullOrEmpty())
            {
                return JsonModelResult.PackageFail(OperateResCodeEnum.参数错误);
            }
            var gameTable = _repository.GetByKey(gameTableID).Result;
            if (gameTable == null || gameTable.CreateUserCode == userCode)
            {
                return JsonModelResult.PackageFail(OperateResCodeEnum.同时只能创建或占用一个游戏房间);
            }
            if (!gameTable.PlayerUserCode.IsNullOrEmpty())
            {
                return JsonModelResult.PackageFail(OperateResCodeEnum.这个房间已被其他玩家占用);
            }
            if (_repository.Get(c => c.PlayerUserCode == userCode).Result.TotalItemsCount > 0)
            {
                return JsonModelResult.PackageFail(OperateResCodeEnum.同时只能创建或占用一个游戏房间);
            }
            gameTable.PlayerUserCode = userCode;            
            return JsonModelResult.PackageSuccess(_repository.Update(gameTable).Result.ToString());
        }
    }
}
