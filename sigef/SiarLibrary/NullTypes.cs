using System;
using System.Runtime.Serialization;

namespace SiarLibrary
{
    /// <summary>
    /// Summary description for NullTypes.
    /// </summary>
    namespace NullTypes
    {
        //[Serializable]
        public class NullType : IComparable, IFormattable
        {
            protected object _value;

            /// <summary>
            /// IComparable.CompareTo implementation.
            /// </summary>
            public int CompareTo(object obj)
            {
                if (obj is NullType)
                {
                    NullType temp = (NullType)obj;

                    return compare(this, temp);
                }
                throw new ArgumentException("object is not a NullType");
            }
            private static System.Collections.Comparer _Comparer = new System.Collections.Comparer(System.Globalization.CultureInfo.CurrentCulture);
            protected static int compare(NullType a, NullType b)
            {
                if (!isNull(a) && isNull(b))
                    return 1;

                if (isNull(a) && !isNull(b))
                    return -1;

                if (isNull(a) && isNull(b))
                    return 0;
                return _Comparer.Compare(a._value, b._value);
            }
            protected static bool isNull(NullType a)
            {
                return (object)a == null || a._value == null || a._value.ToString() == "";
            }
            /*		
                        i= new  System.Collections.Comparer(System.Globalization.CultureInfo.CurrentCulture).Compare(o2,o1);
	
                        public int Compare(object x, object y)
                        {
                            object a = x.GetType().GetProperty(PropertyName).GetValue(x, null);
                            object b = y.GetType().GetProperty(PropertyName).GetValue(y, null);

                            if ( a != null && b == null )
                                return 1;

                            if ( a == null && b != null )
                                return -1;

                            if ( a == null && b == null )
                                return 0;

                            return ((IComparable)a).CompareTo(b);
                        }
            */

            //public bool isNull {get { return _value == null;} set { if (value) _value = null; }}
            public NullType()
            {
                _value = null;
            }
            public override int GetHashCode()
            {
                if (_value != null) return _value.GetHashCode();
                return base.GetHashCode();

            }
            public static bool operator ==(NullType nt, NullType o)
            {
                // null null true
                // null val false
                // val null false
                // val val confronto
                /*if (((object)nt==null)|| nt._value == null)
                {
                    return (((object)o==null)|| o._value == null);
                }
                return (((object)o==null)|| o._value == null)? false : System.Convert.Equals(nt._value,o._value);
                */
                return compare(nt, o) == 0;
            }
            public static bool operator !=(NullType nt, NullType o)
            {
                return compare(nt, o) != 0;
                //return !(pi == o);
            }

            public static bool operator <(NullType nt, NullType o)
            {
                return compare(nt, o) < 0;
            }

            public static bool operator >(NullType nt, NullType o)
            {
                return compare(nt, o) > 0;
            }

            public static bool operator <=(NullType nt, NullType o)
            {
                return compare(nt, o) <= 0;
            }

            public static bool operator >=(NullType nt, NullType o)
            {
                return compare(nt, o) >= 0;
            }

            //		public static bool IsNull(NullType pi)
            //		{
            //			return (((object)pi == null) || (pi.isNull)) ? true : false;
            //		}
            //		public static bool IsNull(object pi)
            //		{
            //			return (((object)pi == null) || (pi is System.DBNull) ) ? true : false;
            //		}

            public static bool operator ==(NullType pi, object o)
            {
                try
                {
                    // null null true
                    // null val false
                    // val null false
                    // val val confronto
                    if (((object)pi == null) || pi._value == null)
                    {
                        return ((o == null) || Convert.IsDBNull(o));
                    }
                    return ((o == null) || Convert.IsDBNull(o)) ? false : System.Convert.Equals(pi._value, o);
                }
                catch
                {
                    return false;
                }
            }
            public override bool Equals(object o)
            {
                if (o is NullType) return (this == (NullType)o);
                else return (this == o);
            }

            public static bool operator !=(NullType pi, object o)
            {
                return !(pi == o);
            }

            /// <summary>
            /// fa l'override del ToString. Se è nullo ritorna "" altrimenti passa al tostring del valore contenuto.
            /// </summary>
            /// <returns></returns>
            public override string ToString()
            {
                return this == null ? "" : _value.ToString();
            }

            public static implicit operator string(NullType nt)
            {
                return nt == null ? "" : nt._value.ToString();
            }

            #region IFormattable Members

            string System.IFormattable.ToString(string format, IFormatProvider formatProvider)
            {
                return _value == null ? "" : ((System.IFormattable)_value).ToString(format, formatProvider);
            }

            #endregion
        }


        [Serializable]
        public class IntNT : NullType, ISerializable, System.Xml.Serialization.IXmlSerializable, IFormattable
        {
            #region IXmlSerializable
            public void WriteXml(System.Xml.XmlWriter writer)
            {
                if (_value != null)
                    writer.WriteString(this.ToString());
                else writer.WriteAttributeString("null", "true");
            }

