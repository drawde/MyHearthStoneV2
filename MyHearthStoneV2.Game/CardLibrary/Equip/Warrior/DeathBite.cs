using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver;
using MyHearthStoneV2.Game.Widget.Condition.DamageType;
using MyHearthStoneV2.Game.Widget.Filter.ParameterFilter.Servant;
using MyHearthStoneV2.Game.Widget.Number;
using MyHearthStoneV2.Game.Widget.Filter.CardLocationFilter;
using System.Collections.Generic;
namespace MyHearthStoneV2.Game.CardLibrary.Equip.Warrior
{
    public class DeathBite : BaseEquip
    {
        public override string Name => "死亡之咬";
        public override string BackgroudImage => "WOW_EQU_001_D_1.png";

        public override int Damage => 4;
        
        public override int InitialDamege => 4;
        public override int Durable => 2;
        public override int Cost => 4;
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
