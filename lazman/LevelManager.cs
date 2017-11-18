using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lazman
{
    class LevelManager
    {
        static public Dictionary<string, Level> levels = new Dictionary<string, Level>();
        static public Level currentLevel;

        public LevelManager()
        {
            levels.Add("level1", new Level(new Point(100, 100)));
        }

        static public void Init()
        {
            levels.Add("level1", new Level(new Point(100, 100)));

            currentLevel = levels["level1"];
        }
    }
}
