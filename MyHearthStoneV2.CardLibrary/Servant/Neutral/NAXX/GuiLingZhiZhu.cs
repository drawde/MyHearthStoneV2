using MyHearthStoneV2.CardEnum;
using System.Collections.Generic;
using MyHearthStoneV2.CardSpecialEffect.Deathwhisper;
using MyHearthStoneV2.CardSpecialEffect;
using MyHearthStoneV2.CardLibrary.Monitor;

namespace MyHearthStoneV2.CardLibrary.Servant.Neutral.NAXX
{
    [PropertyChangedNotification]
    public class GuiLingZhiZhu : BaseServant
    {
        public override int Damage { get; set; } = 2;
        public override int Life { get; set; } = 1;
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
        
        public override List<BaseSpecialEffect> LstBuff { get; set; } = new List<BaseSpecialEffect>() { new SE_GuiLingZhiZhu() };

        public override string Name
        {
            get
            {
                return "鬼灵爬行者";
            }
        }
    }
}
