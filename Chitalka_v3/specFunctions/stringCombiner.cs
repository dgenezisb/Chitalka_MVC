namespace Chitalka_v3.specFunctions
{
    public class stringCombiner
    {
        public string newStringOut = "";
        string prStr = "";
        char[] OSN = {'.'};
        char[] NSN = { '.' };
        int i = 0;
        int i2 = 0;
        public stringCombiner(string oldString,string newString)
        {
            if(oldString == null)
            {
                newStringOut = newString;
            }
            else
            {
               
                while(oldString[i] != '|')
                {
                    OSN[i] = oldString[i];
                    i++;
                }

                newStringOut = new string(OSN, 0, i);
                NSN[i2] = '\\';
                while(i2 < newString.Length)
                {
                    NSN[i2 + 1] = newString[i2];
                }
                prStr = new string(NSN);
                newStringOut = newStringOut + prStr;
            }
        }
    }
}
