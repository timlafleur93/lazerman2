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
    static class ResourceManager
    {

        static public ContentManager contRef;

        static public Resources resource;

        static public Dictionary<string, SpriteFont> fonts;

        static public void setContentRef(ContentManager inContRef)
        {
            fonts = new Dictionary<string, SpriteFont>();
            resource = new Resources();

            contRef = inContRef;

            fonts.Add("uiFont", contRef.Load<SpriteFont>("buttonFont"));

            resource.textureDic.Add("groundtiles", contRef.Load<Texture2D>("groundtiles"));
            resource.textureDic.Add("someFloors", contRef.Load<Texture2D>("someFloors"));
            resource.textureDic.Add("down", contRef.Load<Texture2D>("down"));
            resource.textureDic.Add("player", contRef.Load<Texture2D>("player"));
            //resource.textureDic["backgrounds"].GetData()
        }
    }
}