            public void ReadXml(System.Xml.XmlReader reader)
            {
                //if (reader.GetAttribute("null")!="true") //	if (reader.HasValue)
                if (reader.HasAttributes) // se ha attributi è nullo.
                    _value = null;
                else
                {
                    string str = reader.ReadString();
                    if (IsInt(str)) _value = Convert.ToInt32(str);
                }
                reader.ReadEndElement();
            }

            public System.Xml.Schema.XmlSchema GetSchema()
            {
                return (null);
            }
            #endregion

            #region Serializable
            public void GetObjectData(SerializationInfo info, StreamingContext context)
            {
                if (_value != null)
                    info.AddValue("_value", Value);
            }

            private IntNT(SerializationInfo info, StreamingContext context)
            {
                if (info.MemberCount == 1)
                {
                    _value = info.GetInt32("_value");
                }
                else _value = null;
            }
            #endregion
            /// <summary>
            /// IntNT nullo
            /// </summary>
            public IntNT()
            {
                _value = null;
            }
            /// <summary>
            /// costruttore 
            /// </summary>
            /// <param name="valore"></param>
            public IntNT(object valore)
            {
                if (null == valore || Convert.IsDBNull(valore) || valore.ToString() == "")
                    _value = null;
                else
                    _value = Convert.ToInt32(valore);
            }

            /// <summary>
            /// costruttore di copia
            /// </summary>
            /// <param name="IntNTObj"></param>
            public IntNT(IntNT IntNTObj)
            {
                if (null == (object)IntNTObj)
                    _value = null;
                else
                    _value = IntNTObj._value;
            }

            /// <summary>
            /// Restituisce il valore intero
            /// </summary>
            public int Value
            {
                get
                {
                    if (this._value == null) throw new System.NullReferenceException();
                    return Convert.ToInt32(_value);
                }
                /*set 
                { 
                    _value = value;
                } */
            }

            /// <summary>
            /// converte dal tipo-base intero al tipo IntNT
            /// </summary>
            /// <param name="i"></param>
            /// <returns></returns>
            public static implicit operator IntNT(int i)
            {
                return new IntNT((object)i);
            }

            /// <summary>
            /// converte dal IntNT intero al tipo tipo-base
            /// </summary>
            /// <param name="o"></param>
            /// <returns></returns>
            public static implicit operator int(IntNT o)
            {
                return o.Value;
            }

            //Conversione dal IntNT al nullable int: da rivedere
            public static implicit operator System.Nullable<int>(IntNT o)
            {
                if (o != null)
                    return o.Value;
                else
                    return null;
            }

            /// <summary>
            /// converte il dbnull nel tipo IntNT
            /// </summary>
            /// <param name="dbn"></param>
            /// <returns></returns>
            public static implicit operator IntNT(System.DBNull dbn)
            {
                return new IntNT();
            }

            public static implicit operator IntNT(string str)
            {
                if (IsInt(str)) return new IntNT(Convert.ToInt32(str));
                else return new IntNT();
            }

            // è intero solo se è numerico e senza virgola.
            public static bool IsInt(string str)
            {
                if (str == null) return false;
                return (str.IndexOf(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator) < 0 && DecimalNT.IsNumeric(str));
            }

            public static bool FindInValues(IntNT compare_value, params int[] patterns)
            {
                if (!isNull(compare_value)) foreach (int p in patterns) if (compare_value.Value == p) return true;
                return false;
            }

            #region IFormattable Members

            public string ToString(string format, IFormatProvider formatProvider)
            {
                if (format != null)
                {
                    if (format.IndexOf('|') > 0)
                    {
                        string[] split = format.Split('|');
                        for (int i = 0; i < split.Length; i++)
                        {
                            if (split[i].IndexOf('=') >= 0)
                            {
                                string[] split2 = split[i].Split('=');
                                if (base.ToString() == split2[0]) return split2[1];
                            }
                        }
                    }
                    return ((System.IFormattable)_value).ToString(format, formatProvider);
                }
                return base.ToString();
            }

            #endregion

        }


        [Serializable]
        public class Int64NT : NullType, ISerializable, System.Xml.Serialization.IXmlSerializable
        {
            #region IXmlSerializable
            public void WriteXml(System.Xml.XmlWriter writer)
            {
                if (_value != null)
                    writer.WriteString(this.ToString());
                else writer.WriteAttributeString("null", "true");
            }

            public void ReadXml(System.Xml.XmlReader reader)
            {
                //if (reader.GetAttribute("null")!="true") //	if (reader.HasValue)
                if (reader.HasAttributes) // se ha attributi è nullo.
                    _value = null;
                else
                {
                    string str = reader.ReadString();
                    if (IsInt(str)) _value = Convert.ToInt64(str);
                }
                reader.ReadEndElement();
            }

            public System.Xml.Schema.XmlSchema GetSchema()
            {
                return (null);
            }
            #endregion

