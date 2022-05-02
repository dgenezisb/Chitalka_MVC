namespace Chitalka_v3.specFunctions
{
    public class stringReaper
    {
        int start = 0;
        int end = 0;
        int i = 0;
        public List<string> listOfStrings = new List<string>();
        public stringReaper(string stringToReap) 
        {
            while(stringToReap[i] != '|')
            {
                if(stringToReap[i] == '\\')
                {
                    start = end;
                    end = i;
                    string res = stringToReap.Substring(start, end);
                    listOfStrings.Add(res);
                }
            }
        }
    }
}
