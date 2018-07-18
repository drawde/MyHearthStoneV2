using BattleForAzeroth.Game.Util;
using BattleForAzeroth.Game.CardLibrary;
using BattleForAzeroth.Game.CardLibrary.Servant;
using BattleForAzeroth.Game.Widget.Number;
using System;
using System.Collections.Generic;
using System.Linq;
using BattleForAzeroth.Game.Parameter;

namespace BattleForAzeroth.Game.Widget.Filter.Servant
{
    public class RandomServantOfCostFilter<Q> : IServantCardFilter where Q : INumber
    {
        public Func<Card, bool> Filter(ActionParameter actionParameter)
        {
            Q qat = GameActivator<Q>.CreateInstance();
            List<Card> lstCardLib = actionParameter.GameContext.GameCache.GetAllCard();
            List<Card> servants = lstCardLib.Where(c => c.Cost == qat.Number && c.CardType == CardType.随从 && c.Profession == Profession.Neutral && c.IsDerivative == false).ToList();
            BaseServant servant = servants[RandomUtil.CreateRandomInt(0, servants.Count - 1)] as BaseServant;
            return new Func<Card, bool>(c => c.CardCode == servant.CardCode);
        }
    }
}
