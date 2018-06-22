using MyHearthStoneV2.Common.Util;
using MyHearthStoneV2.Game;
using MyHearthStoneV2.Game.Context;
using PostSharp.Aspects;
using System;
using System.Linq;

namespace MyHearthStoneV2.GameTest.Loader.HandCard
{
    [Serializable]
    public class AllRandomFiveCard : OnMethodBoundaryAspect
    {
        public override void OnEntry(MethodExecutionArgs args)
        {
            GameContext gameContext = (args.Instance as BaseTest).GameContext;
            foreach (UserContext uc in gameContext.Players)
            {
                var idxs = RandomUtil.CreateRandomInt(0, uc.StockCards.Count() - 1, 5).OrderByDescending(c => c);
                foreach (int i in idxs)
                {
                    uc.StockCards.ToList()[i].CardLocation = CardLocation.手牌;
                }
            }
            base.OnEntry(args);
        }
    }
}
