using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;

namespace BoxOfCoins
{
    public class BoxOfCoins
    {

        public static int Solve(int[] boxes)
        {
            int n = boxes.Length;
            int left = 0;
            int right = n - 1;

            int[,] memo = new int[n, n];
            bool[,] visited = new bool[n, n];
            return CalculateDifference(boxes, left, right, memo, visited);
        }

        private static int CalculateDifference(int[] boxes, int left, int right, int[,] memo, bool[,] visited)
        {
            if (left == right) return boxes[left];

            if (visited[left, right]) return memo[left, right];

            // Alex pick left first 
            int pickLeft = boxes[left] - CalculateDifference(boxes, left + 1, right, memo, visited);
            // Alex pick right first
            int pickRight = boxes[right] - CalculateDifference(boxes, left, right - 1, memo, visited);

            // we memorize the result of choice each run
            memo[left, right] = Math.Max(pickLeft, pickRight);
            visited[left, right] = true;    // avoid repeat calculation for the same left and right index

    
            return memo[left, right];   
        }
        
        
    }

}