            #region Serializable
            public void GetObjectData(SerializationInfo info, StreamingContext context)
            {
                if (_value != null)
                    info.AddValue("_value", Value);
            }

            private Int64NT(SerializationInfo info, StreamingContext context)
            {
                if (info.MemberCount == 1)
                {
                    _value = info.GetInt64("_value");
                }
                else _value = null;
            }
            #endregion
            /// <summary>
            /// Int64NT nullo
            /// </summary>
            public Int64NT()
            {
                _value = null;
            }
            /// <summary>
            /// costruttore 
            /// </summary>
            /// <param name="valore"></param>
            public Int64NT(object valore)
            {
                if (null == valore || Convert.IsDBNull(valore) || valore.ToString() == "")
                    _value = null;
                else
                    _value = Convert.ToInt64(valore);
            }

            /// <summary>
            /// costruttore di copia
            /// </summary>
            /// <param name="IntNTObj"></param>
            public Int64NT(Int64NT IntNTObj)
            {
                if (null == (object)IntNTObj)
                    _value = null;
                else
                    _value = IntNTObj._value;
            }

            /// <summary>
            /// Restituisce il valore intero
            /// </summary>
            public Int64 Value
            {
                get
                {
                    if (this._value == null) throw new System.NullReferenceException();
                    return Convert.ToInt64(_value);
                }
                /*set 
                { 
                    _value = value;
                } */
            }

            /// <summary>
            /// converte dal tipo-base intero al tipo IntNT
            /// </summary>
            /// <param name="i"></param>
            /// <returns></returns>
            public static implicit operator Int64NT(Int64 i)
            {
                return new Int64NT((object)i);
            }

            /// <summary>
            /// converte dal Int64NT intero al tipo tipo-base
            /// </summary>
            /// <param name="o"></param>
            /// <returns></returns>
            public static implicit operator Int64(Int64NT o)
            {
                return o.Value;
            }

            /// <summary>
            /// converte il dbnull nel tipo Int64NT
            /// </summary>
            /// <param name="dbn"></param>
            /// <returns></returns>
            public static implicit operator Int64NT(System.DBNull dbn)
            {
                return new Int64NT();
            }

            public static implicit operator Int64NT(string str)
            {
                if (IsInt(str)) return new Int64NT(Convert.ToInt64(str));
                else return new Int64NT();
            }

            // è intero solo se è numerico e senza virgola.
            public static bool IsInt(string str)
            {
                if (str == null) return false;
                return (str.IndexOf(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator) < 0 && DecimalNT.IsNumeric(str));
            }

        }


        [Serializable]
        public class StringNT : NullType, ISerializable, System.Xml.Serialization.IXmlSerializable, IFormattable
        {
            #region IXmlSerializable
            public void WriteXml(System.Xml.XmlWriter writer)
            {
                if (_value != null)
                    writer.WriteString(Value);
                else writer.WriteAttributeString("null", "true");
            }

            public void ReadXml(System.Xml.XmlReader reader)
            {
                //if (reader.GetAttribute("null")!="true") //	if (reader.HasValue)
                if (reader.HasAttributes) // se ha attributi è nullo.
                    _value = null;
                else
                    _value = reader.ReadString();
                reader.ReadEndElement();
            }

            public System.Xml.Schema.XmlSchema GetSchema()
            {
                return (null);
            }
            #endregion


            #region ISerializable
            public void GetObjectData(SerializationInfo info, StreamingContext context)
            {
                if (_value != null)
                    info.AddValue("_value", Value);
            }

            private StringNT(SerializationInfo info, StreamingContext context)
            {
                if (info.MemberCount == 1)
                {
                    _value = info.GetString("_value");
                }
                else _value = null;
            }
            #endregion

            /// <summary>
            /// StringNT nullo
            /// </summary>
            public StringNT()
            {
                _value = null;
            }
            /// <summary>
            /// costruttore generico
            /// </summary>
            /// <param name="valore"></param>
            public StringNT(object valore)
            {
                if (null == valore || Convert.IsDBNull(valore))
                    _value = null;
                else
                    _value = Convert.ToString(valore);
            }

            /// <summary>
            /// costruttore di copia
            /// </summary>
            /// <param name="StringNTObj"></param>
            public StringNT(StringNT StringNTObj)
            {
                if (null == StringNTObj)
                    _value = null;
                else
                    _value = StringNTObj._value;
            }

            /// <summary>
            /// Restituisce il valore stringa
            /// </summary>
            public string Value
            {
                get
                {
                    if (this._value == null) throw new System.NullReferenceException();
                    return Convert.ToString(_value);
                }
                /*set 
                { 
                    _value = value;
                }*/
            }
            /// <summary>
            /// converte dal tipo-base intero al tipo StringNT
            /// </summary>
            /// <param name="i"></param>
            /// <returns></returns>
            public static implicit operator StringNT(string s)
            {
                StringNT t = new StringNT();
                if (s != "") t._value = s;
                return t;
            }

