using MyHearthStoneV2.CardEnum;
using MyHearthStoneV2.CardMonitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyHearthStoneV2.CardSpecialEffect.Other;
namespace MyHearthStoneV2.CardLibrary.Servant.Classical
{
    [PropertyChangedNotification]
    public class Al_akir : BaseServant
    {
        public int Damage = 3;
        public int Life = 4;
        public int Cost = 8;
        public CardLocation CardLocation = CardLocation.牌库;
        
        public List<BuffTime> LstBuff = new List<BuffTime>() { new BuffTime(typeof(Taunt), BuffTimeLimit.无限制) , new BuffTime(typeof(Windfury), BuffTimeLimit.无限制),
        new BuffTime(typeof(Charge), BuffTimeLimit.无限制),new BuffTime(typeof(HolyShield), BuffTimeLimit.无限制)};
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
                return Rarity.传说;
            }
        }
        
        public string Name
        {
            get
            {
                return "风领主奥拉基尔";
            }
        }
    }
}
