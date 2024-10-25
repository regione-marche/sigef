using System;

namespace SiarLibrary.Extensions
{
    public static class SiarExtensionMethods
    {
        public static bool FindValueIn(this object o, params object[] valori)
        {
            if (o != null) foreach (object v in valori)
                    if (v != null && o.GetType() == v.GetType() && o.Equals(v)) return true;
            return false;
        }

        public static bool FindValueIn(this NullTypes.NullType o, params object[] valori)
        {
            if (o == null) return false;
            return o.GetType().GetProperty("Value").GetValue(o, null).FindValueIn(valori);
        }

        public static bool Between(this NullTypes.DecimalNT o, decimal start_val, decimal end_val)
        {
            if (o == null) return false;
            return Between(o.Value, start_val, end_val);
        }

        public static bool Between(this NullTypes.IntNT o, decimal start_val, decimal end_val)
        {
            if (o == null) return false;
            return Between((decimal)o.Value, start_val, end_val);
        }

        public static bool Between(this decimal d, decimal start_val, decimal end_val)
        {
            return d >= start_val && d <= end_val;
        }

        public static string ToJsonString(this NullTypes.NullType o)
        {
            if (o == null) return "''";
            string v = ToCleanJsString(o);
            if (o is SiarLibrary.NullTypes.StringNT || o is SiarLibrary.NullTypes.DatetimeNT) return "'" + v + "'";
            else if (o is SiarLibrary.NullTypes.BoolNT) return v.ToLower();
            else if (o is SiarLibrary.NullTypes.DecimalNT) return v.Replace(",", ".");
            return v;
        }

        public static string ToCleanJsString(this object o)
        {
            if (o == null) return "";
            return o.ToString().Replace("'", "`").Replace("\"", "").Replace("\n", "").Replace("\r", "");
        }

        public static string ToFullJsString(this object o)
        {
            if (o == null) return "";
            return o.ToString();
        }

        public static string ToStringArray(this System.Collections.ArrayList al, string separatore)
        {
            string retval = "";
            foreach (object o in al) retval += o.ToCleanJsString() + separatore;
            if (retval.Length > 0) retval = retval.Substring(0, retval.Length - separatore.Length);
            return retval;
        }

        public static bool StartsWith(this NullTypes.NullType o, params string[] valori)
        {
            if (o != null)
            {
                string val = o.ToString().ToUpper();
                foreach (string v in valori) if (val.StartsWith(v.ToUpper())) return true;
            }
            return false;
        }

        public static bool Contains(this NullTypes.NullType o, params string[] valori)
        {
            if (o != null)
            {
                string val = o.ToString().ToUpper();
                foreach (string v in valori) if (val.Contains(v.ToUpper())) return true;
            }
            return false;
        }

        public static string Contains(this string[] valori, string pattern)
        {
            foreach (string s in valori) if (s.Contains(pattern)) return s;
            return null;
        }

        public static NullTypes.NullType IsNullAlt(this NullTypes.NullType nt1, NullTypes.NullType nt2)
        {
            if (nt1 == null) return nt2; return nt1;
        }
    }
}
