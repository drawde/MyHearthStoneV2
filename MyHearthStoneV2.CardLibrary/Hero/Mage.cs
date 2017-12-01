
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.CardLibrary.Hero
{
    public class Mage : BaseHero
    {
        public virtual new string Name { get; } = "法师";
        public virtual new Profession profession { get; } = Profession.法师;
    }
}
