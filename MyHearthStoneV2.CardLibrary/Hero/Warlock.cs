
using MyHearthStoneV2.CardLibrary.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.CardLibrary.Hero
{
    public class Warlock : BaseHero
    {
        public virtual new string Name { get; } = "术士";
        public virtual new Profession profession { get; } = Profession.术士;
    }
}
