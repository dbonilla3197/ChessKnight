using System;
using System.Collections.Generic;

namespace ChessKnight
{
    /// <summary>
    ///  This class contains the solution of the knight movement.
    /// </summary>
    public class Movement
    {
        private Dictionary<int, int[]> map = new Dictionary<int, int[]>();

        /// <summary>
        ///  This method fill the matrix of numbers.
        ///  Symbolize the chessboard with numbers and positions.
        /// </summary>
        public void Fill()
        {
            int cont = 0;
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    int[] boardPosition = new int[2];
                    boardPosition[0] = x;
                    boardPosition[1] = y;
                    map.Add(cont++, boardPosition);
                }
            }
        }

        /// <summary>
        ///  This method save the position in rows and columns of the start position and end position.
        /// </summary>
        /// <param name="start">The initial position of the knight.</param>
        /// <param name="end">The expected final position of the knight.</param>
        public void Calculo(int start, int end)
        {
            Fill();

            int[] firstPoint = map[start];
            int[] endPoint = map[end];

            if (firstPoint == endPoint)
            {
                Console.WriteLine("Movimientos: 0");
                return;
            }

            List<Coordinate> root = new List<Coordinate>();
            root.Add(new Coordinate(firstPoint[1], firstPoint[0]));

            Coordinate result = RSeek(root, new Coordinate(endPoint[1], endPoint[0]), 0);
        }

        /// <summary>
        ///  This method search the positions where the knight can move.
        /// </summary>
        /// <param name="genParents">The first position of the tree.</param>
        /// <param name="end">The end expected position.</param>
        /// <param name="counter">The number of movements needed.</param>
        /// <returns>The recursive method.</returns>
        public Coordinate RSeek(List<Coordinate> genParents, Coordinate end, int counter)
        {
            counter++;

            List<Coordinate> genChilds = new List<Coordinate>();

            foreach (Coordinate genParent in genParents)
            {
                List<Coordinate> childCoordinates = GetValidCoordinates(genParent.X, genParent.Y);

                foreach (Coordinate genChild in childCoordinates)
                {
                    if (end.X == genChild.X && end.Y == genChild.Y)
                    {
                        Console.WriteLine("Movimientos: " + counter);
                        return genChild;
                    }

                    genChilds.Add(genChild);
                }
            }

            return RSeek(genChilds, end, counter);
        }

        /// <summary>
        ///  This method save the values of the next positions after the start.
        /// </summary>
        /// <param name="x">The column position of the start.</param>
        /// <param name="y">The row position of the start.</param>
        /// <returns>The list of the next positions.</returns>
        public List<Coordinate> GetValidCoordinates(int x, int y)
        {
            List<Coordinate> coordinates = new List<Coordinate>();

            int[] pattr = { -1, -2, -2, -1, -2, 1, -1, 2 };

            for (int i = 0; i < 8; i += 2)
            {
                Coordinate coord = new Coordinate(x + pattr[i], y + pattr[i + 1]);
                Coordinate oppos = new Coordinate(x - pattr[i], y - pattr[i + 1]);

                if (coord.IsValid)
                {
                    coordinates.Add(coord);
                }

                if (oppos.IsValid)
                {
                    coordinates.Add(oppos);
                }
            }

            return coordinates;
        }
    }
}
