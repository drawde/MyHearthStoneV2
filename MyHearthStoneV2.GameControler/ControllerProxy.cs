using MyHearthStoneV2.BLL;
using MyHearthStoneV2.Common.Util;
using MyHearthStoneV2.Game;
using MyHearthStoneV2.GameControler;
using MyHearthStoneV2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyHearthStoneV2.Common.JsonModel;
using MyHearthStoneV2.Common.Enum;
using MyHearthStoneV2.Redis;

namespace MyHearthStoneV2.GameControler
{
    /// <summary>
    /// 游戏控制器代理
    /// </summary>
    public class ControllerProxy
    {
        /// <summary>
        /// 当前环境下的所有控制器
        /// </summary>
        //public static List<Controler> lstCtl
        //{
        //    get
        //    {
        //        using (var redisClient = RedisManager.GetClient())
        //        {
        //            return redisClient.Get<List<Controler>>(ConfigEnum.GameControllers.ToString());
        //        }
        //    }
        //    set
        //    {
        //        using (var redisClient = RedisManager.GetClient())
        //        {
        //            redisClient.Set(ConfigEnum.GameControllers.ToString(), value);
        //        }
        //    }
        //}

        
        //private static Controler CtlInstance(string gameID)
        //{
        //    return lstCtl.First(c => c.GameID == gameID);
        //}
        /// <summary>
        /// 创建一局游戏
        /// </summary>
        /// <param name="firstPlayerCode">先手玩家</param>
        /// <param name="secondPlayerCode">后手玩家</param>
        /// <param name="fristCardGroupCode">先手玩家卡组</param>
        /// <param name="secondCardGroupCode">后手玩家卡组</param>
        /// <returns>游戏ID</returns>
        public static string CreateGame(string firstPlayerCode, string secondPlayerCode, string fristCardGroupCode, string secondCardGroupCode)
        {
            string res = JsonStringResult.VerifyFail();
            string gameID = "";
            try
            {
                //if (lstCtl == null)
                //{
                //    lstCtl = new List<Controler>();
                //}

                if (firstPlayerCode.IsNullOrEmpty() || secondPlayerCode.IsNullOrEmpty() || fristCardGroupCode.IsNullOrEmpty() || secondCardGroupCode.IsNullOrEmpty())
                {
                    res = JsonStringResult.Error(OperateResCodeEnum.参数错误);
                    return res;
                }

                HS_Users firstUser = UsersBll.Instance.GetUserByAdmin(firstPlayerCode);
                if (firstUser == null)
                {
                    res = JsonStringResult.Error(OperateResCodeEnum.参数错误);
                    return res;
                }

                HS_Users secondUser = UsersBll.Instance.GetUserByAdmin(secondPlayerCode);
                if (secondUser == null)
                {
                    res = JsonStringResult.Error(OperateResCodeEnum.参数错误);
                    return res;
                }
                //var lstCtl = ControllerCache.Lstctl;
                //if (lstCtl.Any(c => c.chessboard.Players.First(x => x.IsFirst).User.UserCode == firstPlayerCode || 
                //c.chessboard.Players.First(x => x.IsFirst == false).User.UserCode == secondPlayerCode))
                //{
                //    res = OperateJsonRes.Error(OperateResCodeEnum.无法多开游戏);
                //    return res;
                //}

                List<HS_UserCardGroupDetail> firstCardGroup = UserCardGroupDetailBll.Instance.GetCardGroupDetail(fristCardGroupCode, firstPlayerCode);
                if (firstCardGroup == null || firstCardGroup.Count < 1)
                {
                    res = JsonStringResult.Error(OperateResCodeEnum.参数错误);
                    return res;
                }

                List<HS_UserCardGroupDetail> secondCardGroup = UserCardGroupDetailBll.Instance.GetCardGroupDetail(secondCardGroupCode, secondPlayerCode);
                if (secondCardGroup == null || secondCardGroup.Count < 1)
                {
                    res = JsonStringResult.Error(OperateResCodeEnum.参数错误);
                    return res;
                }


                gameID = SignUtil.CreateSign(firstPlayerCode + secondPlayerCode + RandomUtil.CreateRandomStr(10) + DateTime.Now.Ticks);
                Controler ctl = new Controler(gameID, firstUser, secondUser, firstCardGroup, secondCardGroup);          
            }
            catch (Exception ex)
            {
                res = JsonStringResult.Error(OperateResCodeEnum.内部错误);
                return res;
            }
            res = JsonStringResult.SuccessResult(gameID);
            return res;
        }

        public void GameStart()
        {
            throw new NotImplementedException();
        }

        public void RoundEnd()
        {
            throw new NotImplementedException();
        }

        public string SwitchCard(string gameID, string userCode, List<int> lstInitCardIndex)
        {
            string res = JsonStringResult.VerifyFail();
            Controler ctl = null;
            if (!ControllerCache.LstCtl.Any(c => c.GameID == gameID) || !ControllerCache.LstCtl.Any(c => c.chessboard.Players.Any(x => x.User.UserCode == userCode)))
            {
                res = JsonStringResult.Error(OperateResCodeEnum.查询不到需要的数据);
                return res;
            }
            ctl = ControllerCache.LstCtl.First(c => c.GameID == gameID);
            if (ctl.roundIndex != 2)
            {
                res = JsonStringResult.Error(OperateResCodeEnum.查询不到需要的数据);
                return res;
            }
            ctl.SwitchCard(userCode, lstInitCardIndex);
            res = JsonStringResult.SuccessResult(ctl.chessboard.Players.First(c => c.User.UserCode == userCode).HandCards);
            return res;
        }

        public void PickUpACard(string userCode)
        {
            throw new NotImplementedException();
        }

        public void RoundStart()
        {
            throw new NotImplementedException();
        }
    }
}
