using System;
using System.Collections.Generic;

public class Solution
{
    public int NetworkDelayTime(int[][] times, int n, int k)
    {
        // Build adjacency list: for each node, the nodes it can reach and the travel time
        List<(int Neighbor, int TravelTime)>[] adjacency = new List<(int, int)>[n + 1];
        for (int node = 1; node <= n; node++)
            adjacency[node] = new List<(int, int)>();

        foreach (var edge in times)
        {
            int source = edge[0], target = edge[1], travelTime = edge[2];
            adjacency[source].Add((target, travelTime));
        }

        // Shortest time for the signal to reach each node
        int[] shortestTime = new int[n + 1];
        Array.Fill(shortestTime, int.MaxValue);
        shortestTime[k] = 0;

        // Min-heap of nodes, ordered by their arrival time
        PriorityQueue<int, int> minHeap = new PriorityQueue<int, int>();
        minHeap.Enqueue(k, 0);

        while (minHeap.Count > 0)
        {
            int currentNode = minHeap.Dequeue();

            foreach (var (neighbor, travelTime) in adjacency[currentNode])
            {
                int arrivalTime = shortestTime[currentNode] + travelTime;
                if (arrivalTime < shortestTime[neighbor])
                {
                    shortestTime[neighbor] = arrivalTime;
                    minHeap.Enqueue(neighbor, arrivalTime);
                }
            }
        }

        // The network delay is the time the LAST node receives the signal
        int maxDelay = 0;
        for (int node = 1; node <= n; node++)
        {
            if (shortestTime[node] == int.MaxValue)
                return -1;                          // this node never receives the signal

            maxDelay = Math.Max(maxDelay, shortestTime[node]);
        }

        return maxDelay;
    }
}