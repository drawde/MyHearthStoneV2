using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver;
using MyHearthStoneV2.Game.CardLibrary.Filter.Condition.Number;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.Filter.Hero;
using System.Collections.Generic;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Filter;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.BattlecryDriver;

namespace MyHearthStoneV2.Game.CardLibrary.Servant.Neutral.GVG
{
    public class AntiqueHealbot : BaseServant
    {
        public override int Damage { get; set; } = 3;
        public override int Life { get; set; } = 3;
        public override int Cost { get; set; } = 5;

        public override int InitialDamage { get; set; } = 3;
        public override int InitialLife { get; set; } = 3;
        public override int InitialCost { get; set; } = 5;

        public override int BuffLife { get; set; } = 3;
        public override string Describe { get; set; } = "战吼：为你的英雄恢复8点生命值。";

        public override Rarity Rare { get; set; } = Rarity.普通;

        public override List<ICardAbility> Abilities { get; set; } = new List<ICardAbility>()
        {
            new NoneTargetBattlecryDriver<Heal<MainHeroFilter,Eight>,NullFilter>(),            
        };

        public override string Name { get; set; } = "老式治疗机器人";
        public override Profession Profession { get; set; } = Profession.Neutral;

        public override Race Race { get; set; } = Race.机械;
        public override string BackgroudImage { get; set; } = "GVG/AntiqueHealbot.jpg";
    }
}
