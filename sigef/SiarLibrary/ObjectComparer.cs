using System;
using System.Collections;

namespace SiarLibrary
{
	/// <summary>
	/// Summary description for ObjectComparer.
	/// </summary>
	/// 
    [Serializable]
    public class ObjectPropertyComparer : IComparer
    {
        //private string PropertyName;
        private ArrayList _Properties = new ArrayList();
        private ArrayList _Directions = new ArrayList();

        /// <summary>
        /// Provides Comparison opreations.
        /// </summary>
        /// <param name="propertyName">The property to compare</param>
        public ObjectPropertyComparer(string Expression)
        {
            //PropertyName = propertyName;
            string[] SplittedExpr = Expression.Split(',');
            string PropertyName;
            bool DirectionRev;
            for (int i = 0; i <= SplittedExpr.GetUpperBound(0); i++)
            {
                DirectionRev = false;
                if (-SplittedExpr[i].ToUpper().IndexOf(" ASC") < 0)
                {
                    PropertyName = SplittedExpr[i].Replace(" ASC", "").Trim();
                    //Direction = ListSortDirection.Ascending  ;
                }
                else if (-SplittedExpr[i].ToUpper().IndexOf(" DESC") < 0)
                {
                    PropertyName = SplittedExpr[i].Replace(" DESC", "").Trim();
                    DirectionRev = true;
                }
                else
                {
                    PropertyName = SplittedExpr[i].Trim();
                    //Direction = ListSortDirection.Ascending  ;
                }
                _Properties.Add(PropertyName);
                _Directions.Add(DirectionRev);
            }
        }
        private int singleCompare(object x, object y, string propertyName, bool reverse)
        {
            int result = 0;
            object a = x.GetType().GetProperty(propertyName).GetValue(x, null);
            object b = y.GetType().GetProperty(propertyName).GetValue(y, null);

            if (a != null && b == null)
                result = 1;
            else
                if (a == null && b != null)
                    result = -1;
                else
                    if (a == null && b == null)
                        result = 0;
                    else
                        result = ((IComparable)a).CompareTo(b);
            return result * ((reverse) ? -1 : 1);
        }

        /// <summary>
        /// Compares 2 objects by their properties, given on the constructor
        /// </summary>
        /// <param name="x">First value to compare</param>
        /// <param name="y">Second value to compare</param>
        /// <returns></returns>
        public int Compare(object x, object y)
        {
            int result = 0;
            for (int i = 0; i < _Properties.Count; i++)
            {
                result = singleCompare(x, y, (string)_Properties[i], (bool)_Directions[i]);
                if (result != 0)
                    break;
            }
            return result;
        }
    }
}
