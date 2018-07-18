using BattleForAzeroth.Game.CardLibrary.CardAction.Hero;
using BattleForAzeroth.Game.CardLibrary.Hero;
using BattleForAzeroth.Game.Context;
using BattleForAzeroth.Game.Parameter;
using System.Linq;

namespace BattleForAzeroth.Game.CardLibrary.CardAction.Player
{
    public class DrawCardAction : Action.IGameAction
    {
        public IActionOutputParameter Action(ActionParameter actionParameter)
        {
            int drawCount = actionParameter.DrawCount;
            UserContext uc = actionParameter.UserContext;

            BaseHero hero = actionParameter.GameContext.GetHeroByActivation(uc.IsActivation);
            for (int i = 1; i <= drawCount; i++)
            {
                //当牌库里有牌时
                if (uc.StockCards.Count() > 0)
                {
                    var drawCard = uc.StockCards.First();
                    if (uc.HandCards.Count() < 10)
                    {
                        //如果手牌没满则放入手牌中
                        //uc.HandCards.Add(drawCard);
                        drawCard.CardLocation = CardLocation.手牌;
                    }
                    else
                    {
                        //否则撕了这张牌
                        drawCard.CardLocation = CardLocation.坟场;
                        //uc.GraveyardCards.Add(drawCard);
                    }
                    //最后从牌库移除这张牌
                    //uc.StockCards.RemoveAt(0);
                }
                else
                {
                    //没牌则计算疲劳值
                    uc.FatigueValue++;
                    int trueDamege = uc.FatigueValue;
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
                    new DeductionHeroLifeAction().Action(new ActionParameter()
                    {
                        PrimaryCard = hero,
                        GameContext = actionParameter.GameContext,
                        DamageOrHeal = trueDamege
                    });
                    //hero.Life -= trueDamege;
                }
            }
            return null;
        }
    }
}
