using System;
using ChessKnight;

namespace ChessKnigthProblem
{
    /// <summary>
    ///  This class execute the knight solution.
    /// </summary>
    public class Program
    {
        /// <summary>
        ///  This method is the main of the project.
        /// </summary>
        public static void Main()
        {
            Movement test = new Movement();
            test.Calculo(0, 63);
            Console.ReadLine();
        }
    }
}