using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.BUFF.ChangeBody;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.BattlecryDriver;
using MyHearthStoneV2.Game.Widget.Filter.CardLocationFilter;
using MyHearthStoneV2.Game.Widget.Direction;
using MyHearthStoneV2.Game.Widget.Number;
using MyHearthStoneV2.Game.Event.GameProcess;
using System.Collections.Generic;
using MyHearthStoneV2.Game.Widget.Filter.ParameterFilter.Spell;

namespace MyHearthStoneV2.Game.CardLibrary.Servant.Neutral.NAXX
{
    public class Loatheb : BaseServant
    {
        public override int Damage => 5;
        public override int Life => 5;
        public override int Cost => 5;

        public override int InitialDamage => 5;
        public override int InitialLife => 5;
        public override int InitialCost => 5;

        public override int BuffLife => 5;
        public override string Describe => "战吼：下一回合敌方法术的法力值消耗增加（5）点。";

        public override Rarity Rare => Rarity.传说;

        public override List<ICardAbility> Abilities => new List<ICardAbility>()
        {
            new NoneTargetBattlecryDriver<
                ChangeCost<SecondaryPrimarySpell,Five,ONE,Plus,InHandFilter,
                        RestoreCost<PrimaryHandSpell,Five,ONE,Minus,InHandFilter,MyTurnEndEvent>>>()
        };

        public override string Name => "洛欧塞布";
        public override Profession Profession => Profession.Neutral;
        public override string BackgroudImage => "NAXX/Loatheb.jpg";
    }
}
