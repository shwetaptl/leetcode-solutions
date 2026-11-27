public class Solution {
    public int CanCompleteCircuit(int[] gas, int[] cost) {
        int start = 0 , total = 0 , fuel = 0;
        for(int i = 0 ; i < gas.Length ; i++)
        {
            int gain = gas[i] - cost[i];
            total += gain;
            fuel += gain;
            if(fuel < 0)
            {
                start = i+1;
                fuel = 0;
            }
        } 
        return total >= 0 ? start : -1; 
    }
}