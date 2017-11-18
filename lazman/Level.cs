using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace lazman
{
    class Level
    {

        public Rectangle levelWorldDims;
        public Point tileMapDims;
        public int[,] tileMap;
        public bool drawTiles = true;

        public Level(Point worldDims)
        {
            levelWorldDims = new Rectangle(0, 0, worldDims.X * TileEngine.tileDims.X,
                worldDims.Y * TileEngine.tileDims.Y);

            InitLevel();
        }

        public void InitLevel()
        {
            tileMapDims = new Point(levelWorldDims.Width / 16, levelWorldDims.Height / 16);
            tileMap = new int[tileMapDims.X, tileMapDims.Y];

            for (int y = 0; y < tileMapDims.Y; y++)
            {
                for (int x = 0; x < tileMapDims.X; x++)
                {
                    tileMap[x, y] = TileEngine.randy.Next(TileEngine.tiles.Count);
                    
                }
            }
        }
    }
}
