﻿using System;
using System.Collections.Generic;
using System.Text;
using ChessProject.board;
using ChessProject.chess;

namespace ChessProject
{
    class Screen
    {
        public static void imprGame(GameChess game)
        {
            imprBoard(game.Tab);
            Console.WriteLine();
            imprCapturedPieces(game);
            Console.WriteLine();
            Console.WriteLine("Shift: " + game.Shift);
            if (!game.finished)
            {
                Console.WriteLine("Wainting Move... Player:  " + game.ActualPlayer);
                if (game.Xeque)
                {
                    Console.WriteLine("XEQUE");
                }
               
            }
            else
            {
                Console.WriteLine("XEQUEMATE!!!! :)");
                Console.WriteLine("The winner is " + game.ActualPlayer);
            }
        }

        public static void imprCapturedPieces(GameChess game)
        {
            Console.WriteLine("Captured Pieces:");
            Console.Write("White Pieces: ");
            imprCollection(game.colorPieceCaptured(Color.White));
            Console.WriteLine();
            Console.Write("Black Pieces: ");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            imprCollection(game.colorPieceCaptured(Color.Black));
            Console.ForegroundColor = aux;
            Console.WriteLine();
        }


        public static void imprCollection(HashSet<Piece> conjunto)
        {
            Console.Write("[");
            foreach (Piece x in conjunto)
            {
                Console.Write(x + " ");
            }
            Console.Write("]");
        }


        public static void imprBoard(Board tab) {

            for (int i = 0; i < tab.Rows; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < tab.Columns; j++)
                {
                        printPiace(tab.piece(i, j));
                           
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }


        public static void imprBoard(Board tab, bool[,] possiblePositions)
        {

            ConsoleColor backgroundOriginal = Console.BackgroundColor;
            ConsoleColor backgroundAlternative = ConsoleColor.DarkGray;

            for (int i = 0; i < tab.Rows; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < tab.Columns; j++)
                {
                    if (possiblePositions[i, j])
                    {
                        Console.BackgroundColor = backgroundAlternative;
                    }
                    else
                    {
                        Console.BackgroundColor = backgroundOriginal;
                    }
                    printPiace(tab.piece(i, j));
                    Console.BackgroundColor = backgroundOriginal;

                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
            Console.BackgroundColor = backgroundOriginal;
        }


        //create a method to read the position input
        public static PositionChess readPositionChess()
        {
            string s = Console.ReadLine();
            char column = s[0];
            int row =int.Parse( s[1] + "");
            return new PositionChess(column, row);
        }

        //create method to change the color of piece
        public static void printPiace(Piece piece)
        {
            if (piece == null)
            {
                Console.Write("- ");
            }
            else
            {
                if (piece.Color == Color.White)
                {
                    Console.Write(piece);
                }
                else
                {
                    ConsoleColor x = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(piece);
                    Console.ForegroundColor = x;
                }
                Console.Write(" ");
            }
        }

    }
}
