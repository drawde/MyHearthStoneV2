using MyHearthStoneV2.CardLibrary.Base;
using MyHearthStoneV2.SpecialEffect.WarCry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.CardLibrary.Servant.Classical
{
    public class JiaoXiaoDeZhongShi : BaseServant, ChangeBody
    {
        private int _damage = 2;
        private int _life = 1;
        private int _cost = 1;
        private CardLocation _cardLocation = CardLocation.牌库;

        public CardLocation cardLocation
        {
            get
            {
                return _cardLocation;
            }

            set
            {
                _cardLocation = value;
            }
        }

        private int _chessboardIndex = -1;
        public int ChessboardIndex
        {
            get
            {
                return _chessboardIndex;
            }

            set
            {
                _chessboardIndex += value;
            }
        }
        public int Damage
        {
            get
            {
                return _damage;
            }

            set
            {
                _damage += value;
            }
        }

        public int Life
        {
            get
            {
                return _life;
            }

            set
            {
                _life = value;
            }
        }

        public string Name
        {
            get
            {
                return "叫嚣的中士";
            }
        }

        public int Cost
        {
            get
            {
                return _cost;
            }

            set
            {
                _cost += value;
            }
        }
        public void InChessboard()
        {
            throw new NotImplementedException();
        }

        public void OutChessboard()
        {
        }

        public void Spell()
        {
        }
    }
}
