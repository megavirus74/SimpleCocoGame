using CocosSharp;

namespace SimpleCocoGame {
    internal class Program {
        private static void Main(string[] args) {
            var application = new CCApplication(false, new CCSize(800, 600)) {
                ApplicationDelegate = new GameDelegate()
            };

            application.StartGame();
        }
    }
}