using MyHearthStoneV2.Game.CardLibrary.CardAction.Controler;
using MyHearthStoneV2.Game.Parameter;
using MyHearthStoneV2.Game.Parameter.Controler;
using MyHearthStoneV2.Game.Context;
using System.Collections.Generic;
using MyHearthStoneV2.Redis;
using System.Linq;
using MyHearthStoneV2.Game.CardLibrary.Servant;
using MyHearthStoneV2.Common.Util;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.Deathwhisper
{
    public class CA_PilotedShredder : BaseCardAbility
    {
        public override AbilityType AbilityType { get; set; } = AbilityType.亡语;
        public override IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            bool isActivation = actionParameter.GameContext.IsThisActivationUserCard(actionParameter.MainCard);
            List<Card> lstCardLib;
            using (var redisClient = RedisManager.GetClient())
            {
                lstCardLib = redisClient.Get<List<Card>>(RedisKey.GetKey(RedisAppKeyEnum.Alpha, RedisCategoryKeyEnum.CardsInstance));
            }
            List<Card> servants = lstCardLib.Where(c => c.Cost == 2 && c.CardType == CardType.随从 && c.Profession == Profession.Neutral).ToList();
            BaseServant servant = servants[RandomUtil.CreateRandomInt(0, servants.Count - 1)] as BaseServant;
            CreateNewCardInDeskAction action = new CreateNewCardInDeskAction();
            ControlerActionParameter para = new ControlerActionParameter()
            {
                GameContext = actionParameter.GameContext,
                IsActivation = isActivation,
                MainCard = servant,
            };
            action.Action(para);
            return null;
        }
    }
}
