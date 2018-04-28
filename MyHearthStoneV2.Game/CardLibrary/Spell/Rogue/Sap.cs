using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.Spell.Single;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.Filter.Servant;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Spell;
using MyHearthStoneV2.Game.CardLibrary.CardAction.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Filter;

namespace MyHearthStoneV2.Game.CardLibrary.Spell.Rogue
{
    public class Sap : BaseSpell
    {
        public override Rarity Rare { get; set; } = Rarity.普通;

        public override string Name { get; set; } = "闷棍";
        public override int Cost { get; set; } = 2;
        public override int InitialCost { get; set; } = 2;
        public override string Describe { get; set; } = "将一个敌方随从移回其拥有者的手牌。";

        public override List<ICardAbility> Abilities { get; set; } = new List<ICardAbility>()
        {
            new SpellDriver_Single_AllEnemyServant<Recover<SecondaryServantFilter>,NullFilter>(),
            //new CA_Sap()
        };

        public override string BackgroudImage { get; set; } = "Classical/Sap.jpg";
        public override Profession Profession { get; set; } = Profession.Rogue;
    }
}
