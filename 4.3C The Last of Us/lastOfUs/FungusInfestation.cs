using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;

namespace FungusInfestation
{
    public class FungusInfestation
    {

        private const char player = '$';
        private const char infection = 'F';
        private const char empty = '.';
        private static char wall = '#';
    //======================================================
        
        // == INFECTION ==
        private static Queue<int[]> infectedQueue = new Queue<int[]>();
        private static int[,] infectedTime = {};
        // == PLAYER ==
        private static Queue<int[]> playerQueue = new Queue<int[]>();
        private static int[,] playerTime = {};
        private static int longestTime = -1;

        public static int Solve(string[] matrix)
        {
            // refresh data
            longestTime = -1;
            infectedQueue.Clear();
            playerQueue.Clear();

            infectedTime = new int[matrix.Length,matrix[0].Length];
            playerTime   = new int[matrix.Length,matrix[0].Length];

            // initialize all cells to MaxValue
            for (int i = 0; i < matrix.Length; i++)
                for (int j = 0; j < matrix[0].Length; j++)
                {
                    infectedTime[i, j] = int.MaxValue;
                }
                    
            InitializeInfection(matrix);    // get infection list
            InfectedSpread(matrix);    // matrixArray, infected list, timeInfected
            int[] playerLocation = FindPlayerLocation(matrix);  // get player location
            longestTime = infectedTime[playerLocation[0], playerLocation[1]];

            return PlayerMove(matrix);  
        }

        // == PLAYER ==
        private static int[] FindPlayerLocation(string[] matrix)
        {
            int[] location = null;
            for (int i=0; i<matrix.Length;i++)   // ROW
                {
                    for (int j=0;j<matrix[i].Length;j++)    // COLUMN
                    {
                        if (matrix[i][j] == player)
                        {
                            playerQueue.Enqueue(new int[] {i, j});
                            playerTime[i, j] = 0; // mark player at 0 hour
                            location = new int[] { i, j };
                        }
                        else
                        {
                            playerTime[i,j] = -1;
                        }
                    }
                }
            return location;
        }

        private static int PlayerMove(string[] matrix)
        {
            
            while (playerQueue.Count > 0)
            {
                int[] current = playerQueue.Dequeue();
                int x = current[0];
                int y = current[1];

                // already safe DONT MOVE
                if (infectedTime[x, y] == int.MaxValue) return -1;  

                if (infectedTime[x, y] > longestTime)
                    longestTime = infectedTime[x, y];

                int nextPlayerTime = playerTime[x, y] + 1;

                Move(matrix, x, y-1, nextPlayerTime);   // UP
                Move(matrix, x, y+1, nextPlayerTime);   // DOWN 
                Move(matrix, x+1, y, nextPlayerTime);   // RIGHT
                Move(matrix, x-1, y, nextPlayerTime);   // LEFT

            }
            return  longestTime;
        }

        private static void Move(string[] matrix, int x, int y, int time)
        {
            // boundary check
            if (x < 0 || x >= matrix.Length || 
                y < 0 || y >= matrix[0].Length) return;
            
            // wall check
            if (matrix[x][y] == wall) return;
            // survive check
            // player can move if they haven't been there (-1)
            // AND they arrive before infection
            if (playerTime[x, y] == -1)
            {
                if (infectedTime[x, y] == int.MaxValue || time < infectedTime[x, y])
                {
                    playerTime[x, y] = time;
                    playerQueue.Enqueue(new int[] { x, y });
                }
            }
        }

        // == INFECTION ==
        private static void InfectedSpread(string[] matrix)
        {   
            while (infectedQueue.Count > 0)
            {
                int[] current = infectedQueue.Dequeue();
                int x = current[0];
                int y = current[1];

                int nextTime = infectedTime[x,y]+1;

                Spread(matrix, infectedTime, x, y-1, nextTime);   // UP
                Spread(matrix, infectedTime, x, y+1, nextTime);   // DOWN 
                Spread(matrix, infectedTime, x+1, y, nextTime);   // RIGHT
                Spread(matrix, infectedTime, x-1, y, nextTime);   // LEFT

            }
        }

        private static void Spread(string[] matrix, int[,] infectedTime, int x, int y, int time)
        {
            // boundary check
            if (x >= matrix.Length    || x < 0 || 
                y >= matrix[0].Length || y < 0) return;

            // pass wall 
            if (matrix[x][y] == wall)   return;
            // visit check
            if (infectedTime[x,y] == int.MaxValue)
            {
                infectedTime[x, y] = time;
                infectedQueue.Enqueue(new int[] { x, y });
            }
        }
        private static void InitializeInfection(string[] matrix) 
        {
            for (int i=0; i<matrix.Length;i++)
            {
                for (int j=0; j<matrix[i].Length;j++)
                {
                    if (matrix[i][j] == infection)
                    {
                        infectedQueue.Enqueue(new int[] {i, j});
                        infectedTime[i, j] = 0; // mark infection at 0 hour
                    }
                }
            }
        } 

    }
}