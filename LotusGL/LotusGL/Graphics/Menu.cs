﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenTK.Graphics.OpenGL;
using OpenTK;

namespace LotusGL.Graphics
{
    class Menu
    {
        static bool Loaded = false;
        static float height = 10;
        
        public static void Load()
        {
            Loaded = true;
            TextureLoader.get().loadTexture(@"..\..\images\title.bmp", "Title");
            TextureLoader.get().loadTexture(@"..\..\images\gameover.bmp", "GameOver");
        }

        
        public static void Draw(string menuname)
        {
            if(!Loaded)
                Load();
            GL.PushMatrix();

            Matrix4 translation = Matrix4.Identity;// Matrix4.CreateTranslation(new Vector3(-0.5f, -0.5f, 0));
            GL.LoadMatrix(ref translation);
            GL.Enable(EnableCap.Texture2D);
            switch(menuname)
            {
                case "title":
                    GL.BindTexture(TextureTarget.Texture2D, TextureLoader.get().getTexture("Title"));
                    break;
                case "gameover":
                    GL.BindTexture(TextureTarget.Texture2D, TextureLoader.get().getTexture("GameOver"));
                    break;
            }
            GL.Begin(BeginMode.TriangleStrip);
            GL.TexCoord2(new OpenTK.Vector2d(0, 0));
            GL.Vertex3(-1, -1, 0);
            GL.TexCoord2(new OpenTK.Vector2d(1, 0));
            GL.Vertex3(1, -1, 0);
            GL.TexCoord2(new OpenTK.Vector2d(0, 1f));
            GL.Vertex3(-1, 1, 0);
            GL.TexCoord2(new OpenTK.Vector2d(1, 1f));
            GL.Vertex3(1, 1, 0);

            GL.End();
            GL.PopMatrix();
        }

        public static void DrawString(string text)
        {
            
        }

        public static void UnLoad()
        {
            TextureLoader.get().releaseTextures();
        }
    }
}
