using MyHearthStoneV2.BLL;
using MyHearthStoneV2.Game;
using MyHearthStoneV2.Game.CardLibrary;
using MyHearthStoneV2.Game.CardLibrary.Servant.Neutral.Classical;
using MyHearthStoneV2.Game.CardLibrary.Servant.Neutral.NAXX;
using MyHearthStoneV2.Common;
using MyHearthStoneV2.Common.Util;
using MyHearthStoneV2.Model;
using MyHearthStoneV2.Redis;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using MyHearthStoneV2.Common.Enum;
using MyHearthStoneV2.Common.JsonModel;
using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.ShortCodeBll;
using MyHearthStoneV2.Game.Controler.Proxy;
using MyHearthStoneV2.Model.CustomModels;

namespace MyHearthStoneV2.TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //CardUtil.AddToRedis();
            //List<Card> lstCards = CardUtil.GetCardInRedis();
            //var lst = ShortCodeBusiness.Instance.GetList();

            HS_Users drawde = UsersBll.Instance.GetUserByAdmin("58657C04BCADF3C6AA26F2B79D24994D",
                "DECC8686654B465E5313259325149A86");
            HS_Users mendicantbias = UsersBll.Instance.GetUserByAdmin("7CB46FE0E48E2A81FF3055927AB33B9C",
                "DECC8686654B465E5313259325149A86");

            string res = "";
            APIResultBase reslut = null;
            //res = Go(GameTableBll.Instance.GetTable("00009", "123"));
            string gameCode = GameBll.Instance.GetGameByTableCode("00009").GameCode;

            //ControllerProxy.SwitchCard(gameCode, drawde.UserCode, new List<string>() { });

            //reslut = ControllerProxy.SwitchCard(gameCode, drawde.UserCode, new List<string>() { "0", "1", "2" });
            //reslut = ControllerProxy.SwitchCard(gameCode, mendicantbias.UserCode, new List<string>() { "0", "1", "2", "3" });

            //reslut = ControllerProxy.CastSpell(gameCode, drawde.UserCode, "60", -1);
            //reslut = ControllerProxy.CastSpell(gameCode, mendicantbias.UserCode, "60", -1);

            //reslut = ControllerProxy.CastServant(gameCode, drawde.UserCode, "20", 3, 1);
            //reslut = ControllerProxy.CastServant(gameCode, mendicantbias.UserCode, "36", 11, -1);

            //reslut = ControllerProxy.ServantAttack(gameCode, drawde.UserCode, "11", 8);
            //reslut = ControllerProxy.ServantAttack(gameCode, mendicantbias.UserCode, "40", 2);


            //reslut = ControllerProxy.TurnEnd(gameCode, drawde.UserCode);
            //reslut = ControllerProxy.TurnEnd(gameCode, mendicantbias.UserCode);

            //reslut = ControllerProxy.TurnStart(gameCode, drawde.UserCode);
            //reslut = ControllerProxy.TurnStart(gameCode, mendicantbias.UserCode);

            //reslut = ControllerProxy.CastHeroPower(gameCode, drawde.UserCode);
            //reslut = ControllerProxy.CastHeroPower(gameCode, mendicantbias.UserCode);

            //reslut = ControllerProxy.HeroAttack(gameCode, drawde.UserCode, 10);
            //reslut = ControllerProxy.HeroAttack(gameCode, mendicantbias.UserCode, "30", 4);

            var gameContext = GetContext(gameCode);


            //gameContext.Players[1].Power = 10;
            //SetContext(gameContext);
            //gameContext.DeskCards[2] = null;
            //gameContext.Players[1].DeskCards[2].RemainAttackTimes = 1;

            //SetContext(gameContext);

            Console.WriteLine("=================End=================");
            Console.ReadKey();
        }

        internal static void SetContext(GameContext ctl)
        {
            var lstCtls = GetContexts();
            if (lstCtls.Any(c => c.GameCode == ctl.GameCode))
            {
                lstCtls[lstCtls.FindIndex(c => c.GameCode == ctl.GameCode)] = ctl;
            }
            else
            {
                lstCtls.Add(ctl);
            }
            using (var redisClient = RedisManager.GetClient())
            {
                redisClient.Set(RedisKey.GetKey(RedisAppKeyEnum.Alpha, RedisCategoryKeyEnum.GameContext), lstCtls);
            }
        }

        static GameContext GetContext(string gameCode)
        {
            var lstCtls = GetContexts();
            if (lstCtls.Any(c => c.GameCode == gameCode))
            {
                return lstCtls[lstCtls.FindIndex(c => c.GameCode == gameCode)];
            }
            return null;
        }
        internal static List<GameContext> GetContexts()
        {
            using (var redisClient = RedisManager.GetClient())
            {
                var lst = redisClient.Get<List<GameContext>>(RedisKey.GetKey(RedisAppKeyEnum.Alpha, RedisCategoryKeyEnum.GameContext));
                if (lst == null)
                {
                    lst = new List<GameContext>();
                    redisClient.Set(RedisKey.GetKey(RedisAppKeyEnum.Alpha, RedisCategoryKeyEnum.GameContext), lst);
                }
                return lst;
            }
        }
        private static string Go(HS_GameTable gameTable)
        {
            int firstPlayerIndex = RandomUtil.CreateRandomInt(0, 1);
            string firstPlayerCode = "", secondPlayerCode = "", firstPlayerCardGroupCode = "", secondPlayerCardGroupCode = "";
            if (firstPlayerIndex == 0)
            {
                firstPlayerCode = gameTable.CreateUserCode;
                firstPlayerCardGroupCode = gameTable.CreateUserCardGroup;

                secondPlayerCode = gameTable.PlayerUserCode;
                secondPlayerCardGroupCode = gameTable.PlayerUserCardGroup;
            }
            else
            {
                firstPlayerCode = gameTable.PlayerUserCode;
                firstPlayerCardGroupCode = gameTable.PlayerUserCardGroup;

                secondPlayerCode = gameTable.CreateUserCode;
                secondPlayerCardGroupCode = gameTable.CreateUserCardGroup;
            }
            var game = GameBll.Instance.GetGameByTableCode(gameTable.TableCode);
            string gameCode = "";

            //如果游戏记录为空，则创建游戏
            if (game == null || ControllerProxy.GetGame(game.GameCode) == null)
            {
                CUsers firstUser = UsersBll.Instance.GetUser(firstPlayerCode);
                CUsers secondUser = UsersBll.Instance.GetUser(secondPlayerCode);

                List<HS_UserCardGroupDetail> firstCardGroup = UserCardGroupDetailBll.Instance.GetCardGroupDetail(firstPlayerCardGroupCode, firstPlayerCode);
                List<HS_UserCardGroupDetail> secondCardGroup = UserCardGroupDetailBll.Instance.GetCardGroupDetail(secondPlayerCardGroupCode, secondPlayerCode);

                game = GameBll.Instance.CreateGame(gameTable.TableCode, firstPlayerCode, secondPlayerCode, firstPlayerCardGroupCode, secondPlayerCardGroupCode);

                string firstUserProfession = UserCardGroupBll.Instance.GetCardGroup(firstPlayerCardGroupCode, firstPlayerCode).Profession;
                string secondUserProfession = UserCardGroupBll.Instance.GetCardGroup(secondPlayerCardGroupCode, secondPlayerCode).Profession;
                int whoIsFirst = RandomUtil.CreateRandomInt(0, 100);
                APIResultBase res = null;
                if (whoIsFirst % 2 == 0)
                {
                    res = ControllerProxy.CreateGame(gameTable.TableCode, firstUser, secondUser, firstCardGroup, secondCardGroup, game, firstUserProfession, secondUserProfession);
                }
                else
                {
                    res = ControllerProxy.CreateGame(gameTable.TableCode, secondUser, firstUser, secondCardGroup, firstCardGroup, game, secondUserProfession, firstUserProfession);
                }
                if (res.code == (int)OperateResCodeEnum.成功)
                {
                    GameContextOutput chessBoard = ((APISingleModelResult<GameContextOutput>)res).data;
                    gameCode = chessBoard.GameCode;
                }
                else
                {
                    
                }
            }
            else
            {
                gameCode = game.GameCode;
            }
            return JsonStringResult.SuccessResult(gameCode);
        }
    }
}
