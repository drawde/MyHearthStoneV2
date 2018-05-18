using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.BattlecryDriver;
using MyHearthStoneV2.Game.Widget.Filter.ParameterFilter.Hero;
using MyHearthStoneV2.Game.Widget.Filter.CardLocationFilter;
using System.Collections.Generic;

namespace MyHearthStoneV2.Game.CardLibrary.Servant.Neutral.Classical
{
    public class AcidicSwampOoze : BaseServant
    {
        public override int Damage => 3;
        public override int Life => 2;
        public override int Cost => 2;

        public override int InitialDamage => 3;
        public override int InitialLife => 2;
        public override int InitialCost => 2;


        public override int BuffLife => 2;
        public override string Describe => "战吼：摧毁你的对手的武器。";

        public override Rarity Rare => Rarity.精良;

        public override List<ICardAbility> Abilities => new List<ICardAbility>()
        {
            new NoneTargetBattlecryDriver<DestroyEquip<SecondaryHeroFilter>>()
        };


        public override string Name => "酸性沼泽软泥怪";

        public override string BackgroudImage => "Classical/AcidicSwampOoze.jpg";

        public override Profession Profession => Profession.Neutral;

    }
}
