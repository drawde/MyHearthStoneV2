using BattleForAzeroth.Game.CardLibrary.CardAbility;
using BattleForAzeroth.Game.CardLibrary.CardAbility.BaseAbility;
using BattleForAzeroth.Game.CardLibrary.CardAbility.Driver;
using BattleForAzeroth.Game.Widget.Condition.DamageType;
using BattleForAzeroth.Game.Widget.Filter.ParameterFilter.Servant;
using BattleForAzeroth.Game.Widget.Number;
using BattleForAzeroth.Game.Widget.Filter.CardLocationFilter;
using System.Collections.Generic;
namespace BattleForAzeroth.Game.CardLibrary.Equip.Warrior
{
    public class DeathBite : BaseEquip
    {
        public override string Name => "死亡之咬";
        public override string BackgroudImage => "WOW_EQU_001_D_1.png";

        public override int Damage { get; set; }  = 4;
        
        public override int InitialDamege => 4;
        public override int Durable { get; set; }  = 2;
        public override int Cost { get; set; }  = 4;
        public override int InitialCost => 4;
        public override string Describe { get; set; }  = "亡语：对所有随从造成1点伤害";
        public override List<ICardAbility> Abilities => new List<ICardAbility>()
        {
            new DeathWhisperDriver<RiseDamage<AllServantFilter,ONE,ONE,SpellDamage>,InDeskFilter>(),
            //new CA_DeathBite()
        };
        public override Profession Profession => Profession.Warrior;
    }
}
