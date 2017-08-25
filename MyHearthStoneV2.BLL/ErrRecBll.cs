using MyHearthStoneV2.DAL;
using MyHearthStoneV2.DAL.Impl;
using MyHearthStoneV2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.BLL
{
    public class ErrRecBll : BaseBLL<HS_ErrRec>
    {
        private IRepository<HS_ErrRec> _repository = new Repository<HS_ErrRec>();
        private ErrRecBll()
        {
        }
        public static ErrRecBll Instance = new ErrRecBll();
    }
}
