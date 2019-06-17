using System;
using System.Threading;

namespace Game_Of_Life
{
    internal class Program
    {
        private const int _width = 80,
            _height = 40; 
        
        private static int[,] _output,
            _state;

        public static void Main()
        {
            _output = new int[_width,  _height];
            _state = new int[_width, _height];

            Random random = new Random();
            for (int x = 0; x < _width; x++)
            for (int y = 0; y < _height; y++)
            {
                _state[x, y] = random.Next() % 2;
                Console.Write(_state[x, y]);
            }

            Console.ReadKey();
            Run();
        }

        private static void Run()
        {
            while (true)
            {
                Console.Clear();
                _output = _state;
                
                
                for (int y = 0; y < _height; y++)
                {
                    for (int x = 0; x < _width; x++)
                    {
                        Console.BackgroundColor = _output[x, y] == 1 ? ConsoleColor.White : ConsoleColor.Black;

                        Console.Write("  ");
                    }
                    Console.Write('\n');
                }

                Console.BackgroundColor = ConsoleColor.Black;

                Thread.Sleep(100);
                
                for (int x = 1; x < _width - 1; x++)
                for (int y = 1; y < _height - 1; y++)
                {
                    int neighbours = Cell(x - 1, y - 1) + Cell(x + 0, y - 1) + Cell(x + 1, y - 1) +
                                     Cell(x - 1, y + 0) + 0 + Cell(x + 1, y + 0) +
                                     Cell(x - 1, y + 1) + Cell(x + 0, y - 1) + Cell(x + 1, y + 1);

                    if (Cell(x, y) == 1)
                    {
                        if (neighbours == 2 || neighbours == 3)
                            _state[x, y] = 1;
                        else
                        {
                            _state[x, y] = 0;
                        }
                    }
                    else
                    {
                        if (neighbours == 3)
                            _state[x, y] = 1;
                    }
                }
            }
        }

        private static int Cell(int x, int y) => _output[x, y];
    }
}