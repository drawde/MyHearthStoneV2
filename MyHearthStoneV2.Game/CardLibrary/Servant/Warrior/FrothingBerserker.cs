using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver;
using MyHearthStoneV2.Game.CardLibrary.Filter.Condition.Quantity;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.Filter.Servant;
using System.Collections.Generic;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Filter;

namespace MyHearthStoneV2.Game.CardLibrary.Servant.Warrior
{
    public class FrothingBerserker : BaseServant
    {
        public override int Damage { get; set; } = 2;
        public override int Life { get; set; } = 4;
        public override int Cost { get; set; } = 3;

        public override int InitialDamage { get; set; } = 2;
        public override int InitialLife { get; set; } = 4;
        public override int InitialCost { get; set; } = 3;

        
        public override int BuffLife { get; set; } = 4;
        public override string Describe { get; set; } = "每当一个随从受到伤害时，便获得+1攻击力。";

        public override Rarity Rare { get; set; } = Rarity.史诗;

        public override List<IBaseCardAbility> Abilities { get; set; } = new List<IBaseCardAbility>()
        {
            new ServantHurtObserverDriver<AddDamage<MainServantFilter,ONE>,InDeskFilter>()
        };


        public override string Name { get; set; } = "暴乱狂战士";

        public override string BackgroudImage { get; set; } = "W6_222_D.png";

        public override Profession Profession { get; set; } = Profession.Warrior;
    }
}
