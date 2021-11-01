using System;
using System.Collections.Generic;
using System.Text;

namespace TextTaggingDmitroShtempelyuk
{
    public class TagsWriting
    {
        TagsWriting()
        {

        }
        public TagsWriting(string st,byte x1, byte x2, byte x3, byte x4, byte x5)
        {
            string stForm ="";
            if (x1 == 1 && x2 == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                stForm = st;
            }
            else if(x1 == 0 && x2 ==0)
            {
                Console.ResetColor();
                stForm = "";
            }
            if(x2 == 1 && x1 == 0)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                stForm = st;
            }
            else if (x1 == 0 && x2 == 0)
            {
                Console.ResetColor();
                stForm = "";
            }
            if (x3 == 1)
            {
                stForm = st.ToUpper();
            }
            else if (x3 == 0)
            {
                stForm = st;
            }
            if(x4 == 1)
            {
                stForm = "***" + stForm + "***";
            }
            if(x5 == 1)
            {
                int xStForm = stForm.Length;
                stForm = "";
                for (int i = 0; i < xStForm; i++)
                {
                    stForm += "*";
                }
            }
            Console.Write(stForm + " ");
        }

    }
}
