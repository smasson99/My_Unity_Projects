﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Diagnostics;

/// <summary>
/// The AI Opponent
/// </summary>
public class cgEngine : MonoBehaviour
{
    /// <summary>
    /// Should a move for white(true) or black(false) be generated?
    /// </summary>
    public bool MoveAsWhite = true;

    /// <summary>
    /// Has the engine finished analyzing moves?
    /// </summary>
    public bool Finished = false;

    /// <summary>
    /// How deep should the engine search seemingly weak move?
    /// </summary>
    public byte SearchDepthWeak = 4;

    /// <summary>
    /// How deep should the engine search a seemingly strong move?
    /// </summary>
    public byte SearchDepthStrong = 4;

    /// <summary>
    /// How deep should the engine search when the number of possible moves are low(i.e. lategame or king checked situations).
    /// </summary>
    public byte SearchDepthEndGame = 5;

    /// <summary>
    /// How many board states have been examined
    /// </summary>
    public int BoardStatesExamined = 0;

    /// <summary>
    /// The current value of the board.
    /// </summary>
    public int CurrentBoardValue = 0;

    /// <summary>
    /// All legal moves being analyzed.
    /// </summary>
    public List<cgSimpleMove> Moves;

    /// <summary>
    /// How many moves are left to analyze.
    /// </summary>
    public int MovesLeftToAnalyze = 0;

    /// <summary>
    /// How many moves in total have to be analyzed.
    /// </summary>
    public int TotalMovesToAnalyze = 0;

    /// <summary>
    /// The provided loadbar to display how far the analysis is.
    /// </summary>
    public GameObject LoadBar;
    private cgBoard _board;
    private Action<cgSimpleMove> _callback;


    private Stopwatch stopwatch;


    /// <summary>
    /// Called when the engine should generate a new move.
    /// </summary>
    /// <param name="board">The current board state.</param>
    /// <param name="MoveAsWhiteP">Move as white(true) or black(false).</param>
    /// <param name="callback">Where the prefered move will be returned.</param>
    public void MakeMove(cgBoard board, bool MoveAsWhiteP, Action<cgSimpleMove> callback)
    {
        //stopwatch = new Stopwatch();
        //stopwatch.Start();

        Finished = false;
        _board = board;
        MoveAsWhite = MoveAsWhiteP;
        _callback = callback;


        StartCoroutine(_startAnalysis());
    }

    /// <summary>
    /// Called when the analysis starts.
    /// </summary>
    /// <returns></returns>
    IEnumerator _startAnalysis()
    {
        yield return null;
        Finished = false;
        Moves = _board.findStrictLegalMoves(MoveAsWhite);
        if (Moves.Count > 1)
        {
            MovesLeftToAnalyze = Moves.Count;
            TotalMovesToAnalyze = Moves.Count;
            if (LoadBar != null) LoadBar.transform.localScale = new Vector3(0, LoadBar.transform.localScale.y, 1);
            int alpha = int.MinValue;
            int beta = int.MaxValue;
            for (int i = 0; i < Moves.Count; i++)
            {
                cgSimpleMove possibleMove = Moves[i];
                byte depth = (cgValueModifiers.AlphaBeta_Strong_Delineation < possibleMove.positionalVal ? SearchDepthStrong : SearchDepthWeak);
                if (Moves.Count < 10) depth = SearchDepthEndGame;
                //determining whether move looks weak or strong based on positional value, if its strong we use strong depth otherwise we use weak depth.
                possibleMove.val = _alfaBeta(possibleMove, depth, alpha, beta, !MoveAsWhite);
                MovesLeftToAnalyze--;
                yield return null;
            }
            _sortMovesOnBoardValue(Moves, MoveAsWhite);

        }

        yield return null;
        _analysisComplete();
    }

