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
using MyHearthStoneV2.Game.CardLibrary.Servant.Neutral.BlackrockMountain;
using MyHearthStoneV2.Game.CardLibrary.Servant.Warrior;

namespace MyHearthStoneV2.TestConsole
{

    class Program
    {
        static void Main(string[] args)
        {            

            CardUtil.AddToRedis();
            //List<Card> lstCards = CardUtil.GetCardInRedis();
            //var lst = ShortCodeBusiness.Instance.GetList();

            string drawde = "58657C04BCADF3C6AA26F2B79D24994D";
            string mendicantbias = "7CB46FE0E48E2A81FF3055927AB33B9C";

            string res = "";
            APIResultBase reslut = null;
            GameContext gameContext = null;
            //res = Go(GameTableBll.Instance.GetTable("00009", "123"));
            string gameCode = GameBll.Instance.GetGameByTableCode("00009").GameCode;
            gameContext = GetContext(gameCode);
            //gameContext.Players[0].Power = 10;
            //gameContext.Players[1].Power = 10;
            //GameTester.DrawCard(gameContext, 7);                  
            //SetContext(gameContext);

            //var lstRec = GameRecordBll.Instance.GetGameRecord(gameCode, 10, 1);
            //for (int i = 0; i < lstRec.Count; i++)
            //{
            //    JObject obj = JObject.Parse(lstRec[i].GameContext);
            //    string deskCard = obj["DeskCards"].ToString();
            //}
            //Controller_Base_Proxy.SwitchCard(gameCode, drawde, new List<string>() { });

            //reslut = Controller_Base_Proxy.LoadEquip(gameCode, drawde, "50");
            //reslut = Controller_Base_Proxy.LoadEquip(gameCode, mendicantbias, "20");

            //reslut = Controller_Base_Proxy.SwitchCard(gameCode, drawde, new List<string>() { "1", "2" });
            //reslut = Controller_Base_Proxy.SwitchCard(gameCode, mendicantbias, new List<string>() { "0", "1", "2" });

            //reslut = Controller_Base_Proxy.CastSpell(gameCode, drawde, "43", 1);
            //reslut = Controller_Base_Proxy.CastSpell(gameCode, mendicantbias, "28", -1);
            
            //reslut = Controller_Base_Proxy.CastServant(gameCode, drawde, "35", 9, -1);
            //reslut = Controller_Base_Proxy.CastServant(gameCode, mendicantbias, "25", 5, -1);

            //reslut = Controller_Base_Proxy.ServantAttack(gameCode, drawde, "31", 1);
            //reslut = Controller_Base_Proxy.ServantAttack(gameCode, mendicantbias, "27", 8);

            //reslut = Controller_Base_Proxy.CastHeroPower(gameCode, drawde);
            //reslut = Controller_Base_Proxy.CastHeroPower(gameCode, mendicantbias);

            //reslut = Controller_Base_Proxy.HeroAttack(gameCode, drawde, 5);
            //reslut = Controller_Base_Proxy.HeroAttack(gameCode, mendicantbias, 8);



            //GameTester.CastServant(gameContext, "36");
            //GameTester.CastServant(gameContext, "37");
            //GameTester.TurnEnd(gameContext);
            //SetContext(gameContext);            

            gameContext = GetContext(gameCode);            
            //gameContext.DeskCards[1].RemainAttackTimes = 1;
            //gameContext.DrawCard(true, 6);
            //gameContext.Players[0].Power = 10;

            
            //reslut = Controller_Base_Proxy.CastServant(gameCode, drawde, "0", 1, -1);
            //gameContext.DeskCards[2] = null;
            //gameContext.Players[1].DeskCards[2].RemainAttackTimes = 1;
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
            if (game == null || Controller_Base_Proxy.GetGame(game.GameCode) == null)
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
                    res = Controller_Base_Proxy.CreateGame(gameTable.TableCode, firstUser, secondUser, firstCardGroup, secondCardGroup, game, firstUserProfession, secondUserProfession);
                }
                else
                {
                    res = Controller_Base_Proxy.CreateGame(gameTable.TableCode, secondUser, firstUser, secondCardGroup, firstCardGroup, game, secondUserProfession, firstUserProfession);
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
