using System;
using CocosSharp;

namespace SimpleCocoGame
{
    internal class Enemy : CCSprite
    {
        public CCRect Mask;


        public Enemy(string url)
            : base(url)
        {
        }

        private void UpdateMask()
        {
            Mask = new CCRect(PositionX - Texture.PixelsWide * ScaleX * 0.5f, PositionY - Texture.PixelsHigh * ScaleY * 0.5f, Texture.PixelsWide * ScaleY, Texture.PixelsWide * ScaleX);
            Console.WriteLine(Mask);
        }

        public override void Update(float dt)
        {
            base.Update(dt);
            UpdateMask();
        }

        public override void OnEnter()
        {
            base.OnEnter();
            Schedule(Update);
        }

    }
}