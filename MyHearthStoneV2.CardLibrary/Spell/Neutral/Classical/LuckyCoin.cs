
using System.Collections.Generic;
using MyHearthStoneV2.CardLibrary.Base;
using MyHearthStoneV2.CardLibrary.Context;
using MyHearthStoneV2.CardLibrary.Monitor;
using MyHearthStoneV2.CardLibrary.CardAbility;

namespace MyHearthStoneV2.CardLibrary.Spell.Neutral.Classical
{
    [PropertyChangedNotification]
    public class LuckyCoin: BaseSpell
    {
        public override BuffTimeLimit buffTime { get; } = BuffTimeLimit.己方回合结束;
        public override Rarity Rare
        {
            get
            {
                return Rarity.普通;
            }
        }

        //public override List<ISpecialEffect> LstBuff { get; set; } = new List<ISpecialEffect>() { };

        public override string Name
        {
            get
            {
                return "幸运币";
            }
        }

        public override void CastAbility(GameContext gameContext, Card triggerCard, Card sourceCard, List<int> targetCardIndex, int location)
        {
            
        }

        public override void CastSpell(GameContext gameContext, BaseSpell sourceCard, List<int> targetCardIndex)
        {
            gameContext.GetActivationUserContext().Power += 1;
        }

        public override void DisableAbility(GameContext gameContext)
        {
            //gameContext.GetActivationUserContext().Power -= 1;
        }
    }
}
