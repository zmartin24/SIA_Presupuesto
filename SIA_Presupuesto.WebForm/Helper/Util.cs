using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIA_Presupuesto.WebForm.Helper
{
    public class Util
    {
        const char SerializedStringArraySeparator = '|';

        public static List<string> DeserializeCallbackArgs(string data)
        {
            var items = new List<string>();
            try
            {
                if (!string.IsNullOrEmpty(data))
                {
                    int currentPos = 0;
                    int dataLength = data.Length;
                    while (currentPos < dataLength)
                    {
                        string item = DeserializeStringArrayItem(data, ref currentPos);
                        items.Add(item);
                    }
                }
            }
            catch
            {
                items.Clear();
            }
            return items;
        }

        static string DeserializeStringArrayItem(string data, ref int currentPos)
        {
            int indexOfFirstSeparator = data.IndexOf(SerializedStringArraySeparator, currentPos);
            string itemLengthString = data.Substring(currentPos, indexOfFirstSeparator - currentPos);
            int itemLength = Int32.Parse(itemLengthString);
            currentPos += itemLengthString.Length + 1;
            string item = data.Substring(currentPos, itemLength);
            currentPos += itemLength;
            return item;
        }

        //public static ImagenHelper imgHelper = new ImagenHelper();
    }
}