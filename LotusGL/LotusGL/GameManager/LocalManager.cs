﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LotusGL
{
    class LocalManager : GameManager
    {
        Board board;

        int currentPlayer;
        public int getCurrentPlayerID()
        {
            return currentPlayer;
        }

        public LocalManager(Board b)
        {
            board = b;
        }

        public void onGameEvent(GameEvent.GameEvent ge)
        {
            switch (ge.type)
            {
                case GameEvent.GameEventType.RegionClick:
                    GameEvent.RegionClick rc = (GameEvent.RegionClick)ge;
                    if (rc.player == LotusGame.get().players[currentPlayer])
                    {
                        if (board.selectedId == int.MinValue) // Select Piece
                        {
                            if (isSelectValid(rc.pos, rc.player))
                            {
                                LotusGame.get().FireEvent(new GameEvent.Select(rc.pos));
                            }
                            else //Deselect
                            {
                                LotusGame.get().FireEvent(new GameEvent.Select(int.MinValue));
                            }
                        }
                        else if (isMoveValid(board.selectedId, rc.pos, rc.player)) // Move Piece
                        {
                            LotusGame.get().FireEvent(new GameEvent.Move(board.selectedId, rc.pos));
                        }
                        else //Deselect
                        {
                            LotusGame.get().FireEvent(new GameEvent.Select(int.MinValue));
                        }
                    }
                    break;

                case GameEvent.GameEventType.MovePiece:
                    GameEvent.Move move = (GameEvent.Move)ge;

                    board.selectedId = int.MinValue;
                    if (move.frompos != move.topos)
                        board.movePiece(move.frompos, move.topos);
                    cyclePlayer();
                    break;


                case GameEvent.GameEventType.SelectPiece:
                    GameEvent.Select select = (GameEvent.Select)ge;

                    board.selectedId = select.pos;
                    break;


                case GameEvent.GameEventType.GameOver:
                    GameEvent.GameOver gameover = (GameEvent.GameOver)ge;


                    break;
                case GameEvent.GameEventType.AITurn:
                    GameEvent.AITurn aiturn = (GameEvent.AITurn) ge;
                    LotusGame.get().players[aiturn.ai].getAI().doMove(LotusGame.get().players[aiturn.ai], board);
                    break;
            }
        }

        private void cyclePlayer()
        {
            currentPlayer = (currentPlayer + 1) % LotusGame.get().players.Length;
            while (LotusGame.get().players[currentPlayer].finished)
                currentPlayer = (currentPlayer + 1) % LotusGame.get().players.Length;
            Console.WriteLine(LotusGame.get().players[currentPlayer].color);
            int pc = board.getRemainingPlayers();
            if (pc == 1)
            {
                LotusGame.get().FireEvent(new GameEvent.GameOver(currentPlayer));
            }
            else if (LotusGame.get().players[currentPlayer].getAI() != null)
            {
                Console.WriteLine("Herpies!");
                LotusGame.get().ScheduleEvent(new GameEvent.AITurn(currentPlayer), 0.0f);
            }
        }

        private bool isSelectValid(int select, Player p)
        {
            List<Player> starttile = board.getTile(select);
            if (starttile.Count > 0 && starttile[starttile.Count - 1] == p)
            {
                return true;
            }
            return false;
        }

        private bool isMoveValid(int start, int end, Player p)
        {
            List<Player> starttile = board.getTile(start);
            start -= board.startTiles.Length;
            end -= board.startTiles.Length;
            if (starttile[starttile.Count - 1] == p)
            {
                int dist = starttile.Count;
                if (start < 0)
                {
                    if (dist < 4)
                        if (dist - 1 == end)
                            return true;
                    if (dist + 2 == end)
                        return true;
                }
                else
                {
                    if (start < 3 && start + dist > 2)
                        dist += 3;
                    if (end == start + dist)
                        return true;
                }
            }
            return false;
        }
    }
}
