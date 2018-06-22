using MyHearthStoneV2.BLL;
using MyHearthStoneV2.Game;
using MyHearthStoneV2.Game.CardLibrary;
using MyHearthStoneV2.Game.CardLibrary.Hero;
using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Model;
using MyHearthStoneV2.Model.CustomModels;
using MyHearthStoneV2.Redis;
using PostSharp.Aspects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyHearthStoneV2.GameTest.Loader
{
    public class SwordOil_VS_Zoo : BaseTest
    {
        public SwordOil_VS_Zoo()
        {            
            string drawde = "58657C04BCADF3C6AA26F2B79D24994D";
            string mendicantbias = "7CB46FE0E48E2A81FF3055927AB33B9C";
            string drawdeCardGroupCode = "000Ai";
            string mendicantbiasCardGroupCode = "0008j";
            CUsers firstPlayer = UsersBll.Instance.GetUser(drawde);
            CUsers secondPlayer = UsersBll.Instance.GetUser(mendicantbias);

            List<HS_UserCardGroupDetail> firstCardGroup = UserCardGroupDetailBll.Instance.GetCardGroupDetail(drawdeCardGroupCode, drawde);
            List<HS_UserCardGroupDetail> secondCardGroup = UserCardGroupDetailBll.Instance.GetCardGroupDetail(mendicantbiasCardGroupCode, mendicantbias);

            UserContext firstUser = new UserContext
            {
                UserCode = firstPlayer.UserCode,
                User = firstPlayer,
                IsActivation = true,
                IsFirst = true,
                AllCards = new List<Card>(),
                Power = 10,
                FullPower = 10,
                RemainingHeroPowerCastCount = 1,
                TurnIndex = 10,
                SwitchDone = true
            };
            List<Card> lstCardLib;
            using (var redisClient = RedisManager.GetClient())
            {
                lstCardLib = redisClient.Get<List<Card>>(RedisKey.GetKey(RedisAppKeyEnum.Alpha, RedisCategoryKeyEnum.CardsInstance));
            }

            int cardInGameIndex = 0;
            foreach (var cg in firstCardGroup)
            {
                Card libCard = lstCardLib.First(c => c.CardCode == cg.CardCode);
                var card = Activator.CreateInstance(libCard.GetType()) as Card;
                card.CardCode = libCard.CardCode;
                card.CardInGameCode = cardInGameIndex.ToString();
                card.IsFirstPlayerCard = true;
                firstUser.AllCards.Add(card);
                cardInGameIndex++;
            }

            UserContext secondUser = new UserContext
            {
                UserCode = secondPlayer.UserCode,
                User = secondPlayer,
                IsActivation = false,
                IsFirst = false,
                AllCards = new List<Card>(),
                Power = 10,
                FullPower = 10,
                RemainingHeroPowerCastCount = 1,
                TurnIndex = 10,
                SwitchDone = true
            };
            secondCardGroup.ForEach(delegate (HS_UserCardGroupDetail detail)
            {
                Card libCard = lstCardLib.First(c => c.CardCode == detail.CardCode);
                var card = Activator.CreateInstance(libCard.GetType()) as Card;
                card.CardCode = libCard.CardCode;
                card.CardInGameCode = cardInGameIndex.ToString();
                card.IsFirstPlayerCard = false;
                secondUser.AllCards.Add(card);
                cardInGameIndex++;
            });

            //secondUser.StockCards = secondUser.AllCards;


            GameContext = new GameContext
            {
                Players = new List<UserContext>(),
                DeskCards = null,
                GameCode = "XXXXX",
                CurrentTurnCode = "YYYYY",
                NextTurnCode = "ZZZZZ",
                GameStatus = GameStatus.进行中
            };
            GameContext.Players.Add(firstUser);
            GameContext.Players.Add(secondUser);

            BaseHero firstHero = null, secondHero = null;
            string firstUserProfession = UserCardGroupBll.Instance.GetCardGroup(drawdeCardGroupCode, drawde).Profession;
            string secondUserProfession = UserCardGroupBll.Instance.GetCardGroup(mendicantbiasCardGroupCode, mendicantbias).Profession;
            switch (firstUserProfession)
            {
                case "Druid": firstHero = new Druid(); break;
                case "Hunter": firstHero = new Hunter(); break;
                case "Mage": firstHero = new Mage(); break;
                case "Paladin": firstHero = new Paladin(); break;
                case "Priest": firstHero = new Priest(); break;
                case "Rogue": firstHero = new Rogue(); break;
                case "Shaman": firstHero = new Shaman(); break;
                case "Warlock": firstHero = new Warlock(); break;
                case "Warrior": firstHero = new Warrior(); break;
            }
            switch (secondUserProfession)
            {
                case "Druid": secondHero = new Druid(); break;
                case "Hunter": secondHero = new Hunter(); break;
                case "Mage": secondHero = new Mage(); break;
                case "Paladin": secondHero = new Paladin(); break;
                case "Priest": secondHero = new Priest(); break;
                case "Rogue": secondHero = new Rogue(); break;
                case "Shaman": secondHero = new Shaman(); break;
                case "Warlock": secondHero = new Warlock(); break;
                case "Warrior": secondHero = new Warrior(); break;
            }

            firstHero.CardCode = lstCardLib.First(c => c.GetType().Name == firstHero.GetType().Name).CardCode;
            firstHero.CardInGameCode = cardInGameIndex.ToString();
            firstHero.DeskIndex = 0;
            firstHero.IsFirstPlayerCard = true;

            cardInGameIndex++;
            secondHero.CardCode = lstCardLib.First(c => c.GetType().Name == secondHero.GetType().Name).CardCode;
            secondHero.CardInGameCode = cardInGameIndex.ToString();
            secondHero.DeskIndex = 8;
            secondHero.IsFirstPlayerCard = false;

            GameContext.DeskCards = new DeskBoard() { firstHero, null, null, null, null, null, null, null, secondHero, null, null, null, null, null, null, null };
        }
    }
}
