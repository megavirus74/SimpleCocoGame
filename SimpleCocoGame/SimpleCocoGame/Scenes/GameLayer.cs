using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using CocosSharp;
using SharpDX;

namespace SimpleCocoGame.Scenes {
    /// двоеточие после названия класса - Класс, от которого наследуемся
    internal class GameLayer: CCLayer {
        private List<Player> ListOfPlayers = new List<Player>();
        private Player _player;

        /// <summary>
        ///     Вызывается после инициализации, при входе на сцену. Схож с методом AddedToScene
        /// </summary>
        public override void OnEnter() {
            base.OnEnter();

            var labelSome = new CCLabelTtf("Press WASD to move, fucker", "kongtext", 24) {
                Color = CCColor3B.Orange,
                AnchorPoint = CCPoint.AnchorMiddleBottom,
                Position = Window.WindowSizeInPixels.Center,
            };


            // Action Examples:
            var moveBy = new CCMoveBy(1, new CCPoint(100, 0));
            var action = new CCRepeatForever(new CCSequence(moveBy, moveBy.Reverse()));

            labelSome.PositionX -= 50;
            labelSome.AddAction(action);

            AddChild(labelSome);

            // Player object here:
            _player = new Player("square") {
                Position = new CCPoint(200, 200),
                Scale = 4,
                IsAntialiased = false
            };
            AddChild(_player);
            ListOfPlayers.Add(_player);

            // Player object here:
            var _player2 = new Player("square")
            {
                Position = new CCPoint(400, 400),
                Scale = 3,
                IsAntialiased = false
            };
            AddChild(_player2);
            ListOfPlayers.Add(_player2);

            // Adding listeners
            var keyListener = new CCEventListenerKeyboard {OnKeyPressed = OnKeyPress};
            AddEventListener(keyListener);

            Schedule(Update);

            Console.WriteLine("Start Game Layer! hey-hey");

        }

        private void CheckCollision()
        {
            foreach (var Player in ListOfPlayers)
            {
                foreach (var Player2 in ListOfPlayers)
                {
                    if ((Player.Mask.IntersectsRect(Player2.Mask)) && (Player!=Player2))
                    {
                        Player.Collision(Player2);
                    }
                }
            }
        }

        private void CheckWalls()
        {
            foreach (var Player in ListOfPlayers)
            {
                ///Проверка стен справа
                if (Player.PositionX + Player.Texture.PixelsWide*Player.ScaleX/2 > Window.WindowSizeInPixels.Width)
                    Player.PositionX = Window.WindowSizeInPixels.Width - Player.Texture.PixelsWide * Player.ScaleX/2;
                ///Проверка стен сверху
                if (Player.PositionY + Player.Texture.PixelsHigh * Player.ScaleY / 2 > Window.WindowSizeInPixels.Height)
                    Player.PositionY = Window.WindowSizeInPixels.Height - Player.Texture.PixelsHigh * Player.ScaleY / 2;
                ///Проверка стен слева
                if (Player.PositionX - Player.Texture.PixelsWide * Player.ScaleX / 2 < 0)
                    Player.PositionX = Player.Texture.PixelsWide * Player.ScaleX / 2;
                ///Проверка стен снизу
                if (Player.PositionY - Player.Texture.PixelsHigh * Player.ScaleY / 2 < 0)
                    Player.PositionY = Player.Texture.PixelsHigh * Player.ScaleY / 2;
            }
        }

        public override void Update(float dt)
        {
            base.Update(dt);
            CheckCollision();
            CheckWalls();
        }

        /// <summary>
        ///     Обработчик события нажатия клавиши.
        ///     Назначается при создании Слушателя (Listener) выше
        /// </summary>
        private void OnKeyPress(CCEventKeyboard e) {
            const int moveSpeed = 20;
            var moveByR = new CCMoveBy(1, new CCPoint(moveSpeed, 0));
            var moveByL = new CCMoveBy(1, new CCPoint(-moveSpeed, 0));
            var moveByU = new CCMoveBy(1, new CCPoint(0, moveSpeed));
            var moveByD = new CCMoveBy(1, new CCPoint(0, -moveSpeed));
            if (e.Keys == CCKeys.W){
                _player.AddAction(moveByU);
            }
            if (e.Keys == CCKeys.D){
                _player.AddAction(moveByR);
            }
            if (e.Keys == CCKeys.S){

                _player.AddAction(moveByD);
            }
            if (e.Keys == CCKeys.A){
                _player.AddAction(moveByL);
            }
        }
    }
}