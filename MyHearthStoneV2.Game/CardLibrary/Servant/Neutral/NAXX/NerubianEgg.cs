using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver;
using MyHearthStoneV2.Game.CardLibrary.Filter.Condition.Quantity;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.Filter.Context;
using System.Collections.Generic;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Filter;
using MyHearthStoneV2.Game.CardLibrary.Filter.Servant;

namespace MyHearthStoneV2.Game.CardLibrary.Servant.Neutral.NAXX
{
    public class NerubianEgg : BaseServant
    {
        public override int Damage { get; set; } = 0;
        public override int Life { get; set; } = 2;
        public override int Cost { get; set; } = 2;

        public override int InitialDamage { get; set; } = 0;
        public override int InitialLife { get; set; } = 2;
        public override int InitialCost { get; set; } = 2;
        
        public override int BuffLife { get; set; } = 2;

        public override string Describe { get; set; } = "亡语：召唤一个4/4的蛛魔。";

        public override Rarity Rare { get; set; } = Rarity.精良;

        public override List<IBaseCardAbility> Abilities { get; set; } = new List<IBaseCardAbility>()
        {
            new DeathWhisperDriver<Summon<MainUserContextFilter,AssignServantFilter<Nerubian>,ONE>,InDeskFilter>()
        };

        public override string BackgroudImage { get; set; } = "NAXX/NerubianEgg.jpg";

        public override string Name { get; set; } = "蛛魔之卵";
        public override bool CanAttack { get; set; } = false;
        public override Profession Profession { get; set; } = Profession.Neutral;
    }
}
