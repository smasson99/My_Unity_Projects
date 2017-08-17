using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jeu : MonoBehaviour
{
    public GameObject pointUp;
    public GameObject pointDown;
    public GameObject deadLocation;
    public float casesSpacement;
    public Color hilightColor = Color.green;
    public Color hilightEnemyColor = Color.red;
    public int[] gameTable_Occuped;

    private static float Width;
    private static float Heigth;
    private static Case[] cases;
    private List<Case> potentialMoveCases;
    private List<Case> potentialKillCases;
    private Case selectedCase;
    private Case deadCase;
    private Piece selectedPiece;
    private bool pieceSelected;
    private static int occupedIndicator;
    private static List<Piece> pieces;
    private List<Piece> deadPieces;

    private static MoveGen MOVES;

    private void Awake()
    {
        cases = GetComponentsInChildren<Case>();
        pieces = GetComponentsInChildren<Piece>().ToList();
        if (deadLocation != null)
            deadCase = deadLocation.GetComponent<Case>();
    }

    private void Start()
    {
        MOVES = MoveGen.GetInstance();
        gameTable_Occuped = new int[64]
        {
            0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0
        };
        InstantiatePieceCases();
        occupedIndicator = -1;
        UpdateOccupedCases();
        potentialMoveCases = new List<Case>();
        potentialKillCases = new List<Case>();
        deadPieces = new List<Piece>();
        pieceSelected = false;
        //Subscribe to the clickUp events:
        foreach (Piece currentPiece in pieces)
        {
            currentPiece.SubscribeTo_CLICK_UP(
                delegate (Piece clickedPiece)
                {
                    SelectPiece(clickedPiece);
                }
                );
        }
        foreach (Case currentCase in cases)
        {
            currentCase.SubscribeToClickUp(
                delegate (Case clickedCase)
                {
                    ClickCase(clickedCase);
                }
                );
        }
    }

    private void InstantiatePieceCases()
    {
        foreach (Piece pieceCourante in pieces)
        {
            foreach (Case caseCourante in cases)
            {
                if (pieceCourante.transform.position == caseCourante.transform.position)
                {
                    pieceCourante.CurrentCase = caseCourante;
                }
            }
        }
    }

    private void UpdateOccupedCases()
    {
        if (cases.Length == gameTable_Occuped.Length)
        {
            int index = 0;
            foreach (Case caseCourante in cases)
            {
                if (caseCourante.isOccuped)
                {
                    gameTable_Occuped[index] = occupedIndicator;
                }
                else
                {
                    gameTable_Occuped[index] = 0;
                }
                index++;
            }
        }
    }

    private void HilightCase(Case caseToHilight, Color color)
    {
        caseToHilight.SetColor(color);
    }

    private void SelectPiece(Piece pieceToSelect)
    {
        //Clear the ancient case visual and Lists:
        ClearHilightVisual();
        potentialMoveCases = new List<Case>();
        potentialKillCases = new List<Case>();
        //Set the new variables:
        selectedPiece = pieceToSelect;
        pieceSelected = true;
        selectedCase = pieceToSelect.CurrentCase;
        //Hilight the case of the selected piece:
        pieceToSelect.CurrentCase.SetColor(hilightColor);
        //Now, hilight the way for the possibles movements of the selected piece:
        int index = (int)pieceToSelect.currentType;

        switch (index)
        {
            //ROI
            case 0:
                for (int i = 0; i < MOVES.movesRoi_X.GetLength(0); i++)
                {
                    for (int j = 0; j < MOVES.movesRoi_X.GetLength(1); j++)
                    {
                        bool mustBreak = false;
                        Vector3 positionToSearch = new Vector3(pieceToSelect.transform.position.x + (casesSpacement * MOVES.movesRoi_X[i, j]),
                            pieceToSelect.transform.position.y + (casesSpacement * MOVES.movesRoi_Y[i, j]),
                            0);
                        foreach (Case caseCourante in cases)
                        {
                            if (positionToSearch == caseCourante.transform.position)
                            {
                                if (caseCourante.isOccuped)
                                {
                                    mustBreak = true;
                                    foreach (Piece pieceCourante in pieces)
                                    {
                                        if (pieceCourante.CurrentCase == caseCourante)
                                        {
                                            if (pieceCourante.isWhite != selectedPiece.isWhite)
                                            {
                                                caseCourante.SetColor(hilightEnemyColor);
                                                potentialKillCases.Add(caseCourante);
                                            }
                                            else
                                            {
                                                break;
                                            }
                                        }
                                    }
                                }
                                else if (mustBreak == false)
                                {
                                    caseCourante.SetColor(hilightColor);
                                    potentialMoveCases.Add(caseCourante);
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                        if (mustBreak)
                        {
                            break;
                        }
                    }
                }
                break;
            //REINE
            case 1:
                for (int i = 0; i < MOVES.movesReine_X.GetLength(0); i++)
                {
                    for (int j = 0; j < MOVES.movesReine_X.GetLength(1); j++)
                    {
                        bool mustBreak = false;
                        Vector3 positionToSearch = new Vector3(pieceToSelect.transform.position.x + (casesSpacement * MOVES.movesReine_X[i, j]),
                            pieceToSelect.transform.position.y + (casesSpacement * MOVES.movesReine_Y[i, j]),
                            0);
                        foreach (Case caseCourante in cases)
                        {
                            if (positionToSearch == caseCourante.transform.position)
                            {
                                if (caseCourante.isOccuped)
                                {
                                    mustBreak = true;
                                    foreach (Piece pieceCourante in pieces)
                                    {
                                        if (pieceCourante.CurrentCase == caseCourante)
                                        {
                                            if (pieceCourante.isWhite != selectedPiece.isWhite)
                                            {
                                                HilightCase(caseCourante, hilightEnemyColor);
                                                potentialKillCases.Add(caseCourante);
                                            }
                                            else
                                            {
                                                break;
                                            }
                                        }
                                    }
                                }
                                else if (mustBreak == false)
                                {
                                    HilightCase(caseCourante, hilightColor);
                                    potentialMoveCases.Add(caseCourante);
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                        if (mustBreak)
                        {
                            break;
                        }
                    }
                }
                break;
            //FOU
            case 2:
                for (int i = 0; i < MOVES.movesFou_X.GetLength(0); i++)
                {
                    for (int j = 0; j < MOVES.movesFou_X.GetLength(1); j++)
                    {
                        bool mustBreak = false;
                        Vector3 positionToSearch = new Vector3(pieceToSelect.transform.position.x + (casesSpacement * MOVES.movesFou_X[i, j]),
                            pieceToSelect.transform.position.y + (casesSpacement * MOVES.movesFou_Y[i, j]),
                            0);
                        foreach (Case caseCourante in cases)
                        {
                            if (positionToSearch == caseCourante.transform.position)
                            {
                                if (caseCourante.isOccuped)
                                {
                                    mustBreak = true;
                                    foreach (Piece pieceCourante in pieces)
                                    {
                                        if (pieceCourante.CurrentCase == caseCourante)
                                        {
                                            if (pieceCourante.isWhite != selectedPiece.isWhite)
                                            {
                                                HilightCase(caseCourante, hilightEnemyColor);
                                                potentialKillCases.Add(caseCourante);
                                            }
                                            else
                                            {
                                                break;
                                            }
                                        }
                                    }
                                }
                                else if (mustBreak == false)
                                {
                                    HilightCase(caseCourante, hilightColor);
                                    potentialMoveCases.Add(caseCourante);
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                        if (mustBreak)
                        {
                            break;
                        }
                    }
                }
                break;
            //CAVALIER
            case 3:
                for (int i = 0; i < MOVES.movesCavalier_X.Length; i++)
                {
                    Vector3 positionToSearch = new Vector3(pieceToSelect.transform.position.x + (casesSpacement * MOVES.movesCavalier_X[i]),
                        pieceToSelect.transform.position.y + (casesSpacement * MOVES.movesCavalier_Y[i]),
                        0);
                    foreach (Case caseCourante in cases)
                    {
                        if (positionToSearch == caseCourante.transform.position)
                        {
                            if (caseCourante.isOccuped)
                            {
                                foreach (Piece pieceCourante in pieces)
                                {
                                    if (pieceCourante.CurrentCase == caseCourante)
                                    {
                                        if (pieceCourante.isWhite != selectedPiece.isWhite)
                                        {
                                            HilightCase(caseCourante, hilightEnemyColor);
                                            potentialKillCases.Add(caseCourante);
                                        }
                                        else
                                        {
                                            break;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                HilightCase(caseCourante, hilightColor);
                                potentialMoveCases.Add(caseCourante);
                            }
                        }
                    }
                }
                break;
            //TOUR
            case 4:
                for (int i = 0; i < MOVES.movesTour_X.GetLength(0); i++)
                {
                    for (int j = 0; j < MOVES.movesTour_X.GetLength(1); j++)
                    {
                        bool mustBreak = false;
                        Vector3 positionToSearch = new Vector3(pieceToSelect.transform.position.x + (casesSpacement * MOVES.movesTour_X[i, j]),
                            pieceToSelect.transform.position.y + (casesSpacement * MOVES.movesTour_Y[i, j]),
                            0);
                        foreach (Case caseCourante in cases)
                        {
                            if (positionToSearch == caseCourante.transform.position)
                            {
                                if (caseCourante.isOccuped)
                                {
                                    mustBreak = true;
                                    foreach (Piece pieceCourante in pieces)
                                    {
                                        if (pieceCourante.CurrentCase == caseCourante)
                                        {
                                            if (pieceCourante.isWhite != selectedPiece.isWhite)
                                            {
                                                HilightCase(caseCourante, hilightEnemyColor);
                                                potentialKillCases.Add(caseCourante);
                                            }
                                            else
                                            {
                                                break;
                                            }
                                        }
                                    }
                                }
                                else if (mustBreak == false)
                                {
                                    HilightCase(caseCourante, hilightColor);
                                    potentialMoveCases.Add(caseCourante);
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                        if (mustBreak)
                        {
                            break;
                        }
                    }
                }
                break;
            //PION
            case 5:
                //For the Pawn movements
                int iLength;
                if (selectedPiece.isStarting)
                {
                    iLength = MOVES.movesPion_X.GetLength(0);
                }
                else
                {
                    iLength = MOVES.movesPion_X.GetLength(0) - 1;
                }
                for (int i = 0; i < iLength; i++)
                {
                    for (int j = 0; j < MOVES.movesPion_X.GetLength(1); j++)
                    {
                        bool mustBreak = false;
                        Vector3 positionToSearch;
                        if (pieceToSelect.isWhite)
                        {
                            positionToSearch = new Vector3(pieceToSelect.transform.position.x + (casesSpacement * MOVES.movesPion_X[i, j]),
                            pieceToSelect.transform.position.y + (casesSpacement * MOVES.movesPion_Y[i, j]),
                            0);
                        }
                        else
                        {
                            positionToSearch = new Vector3(pieceToSelect.transform.position.x - (casesSpacement * MOVES.movesPion_X[i, j]),
                            pieceToSelect.transform.position.y - (casesSpacement * MOVES.movesPion_Y[i, j]),
                            0);
                        }
                        foreach (Case caseCourante in cases)
                        {
                            if (positionToSearch == caseCourante.transform.position)
                            {
                                if (caseCourante.isOccuped)
                                {
                                    foreach (Piece pieceCourante in pieces)
                                    {
                                        if (pieceCourante.CurrentCase == caseCourante)
                                        {
                                            if (pieceCourante.isWhite != selectedPiece.isWhite)
                                            {
                                                HilightCase(caseCourante, hilightEnemyColor);
                                                potentialKillCases.Add(caseCourante);
                                            }
                                            else
                                            {
                                                mustBreak = true;
                                                break;
                                            }
                                        }
                                    }
                                }
                                else if (mustBreak == false)
                                {
                                    HilightCase(caseCourante, hilightColor);
                                    potentialMoveCases.Add(caseCourante);
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                        if (mustBreak)
                        {
                            break;
                        }
                    }
                }
                //For the Pawn attacks
                for (int i = 0; i < MOVES.attacksPion_X.GetLength(0); i++)
                {
                    for (int j = 0; j < MOVES.attacksPion_X.GetLength(1); j++)
                    {
                        Vector3 positionToSearch;
                        if (pieceToSelect.isWhite)
                        {
                            positionToSearch = new Vector3(pieceToSelect.transform.position.x + (casesSpacement * MOVES.attacksPion_X[i, j]),
                            pieceToSelect.transform.position.y + (casesSpacement * MOVES.attacksPion_Y[i, j]),
                            0);
                        }
                        else
                        {
                            positionToSearch = new Vector3(pieceToSelect.transform.position.x - (casesSpacement * MOVES.attacksPion_X[i, j]),
                            pieceToSelect.transform.position.y - (casesSpacement * MOVES.attacksPion_Y[i, j]),
                            0);
                        }
                        foreach (Case caseCourante in cases)
                        {
                            if (caseCourante.transform.position == positionToSearch)
                            {
                                if (caseCourante.isOccuped)
                                {
                                    foreach (Piece pieceCourante in pieces)
                                    {
                                        if (pieceCourante.CurrentCase == caseCourante)
                                        {
                                            if (pieceCourante.isWhite != selectedPiece.isWhite)
                                            {
                                                potentialKillCases.Add(caseCourante);
                                                HilightCase(caseCourante, hilightEnemyColor);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                break;
            default:
                break;
        }
    }

    private void ClickCase(Case clickedCase)
    {
        if (pieceSelected)
        {
            if (potentialMoveCases.Contains(clickedCase))
            {
                selectedPiece.MoveTo(clickedCase);
                ClearHilightVisual();
                pieceSelected = false;
            }
        }
    }

    private void ClearHilightVisual()
    {
        if (selectedCase != null)
            selectedCase.ResetColor();
        foreach (Case caseCourante in cases)
        {
            caseCourante.ResetColor();
        }
    }
}