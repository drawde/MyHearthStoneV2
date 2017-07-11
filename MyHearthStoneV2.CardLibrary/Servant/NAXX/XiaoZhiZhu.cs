using MyHearthStoneV2.CardEnum;
using MyHearthStoneV2.CardMonitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.CardLibrary.Servant.NAXX
{
    [PropertyChangedNotification]
    public class XiaoZhiZhu : BaseServant
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
                return Rarity.普通;
            }
        }
        public string Name
        {
            get
            {
                return "小蜘蛛";
            }
        }        
    }
}
