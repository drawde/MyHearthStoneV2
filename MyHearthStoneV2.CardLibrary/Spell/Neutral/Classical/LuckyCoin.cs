
using System.Collections.Generic;
using MyHearthStoneV2.CardLibrary.Base;
using MyHearthStoneV2.CardLibrary.Context;
using MyHearthStoneV2.CardLibrary.Monitor;
using MyHearthStoneV2.CardLibrary.CardAbility;
using MyHearthStoneV2.CardLibrary.CardAbility.Spell;

namespace MyHearthStoneV2.CardLibrary.Spell.Neutral.Classical
{
    public class LuckyCoin: BaseSpell
    {
        public override Rarity Rare
        {
            get
            {
                return Rarity.普通;
            }
        }        

        public override string Name
        {
            get
            {
                return "幸运币";
            }
        }
        public override int Cost { get; set; } = 0;

        public override string Describe
        {
            get
            {
                return "";
            }
        }

        public override List<BaseCardAbility> Abilities { get; set; } = new List<BaseCardAbility>() { new AppendPower() };

        public override string BackgroudImage { get; set; } = "coin_D_1.png";
    }
}
