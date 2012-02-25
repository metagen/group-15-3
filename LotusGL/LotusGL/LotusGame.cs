﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LotusGL
{
    class LotusGame
    {
        Graphics.GraphicsFacade graphics;
        
        Player[] players;

        Player currentPlayer;
        Board board;

        public LotusGame(Graphics.GraphicsFacade graphics)
        {
            this.graphics = graphics;
            Start();
            graphics.Init();
            graphics.onUpdate += new Graphics.GraphicsFacade.UpdateEventHandler(this.Update);
            graphics.onDraw += new Graphics.GraphicsFacade.DrawEventHandler(this.Draw);
            graphics.Run();
        }

        public void Start()
        {
            players = new Player[4];
            players[0] = new Player(System.Drawing.Color.Red);
            players[1] = new Player(System.Drawing.Color.Black);
            players[2] = new Player(System.Drawing.Color.White);
            players[3] = new Player(System.Drawing.Color.Blue);

            board = new Board(players);
            Graphics.GraphicsFacade.mode = Graphics.GraphicsFacade.Mode.BOARD;

        }

        public void Update(Graphics.GraphicsFacade.MouseEvent m)
        {
            if (m.x != 0)
            {
                Console.WriteLine(m.x + ", " + m.y);
            }
            graphics.setClickableRegions(board.getRegions());
        }

        public void Draw()
        {
            if (false == true)
            {

            }
            else
            {
                board.Draw(graphics);
            }
        }
    }
}
