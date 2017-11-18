using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace lazman
{
    static class TileEngine
    {

        static public Dictionary<string, Camera> cameras = new Dictionary<string, Camera>();

        static public Point tileDims = new Point(16, 16);

        static public List<TileUnit> tiles = new List<TileUnit>();

        static public Random randy;

        static public void AddCamera(string keyName, Camera inVal)
        {
            cameras.Add(keyName, inVal);
        }

        static public void Init()
        {
            randy = new Random();

            tiles.Add(new TileUnit(
                new TileArt(ResourceManager.resource.textureDic["groundtiles"], 1.0f, 1, 1)
                ));
            tiles.Add(new TileUnit(
                new TileArt(ResourceManager.resource.textureDic["groundtiles"], 1.0f, 1, 0)
                ));
            tiles.Add(new TileUnit(
                new TileArt(ResourceManager.resource.textureDic["someFloors"], 1.0f, 1, 0)
                ));
            tiles.Add(new TileUnit(
                new TileArt(ResourceManager.resource.textureDic["someFloors"], 1.0f, 1, 1)
                ));
            tiles.Add(new TileUnit(
                new TileArt(ResourceManager.resource.textureDic["someFloors"], 1.0f, 1, 2)
                ));


        }

        static public void DrawTiles(GameTime time)
        {
            if (LevelManager.currentLevel.drawTiles == false) return;

            int x = (int)(cameras["player1"].Position.X / tileDims.X);
            int boundsX = (int)(cameras["player1"].screenDims.X / 16) + x;

            if (boundsX < LevelManager.currentLevel.tileMapDims.X) boundsX += 1;

            int boundsY = (int)((cameras["player1"].screenDims.Y / 16) + (int)(cameras["player1"].Position.Y / tileDims.Y));

            if (boundsY < LevelManager.currentLevel.tileMapDims.Y) boundsY += 1;

            for (float xp = 0 - (cameras["player1"].Position.X - (x * tileDims.X)); x < boundsX; x++, xp += tileDims.X)
            {
                int y = (int)(cameras["player1"].Position.Y / tileDims.Y);
                for (float yp = 0 - (cameras["player1"].Position.Y - (y * tileDims.Y)); y < boundsY; y++, yp += tileDims.Y)
                {
                    //Renderer.batch.Draw(
                    //  ResourceManager.resource.textureDic["groundtiles"],
                    //  new Vector2(xp,yp), 
                    //  groundTiles[tileMap[x,y]], 
                    //  Color.White);

                    tiles[LevelManager.currentLevel.tileMap[x, y]].Draw(
                        new Vector2(xp + cameras["player1"].targetWindowRectangle.X, yp + cameras["player1"].targetWindowRectangle.Y));
                }
            }
        }

        static public void Draw(GameTime time)
        {
            DrawTiles(time);


        }
    }
}
