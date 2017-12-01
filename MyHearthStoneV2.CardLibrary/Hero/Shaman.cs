
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.CardLibrary.Hero
{
    public class Shaman : BaseHero
    {
        public virtual new string Name { get; } = "萨满";
        public virtual new Profession profession { get; } = Profession.萨满;
    }
}
