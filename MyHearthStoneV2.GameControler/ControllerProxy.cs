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
using MyHearthStoneV2.Common.Common;
using MyHearthStoneV2.Common.Enum;

namespace MyHearthStoneV2.GameControler
{
    public class ControllerProxy
    {
        /// <summary>
        /// 当前环境下的所有控制器
        /// </summary>
        private static List<Controler> lstCtl = new List<Controler>();
        public static Controler CtlInstance(string gameID)
        {
            return lstCtl.First(c => c.GameID == gameID);
        }
        /// <summary>
        /// 创建一局游戏
        /// </summary>
        /// <param name="firstPlayerCode">先手玩家</param>
        /// <param name="secondPlayerCode">后手玩家</param>
        /// <param name="fristCardGroupID">先手玩家卡组</param>
        /// <param name="secondCardGroupID">后手玩家卡组</param>
        /// <returns>游戏ID</returns>
        public static string CreateGame(string firstPlayerCode, string secondPlayerCode, int fristCardGroupID, int secondCardGroupID)
        {
            string res = OperateJsonRes.VerifyFail();
            string gameID = "";
            try
            {
                if (firstPlayerCode.IsNullOrEmpty() || secondPlayerCode.IsNullOrEmpty() || fristCardGroupID < 1 || secondCardGroupID < 1)
                {
                    res = OperateJsonRes.Error(OperateResCodeEnum.参数错误);
                    return res;
                }

                HS_Users firstUser = HS_UsersBll.Instance.GetUser(firstPlayerCode);
                if (firstUser == null)
                {
                    res = OperateJsonRes.Error(OperateResCodeEnum.参数错误);
                    return res;
                }

                HS_Users secondUser = HS_UsersBll.Instance.GetUser(secondPlayerCode);
                if (secondUser == null)
                {
                    res = OperateJsonRes.Error(OperateResCodeEnum.参数错误);
                    return res;
                }

                if (lstCtl.Any(c => c.firstPlayer.UserCode == firstPlayerCode || c.firstPlayer.UserCode == secondPlayerCode))
                {
                    res = OperateJsonRes.Error(OperateResCodeEnum.无法多开游戏);
                    return res;
                }

                HS_UserCardGroup firstCardGroup = hs_usercardgroup_BLL.Instance.GetCardGroup(fristCardGroupID, firstPlayerCode);
                if (firstCardGroup == null)
                {
                    res = OperateJsonRes.Error(OperateResCodeEnum.参数错误);
                    return res;
                }

                HS_UserCardGroup secondCardGroup = hs_usercardgroup_BLL.Instance.GetCardGroup(secondCardGroupID, secondPlayerCode);
                if (secondCardGroup == null)
                {
                    res = OperateJsonRes.Error(OperateResCodeEnum.参数错误);
                    return res;
                }


                gameID = SignUtil.CreateSign(firstPlayerCode + secondPlayerCode);
                Controler ctl = new Controler(gameID, firstUser, secondUser, firstCardGroup, secondCardGroup);

                //ctl.chessboard = new Chessboard();

                lstCtl.Add(ctl);
            }
            catch (Exception ex)
            {
                res = OperateJsonRes.Error(OperateResCodeEnum.内部错误);
            }
            res = OperateJsonRes.SuccessResult(gameID);
            return res;
        }
    }
}
