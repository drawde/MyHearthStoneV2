using MyHearthStoneV2.DAL;
using MyHearthStoneV2.DAL.Impl;
using MyHearthStoneV2.Model;
using System;
using System.Linq;
using MyHearthStoneV2.Common.Util;
using MyHearthStoneV2.Common.JsonModel;
using MyHearthStoneV2.Common.Enum;
using MyHearthStoneV2.Common;
using MyHearthStoneV2.ShortCodeBll;

namespace MyHearthStoneV2.BLL
{
    public class GameTableBll : BaseBLL<HS_GameTable>
    {
        private IRepository<HS_GameTable> _repository = new Repository<HS_GameTable>();
        private GameTableBll()
        {
        }
        public static GameTableBll Instance = new GameTableBll();
        public HS_GameTable GetTable(string tableCode, string password = "")
        {
            var where = LDMFilter.True<HS_GameTable>();
            where = where.And(c => c.TableCode == tableCode);
            if (password.IsNullOrEmpty() == false)
            {
                where = where.And(c => c.Password == password);
            }
            using (MyHearthStoneV2Context context = new MyHearthStoneV2Context())
            {
                return context.hs_gametable.AsNoTracking().First(where);
            }                
        }

        public HS_GameTable LeaveRoom(string userCode, string tableCode)
        {
            using (MyHearthStoneV2Context context = new MyHearthStoneV2Context())
            {
                var gameTable = context.hs_gametable.AsNoTracking().FirstOrDefault(c => c.TableCode == tableCode);
                if (gameTable != null)
                {
                    if (gameTable.PlayerUserCode == userCode && gameTable.PlayerUserCardGroup.IsNullOrEmpty() == false)
                    {
                        gameTable.PlayerUserCode = "";
                        gameTable.PlayerIsReady = false;
                        gameTable.PlayerUserCardGroup = "";
                        context.SaveChanges();
                    }
                }
                return gameTable;
            }
        }

        public bool Repick(string tableCode, string userCode)
        {
            using (MyHearthStoneV2Context context = new MyHearthStoneV2Context())
            {
                var gameTable = context.hs_gametable.FirstOrDefault(c => c.TableCode == tableCode);
                if (gameTable != null)
                {
                    if (gameTable.PlayerUserCode == userCode)
                    {
                        gameTable.PlayerIsReady = false;
                        gameTable.PlayerUserCardGroup = "";
                    }
                    else if (gameTable.CreateUserCode == userCode)
                    {
                        gameTable.CreateUserIsReady = false;
                        gameTable.CreateUserCardGroup = "";
                    }
                    context.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        public HS_GameTable IAmReady(string tableCode, string userCode, string cardGroupCode)
        {
            using (MyHearthStoneV2Context context = new MyHearthStoneV2Context())
            {
                var gameTable = context.hs_gametable.FirstOrDefault(c => c.TableCode == tableCode);
                if (gameTable != null)
                {
                    if (gameTable.PlayerUserCode == userCode && gameTable.PlayerIsReady == false)
                    {
                        gameTable.PlayerIsReady = true;
                        gameTable.PlayerUserCardGroup = cardGroupCode;
                        context.SaveChanges();
                    }
                    else if (gameTable.CreateUserCode == userCode && gameTable.CreateUserIsReady == false)
                    {
                        gameTable.CreateUserIsReady = true;
                        gameTable.CreateUserCardGroup = cardGroupCode;
                        context.SaveChanges();
                    }                    
                    return gameTable;
                }
            }
            return null;
        }
        public APITextResult AddOrUpdate(HS_GameTable gameTable)
        {
            if (gameTable.CreateUserCode.IsNullOrEmpty() || gameTable.TableName.IsNullOrEmpty())
            {
                return JsonModelResult.PackageFail(OperateResCodeEnum.参数错误);
            }
            if (_repository.Get(c => (c.CreateUserCode == gameTable.CreateUserCode || c.PlayerUserCode == gameTable.CreateUserCode) && gameTable.ID < 1).Result.TotalItemsCount > 0)
            {
                return JsonModelResult.PackageFail(OperateResCodeEnum.同时只能创建或占用一个游戏房间);
            }
            if (gameTable.ID > 0)
            {
                //gameTable.AddTime = _repository.GetByKey(gameTable.ID).Result.AddTime;
                _repository.Update(gameTable);
                return JsonModelResult.PackageSuccess(gameTable.ID.ToString());
            }
            else
            {
                gameTable.TableCode = ShortCodeBusiness.Instance.CreateCode(ShortCodeTypeEnum.TableCode, gameTable.TableName);
                gameTable.PlayerUserCode = "";
                gameTable.AddTime = DateTime.Now;
                using (MyHearthStoneV2Context context = new MyHearthStoneV2Context())
                {
                    context.hs_gametable.Add(gameTable);
                    context.SaveChanges();

                }
                return JsonModelResult.PackageSuccess(gameTable.ID.ToString());
            }
            
        }

        /// <summary>
        /// 占座儿
        /// </summary>
        /// <param name="gameTableID"></param>
        /// <param name="userCode"></param>
        /// <returns></returns>
        public APITextResult ZhanZuoEr(string tableCode, string userCode, string password)
        {
            if (tableCode.IsNullOrEmpty() || userCode.IsNullOrEmpty())
            {
                return JsonModelResult.PackageFail(OperateResCodeEnum.参数错误);
            }
            var gameTable = GetTable(tableCode, password);

            if (gameTable == null)
            {
                return JsonModelResult.PackageFail(OperateResCodeEnum.参数错误);
            }
            
            if (_repository.Get(c => (c.PlayerUserCode == userCode || c.CreateUserCode == userCode) && c.TableCode != tableCode).Result.TotalItemsCount > 0)
            {
                return JsonModelResult.PackageFail(OperateResCodeEnum.同时只能创建或占用一个游戏房间);
            }

            if (!gameTable.PlayerUserCode.IsNullOrEmpty() && gameTable.PlayerUserCode != userCode && gameTable.CreateUserCode != userCode)
            {
                return JsonModelResult.PackageFail(OperateResCodeEnum.这个房间已被其他玩家占用);
            }
            if (gameTable.PlayerUserCode.IsNullOrEmpty() && gameTable.CreateUserCode != userCode)
            {
                gameTable.PlayerUserCode = userCode;
                return JsonModelResult.PackageSuccess(_repository.Update(gameTable).Result.ToString());
            }
            return JsonModelResult.PackageSuccess();
        }
    }
}