            /// <summary>
            /// converte il dbnull nel tipo StringNT
            /// </summary>
            /// <param name="dbn"></param>
            /// <returns></returns>
            public static implicit operator StringNT(System.DBNull dbn)
            {
                return new StringNT();
            }

            /// <summary>
            /// Calculate the distance between the strings using the Levenshtien algorithm
            /// </summary>
            /// <param name="orginale">Orginale srting</param>
            /// <param name="compare">String to whcih to compare the orginal</param>
            /// <returns>Distance between the strings</returns>
            public static int LDistance(string orginale, string compare)
            {
                int[,] distance = new int[orginale.Length + 1, compare.Length + 1];
                int cost;

                // fill the string lenght in the matrix
                for (int i = 0; i <= orginale.Length; i++)
                    distance[i, 0] = i;

                // fill the string lenght in the matrix
                for (int j = 0; j <= compare.Length; j++)
                    distance[0, j] = j;

                for (int i = 1; i <= orginale.Length; i++)
                    for (int j = 1; j <= compare.Length; j++)
                    {
                        if (orginale[i - 1] == compare[j - 1])
                        {
                            cost = 0;
                        }
                        else
                        {
                            cost = 1;
                        }
                        distance[i, j] = Math.Min(distance[i - 1, j] + 1, Math.Min(distance[i, j - 1] + 1, distance[i - 1, j - 1] + cost));
                    }
                return distance[orginale.Length, compare.Length];
            }

            public int LDistance(StringNT compare)
            {
                return LDistance(this, compare);
            }

            /// <summary>
            /// Operatore Like come in SQL
            /// </summary>
            /// <param name="text">testo</param>
            /// <param name="pattern">pattern con le wildcards di sql "%" per il "tutto" e "_" per il singolo carattere</param>
            /// <returns></returns>
            public static bool Like(StringNT text, string pattern)
            {
                if (text == null) return false;
                string regexPattern = pattern;
                regexPattern = regexPattern.Replace("\\", "\\\\");
                //regexPattern = regexPattern.Replace ("[", "[[]");
                //regexPattern = regexPattern.Replace ("]", "[\\]]");
                regexPattern = regexPattern.Replace("$", "\\$");
                regexPattern = regexPattern.Replace("^", "\\^");
                regexPattern = regexPattern.Replace("[\\^", "[^");
                regexPattern = regexPattern.Replace(".", "\\.");
                regexPattern = regexPattern.Replace("%", ".*");
                regexPattern = regexPattern.Replace("_", ".");
                //regexPattern = regexPattern.Replace ("#", "[0-9]");
                regexPattern = "^" + regexPattern + "$";
                System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(regexPattern, System.Text.RegularExpressions.RegexOptions.IgnoreCase | System.Text.RegularExpressions.RegexOptions.Singleline);
                return regex.IsMatch(text.Value);
            }
            public bool Like(string pattern)
            {
                return Like(this, pattern);
            }

            public static bool operator ==(StringNT nt, string o)
            {
                return compare(nt, (StringNT)o) == 0;
            }

            public static bool operator !=(StringNT nt, string o)
            {
                return compare(nt, (StringNT)o) != 0;
            }

            public static bool operator <(StringNT nt, StringNT o)
            {
                return compare(nt, o) < 0;
            }

            public static bool operator >(StringNT nt, StringNT o)
            {
                return compare(nt, o) > 0;
            }

            public static bool operator <=(StringNT nt, StringNT o)
            {
                return compare(nt, o) <= 0;
            }

            public static bool operator >=(StringNT nt, StringNT o)
            {
                return compare(nt, o) >= 0;
            }
            public override int GetHashCode()
            {
                if (_value != null) return _value.GetHashCode();
                return base.GetHashCode();

            }
            public override bool Equals(object o)
            {
                if (o is NullType) return ((NullType)this == (NullType)o);
                else return (this == o);
            }
            #region IFormattable Members

            public string ToString(string format, IFormatProvider formatProvider)
            {
                if (format != null)
                {
                    if (format.IndexOf('|') > 0)
                    {
                        string[] split = format.Split('|');
                        for (int i = 0; i < split.Length; i++)
                        {
                            if (split[i].IndexOf('=') >= 0)
                            {
                                string[] split2 = split[i].Split('=');
                                if (base.ToString() == split2[0]) return split2[1];
                            }
                        }
                    }
                    if (formatProvider != null) return String.Format(formatProvider, format, _value);
                }
                return base.ToString();
            }

            #endregion
        }


        [Serializable]
        public class DatetimeNT : NullType, ISerializable, System.Xml.Serialization.IXmlSerializable
        {
            #region IXmlSerializable
            public void WriteXml(System.Xml.XmlWriter writer)
            {
                if (_value != null)
                    writer.WriteString(this.ToString());
                else writer.WriteAttributeString("null", "true");
            }

