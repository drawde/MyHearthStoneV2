
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.CardLibrary.Hero
{
    public class Rogue : BaseHero
    {
        public virtual new string Name { get; } = "盗贼";
        public virtual new Profession profession { get; } = Profession.盗贼;
    }
}
