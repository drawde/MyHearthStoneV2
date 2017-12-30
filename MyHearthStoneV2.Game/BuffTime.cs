using MyHearthStoneV2.CardEnum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.CardLibrary
{
    public class BuffTime
    {
        public BuffTime(Type type, BuffTimeLimit time)
        {
            buffType = type;
            timeLimit = time;
        }
        public Type buffType { get; set; }
        public BuffTimeLimit timeLimit { get; set; }
    }
}
