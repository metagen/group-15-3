﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LotusGL.Graphics;
namespace LotusGL.Menu
{
    class TitleScreen : Menu
    {
        public void handleRegionClick(int regionid)
        {
            if (regionid == 1)
                Graphics.GraphicsFacade.mode = Graphics.GraphicsFacade.Mode.BOARD;
        }

        public void Draw(Graphics.GraphicsFacade graphics)
        {
            graphics.DrawTitle();
            graphics.DrawText(System.Drawing.Color.White, 128, 256, "You Rock!");
        }

        public GraphicsFacade.BoardRegion2D[] getRegions()
        {
            GraphicsFacade.BoardRegion2D[] ret = new GraphicsFacade.BoardRegion2D[]
            {
                new GraphicsFacade.BoardRegion2D(1, 128, 256, 256, 128)
            };

            return ret;
        }
    }
}
