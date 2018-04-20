using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.Filter;
using MyHearthStoneV2.Game.CardLibrary.Servant;
using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.Parameter;
using System.Collections.Generic;
using System.Linq;
namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility
{
    /// <summary>
    /// 获取一个随从的控制权
    /// </summary>
    /// <typeparam name="UC"></typeparam>
    /// <typeparam name="TAG"></typeparam>
    public class Possession<UC, TAG> : IBaseCardAbility where UC : IUserContextFilter where TAG : IServantFilter
    {
        public override IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            UC uc = GameActivator<UC>.CreateInstance();
            var enemy = actionParameter.GameContext.Players.First(uc.Filter(actionParameter));
            var user = actionParameter.GameContext.Players.First(c=>c.IsFirst != enemy.IsFirst);
            foreach (BaseBiology biology in actionParameter.GameContext.DeskCards.Where(GameActivator<TAG>.CreateInstance().Filter(actionParameter)))
            {
                BaseServant rndServant = biology as BaseServant;
                enemy.AllCards.RemoveAt(enemy.AllCards.FindIndex(c => c.CardInGameCode == rndServant.CardInGameCode));
                user.AllCards.Add(rndServant);

                actionParameter.GameContext.DeskCards[rndServant.DeskIndex] = null;

                if (rndServant.DeskIndex > 8)
                {
                    for (int i = 1; i < 8; i++)
                    {
                        if (actionParameter.GameContext.DeskCards[i] == null)
                        {
                            rndServant.DeskIndex = i;
                            break;
                        }
                    }
                }
                else
                {
                    for (int i = 9; i < 16; i++)
                    {
                        if (actionParameter.GameContext.DeskCards[i] == null)
                        {
                            rndServant.DeskIndex = i;
                            break;
                        }
                    }
                }

                actionParameter.GameContext.DeskCards[rndServant.DeskIndex] = rndServant;
            }            
            return null;
        }
    }
}
