using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.Spell.Single;
using MyHearthStoneV2.Game.Widget.Filter.ParameterFilter.Servant;

using MyHearthStoneV2.Game.CardLibrary.CardAction.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyHearthStoneV2.Game.Widget.Filter.CardLocationFilter;

namespace MyHearthStoneV2.Game.CardLibrary.Spell.Rogue
{
    public class Sap : BaseSpell
    {
        public override Rarity Rare => Rarity.普通;

        public override string Name => "闷棍";
        public override int Cost { get; set; }  = 2;
        public override int InitialCost => 2;
        public override string Describe => "将一个敌方随从移回其拥有者的手牌。";

        public override List<ICardAbility> Abilities => new List<ICardAbility>()
        {
            new SpellDriver_Single_AllEnemyServant<Recover<SecondaryServantFilter>>(),
            //new CA_Sap()
        };

        public override string BackgroudImage => "Classical/Sap.jpg";
        public override Profession Profession => Profession.Rogue;
    }
}
