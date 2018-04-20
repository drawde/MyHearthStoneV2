using MyHearthStoneV2.Game.Action;
using MyHearthStoneV2.Game.CardLibrary.Hero;
using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.Parameter;
using MyHearthStoneV2.Game.Parameter.Player;
using System.Collections.Generic;
using System.Linq;

namespace MyHearthStoneV2.Game.CardLibrary.CardAction.Player
{
    public class DrawCardAction : Action.IGameAction
    {
        public IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            DrawCardActionParameter drawPara = actionParameter as DrawCardActionParameter;
            int drawCount = drawPara.DrawCount;
            UserContext uc = drawPara.UserContext;

            BaseHero hero = drawPara.GameContext.GetHeroByActivation(uc.IsActivation);
            for (int i = 1; i <= drawCount; i++)
            {
                //当牌库里有牌时
                if (uc.StockCards.Count > 0)
                {
                    var drawCard = uc.StockCards.First();
                    if (uc.HandCards.Count < 10)
                    {
                        //如果手牌没满则放入手牌中
                        uc.HandCards.Add(drawCard);
                        drawCard.CardLocation = CardLocation.手牌;
                    }
                    else
                    {
                        //否则撕了这张牌
                        drawCard.CardLocation = CardLocation.坟场;
                        uc.GraveyardCards.Add(drawCard);
                    }
                    //最后从牌库移除这张牌
                    uc.StockCards.RemoveAt(0);
                }
                else
                {
                    //没牌则计算疲劳值
                    uc.FatigueValue++;
                    int trueDamege = uc.FatigueValue;
                    if (hero.Abilities.Any(c => c.SpellCardAbilityTimes.Any(x => x == SpellCardAbilityTime.己方英雄受到伤害前)))
                    {
                        drawPara.GameContext.TriggerCardAbility(drawPara.GameContext.DeskCards.GetDeskCardsByIsFirst(drawPara.GameContext.Players.First(c => c.IsActivation == uc.IsActivation).IsFirst), SpellCardAbilityTime.己方英雄受到伤害前);
                    }
                    else
                    {
                        if (trueDamege >= hero.Ammo)
                        {
                            trueDamege -= hero.Ammo;
                            hero.Ammo = 0;
                        }
                        else
                        {
                            hero.Ammo -= trueDamege;
                            trueDamege = 0;
                        }
                        hero.Life -= trueDamege;
                    }
                    drawPara.GameContext.TriggerCardAbility(new List<Card>() { hero }, SpellCardAbilityTime.己方英雄受到伤害后);
                }
            }
            return null;
        }
    }
}
