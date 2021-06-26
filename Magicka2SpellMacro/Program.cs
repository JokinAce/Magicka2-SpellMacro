using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using WindowsInput;
using WindowsInput.Events;

namespace Magicka2SpellMacro {
    internal static class Program {

        [DllImport("user32.dll")]
        static extern ushort GetAsyncKeyState(int vKey);

        private static bool IsKeyPushedDown(KeyCode vKey) {
            return (GetAsyncKeyState((int)vKey) & 0x8000) != 0;
        }

        static void Main(string[] args) {
            Console.Title = "Magicka 2 | Spell Macro | JokinAce";

            Console.WriteLine(@"Magicka 2 | Spell Macro | JokinAce
----------------------------------
Num 5 - Highlander Breeze
Num 6 - Ice Tornado
Num 7 - Spike Quake
Num 8 - Summon Living Dead People
---------------------------------");


            while (true) {
                if (IsKeyPushedDown(KeyCode.D5)) {
                    Simulate.Events()
                        .Click(KeyCode.Q, KeyCode.R)
                        .Wait(50)
                        .Click(KeyCode.Q, KeyCode.R)
                        .Wait(50)
                        .Click(KeyCode.Q, KeyCode.R)
                        .Wait(50)
                        .Click(KeyCode.Q, KeyCode.R)
                        .Invoke();
                } else if (IsKeyPushedDown(KeyCode.D6)) {
                    Simulate.Events()
                        .Click(KeyCode.Q, KeyCode.R)
                        .Wait(50)
                        .Click(KeyCode.Q, KeyCode.R)
                        .Wait(50)
                        .Click(KeyCode.D)
                        .Wait(50)
                        .Click(KeyCode.R)
                        .Wait(50)
                        .Click(KeyCode.R)
                        .Invoke();
                } else if (IsKeyPushedDown(KeyCode.D7)) {
                    Simulate.Events()
                        .Click(KeyCode.S)
                        .Wait(50)
                        .Click(KeyCode.S)
                        .Wait(50)
                        .Click(KeyCode.D)
                        .Wait(50)
                        .Click(KeyCode.S)
                        .Wait(50)
                        .Click(KeyCode.S)
                        .Invoke();
                } else if (IsKeyPushedDown(KeyCode.D8)) {
                    Simulate.Events()
                        .Click(KeyCode.Q, KeyCode.R)
                        .Wait(50)
                        .Click(KeyCode.D)
                        .Wait(50)
                        .Click(KeyCode.S)
                        .Wait(50)
                        .Click(KeyCode.R)
                        .Invoke();
                }
                    Thread.Sleep(100);
            }
        }
    }
}
