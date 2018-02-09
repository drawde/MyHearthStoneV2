using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.CardLibrary.Servant.Neutral.NAXX;
using System.Collections.Generic;
using System.Linq;
using MyHearthStoneV2.Common.Util;
using MyHearthStoneV2.Game.CardLibrary.Servant;
using MyHearthStoneV2.Game.Parameter;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.Deathwhisper
{
    public class CA_SylvanasWindrunner : BaseCardAbility
    {
        public override AbilityType AbilityType => AbilityType.亡语;
        public override IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            var enemyContext = actionParameter.GameContext.GetEnemyUserContextByMyCard(actionParameter.MainCard);
            List<BaseBiology> lstBio = actionParameter.GameContext.DeskCards.GetDeskServantsByIsFirst(enemyContext.IsFirst);
            if (lstBio.Count > 0)
            {
                List<int> lstServantIndex = new List<int>();
                foreach (var ser in lstBio)
                {
                    lstServantIndex.Add(ser.DeskIndex);//lstBio.FindIndex(c => c != null && c.CardInGameCode == ser.CardInGameCode)
                }
                int rndIndex = RandomUtil.CreateRandomInt(0, lstServantIndex.Count - 1);
                BaseServant rndServant = actionParameter.GameContext.DeskCards[lstServantIndex[rndIndex]] as BaseServant;
                var userContext = actionParameter.GameContext.GetUserContextByMyCard(actionParameter.MainCard);

                enemyContext.AllCards.RemoveAt(enemyContext.AllCards.FindIndex(c => c.CardInGameCode == rndServant.CardInGameCode));
                userContext.AllCards.Add(rndServant);

                actionParameter.GameContext.DeskCards[lstServantIndex[rndIndex]] = null;

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
