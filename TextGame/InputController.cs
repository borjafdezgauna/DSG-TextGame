using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TextGame
{
    public class InputController
    {
        Action<int> OnKeyPressed { get; set; }

        public InputController(Action<int> onKeyPressed)
        {
            OnKeyPressed = onKeyPressed;
        }
        public int WaitUntilKeyPressed()
        {
            ConsoleKeyInfo key = Console.ReadKey();
            return key.KeyChar;
        }

        public void ProcessKeys()
        {
            while (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey(true); //Intercept= true : The pressed character isn't displayed on the screen
                OnKeyPressed(key.KeyChar);
            }
        }
    }
}
