using MyHearthStoneV2.CardEnum;
using MyHearthStoneV2.CardMonitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyHearthStoneV2.CardSpecialEffect.Deathwhisper;
using MyHearthStoneV2.CardSpecialEffect;

namespace MyHearthStoneV2.CardLibrary.Servant.NAXX
{
    [PropertyChangedNotification]
    public class GuiLingZhiZhu : BaseServant
    {
        public int Damage = 2;
        public int Life = 1;
        public int Cost = 1;
        public CardLocation CardLocation = CardLocation.牌库;
        public string Describe
        {
            get
            {
                return "";
            }
        }

        public Rarity Rare
        {
            get
            {
                return Rarity.精良;
            }
        }

        public List<ISpecialEffect> LstBuff = new List<ISpecialEffect>() { new SE_GuiLingZhiZhu() };
        
        public string Name
        {
            get
            {
                return "鬼灵蜘蛛";
            }
        }        
    }
}
