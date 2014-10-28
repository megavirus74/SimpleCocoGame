using CocosSharp;
using SimpleCocoGame.Scenes;

namespace SimpleCocoGame {
    /// <summary>
    ///     Делегат приложения, создаёт игровое окно, настраивает его и запускает Директора с какой-нибудь сцены
    /// </summary>
    internal class GameDelegate: CCApplicationDelegate {
        public override void ApplicationDidFinishLaunching(CCApplication application, CCWindow mainWindow) {
            base.ApplicationDidFinishLaunching(application, mainWindow);

            mainWindow.SetDesignResolutionSize(800, 600,
                CCSceneResolutionPolicy.ShowAll);

            // Необходимо прописать путь к ресурсам
            // Шрифты должны всегда лежать в папке fonst внутри этой папки
            // Шрифты читаются только в формате xnb (формат xna ресурсов, необходимо вручную конвертировать :( )
            application.ContentRootDirectory = "Res";

            mainWindow.DisplayStats = true;
            mainWindow.AllowUserResizing = false;

            mainWindow.RunWithScene(new GameScene(mainWindow));
        }
    }
}