            public void ReadXml(System.Xml.XmlReader reader)
            {
                //if (reader.GetAttribute("null")!="true") //	if (reader.HasValue)
                if (reader.HasAttributes) // se ha attributi è nullo.
                    _value = null;
                else
                {
                    DatetimeNT d = new DatetimeNT(reader.ReadString());
                    _value = d._value;
                }
                reader.ReadEndElement();
            }

            public System.Xml.Schema.XmlSchema GetSchema()
            {
                return (null);
            }
            #endregion

            #region Serializable
            public void GetObjectData(SerializationInfo info, StreamingContext context)
            {
                if (_value != null)
                    info.AddValue("_value", Value);
            }

            private DatetimeNT(SerializationInfo info, StreamingContext context)
            {
                if (info.MemberCount == 1)
                {
                    _value = info.GetDateTime("_value");
                }
                else _value = null;
            }
            #endregion
            /// <summary>
            /// DateTimeNT nullo
            /// </summary>
            public DatetimeNT()
            {
                _value = null;
            }
            /// <summary>
            /// costruttore generico
            /// </summary>
            /// <param name="valore"></param>
            public DatetimeNT(object valore)
            {
                if (null == valore || Convert.IsDBNull(valore) || valore.ToString() == "")
                    _value = null;
                else
                    _value = Convert.ToDateTime(valore);
            }

            /// <summary>
            /// costruttore di copia
            /// </summary>
            /// <param name="IntNTObj"></param>
            public DatetimeNT(DatetimeNT DateTimeNTObj)
            {
                if (null == DateTimeNTObj)
                    _value = null;
                else
                    _value = DateTimeNTObj._value;
            }

            /// <summary>
            /// Restituisce il valore DateTime
            /// </summary>
            public DateTime Value
            {
                get
                {
                    if (this._value == null) throw new System.NullReferenceException();
                    return Convert.ToDateTime(_value);
                }
                /*set 
                { 
                    _value = value;
                }*/
            }
            /// <summary>
            /// converte dal tipo-base intero al tipo DateTimeNT
            /// </summary>
            /// <param name="i"></param>
            /// <returns></returns>
            public static implicit operator DatetimeNT(DateTime d)
            {
                DatetimeNT t = new DatetimeNT();
                t._value = d;
                return t;
            }

            public static bool IsDatetime(string str)
            {
                return System.Text.RegularExpressions.Regex.Match(str, "(((0[1-9]|[12][0-9]|3[01])([-./])(0[13578]|10|12)([-./])(\\d{4}))|(([0][1-9]|[12][0-9]|30)([-./])(0[469]|11)([-./])(\\d{4}))|((0[1-9]|1[0-9]|2[0-8])([-./])(02)([-./])(\\d{4}))|((29)(\\.|-|\\/)(02)([-./])([02468][048]00))|((29)([-./])(02)([-./])([13579][26]00))|((29)([-./])(02)([-./])([0-9][0-9][0][48]))|((29)([-./])(02)([-./])([0-9][0-9][2468][048]))|((29)([-./])(02)([-./])([0-9][0-9][13579][26])))").Success;
            }
            public static implicit operator DatetimeNT(string str)
            {
                DatetimeNT t = new DatetimeNT();
                try
                {
                    if (str != null && IsDatetime(str))
                        t._value = DateTime.Parse(str);
                }
                catch
                {
                    t._value = null;
                }
                return t;
            }


            /// <summary>
            /// converte dal DateTimeNT intero al tipo tipo-base
            /// </summary>
            /// <param name="o"></param>
            /// <returns></returns>
            public static implicit operator DateTime(DatetimeNT o)
            {
                return o.Value;
            }

            public static implicit operator System.Nullable<DateTime>(DatetimeNT o)
            {
                if (o != null)
                    return o.Value;
                else
                    return null;
            } 

            /// <summary>
            /// converte il dbnull nel tipo DateTimeNT
            /// </summary>
            /// <param name="dbn"></param>
            /// <returns></returns>
            public static implicit operator DatetimeNT(System.DBNull dbn)
            {
                return new DatetimeNT();
            }

            public static implicit operator string(DatetimeNT nt)
            {
                return nt == null ? "" : nt.Value.ToShortDateString();
            }

            public override string ToString()
            {
                return this == null ? "" : Value.ToShortDateString();
            }

            public string ToString(string format)
            {
                return this == null ? "" : Value.ToString(format);
            }

            public string ToFullYearString()
            {
                return this == null ? "" : Value.ToString("dd/MM/yyyy");
            }

            public string ToFullDate()
            {
                return this == null ? "" : Value.ToString("dd/MM/yyyy HH:mm:ss");
            }

            //aggiunta del 16/03/2010 giorgio
            public void AddHour(int ore, int minuti, int secondi)
            {
                _value = Value.Add(new TimeSpan(ore, minuti, secondi));
            }

            public void AddHour(DateTime data)
            {
                AddHour(data.Hour, data.Minute, data.Second);
            }
        }


