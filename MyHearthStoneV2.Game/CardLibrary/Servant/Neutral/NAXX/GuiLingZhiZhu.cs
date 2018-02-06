
using MyHearthStoneV2.Game.CardLibrary.CardAbility;

using MyHearthStoneV2.Game.CardLibrary.CardAbility.Deathwhisper;
using MyHearthStoneV2.Game.CardLibrary.Servant;
using System.Collections.Generic;

namespace MyHearthStoneV2.Game.CardLibrary.Servant.Neutral.NAXX
{
    public class GuiLingZhiZhu : BaseServant
    {
        public override int Damage { get; set; } = 1;
        public override int Life { get; set; } = 2;
        public override int Cost { get; set; } = 2;

        public override int InitialDamage { get; set; } = 1;
        public override int InitialLife { get; set; } = 2;
        public override int InitialCost { get; set; } = 2;
        
        public override int BuffLife { get; set; } = 2;
        public override string Describe
        {
            get
            {
                return "";
            }
        }

        public override Rarity Rare
        {
            get
            {
                return Rarity.精良;
            }
        }
        
        public override List<BaseCardAbility> Abilities { get; set; } = new List<BaseCardAbility>() { new CA_GuiLingZhiZhu() };

        public override string Name { get; set; } = "鬼灵爬行者";
        public override Profession Profession { get; set; } = Profession.Neutral;

        public override Race Race { get; set; } = Race.野兽;
    }
}
