using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.BUFF.ChangeBody;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.BattlecryDriver;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.Filter.Spell;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Filter;
using MyHearthStoneV2.Game.CardLibrary.Filter.Condition.Direction;
using MyHearthStoneV2.Game.CardLibrary.Filter.Condition.Number;
using MyHearthStoneV2.Game.Event.GameProcess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.Game.CardLibrary.Servant.Neutral.NAXX
{
    public class Loatheb : BaseServant
    {
        public override int Damage { get; set; } = 5;
        public override int Life { get; set; } = 5;
        public override int Cost { get; set; } = 5;

        public override int InitialDamage { get; set; } = 5;
        public override int InitialLife { get; set; } = 5;
        public override int InitialCost { get; set; } = 5;

        public override int BuffLife { get; set; } = 5;
        public override string Describe { get; set; } = "战吼：下一回合敌方法术的法力值消耗增加（5）点。";

        public override Rarity Rare { get; set; } = Rarity.传说;

        public override List<ICardAbility> Abilities { get; set; } = new List<ICardAbility>()
        {
            new NoneTargetBattlecryDriver<
                ChangeCost<SecondaryHandSpell,Five,ONE,Plus,InHandFilter,
                        RestoreCost<MainHandSpell,Five,ONE,Minus,InHandFilter,MyTurnEndEvent>>>()
        };

        public override string Name { get; set; } = "洛欧塞布";
        public override Profession Profession { get; set; } = Profession.Neutral;
        public override string BackgroudImage { get; set; } = "NAXX/Loatheb.jpg";
    }
}
