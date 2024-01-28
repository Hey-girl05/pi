```csharp
using System;
using System.Collections.Generic;
using System.Threading;

namespace Piano
{
    class Program
    {
        static int[] firstOctave = new int[] { 262, 294, 330, 349, 392, 440, 494 };
        static int[] secondOctave = new int[] { 523, 587, 659, 698, 784, 880, 988 };
        static int[] thirdOctave = new int[] { 1047, 1175, 1319, 1397, 1568, 1760, 1976 };

        static int[] currentOctave = firstOctave; // начальная октава

        static void Main(string[] args)
        {
            Console.WriteLine("Добро пожаловать в пианино!");

            while (true)
            {
                Console.WriteLine("Доступные команды:");
                Console.WriteLine("1 - переключить октаву");
                Console.WriteLine("2 - играть на пианино");
                Console.WriteLine("3 - выход");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        SwitchOctave();
                        break;
                    case "2":
                        PlayPiano();
                        break;
                    case "3":
                        Console.WriteLine("До свидания!");
                        return;
                    default:
                        Console.WriteLine("Ошибка: неверный ввод");
                        break;
                }
            }
        }

        static void SwitchOctave()
        {
            Console.WriteLine("Выберите октаву:");
            Console.WriteLine("1 - первая");
            Console.WriteLine("2 - вторая");
            Console.WriteLine("3 - третья");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    currentOctave = firstOctave;
                    break;
                case "2":
                    currentOctave = secondOctave;
                    break;
                case "3":
                    currentOctave = thirdOctave;
                    break;
                default:
                    Console.WriteLine("Ошибка: неверный ввод");
                    break;
            }
        }

        static void PlayPiano()
        {
            Console.WriteLine("Играйте на пианино! Для выхода нажмите Esc.");

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                    if (keyInfo.Key == ConsoleKey.Escape)
                    {
                        break;
                    }

                    int noteIndex = GetNoteIndex(keyInfo.Key);
                    if (noteIndex != -1)
                    {
                        int frequency = currentOctave[noteIndex];
                        Console.WriteLine($"Играем ноту {keyInfo.KeyChar}, частота {frequency} Гц");
                        PlaySound(frequency);
                    }
                }
            }
        }

        static int GetNoteIndex(ConsoleKey key)
        {
            List<ConsoleKey> whiteKeys = new List<ConsoleKey> { ConsoleKey.A, ConsoleKey.S, ConsoleKey.D, ConsoleKey.F, ConsoleKey.G, ConsoleKey.H, ConsoleKey.J };
            List<ConsoleKey> blackKeys = new List<ConsoleKey> { ConsoleKey.W, ConsoleKey.E, ConsoleKey.T, ConsoleKey.Y, ConsoleKey.U };

            int index = -1;

            if (whiteKeys.Contains(key))
            {
                index = whiteKeys.IndexOf(key);
            }
            else if (blackKeys.Contains(key))
            {
                index = blackKeys.IndexOf(key);
                if (index == 0)
                {
                    index--; // для клавиши W нет черной клавиши, поэтому индекс нужно уменьшить на 1
                }
                index += whiteKeys.Count; // смещаем индекс на количество белых клавиш
            }

            return index;
        }

        static void PlaySou
            nd(int frequency)
        {
            Console.Beep(frequency, 500);
        }
    }
}