    /// <summary>
    /// Called when the analysis is completed.
    /// </summary>
    private void _analysisComplete()
    {
        _sortMovesOnBoardValue(Moves, MoveAsWhite);
        if(Moves.Count>0)_callback(Moves[0]);
        
        CurrentBoardValue = _board.Evaluate();


        Finished = true;

        //stopwatch.Stop();
        //UnityEngine.Debug.Log("time: " + stopwatch.Elapsed);
    }
    /// <summary>
    /// Utilizing an AlphaBeta searching algorithm, we generate moves evaluate them, prune and decide which is best.
    /// https://en.wikipedia.org/wiki/Alpha%E2%80%93beta_pruning
    /// </summary>
    /// <param name="node">the move to analyze</param>
    /// <param name="depth">The max depth to search to, execution time increases exponentially the higher the depth</param>
    /// <param name="alpha"></param>
    /// <param name="beta"></param>
    /// <param name="maximizing"></param>
    /// <returns>The value of the provided node</returns>
    
    
    private int _alfaBeta(cgSimpleMove node, int depth, int alpha = int.MinValue, int beta = int.MaxValue, bool maximizing = true)
    {
        
        _board.move(node);
        if (depth == 0)
        {
            int val = _board.Evaluate();
            _board.revert();
            return val;
        }

        if (maximizing)
        {
            int v = int.MinValue;
            List<cgSimpleMove> replies = _board.findLegalMoves(true);
            foreach (cgSimpleMove reply in replies)
            {

                int candidate = _alfaBeta(reply, depth - 1, alpha, beta, false);
                v = candidate > v ? candidate : v;
                
                alpha = alpha > v ? alpha : v;
                if (beta < alpha)
                {
                    break;
                }
            }
            _board.revert();
            return v;
        }
        else
        {
            int v = int.MaxValue;
            List<cgSimpleMove> replies = _board.findLegalMoves(false);
            foreach (cgSimpleMove reply in replies)
            {


                int candidate = _alfaBeta(reply, depth - 1, alpha, beta, true);
                v = candidate < v ? candidate : v;
                if (beta > v)
                {
                    beta = v;
                    //node.bestResponse = reply;
                }
                if (beta < alpha)
                {
                    break;
                }
            }
            _board.revert();
            return v;
        }

    }

    //private int _max(int v, int p)
    //{
    //    return v > p ? v : p;
    //}
    //private int _min(int v, int p)
    //{
    //    return v < p ? v : p;
    //}


    void Update()
    {
        if (_board != null) BoardStatesExamined = _board.moveCount;
        if (!Finished && LoadBar != null)
        {
            //Refresh the loadbar.
            if (MovesLeftToAnalyze != 0 && TotalMovesToAnalyze != 0)
            {
                float newX = 1 - ((float)(MovesLeftToAnalyze - 1) / (float)TotalMovesToAnalyze);
                LoadBar.transform.localScale = new Vector3(newX, LoadBar.transform.localScale.y, 1);
            }
        }
    }
    private void _sortMovesOnBoardValue(List<cgSimpleMove> moves, bool white)
    {
        moves.Sort(delegate(cgSimpleMove x, cgSimpleMove y)
        {
            return x.val.CompareTo(y.val);
        });
        if (white) moves.Reverse();
    }
    #region debug

    public void TellLegals(bool p)
    {
        //_board = _buildBoardFrom(_flatNodesPure);
        UnityEngine.Debug.Log("Legal moves for white: " + cgGlobal.ListToString(_board.findLegalMoves(true)));
    }
    private void _testBoard()
    {
        bool asWhite = true;
        int tryMoves = 200;
        UnityEngine.Debug.Log("testing board..");
        for (int i = 0; i < tryMoves; i++)
        {
            List<cgSimpleMove> moves = _board.findLegalMoves(asWhite);
            cgSimpleMove move = moves[UnityEngine.Random.Range(0, moves.Count)];
            UnityEngine.Debug.Log("trying move:" + cgGlobal.MoveToString(move));
            if (moves.Count < 2) break;
            _board.move(move);
            asWhite = !asWhite;
            _debugReadBoard();
        }
        _debugReadBoard();
        UnityEngine.Debug.Log("^^pre reversion.");
        for (int u = tryMoves; u > 0; u--) _board.revert();

        _debugReadBoard();

        UnityEngine.Debug.Log("moves:" + _board.moveCount + " reverts:" + _board.revertCount);
    }

    private void _debug()
    {
        //int index = UnityEngine.Random.Range(0, allHypotheticalMoves.Count);
        //UnityEngine.Debug.Log("Random index:" + index + " out of:" + allHypotheticalMoves.Count);
        _debugReadBoard();
        UnityEngine.Debug.Log("Board moves:" + _board.moveCount + " board reverts:" + _board.revertCount);
    }

    private void _debugReadBoard()
    {
        _board.debugReadBoard();
        //    String str = "";
        //    for (int i = 0; i < _board.squares.Count; i++)
        //    {
        //        str += " [" + ((_board.squares[i] < 0) ? "" : " ") + _board.squares[i] + "] ";
        //        if ((i + 1) % 8 == 0) str += "\n";
        //    }
        //    UnityEngine.Debug.Log(str + ", count." + _board.squares.Count);
    }
    #endregion


}