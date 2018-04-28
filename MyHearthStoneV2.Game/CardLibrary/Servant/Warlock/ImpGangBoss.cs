using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver;
using MyHearthStoneV2.Game.CardLibrary.Filter.Condition.Number;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.Filter.Context;
using System.Collections.Generic;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Filter;
using MyHearthStoneV2.Game.CardLibrary.Filter.Servant;

namespace MyHearthStoneV2.Game.CardLibrary.Servant.Warlock
{
    public class ImpGangBoss : BaseServant
    {
        public override int Damage { get; set; } = 2;
        public override int Life { get; set; } = 4;
        public override int Cost { get; set; } = 3;

        public override int InitialDamage { get; set; } = 2;
        public override int InitialLife { get; set; } = 4;
        public override int InitialCost { get; set; } = 3;
        
        public override int BuffLife { get; set; } = 4;

        public override string Describe { get; set; } = "每当他受到伤害的时候，召唤一只1/1的小鬼。";

        public override Rarity Rare { get; set; } = Rarity.普通;

        public override List<ICardAbility> Abilities { get; set; } = new List<ICardAbility>()
        {
            new HurtDriver<Summon<MainUserContextFilter,AssignServantFilter<Imp>,ONE>,InDeskFilter>(),            
        };

        public override string BackgroudImage { get; set; } = "BlackrockMountain/ImpGangBoss.jpg";

        public override string Name { get; set; } = "小鬼首领";
        public override Profession Profession { get; set; } = Profession.Warlock;
        public override Race Race { get; set; } = Race.恶魔;
    }
}
