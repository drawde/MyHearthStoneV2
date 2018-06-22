using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver;
using MyHearthStoneV2.Game.Widget.Number;
using MyHearthStoneV2.Game.Widget.Filter.CardLocationFilter;
using System.Collections.Generic;
using MyHearthStoneV2.Game.Widget.Filter.Context;

namespace MyHearthStoneV2.Game.CardLibrary.Servant.Warrior
{
    public class Armorsmith : BaseServant
    {
        public override int Damage { get; set; }  = 1;
        public override int Life { get; set; }  = 4;
        public override int Cost { get; set; }  = 2;

        public override int InitialDamage => 1;
        public override int InitialLife => 4;
        public override int InitialCost => 2;

        
        public override int BuffLife { get; set; }  = 4;

        public override string Describe => "每当一个友方随从受到伤害，便获得1点护甲值。";

        public override Rarity Rare => Rarity.精良;

        public override List<ICardAbility> Abilities => new List<ICardAbility>()
        {
            new MyServantHurtObserverDriver<AddAmmo<PrimaryUserContextFilter,ONE>,InDeskFilter>(),
        };

        public override string BackgroudImage => "W10_A047_D.png";

        public override string Name => "铸甲师";
        public override Profession Profession => Profession.Warrior;
    }
}
