using MyHearthStoneV2.CardEnum;
using MyHearthStoneV2.CardSpecialEffect.WarCry;
using MyHearthStoneV2.CardMonitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyHearthStoneV2.CardSpecialEffect;

namespace MyHearthStoneV2.CardLibrary.Servant.Classical
{
    [PropertyChangedNotification]
    public class JiaoXiaoDeZhongShi : BaseServant
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

        public List<ISpecialEffect> LstBuff = new List<ISpecialEffect>() { new SE_JiaoXiaoDeZhongShi() };
        

        public string Name
        {
            get
            {
                return "叫嚣的中士";
            }
        }
        
    }
}
