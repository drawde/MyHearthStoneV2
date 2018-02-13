using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.Quantity;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.Filter.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.Game.CardLibrary.Servant.Neutral.Classical
{
    public class BloodmageThalnos : BaseServant
    {
        public override int Damage { get; set; } = 1;
        public override int Life { get; set; } = 1;
        public override int Cost { get; set; } = 2;

        public override int InitialDamage { get; set; } = 1;
        public override int InitialLife { get; set; } = 1;
        public override int InitialCost { get; set; } = 2;


        public override int BuffLife { get; set; } = 1;
        public override string Describe { get; set; } = "法术伤害+1，亡语：抽一张牌。";

        public override Rarity Rare { get; set; } = Rarity.传说;

        public override List<BaseCardAbility> Abilities { get; set; } = new List<BaseCardAbility>()
        {
            new DeathWhisperDriver<DrawCard<MainUserContextFilter,ONE>>(),
            new SpellPower()
        };


        public override string Name { get; set; } = "血法师萨尔诺斯";
        public override string BackgroudImage { get; set; } = "Classical/BloodmageThalnos.jpg";

        public override Profession Profession { get; set; } = Profession.Neutral;
    }
}
