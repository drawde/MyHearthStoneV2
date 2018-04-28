using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.DamageType;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.Filter.Servant;
using MyHearthStoneV2.Game.CardLibrary.Filter.Condition.Number;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Filter;
using System.Collections.Generic;
namespace MyHearthStoneV2.Game.CardLibrary.Equip.Warrior
{
    public class DeathBite : BaseEquip
    {
        public override string Name { get; set; } = "死亡之咬";
        public override string BackgroudImage { get; set; } = "WOW_EQU_001_D_1.png";

        public override int Damage { get; set; } = 4;
        
        public override int InitialDamege { get; set; } = 4;
        public override int Durable { get; set; } = 2;
        public override int Cost { get; set; } = 4;
        public override int InitialCost { get; set; } = 4;
        public override string Describe { get; set; }  = "亡语：对所有随从造成1点伤害";
        public override List<ICardAbility> Abilities { get; set; } = new List<ICardAbility>()
        {
            new DeathWhisperDriver<RiseDamage<AllServantFilter,ONE,ONE,SpellDamage>,InDeskFilter>(),
            //new CA_DeathBite()
        };
        public override Profession Profession { get; set; } = Profession.Warrior;
    }
}
