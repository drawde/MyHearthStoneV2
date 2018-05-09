using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver;
using MyHearthStoneV2.Game.CardLibrary.Filter.Condition.Number;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.Filter.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Filter;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.BattlecryDriver;

namespace MyHearthStoneV2.Game.CardLibrary.Servant.Neutral.Classical
{
    public class GnomishInventor : BaseServant
    {
        public override int Damage { get; set; } = 2;
        public override int Life { get; set; } = 4;
        public override int Cost { get; set; } = 4;

        public override int InitialDamage { get; set; } = 2;
        public override int InitialLife { get; set; } = 4;
        public override int InitialCost { get; set; } = 4;

        
        public override int BuffLife { get; set; } = 4;
        public override string Describe { get; set; } = "战吼：抽一张牌。";

        public override Rarity Rare { get; set; } = Rarity.普通;

        public override List<ICardAbility> Abilities { get; set; } = new List<ICardAbility>()
        {
            new NoneTargetBattlecryDriver<DrawCard<MainUserContextFilter,ONE>>()
        };


        public override string Name { get; set; } = "侏儒发明家";
        public override string BackgroudImage { get; set; } = "W7_031_D.png";

        public override Profession Profession { get; set; } = Profession.Neutral;
    }
}
