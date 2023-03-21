using System;
using SplashKitSDK;

namespace MyGame
{
    public class GameMain
    {
        public static void LoadResources()
        {
            SplashKit.LoadSoundEffect("Splat", "Splat.wav");
            SplashKit.LoadBitmap("Cherry", "Cherry.png");
            SplashKit.LoadBitmap("Gooseberry", "Gooseberry.png");
            SplashKit.LoadBitmap("Blueberry", "Blueberry.png");
            SplashKit.LoadBitmap("Pomegranate", "Pomegranate.png");
            SplashKit.LoadBitmap("Apricot", "Apricot.png");
            SplashKit.LoadBitmap("Raspberry", "Raspberry.png");
            SplashKit.LoadBitmap("Blackberry", "Blackberry.png");
            SplashKit.LoadBitmap("Strawberry", "Strawberry.png");
            SplashKit.LoadBitmap("Currant", "Currant.png");
        }

        public static void Main()
        {
            LoadResources();

            FruitKarate _game = new FruitKarate();

            // open the game window
            Window window = new Window("Fruit Karate", 800, 600);
            
            // run the game loop
            while(!window.CloseRequested)
            {
                // fetch the next batch of UI interaction
                SplashKit.ProcessEvents();

                // check user input - space to launch fruit
                if (SplashKit.KeyTyped(KeyCode.SpaceKey))
                {
                    _game.LaunchFruit();
                }

                // check user input - left mouse button to slash
                if (SplashKit.MouseClicked(MouseButton.LeftButton))
                {
                    _game.Slash(SplashKit.MousePosition());
                }

                // update the position and velocity of fruit
                _game.Update();
              
                // clear the screen to white
                SplashKit.ClearScreen(Color.White);

                // draw everything in the game
                _game.Draw();
                
                // draw onto the screen, limit to 60fps
                SplashKit.RefreshScreen(60);
            }
        }
    }
}