using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.BattlecryDriver;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.Filter.Servant;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Filter;

using MyHearthStoneV2.Game.CardLibrary.Filter.Condition.Direction;
using MyHearthStoneV2.Game.CardLibrary.Filter.Condition.Number;
using MyHearthStoneV2.Game.CardLibrary.Servant;
using System.Collections.Generic;

namespace MyHearthStoneV2.Game.CardLibrary.Servant.Neutral.Classical
{
    public class DefenderOfArgus : BaseServant
    {
        public override int Damage { get; set; } = 2;
        public override int Life { get; set; } = 3;
        public override int Cost { get; set; } = 4;

        public override int InitialDamage { get; set; } = 2;
        public override int InitialLife { get; set; } = 3;
        public override int InitialCost { get; set; } = 4;
        
        public override int BuffLife { get; set; } = 3;
        public override string Describe { get; set; } = "战吼：使相邻的随从获得+1/+1和嘲讽。";

        public override Rarity Rare { get; set; } = Rarity.精良;

        public override List<ICardAbility> Abilities { get; set; } = new List<ICardAbility>()
        {
            new NoneTargetBattlecryDriver<
                DoubleAbility<
                    Taunt<MainCardBothSidesFilter>,
                    AddDamageAndLife<MainCardBothSidesFilter,ONE,ONE,Plus,InDeskFilter>>>()
        };


        public override string Name { get; set; } = "阿古斯防御者";
        public override string BackgroudImage { get; set; } = "W5_008_D.png";

        public override Profession Profession { get; set; } = Profession.Neutral;
    }
}
