using BattleForAzeroth.Game.CardLibrary.CardAbility;
using BattleForAzeroth.Game.CardLibrary.CardAbility.BaseAbility;
using BattleForAzeroth.Game.CardLibrary.CardAbility.Driver;
using BattleForAzeroth.Game.Widget.Condition.DamageType;
using BattleForAzeroth.Game.Widget.Number;
using BattleForAzeroth.Game.Widget.Filter.ParameterFilter.Servant;
using System.Collections.Generic;
using BattleForAzeroth.Game.Widget.Filter.CardLocationFilter;
using BattleForAzeroth.Game.CardLibrary.CardAbility.Driver.BattlecryDriver;

namespace BattleForAzeroth.Game.CardLibrary.Servant.Warrior
{
    public class CruelTaskmaster : BaseServant
    {
        public override int Damage { get; set; }  = 2;
        public override int Life { get; set; }  = 2;
        public override int Cost { get; set; }  = 2;

        public override int InitialDamage => 2;
        public override int InitialLife => 2;
        public override int InitialCost => 2;

        
        public override int BuffLife { get; set; }  = 2;

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

        public override List<ICardAbility> Abilities => new List<ICardAbility>()
        {
            new AllServantBattlecryDriver<
                DoubleActionDriver<
                    RiseDamage<SecondaryServantFilter,ONE,ONE,PhysicalDamage>,
                    AddDamage<SecondaryServantFilter,Two>,NullFilter>
                >(),
            //new CA_CruelTaskmaster()
        };


        public override string Name => "严酷的监工";
        public override string BackgroudImage => "W6_196_D.png";

        public override Profession Profession => Profession.Warrior;
    }
}
