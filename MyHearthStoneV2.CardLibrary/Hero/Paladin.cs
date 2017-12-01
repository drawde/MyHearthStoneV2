
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.CardLibrary.Hero
{
    public class Paladin : BaseHero
    {
        public virtual new string Name { get; } = "圣骑士";
        public virtual new Profession profession { get; } = Profession.圣骑士;
    }

}
