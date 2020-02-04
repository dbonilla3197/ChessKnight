namespace ChessKnight
{
    /// <summary>
    ///  This class is the properties of the positions in the chessboard.
    /// </summary>
    public class Coordinate
    {
        private int x;
        private int y;
        private bool isValid;

        /// <summary>
        /// Initializes a new instance of the <see cref="Coordinate"/> class.
        /// verify the limits of the chessboard.
        /// </summary>
        /// <param name="x">The column position in the chessboard.</param>
        /// <param name="y">The row position of the chessboard.</param>
        public Coordinate(int x, int y)
        {
            this.y = y;
            this.x = x;
            this.isValid = (x < 8 && x > -1) && (y < 8 && y > -1) ? true : false;
        }

        /// <summary>
        ///  Gets or sets the column position.
        /// </summary>
        public int X
        {
            get { return x; }
            set { x = value; }
        }

        /// <summary>
        ///  Gets or sets the row position.
        /// </summary>
        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        /// <summary>
        ///  Gets or sets a value indicating whether gets or sets the verification of the chessboard limits.
        /// </summary>
        public bool IsValid
        {
            get { return isValid; }
            set { isValid = value; }
        }
    }
}
