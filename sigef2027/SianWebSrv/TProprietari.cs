using System;
using System.Collections.Generic;
using System.Text;

namespace SianWebSrv
{
    /// <summary>
    /// lista codici fiscali
    /// </summary>
    public class TProprietari : System.Collections.CollectionBase
    {
        public void Add(string Proprietario)
        {
            List.Add(Proprietario);
        }
        public void Remove(int index)
        {
            if (index > Count - 1 || index < 0)
            {
                throw new System.Exception("Collection index out of range");
            }
            else
            {
                List.RemoveAt(index);
            }
        }
        public string Item(int Index)
        {
            return (string)List[Index];
        }
    }
}