        [Serializable]
        public class DecimalNT : NullType, ISerializable, System.Xml.Serialization.IXmlSerializable, System.IFormattable
        {
            #region IXmlSerializable
            public void WriteXml(System.Xml.XmlWriter writer)
            {
                if (_value != null)
                    writer.WriteString(this.ToString());
                else writer.WriteAttributeString("null", "true");
            }

            public void ReadXml(System.Xml.XmlReader reader)
            {
                //if (reader.GetAttribute("null")!="true") //	if (reader.HasValue)
                if (reader.HasAttributes) // se ha attributi è nullo.
                    _value = null;
                else
                {
                    DecimalNT d = new DecimalNT(reader.ReadString());
                    _value = d._value;
                }
                reader.ReadEndElement();
            }

            public System.Xml.Schema.XmlSchema GetSchema()
            {
                return (null);
            }
            #endregion

            #region iSerializable
            public void GetObjectData(SerializationInfo info, StreamingContext context)
            {
                if (_value != null)
                    info.AddValue("_value", Value);
            }

            private DecimalNT(SerializationInfo info, StreamingContext context)
            {
                if (info.MemberCount == 1)
                {
                    _value = info.GetDecimal("_value");
                }
                else _value = null;
            }
            #endregion

            /// <summary>
            /// DateTimeNT nullo
            /// </summary>
            public DecimalNT()
            {
                _value = null;
            }

            /// <summary>
            /// costruttore generico
            /// </summary>
            /// <param name="valore"></param>
            public DecimalNT(object valore)
            {
                if (null == valore || Convert.IsDBNull(valore) || valore.ToString() == "")
                    _value = null;
                else
                    _value = Convert.ToDecimal(valore);
            }

            /// <summary>
            /// costruttore di copia
            /// </summary>
            /// <param name="IntNTObj"></param>
            public DecimalNT(DecimalNT DecimalNTObj)
            {
                if (null == DecimalNTObj)
                    _value = null;
                else
                    _value = DecimalNTObj._value;
            }

            /// <summary>
            /// Restituisce il valore Decimal
            /// </summary>
            public decimal Value
            {
                get
                {
                    if (this._value == null) throw new System.NullReferenceException();
                    return Convert.ToDecimal(_value);
                }
                /*set 
                { 
                    _value = value;
                }*/
            }
            /// <summary>
            /// converte dal tipo-base intero al tipo DecimalNT
            /// </summary>
            /// <param name="i"></param>
            /// <returns></returns>
            public static implicit operator DecimalNT(decimal i)
            {
                DecimalNT t = new DecimalNT();
                t._value = i;
                return t;
            }

            /// <summary>
            /// converte dal FloatNT intero al tipo DecimalNT
            /// </summary>
            /// <param name="i"></param>
            /// <returns></returns>
            public static implicit operator DecimalNT(FloatNT f)
            {
                if (f == null) return new DecimalNT();
                else return new DecimalNT(f.Value);
            }

            //Conversione dal DecimalNT al nullable decimal: da rivedere
            public static implicit operator System.Nullable<decimal>(DecimalNT o)
            {
                if (o != null)
                    return o.Value;
                else
                    return null;
            }

            /// <summary>
            /// converte dal DecimalNT intero al tipo tipo-base
            /// </summary>
            /// <param name="o"></param>
            /// <returns></returns>
            public static implicit operator decimal(DecimalNT o)
            {
                return o.Value;
            }

            /// <summary>
            /// converte il dbnull nel tipo DecimalNT
            /// </summary>
            /// <param name="dbn"></param>
            /// <returns></returns>
            public static implicit operator DecimalNT(System.DBNull dbn)
            {
                return new DecimalNT();
            }

            public static implicit operator DecimalNT(string str)
            {
                if (str == null) return new DecimalNT();
                str = str.Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, "");
                if (System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator == ".") str = str.Replace(",", ".");
                else str = str.Replace(".", ",");
                if (IsNumeric(str)) return new DecimalNT(Convert.ToDecimal(str));
                else return new DecimalNT();
            }

            /// <summary>
            /// Determina se una stringa è un numero o no, approccio diverso dal try/catch
            /// </summary>
            /// <param name="str">stringa da verificare</param>
            /// <returns></returns>
            public static bool IsNumeric(string str)
            {
                if (str == null) return false;
                str = str.Trim();
                if (str.Length == 0) return false;
                int i;
                bool punct = false;
                int minpunct = 1;
                for (int x = 0; x < str.Length; x++)
                {
                    i = ("-" + System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator + "1234567890").IndexOf(str[x]);
                    if (i < 2)
                    {
                        if (i < 0) return false; //non è un carattere consentito
                        if (i == 0 && x > 0) return false; // è il "-" ma non è in testa alla cifra
                        if (i == 0) minpunct++;
                        if (i == 1 && x < minpunct) return false; // il segno della virgola è troppo presto.
                        if (i == 1 && punct) return false; // il segno d'interpunzione è già stato utilizzato.
                        if (i == 1) punct = true; // mi segno che il segno d'interpunzione è già stato utilizzato.
                    }
                }
                return true;
            }

