public class Logger {

    Dictionary<string,int> dic;

    public Logger() {
        dic = new Dictionary<string,int>();
    }
    
    public bool ShouldPrintMessage(int timestamp, string message) {
        if(!dic.ContainsKey(message))
        {
            dic[message] = timestamp;
            return true;
        }
        else
        {
            if(dic[message] + 10 <= timestamp)
            {
                dic[message] = timestamp;
                return true;
            } 
            else
                return false;
        }
    }
}

/**
 * Your Logger object will be instantiated and called as such:
 * Logger obj = new Logger();
 * bool param_1 = obj.ShouldPrintMessage(timestamp,message);
 */