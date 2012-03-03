﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using LotusGL.AI;
namespace LotusGL
{
    class Player
    {
        public Color color;
        public string name;
        public bool finished;
        AIStrategy ai;
        public Player(Color color, string name)
        {
            finished = false;
            this.name = name;
            this.color = color;
        }
        public void setAI(AIStrategy ai)
        {
            this.ai = ai;
        }
        public AIStrategy getAI()
        {
            return ai;
        }
    }
}
