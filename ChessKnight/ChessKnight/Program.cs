using System;
using System.Collections.Generic;

namespace ChessKnigthProblem
{

    public class Program
    {

        public static void Main()
        {
            Movement test = new Movement();
            test.Calculo(0, 1);
            Console.ReadLine();
        }
    }

    public class Movement
    {

        Dictionary<int, int[]> map = new Dictionary<int, int[]>();
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

        public List<Coordinate> GetValidCoordinates(int x, int y)
        {
            List<Coordinate> coordinates = new List<Coordinate>();

            int[] pattr = { -1, -2, -2, -1, -2, 1, -1, 2 };

            for (int i = 0; i < 8; i += 2)
            {
                Coordinate coord = new Coordinate(x + pattr[i], y + pattr[i + 1]);
                Coordinate oppos = new Coordinate(x - pattr[i], y - pattr[i + 1]);

                if (coord.IsValid) coordinates.Add(coord);
                if (oppos.IsValid) coordinates.Add(oppos);

            }

            return coordinates;
        }

        public class Coordinate
        {

            private int x;
            private int y;
            private bool isValid;

            public Coordinate(int x, int y)
            {
                this.y = y;
                this.x = x;
                this.isValid = (x < 8 && x > -1) && (y < 8 && y > -1) ? true : false;
            }

            public int X
            {
                get { return x; }
                set { x = value; }
            }

            public int Y
            {
                get { return y; }
                set { y = value; }
            }

            public bool IsValid
            {
                get { return isValid; }
                set { isValid = value; }
            }
        }
    }
}