using MyHearthStoneV2.CardEnum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.CardLibrary.Hero
{
    public class Warrior : BaseHero
    {
        public virtual new string Name { get; } = "战士";
        public virtual new Profession profession { get; } = Profession.战士;
    }
}
