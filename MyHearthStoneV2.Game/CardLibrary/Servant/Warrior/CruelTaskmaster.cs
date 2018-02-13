using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.DamageType;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.Quantity;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.Filter.Servant;
using System.Collections.Generic;

namespace MyHearthStoneV2.Game.CardLibrary.Servant.Warrior
{
    public class CruelTaskmaster : BaseServant
    {
        public override int Damage { get; set; } = 2;
        public override int Life { get; set; } = 2;
        public override int Cost { get; set; } = 2;

        public override int InitialDamage { get; set; } = 2;
        public override int InitialLife { get; set; } = 2;
        public override int InitialCost { get; set; } = 2;

        
        public override int BuffLife { get; set; } = 2;

        public override string Describe
        {
            get
            {
                return "战吼：对一个随从造成1点伤害，并使其获得 2攻击力。";
            }
        }

        public override Rarity Rare
        {
            get
            {
                return Rarity.普通;
            }
        }

        public override List<BaseCardAbility> Abilities { get; set; } = new List<BaseCardAbility>()
        {
            new BattlecryDriver<RiseDamage<SecondaryServantFilter,ONE,ONE,PhysicalDamage>>(),
            new BattlecryDriver<AddDamage<SecondaryServantFilter,Two>>()
            //new CA_CruelTaskmaster()
        };


        public override string Name { get; set; } = "严酷的监工";
        public override string BackgroudImage { get; set; } = "W6_196_D.png";

        public override Profession Profession { get; set; } = Profession.Warrior;
    }
}
