using MyHearthStoneV2.CardEnum;
using MyHearthStoneV2.CardLibrary.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.CardLibrary.Hero
{
    public class Hunter: BaseHero
    {
        public virtual new string Name { get; } = "猎人";
        public virtual new Profession profession { get; } = Profession.猎人;
    }
}
