using MyHearthStoneV2.CardLibrary.Base;
using MyHearthStoneV2.CardLibrary.Servant.NAXX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.CardAction.Servant.NAXX
{
    public class GuiLingZhiZhuAction : IAction
    {
        public GuiLingZhiZhu _entity;
        public GuiLingZhiZhuAction(GuiLingZhiZhu entity)
        {
            _entity = entity;
        }

        public void Attack(IBiology target)
        {
            throw new NotImplementedException();
        }
    }
}
