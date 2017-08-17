using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGen
{
    #region:values
    public int[,] movesPion_X;
    public int[,] movesTour_X;
    public int[] movesCavalier_X;
    public int[,] movesFou_X;
    public int[,] movesReine_X;
    public int[,] movesRoi_X;

    public int[,] attacksPion_X;

    public int[,] movesPion_Y;
    public int[,] movesTour_Y;
    public int[] movesCavalier_Y;
    public int[,] movesFou_Y;
    public int[,] movesReine_Y;
    public int[,] movesRoi_Y;

    public int[,] attacksPion_Y;

    private static MoveGen instance;
    #endregion

    public static MoveGen GetInstance()
    {
        if (instance == null)
            instance = new MoveGen();
        return instance;
    }

    private MoveGen()
    {
        //Instantiate values:

        //PION
        movesPion_X = new int[2, 1]
        {
            { 1 },
            { 2 }
        };
        movesPion_Y = new int[2, 1]
        {
            { 0 },
            { 0 }
        };
        attacksPion_X = new int[2, 1]
        {
            { 1 },
            { 1 }
        };
        attacksPion_Y = new int[2, 1]
        {
            { 1 },
            { -1 }
        };
        //TOUR
        movesTour_X = new int[4, 7]
        {
            { 1, 2, 3, 4, 5, 6, 7 },
            { 0, 0, 0, 0, 0, 0, 0 },
            { -1, -2, -3, -4, -5, -6, -7 },
            { 0, 0, 0, 0, 0, 0, 0 }
        };
        movesTour_Y = new int[4, 7]
        {
            { 0, 0, 0, 0, 0, 0, 0 },
            { 1, 2, 3, 4, 5, 6, 7 },
            {0, 0, 0, 0, 0, 0, 0 },
            {-1, -2, -3, -4, -5, -6, -7 }
        };

        //CAVALIER
        movesCavalier_X = new int[8]
        {
            2, 2, -2, -2, 1, -1, 1, -1
        };
        movesCavalier_Y = new int[8]
        {
            1, -1, 1, -1, 2, 2, -2, -2
        };

        //FOU
        movesFou_X = new int[4, 7]
        {
            { 1, 2, 3, 4, 5, 6, 7 },
            {1, 2, 3, 4, 5, 6, 7 },
            {-1, -2, -3, -4, -5, -6, -7 },
            {-1, -2, -3, -4, -5, -6, -7 }
        };
        movesFou_Y = new int[4, 7]
        {
            { 1, 2, 3, 4, 5, 6, 7 },
            {-1, -2, -3, -4, -5, -6, -7 },
            {1, 2, 3, 4, 5, 6, 7 },
            {-1, -2, -3, -4, -5, -6, -7 }
        };

        //REINE
        movesReine_X = new int[8, 7]
        {
            //Diagonales:
            { 1, 2, 3, 4, 5, 6, 7 },
            { 1, 2, 3, 4, 5, 6, 7 },
            { -1, -2, -3, -4, -5, -6, -7 },
            { -1, -2, -3, -4, -5, -6, -7 },
            //Linéaires:
            { 1, 2, 3, 4, 5, 6, 7 },
            { 0, 0, 0, 0, 0, 0, 0 },
            { -1, -2, -3, -4, -5, -6, -7 },
            { 0, 0, 0, 0, 0, 0, 0 }
        };
        movesReine_Y = new int[8, 7]
        {
            //Diagonales:
            { 1, 2, 3, 4, 5, 6, 7 },
            {-1, -2, -3, -4, -5, -6, -7 },
            {1, 2, 3, 4, 5, 6, 7 },
            {-1, -2, -3, -4, -5, -6, -7 },
            //Linéaires:
            { 0, 0, 0, 0, 0, 0, 0 },
            {1, 2, 3, 4, 5, 6, 7 },
            {0, 0, 0, 0, 0, 0, 0 },
            {-1, -2, -3, -4, -5, -6, -7 }
        };

        //ROI
        movesRoi_X = new int[8, 1]
        {
            //Diagonales:
            { 1 }, 
            { 1 }, 
            { -1 }, 
            { -1 }, 
            //Linéaires:
            { 1 }, 
            { -1 }, 
            { 0 }, 
            { 0 }
        };
        movesRoi_Y = new int[8, 1]
        {
            //Diagonales:
            { 1 },
            { -1 },
            { 1 },
            { -1 }, 
            //Linéaires:
            { 0 },
            { 0 },
            { 1 },
            { -1 }
        };
    }
}
