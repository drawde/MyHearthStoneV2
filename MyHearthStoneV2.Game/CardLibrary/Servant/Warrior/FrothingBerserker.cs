using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver;
using MyHearthStoneV2.Game.Widget.Number;
using MyHearthStoneV2.Game.Widget.Filter.ParameterFilter.Servant;
using System.Collections.Generic;
using MyHearthStoneV2.Game.Widget.Filter.CardLocationFilter;

namespace MyHearthStoneV2.Game.CardLibrary.Servant.Warrior
{
    public class FrothingBerserker : BaseServant
    {
        public override int Damage => 2;
        public override int Life => 4;
        public override int Cost => 3;

        public override int InitialDamage => 2;
        public override int InitialLife => 4;
        public override int InitialCost => 3;

        
        public override int BuffLife => 4;
        public override string Describe => "每当一个随从受到伤害时，便获得+1攻击力。";

        public override Rarity Rare => Rarity.史诗;

        public override List<ICardAbility> Abilities => new List<ICardAbility>()
        {
            new BiologyHurtObserverDriver<AddDamage<PrimaryServantFilter,ONE>,InDeskFilter>()
        };


        public override string Name => "暴乱狂战士";

        public override string BackgroudImage => "W6_222_D.png";

        public override Profession Profession => Profession.Warrior;
    }
}
