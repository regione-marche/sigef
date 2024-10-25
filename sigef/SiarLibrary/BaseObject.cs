using System;
using System.Data;
using System.ComponentModel;
using SiarLibrary.Extensions;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Collections;

namespace SiarLibrary
{

    /// <summary>
    /// Summary description for BaseObject.
    /// </summary>
    /// 
    [Serializable]

    public abstract class BaseObject : ICloneable, IEditableObject, IEnumerable<BaseObject> //, ISerializable
    {
        public enum ObjectStateType { Unchanged = 0, Added = 1, Changed = 2, Deleted = 3 };

        public BaseObject()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public Type TypeOfObject
        {
            get { return this.GetType(); }
        }

        /// <summary>
        /// setta lo stato dell'oggetto così che sia cancellato al prossimo salvataggio
        /// </summary>
        public void MarkForDeletion()
        {
            this.ObjectState = ObjectStateType.Deleted;
            this.IsDirty = true;
        }

        /// <summary>
        /// setta lo stato dell'oggetto così che sia considerato nuovo e da inserire nel db
        /// </summary>
        public void MarkAsNew()
        {
            this.ObjectState = ObjectStateType.Added;
            this.IsPersistent = false;
            this.IsDirty = true;
        }

        [XmlIgnore]
        public CustomCollection Parent = null;

        private bool _ispersistent = false;
        [XmlIgnore]
        public bool IsPersistent
        {
            get { return _ispersistent; }
            set { _ispersistent = value; }
        }

        private ObjectStateType _ObjectState = ObjectStateType.Unchanged;
        [XmlIgnore]
        public ObjectStateType ObjectState
        {
            get { return _ObjectState; }
            set { _ObjectState = value; }
        }

        private bool _IsDirty;
        [XmlIgnore]
        public bool IsDirty
        {
            get
            { return _IsDirty; }
            set { _IsDirty = value; }
        }

        public int Compare(object obj1, object obj2)
        {
            int Rt = 0;
            if (obj1 == null && obj2 == null)
            {
                Rt = 0;
            }
            else if (obj1 == null && obj2 != null)
            {
                Rt = -1;
            }
            else if (obj1 != null & obj2 == null)
            {
                Rt = 1;
            }
            else if (obj1 == obj2)
            {
                Rt = 0;
            }
            else
            {
                if (obj1.Equals(obj2))
                {
                    Rt = 0;
                }
                else
                {
                    Rt = 1;
                }
            }
            return Rt;
        }

        #region IEditableObject
        // Implements IEditableObject

        private bool inTxn = false;

        private bool IsNew = true;

        public void BeginEdit()
        {
            if (!inTxn)
            {
                inTxn = true;

            }
        }

        public void EndEdit()
        {
            inTxn = false;
            IsNew = false;
        }

        public void CancelEdit()
        {
            inTxn = false;
            if (IsNew)
            {
                IsNew = false;
                if (Parent != null)
                {
                    this.Parent.Remove(this);
                }
            }
        }
        #endregion

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public BaseObject CloneAsNew()
        {
            BaseObject obj = (BaseObject)this.MemberwiseClone();
            obj.MarkAsNew();
            return obj;
        }

        public void SetDirtyFlag()
        {

            this.IsDirty = true;
            if (this.Parent != null)
            {
                this.Parent.CollectionChanged(this);
            }
            if (this.IsPersistent)//l'object existe dans la base
            {
                this.ObjectState = ObjectStateType.Changed;//objet changé
            }
            else
            {
                this.ObjectState = ObjectStateType.Added;//objet ajouté
            }

        }