            // aggiunto il 10/12/07 
            public static implicit operator DecimalNT(double i)
            {
                DecimalNT t = new DecimalNT();
                t._value = Convert.ToDecimal(i);
                return t;
            }

            public static implicit operator DecimalNT(int i)
            {
                DecimalNT t = new DecimalNT();
                t._value = Convert.ToDecimal(i);
                return t;
            }

            public static bool operator ==(DecimalNT nt, int i)
            {
                return (nt == Convert.ToDecimal(i));
            }

            public static bool operator !=(DecimalNT nt, int i)
            {
                return !(nt == i);
            }

            public static bool operator ==(DecimalNT nt, double i)
            {
                return (nt == Convert.ToDecimal(i));
            }

            public static bool operator !=(DecimalNT nt, double i)
            {
                return !(nt == i);
            }
            public override bool Equals(object obj)
            {
                return base.Equals(obj);
            }
            public override int GetHashCode()
            {
                return base.GetHashCode();
            }

        }


        [Serializable]
        public class FloatNT : NullType, ISerializable, System.Xml.Serialization.IXmlSerializable
        {
            #region IXmlSerializable
            public void WriteXml(System.Xml.XmlWriter writer)
            {
                if (_value != null)
                    writer.WriteString(this.ToString());
                else writer.WriteAttributeString("null", "true");
            }

            public void ReadXml(System.Xml.XmlReader reader)
            {
                //if (reader.GetAttribute("null")!="true") //	if (reader.HasValue)
                if (reader.HasAttributes) // se ha attributi è nullo.
                    _value = null;
                else
                {
                    FloatNT f = new FloatNT(reader.ReadString());
                    _value = f._value;
                }
                reader.ReadEndElement();
            }

            public System.Xml.Schema.XmlSchema GetSchema()
            {
                return (null);
            }
            #endregion

            #region iSerializable
            public void GetObjectData(SerializationInfo info, StreamingContext context)
            {
                if (_value != null)
                    info.AddValue("_value", Value);
            }

            private FloatNT(SerializationInfo info, StreamingContext context)
            {
                if (info.MemberCount == 1)
                {
                    _value = info.GetDouble("_value");
                }
                else _value = null;
            }
            #endregion


            /// <summary>
            ///  nullo
            /// </summary>
            public FloatNT()
            {
                _value = null;
            }
            /// <summary>
            /// costruttore generico
            /// </summary>
            /// <param name="valore"></param>
            public FloatNT(object valore)
            {
                if (null == valore || Convert.IsDBNull(valore) || valore.ToString() == "")
                    _value = null;
                else
                    _value = Convert.ToDouble(valore);
            }

            public static implicit operator FloatNT(string str)
            {
                if (System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator == ".") str = str.Replace(",", ".");
                else str = str.Replace(".", ",");
                if (DecimalNT.IsNumeric(str)) return new FloatNT(Convert.ToDecimal(str));
                else return new FloatNT();
            }

            //			public FloatNT(StringNT valore)
            //			{
            //				if (valore != null)	_value = double.Parse(valore.Value);
            //			}

            /// <summary>
            /// costruttore di copia
            /// </summary>
            /// <param name="IntNTObj"></param>
            public FloatNT(FloatNT FloatNTObj)
            {
                if (null == FloatNTObj)
                    _value = null;
                else
                    _value = FloatNTObj._value;
            }


            /// <summary>
            /// converte dal DecimalNT al tipo FloatNT
            /// </summary>
            /// <param name="i"></param>
            /// <returns></returns>
            public static implicit operator FloatNT(DecimalNT d)
            {
                if (d == null) return new FloatNT();
                else return new FloatNT(d.Value);
            }

            /// <summary>
            /// Restituisce il valore Float
            /// </summary>
            public float Value
            {
                get
                {
                    if (this._value == null) throw new System.NullReferenceException();
                    return (float)Convert.ToDouble(_value);
                }
                /*set 
                { 
                    _value = value;
                }*/
            }
            /// <summary>
            /// converte dal tipo-base intero al tipo FloatNT
            /// </summary>
            /// <param name="i"></param>
            /// <returns></returns>
            public static implicit operator FloatNT(float i)
            {
                FloatNT t = new FloatNT();
                t._value = i;
                return t;
            }

            public static implicit operator FloatNT(double i)
            {
                FloatNT t = new FloatNT();
                t._value = (float)Convert.ToDouble(i);
                return t;
            }

            public static implicit operator FloatNT(decimal i)
            {
                FloatNT t = new FloatNT();
                t._value = (float)Convert.ToDouble(i);
                return t;
            }

            /// <summary>
            /// converte dal FloatNT intero al tipo tipo-base
            /// </summary>
            /// <param name="o"></param>
            /// <returns></returns>
            public static implicit operator float(FloatNT o)
            {
                return o.Value;
            }

