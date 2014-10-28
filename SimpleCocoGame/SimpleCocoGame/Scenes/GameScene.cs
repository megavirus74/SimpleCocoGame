using CocosSharp;

namespace SimpleCocoGame.Scenes {
    internal class GameScene: CCScene {
        public CCLayerColor BackgroundLayer;
        public CCLayer GameLayer;

        /// <summary>
        ///     Основная игровая сцена. Содержит какое-то количество слоёв и управляет ими
        ///     Двоеточие после названия метода конструктора - вызов базового конструктора этого класса
        /// </summary>
        public GameScene(CCWindow window): base(window) {
            BackgroundLayer = new CCLayerColor {
                Color = new CCColor3B(40, 0, 200),
                Opacity = 20
            };
            AddChild(BackgroundLayer);

            GameLayer = new GameLayer();
            AddChild(GameLayer);
        }
    }
}