﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LotusGL.GameEvent
{
    class Move : GameEvent
    {
        public int frompos, topos;
        public Move(int frompos, int topos) : base(GameEventType.MovePiece)
        {
            this.frompos = frompos;
            this.topos = topos;
        }

        public override int[] packMe()
        {
            return new int[]
            {
                frompos,
                topos
            };
        }
    }
}