            /// <summary>
            /// converte il dbnull nel tipo FloatNT
            /// </summary>
            /// <param name="dbn"></param>
            /// <returns></returns>
            public static implicit operator FloatNT(System.DBNull dbn)
            {
                return new FloatNT();
            }
        }


        [Serializable]
        public class BoolNT : NullType, ISerializable, System.Xml.Serialization.IXmlSerializable, IFormattable
        {
            #region IXmlSerializable
            public void WriteXml(System.Xml.XmlWriter writer)
            {
                if (_value != null)
                    writer.WriteString(this.ToString());
                else writer.WriteAttributeString("null", "true");
            }

            public void ReadXml(System.Xml.XmlReader reader)
            {
                //if (reader.GetAttribute("null")!="true") //	if (reader.HasValue)
                if (reader.HasAttributes) // se ha attributi è nullo.
                    _value = null;
                else
                {
                    string str = reader.ReadString();
                    BoolNT b = new BoolNT(str);
                    _value = b._value;
                }
                reader.ReadEndElement();
            }

            public System.Xml.Schema.XmlSchema GetSchema()
            {
                return (null);
            }
            #endregion

            #region iSerializable
            public void GetObjectData(SerializationInfo info, StreamingContext context)
            {
                if (_value != null)
                    info.AddValue("_value", Value);
            }

            private BoolNT(SerializationInfo info, StreamingContext context)
            {
                if (info.MemberCount == 1)
                {
                    _value = info.GetBoolean("_value");
                }
                else _value = null;
            }
            #endregion

            /// <summary>
            /// BoolNT nullo
            /// </summary>
            public BoolNT()
            {
                _value = null;
            }
            /// <summary>
            /// costruttore 
            /// </summary>
            /// <param name="valore"></param>
            public BoolNT(object valore)
            {
                if (null == valore || Convert.IsDBNull(valore) || valore.ToString() == "")
                    _value = null;
                else
                    _value = Convert.ToBoolean(valore);
            }

            /// <summary>
            /// costruttore di copia
            /// </summary>
            /// <param name="IntNTObj"></param>
            public BoolNT(BoolNT BoolNTObj)
            {
                if (null == (object)BoolNTObj)
                    _value = null;
                else
                    _value = BoolNTObj._value;
            }

            /// <summary>
            /// Restituisce il valore booleano
            /// </summary>
            public bool Value
            {
                get
                {
                    if (this._value == null) throw new System.NullReferenceException();
                    return Convert.ToBoolean(_value);
                }
                /*set 
                { 
                    _value = value;
                }*/
            }

            /// <summary>
            /// converte dal tipo-base bool al tipo BoolNT
            /// </summary>
            /// <param name="i"></param>
            /// <returns></returns>
            public static implicit operator BoolNT(bool b)
            {
                return new BoolNT((object)b);
            }

            /// <summary>
            /// converte dal tipo intero al tipo BoolNT
            /// </summary>
            /// <param name="i"></param>
            /// <returns></returns>
            public static implicit operator BoolNT(int i)
            {
                return new BoolNT(i != 0);
            }

            /// <summary>
            /// converte dal BoolNT intero al tipo tipo-base
            /// </summary>
            /// <param name="o"></param>
            /// <returns></returns>
            public static implicit operator bool(BoolNT o)
            {
                return o.Value;
            }

            public static implicit operator System.Nullable<bool>(BoolNT o)
            {
                if (o != null)
                    return o.Value;
                else
                    return null;
            }

            /// <summary>
            /// converte il dbnull nel tipo IntNT
            /// </summary>
            /// <param name="dbn"></param>
            /// <returns></returns>
            public static implicit operator BoolNT(System.DBNull dbn)
            {
                return new BoolNT();
            }

            public static implicit operator BoolNT(string s)
            {
                BoolNT outb;
                switch (s.Trim().ToLower())
                {
                    case "true":
                    case "v":
                    case "t":
                    case "on":
                    case "yes":
                    case "ok":
                    case "1": outb = new BoolNT(true);
                        break;
                    case "false":
                    case "f":
                    case "off":
                    case "no":
                    case "ko":
                    case "0": outb = new BoolNT(false);
                        break;
                    default: outb = new BoolNT((object)s);
                        break;

                }
                return outb;
            }

            #region IFormattable Members

            // per le boundcolumn la dataformatstring deve essere del tipo:
            //  DataFormatString="{0:StringaPerVero|StringaPerFalso}"
            string IFormattable.ToString(string format, IFormatProvider formatProvider)
            {
                if (format != null)
                {
                    if (format.IndexOf('|') > 0)
                    {
                        string[] split = format.Split('|');
                        if ((bool)_value) return split[0];
                        else return split[1];
                    }
                    if (formatProvider != null) return String.Format(formatProvider, format, _value);
                }
                return base.ToString();
            }

            #endregion
        }

    }

}
