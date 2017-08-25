

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyHearthStoneV2.DAL;
using MyHearthStoneV2.DAL.Impl;
using MyHearthStoneV2.Model;
using MyHearthStoneV2.Common;
using MyHearthStoneV2.Common.Util;


namespace MyHearthStoneV2.BLL
{
    public class GameBll : BaseBLL<HS_Game>
    {
        private IRepository<HS_Game> _repository = new Repository<HS_Game>();
        private GameBll()
        {
        }
        public static GameBll Instance = new GameBll();
    }
}
