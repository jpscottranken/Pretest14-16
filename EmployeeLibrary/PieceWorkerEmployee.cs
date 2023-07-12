using System;

namespace EmployeeLibrary
{
    public class PieceWorkerEmployee : Employee
    {
        /*
            +Pieces			    - decimal
	        +PricePerPiece		- decimal
	        +override string displayText() method
         */

        //  Full-Arg constructor
        /// <summary>
        ///     Full-Arg Constructor for PieceWorkerEmployee class.
        ///     This will allow us to instantiate an piece worker
        ///     employee, with a first name, a last name, an
        ///     employee number, a number of pieces, and a price
        ///     per piece.
        /// </summary>
        /// <param name="firstName">Employee First Name</param>
        /// <param name="lastName">Employee Last Name</param>
        /// <param name="empNum">Employee Number (1000 - 9999)</param>
        /// <param name="pieces">Number of pieces made (0 - 100)</param>
        /// <param name="pricePerPiece">Price per piece (0.00 and 1.00)</param>
        public PieceWorkerEmployee(string firstName,
                                   string lastName,
                                   int    empNum,
                                   int    pieces,
                                   decimal pricePerPiece)
                         : base(firstName, lastName, empNum)
        {
            Pieces          = pieces;
            PricePerPiece   = pricePerPiece;
        }

        //  Getters/Setters
        /// <summary>
        /// </summary>
        /// <returns>
        ///     Returns an integer represeting # pieces made
        /// </returns>

        /// </summary>
        int Pieces { get; set; }

        /// <summary>
        /// </summary>
        /// <returns>
        ///     Returns a decimal representing price per piece
        /// </returns>
        decimal PricePerPiece { get; set; }

        //  displayText() method
        /// <summary>
        /// </summary>
        /// <returns>
        ///     Returns a string with all pieceworker employee info
        /// </returns>
        public override string displayText()
        {
            return base.displayText() +
                   "\r\nPieces: " + Pieces.ToString() +
                   "\r\nPrice Per Piece: " + PricePerPiece.ToString("c");
        }
    }
}