        #region ISerializable Members
        ////		public class SerialCollection : CollectionBase, ISerializable 
        ////		{ 
        ////			public SerialCollection () { } 
        //			protected BaseObject ( SerializationInfo info, StreamingContext 
        //				context ) 
        //			{ 
        //				string exps = ""; 
        //				// get the set of serializable members for our class and base classes 
        //				Type thisType = this.GetType(); 
        //				MemberInfo[] mi = thisType.GetFields( BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance ); 
        //				// DeSerialize all of the allowed fields and handle any of the removed fields. 
        //				foreach ( MemberInfo member in mi ) 
        //				{ 
        //					try 
        //					{ 
        //						((FieldInfo)member).SetValue (this, info.GetValue( member.Name,((FieldInfo)member).FieldType )); 
        //					} 
        //					catch ( Exception e ) 
        //					{ 
        //						// resolve upgrade issues here 
        //						switch ( member.Name ) 
        //						{ 
        //							case "AddEvent": 
        //								// Handle the Event properties 
        //								continue; 
        //						} 
        //						exps += String.Format( "\nError during deserialization setting Member name: {0} : {1}", member.Name, e.Message ); 
        //					} 
        //				} 
        //				// this.InnerList = info.GetString("k"); 
        //			} 
        ////
        ////
        //			void ISerializable.GetObjectData ( SerializationInfo info, StreamingContext context ) 
        //			{ 
        //				// get the set of serializable members for our class and base classes 
        //				Type thisType = this.GetType(); 
        //				MemberInfo[] mi = thisType.GetFields( BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance ); 
        //				foreach ( MemberInfo member in mi ) 
        //				{ 
        //					info.AddValue( member.Name, ((FieldInfo)member).GetValue( this ) ); 
        //				} 
        //
        //
        //			}
        ////		}
        #endregion

        private System.Collections.Specialized.NameValueCollection _AdditionalAttributes;
        [XmlIgnore]
        public System.Collections.Specialized.NameValueCollection AdditionalAttributes
        {
            get
            {
                if (_AdditionalAttributes == null) _AdditionalAttributes = new System.Collections.Specialized.NameValueCollection();
                return _AdditionalAttributes;
            }
        }

        /// <summary>
        /// converte l'oggetto lato server in un oggetto jason del tipo {'key1':'val1','key2':true,'key3':123.44...}
        /// utilizzabile lato client via javascript, i valori sono tipizzati
        /// </summary>
        /// <returns></returns>
        public string ConvertToJSonObject()
        {
            string json_object = "";
            foreach (System.Reflection.PropertyInfo p in this.GetType().GetProperties())
                if (!p.Name.FindValueIn("AdditionalAttributes", "Provider", "TypeOfObject", "IsPersistent", "ObjectState", "IsDirty"))
                    json_object += "'" + p.Name + "':" + ((NullTypes.NullType)p.GetValue(this, null)).ToJsonString() + ",";
            if (_AdditionalAttributes != null)
                foreach (string s in _AdditionalAttributes.AllKeys)
                    json_object += "'" + s + "':'" + _AdditionalAttributes[s].ToCleanJsString() + "',";
            if (json_object.EndsWith(",")) json_object = json_object.Substring(0, json_object.Length - 1);
            return "{" + json_object + "}";
        }

        /// <summary>
        /// popola le proprieta della classe a partire da una stringa json
        /// i valori che non hanno la corrispondente proprietà nella classe vengono aggiunti agli AdditionalAttributes
        /// </summary>
        /// <param name="json_string"></param>
        public void FillByJsonObject(string json_string)
        {
            try
            {
                if (string.IsNullOrEmpty(json_string)) return;
                System.Collections.Generic.Dictionary<string, object> dd = (System.Collections.Generic.Dictionary<string, object>)
                    new System.Web.Script.Serialization.JavaScriptSerializer().DeserializeObject(json_string);
                foreach (string key in dd.Keys)
                {
                    object valore = dd[key] ?? "";
                    System.Reflection.PropertyInfo p = GetType().GetProperty(key);
                    if (p != null)
                    {
                        // popolo la proprieta usanto il costruttore dei nulltype
                        object o = p.PropertyType.GetConstructor(new Type[] { typeof(object) }).Invoke(new object[] { valore.ToString() });
                        p.SetValue(this, o, null);
                    }
                    else AdditionalAttributes.Add(key, valore.ToString());
                }
            }
            catch { }
        }

        public IEnumerator<BaseObject> GetEnumerator()
        {
            return this.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
