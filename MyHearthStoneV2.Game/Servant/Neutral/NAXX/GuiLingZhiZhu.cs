
using System.Collections.Generic;
using MyHearthStoneV2.CardLibrary.Monitor;
using MyHearthStoneV2.CardLibrary.CardAbility;
using MyHearthStoneV2.CardLibrary.CardAbility.Deathwhisper;

namespace MyHearthStoneV2.CardLibrary.Servant.Neutral.NAXX
{
    public class GuiLingZhiZhu : BaseServant
    {
        public override int Damage { get; set; } = 1;
        public override int Life { get; set; } = 2;
        public override int Cost { get; set; } = 2;
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

        public override string Name
        {
            get
            {
                return "鬼灵爬行者";
            }
        }
    }
}
