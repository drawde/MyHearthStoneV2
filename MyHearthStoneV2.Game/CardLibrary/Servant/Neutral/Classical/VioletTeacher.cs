using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Aura;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.Quantity;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.Filter.Context;
using MyHearthStoneV2.Game.CardLibrary.Servant;
using System.Collections.Generic;

namespace MyHearthStoneV2.Game.CardLibrary.Servant.Neutral.Classical
{
    public class VioletTeacher : BaseServant
    {
        public override int Damage { get; set; } = 3;
        public override int Life { get; set; } = 5;
        public override int Cost { get; set; } = 4;

        public override int InitialDamage { get; set; } = 3;
        public override int InitialLife { get; set; } = 5;
        public override int InitialCost { get; set; } = 4;
        
        public override int BuffLife { get; set; } = 5;

        public override string Describe { get; set; } = "每当你施放一个法术时，召唤一个1/1的紫罗兰学徒。";

        public override Rarity Rare { get; set; } = Rarity.精良;

        public override List<BaseCardAbility> Abilities { get; set; } = new List<BaseCardAbility>()
        {
            new BeforeICastSpellDriver<Summon<MainUserContextFilter,VioletStudent,ONE>>(),            
        };


        public override string Name { get; set; } = "紫罗兰教师";

        public override string BackgroudImage { get; set; } = "W7_064_D.png";
        public override Profession Profession { get; set; } = Profession.Neutral;
    }
}
