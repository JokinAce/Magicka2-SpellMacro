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

        private static void DoSpellCombination(params KeyCode[] Combo) {
            for (int num = 0; num != Combo.Length; num++) {
                Simulate.Events()
                    .Click(Combo[num])
                    .Invoke();
                Thread.Sleep(15);
            }
        }

        static void Main(string[] args) {
            Console.Title = "Magicka 2 | Spell Macro | JokinAce";

            Console.WriteLine(@"Magicka 2 | Spell Macro | JokinAce
Spell Combos
----------------------------------
Num 5 - Beam: Wets target, high damage
Num 6 - Shield Wall: Chills targets passing through
----------------------------------

Magicks
----------------------------------
Space + Num 5 - Highlander Breeze
Space + Num 6 - Ice Tornado
Space + Num 7 - Spike Quake
Space + Num 8 - Summon Living Dead People
Space + Num 9 - Thunderhead
Space + Num 0 - Disruptor
---------------------------------");

            while (true) {
                if (!IsKeyPushedDown(KeyCode.Space) && IsKeyPushedDown(KeyCode.D5)) {
                    DoSpellCombination(
                        KeyCode.Q, KeyCode.F,
                        KeyCode.Q, KeyCode.F,
                        KeyCode.S,
                        KeyCode.A, KeyCode.A
                    );
                } else if (!IsKeyPushedDown(KeyCode.Space) && IsKeyPushedDown(KeyCode.D6)) {
                    DoSpellCombination(
                        KeyCode.E,
                        KeyCode.A, KeyCode.A,
                        KeyCode.R, KeyCode.R
                    );
                } else if (IsKeyPushedDown(KeyCode.D5)) {
                    DoSpellCombination(
                        KeyCode.Q, KeyCode.R,
                        KeyCode.Q, KeyCode.R,
                        KeyCode.Q, KeyCode.R,
                        KeyCode.Q, KeyCode.R
                    );
                } else if (IsKeyPushedDown(KeyCode.D6)) {
                    DoSpellCombination(
                         KeyCode.Q, KeyCode.R,
                         KeyCode.Q, KeyCode.R,
                         KeyCode.D,
                         KeyCode.R, KeyCode.R
                     );
                } else if (IsKeyPushedDown(KeyCode.D7)) {
                    DoSpellCombination(
                         KeyCode.S, KeyCode.S,
                         KeyCode.D,
                         KeyCode.S, KeyCode.S
                     );
                } else if (IsKeyPushedDown(KeyCode.D8)) {
                    DoSpellCombination(
                         KeyCode.Q, KeyCode.R,
                         KeyCode.D,
                         KeyCode.S,
                         KeyCode.R
                     );
                } else if (IsKeyPushedDown(KeyCode.D9)) {
                    DoSpellCombination(
                         KeyCode.F, KeyCode.F,
                         KeyCode.S,
                         KeyCode.A, KeyCode.A
                     );
                } else if (IsKeyPushedDown(KeyCode.D0)) {
                    DoSpellCombination(
                         KeyCode.S,
                         KeyCode.D,
                         KeyCode.E
                     );
                }
                Thread.Sleep(100);
            }
        }
    }
}
