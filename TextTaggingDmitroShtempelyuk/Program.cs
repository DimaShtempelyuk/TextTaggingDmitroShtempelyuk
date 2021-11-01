using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


namespace TextTaggingDmitroShtempelyuk
{
    class Program
    {
        public static string[] TagsArr = new string[] { "red", "blue", "upcase","stars","hide"};
        public static int[,] TextTaggedTable = new int[0, TagsArr.Length + 1];
        public static string[] TextTagged = new string[0];

        static void Main(string[] args)
        {
            byte[] tf = new byte[TagsArr.Length];
            string line = "";
            string allText = "";
            int TagPencil = 0;
            string[] textArr = new string[0];
            string[] NumOfTag = new string[0];
            List<string> list = new List<string>();

            using (StreamReader sr = new StreamReader(@"..\..\..\Text.txt"))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    allText += line;
                }
            }
            if (allText.Contains('<'))
            {
                textArr = allText.Split(" ");//neumi entry v textu
                
                TextTaggedTable = new int[textArr.Length, TagsArr.Length];
                TextTagged = new string[textArr.Length];
                for (int i = 0; i < textArr.Length; i++)
                {

                    //POKUS O ZKRACENI 
                    //
                    //bool founded = false;
                    //for (int i2 = 0; i2 < TagsArr.Length; i2++)
                    //{
                    //    if (textArr[i] == @$"<{TagsArr[i2]}>")
                    //    {
                    //        TagPencil = i2;
                    //        tf[i2] = 1;
                    //        TextTaggedTable[i, TagPencil] = tf[i2];
                    //        founded = true;
                    //    }
                    //    else if (textArr[i].StartsWith(@$"</{textArr[i2]}"))
                    //    {
                    //        TagPencil = i2;
                    //        tf[i2] = 0;
                    //        TextTaggedTable[i, TagPencil] = tf[i2];
                    //        founded = true;
                    //    }
                    //}
                    //if (founded == false)
                    //{
                    //    TextTagged[i] = textArr[i];
                    //    for (int ix = 0; ix < TagsArr.Length; ix++)
                    //    {
                    //        TextTaggedTable[i, ix] = tf[ix];
                    //    }
                    //}

                    if (textArr[i] == @$"<{TagsArr[0]}>")
                    {
                        TagPencil = 0;
                        tf[0] = 1;
                        TextTaggedTable[i, TagPencil] = tf[0];
                    }

                    else if (textArr[i].StartsWith(@$"</{TagsArr[0]}>"))
                    {
                        TagPencil = 0;
                        tf[0] = 0;
                        TextTaggedTable[i, TagPencil] = tf[0];
                    }



                    else if (textArr[i] == @$"<{TagsArr[1]}>")
                    {
                        TagPencil = 1;
                        tf[1] = 1;
                        TextTaggedTable[i, TagPencil] = tf[1];
                    }

                    else if (textArr[i].StartsWith(@$"</{TagsArr[1]}>"))
                    {
                        TagPencil = 1;
                        tf[1] = 0;
                        TextTaggedTable[i, TagPencil] = tf[1];
                    }



                    else if (textArr[i] == @$"<{TagsArr[2]}>")
                    {
                        TagPencil = 2;
                        tf[2] = 1;
                        TextTaggedTable[i, TagPencil] = tf[2];
                    }

                    else if (textArr[i].StartsWith(@$"</{TagsArr[2]}>"))
                    {
                        TagPencil = 2;
                        tf[2] = 0;
                        TextTaggedTable[i, TagPencil] = tf[2];
                    }



                    else if (textArr[i] == @$"<{TagsArr[3]}>")
                    {
                        TagPencil = 3;
                        tf[3] = 1;
                        TextTaggedTable[i, TagPencil] = tf[3];
                    }
                    else if (textArr[i].StartsWith(@$"</{TagsArr[3]}>"))
                    {
                        TagPencil = 3;
                        tf[3] = 0;
                        TextTaggedTable[i, TagPencil] = tf[3];
                    }



                    else if (textArr[i] == @$"<{TagsArr[4]}>")
                    {
                        TagPencil = 4;
                        tf[4] = 1;
                        TextTaggedTable[i, TagPencil] = tf[4];
                    }
                    else if (textArr[i].StartsWith(@$"</{TagsArr[4]}>"))
                    {
                        TagPencil = 4;
                        tf[4] = 0;
                        TextTaggedTable[i, TagPencil] = tf[4];
                    }


                    else
                    {
                        TextTagged[i] = textArr[i];
                        for (int ix = 0; ix < TagsArr.Length; ix++)
                        {
                            TextTaggedTable[i, ix] = tf[ix];
                        }
                    }
                }

            }
            else
            {
                Console.WriteLine(allText);
            }
            for (int i = 0; i < TextTaggedTable.GetLength(0); i++)
            {
                byte[] bts = new byte[TagsArr.Length];
                string st = TextTagged[i];
                if(st != null) {
                for (int i2 = 0; i2 < TagsArr.Length; i2++)
                {

                        for (int ib = 0; ib < TagsArr.Length; ib++)
                        {
                            if (i2 == ib && TextTaggedTable[i, i2] == 1)
                            {
                                bts[i2] = 1;
                            }
                            else if (i2 == ib && TextTaggedTable[i, i2] == 0)
                            {
                                bts[i2] = 0;
                            }
                        }
                }
                }
                TagsWriting a = new TagsWriting(st, bts[0], bts[1], bts[2], bts[3], bts[4]);
            }
            Console.ReadLine();
        }
    }
}
