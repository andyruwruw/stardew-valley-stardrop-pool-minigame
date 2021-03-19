﻿using Microsoft.Xna.Framework.Graphics;
using StardropPoolMinigame.Scenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StardropPoolMinigame.Render
{
    interface IDraw
    {
        void draw(IScene scene, SpriteBatch batch);
    }
}