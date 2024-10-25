using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Reflection;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace SiarLibrary
{
    /// <summary>
    /// Summary description for CustomCollection.
    /// </summary>
    /// 
    [DesignerCategoryAttribute("code")]
    [Browsable(true)]
    [ToolboxItem(true)]
    [DesignTimeVisible(true)]
    [Serializable]
    public abstract class CustomCollection : CollectionBase, ICloneable, IBindingList, IComponent, IDisposable
    {
        public CustomCollection()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public void RemoveDeletedAndMarkedForDeletion()
        {
            for (int i = this.Count - 1; i >= 0; i--)
            {
                if (((BaseObject)this[i]).ObjectState == BaseObject.ObjectStateType.Deleted)
                    this.RemoveAt(i);
            }
        }

        public void MarkAllForDeletion()
        {
            for (int i = this.Count - 1; i >= 0; i--)
            {
                ((BaseObject)this[i]).MarkForDeletion();
            }
        }

        public void MarkAllAsNew()
        {
            for (int i = this.Count - 1; i >= 0; i--)
            {
                ((BaseObject)this[i]).MarkAsNew();
            }
        }

        /// <summary>
        /// clona lasciando fuori gli oggetti deleted o markedfordeletion
        /// </summary>
        /// <returns></returns>
        public CustomCollection PresentationClone()
        {
            CustomCollection Rt = (CustomCollection)Activator.CreateInstance(this.GetType());
            for (int i = 0; i < this.Count; i++)
            {
                BaseObject el = (BaseObject)this[i];
                if (el.ObjectState != BaseObject.ObjectStateType.Deleted)
                    Rt.InnerList.Add(el.Clone());
            }
            return Rt;
        }

        /// <summary>
        /// converte la collection e i suoi elementi in un oggetto jason del tipo [{'key11':'val11','key12':true,..},{'key21':123.44,'key22':'val22',...},...]
        /// utilizzabile lato client via javascript
        /// </summary>
        /// <returns></returns>
        public string ConvertToJSonObject()
        {
            string retval = "[";
            foreach (BaseObject obj in this) retval += obj.ConvertToJSonObject() + ",";
            if (this.Count > 0) retval = retval.Substring(0, retval.Length - 1);
            return retval + "]";
        }

        /// <summary>
        /// popola la collection a partire da una string json
        /// </summary>
        /// <param name="json_string"></param>
        public void FillByJsonObject(string json_string)
        {
            if (string.IsNullOrEmpty(json_string)) return;
            // rimuovo le parentesi quadre
            if (json_string.IndexOf("[") == 0) json_string = json_string.Substring(1);
            if (json_string.LastIndexOf("]") == json_string.Length - 1) json_string = json_string.Substring(0, json_string.Length - 1);

            // trovo il type del base object
            if (_ItemType != null)
            {
                string[] keyvalues = System.Text.RegularExpressions.Regex.Split(json_string, ",{");
                foreach (string kv in keyvalues)
                {
                    object o = _ItemType.GetConstructor(System.Type.EmptyTypes).Invoke(null);
                    System.Reflection.MethodInfo mi = _ItemType.GetMethod("FillByJsonObject");
                    if (o != null && mi != null)
                    {
                        mi.Invoke(o, new object[] { kv });
                        Add(o);
                    }
                }
            } 
        }

        /// <summary>
        /// Restituisce una List con gli oggetti della collection. Specificare <typeparamref name="T"/> con la stessa classe della collection.
        /// </summary>
        public List<T> ToArrayList<T>()
        {
            //IEnumerable<T> lista = new IEnumerable<T>();
            
            List<T> lista = new List<T>();

            for(int i = 0; i < this.Count; i++)
            {
                lista.Add((T)this[i]);
            }

            //foreach (object obj in this)
            //{
            //    lista.Add(obj);
            //}

            return lista;
        }

        #region IClonable
        public object Clone()
        {
            Object Rt = Activator.CreateInstance(this.GetType());
            for (int i = 0; i < this.Count; i++)
            {
                ((CustomCollection)Rt).InnerList.Add(((BaseObject)this[i]).Clone());
            }
            return Rt;
        }
        #endregion
        #region My Methods
        public bool IsDirty
        {
            get
            {
                bool Rt = false;
                if (((CustomCollection)this.GetChanges()).Count != 0)
                { Rt = true; }
                return Rt;
            }
        }
        private Type _ItemType;
        public Type ItemType
        {
            get { return _ItemType; }
            set { _ItemType = value; }
        }
        public void Sort(string Expression)
        {
            base.InnerList.Sort(new ObjectPropertyComparer(Expression));
        }
        private bool ischangescontainer = false;
        public bool IsChangesContainer
        {
            get { return ischangescontainer; }
            set { ischangescontainer = value; }
        }
        private bool _IsFiltering = false;
        public bool IsFiltering
        {
            get { return _IsFiltering; }
            set { _IsFiltering = value; }
        }

        public CustomCollection GetChanges()
        {
            try
            {
                object Rt = Activator.CreateInstance(this.GetType());

                object WholeCollection = Activator.CreateInstance(this.GetType());

                WholeCollection = (CustomCollection)this.Clone();

                for (int i = 0; i < this.FiltredItems.Count; i++)
                {
                    ((CustomCollection)WholeCollection).Add(this.FiltredItems[i]);
                }

                for (int i = 0; i < ((CustomCollection)WholeCollection).Count; i++)
                {
                    if (((BaseObject)((CustomCollection)WholeCollection)[i]).ObjectState != BaseObject.ObjectStateType.Unchanged)
                    {
                        ((CustomCollection)Rt).Add(((CustomCollection)WholeCollection)[i]);
                    }
                }

                for (int i = 0; i < DeletedItems.Count; i++)
                {
                    if (((BaseObject)DeletedItems[i]).IsPersistent)
                    {
                        ((BaseObject)DeletedItems[i]).ObjectState = BaseObject.ObjectStateType.Deleted;
                        ((CustomCollection)Rt).Add(DeletedItems[i]);
                    }
                }

                ((CustomCollection)Rt).IsChangesContainer = true;
                return (CustomCollection)Rt;

            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        private CustomCollection deleteditems;
        public CustomCollection DeletedItems
        {
            get
            {
                if (deleteditems == null)
                {
                    deleteditems = (CustomCollection)Activator.CreateInstance(this.GetType());
                }
                return deleteditems;
            }
            set
            {
                deleteditems = value;
            }
        }
        private string filter = string.Empty;
        internal CustomCollection filtreditems;
        public CustomCollection FiltredItems
        {
            get
            {
                if (filtreditems == null)
                {
                    filtreditems = (CustomCollection)Activator.CreateInstance(this.GetType());
                }
                return filtreditems;
            }
            set
            {
                filtreditems = value;
            }

        }
        public string ItemFilter
        {
            get
            {
                return filter;
            }
            set
            {
                try
                {
                    if (value == filter) return;
                    this.IsFiltering = true;
                    for (int i = 0; i <= this.FiltredItems.Count - 1; i++)
                    {
                        this.Add(this.FiltredItems[i]);
                    }

                    this.FiltredItems = (CustomCollection)Activator.CreateInstance(this.GetType());

                    if (value != null & value != string.Empty)
                    {
                        Filter MyFilter = new Filter(this, value);
                    }
                    filter = value;

                    OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, 0, 0));

                }
                catch (System.Exception ex)
                {
                    throw ex;
                }
            }
        }
        #endregion
        #region IList Members

        public bool IsReadOnly
        {
            get { return false; }
        }
        //internal
        public object this[int index]
        {
            get
            {
                return InnerList[index];
            }
            set
            {
                InnerList[index] = value;
            }
        }

        public new void RemoveAt(int index)
        {
            this.Remove(this[index]);
        }

        public void Insert(int index, object value)
        {
            ((BaseObject)value).Parent = this;
            InnerList.Insert(index, value);
        }

        public void Remove(object value)
        {
            this.DeletedItems.Add(value);
            int index = IndexOf(value);
            BaseObject obj = (BaseObject)value;
            obj.Parent = null;
            InnerList.Remove(value);
            OnItemDeleted(new System.EventArgs(), index);
            if ((onListChanged != null) && !this.IsFiltering)
                OnListChanged(new ListChangedEventArgs(ListChangedType.ItemDeleted, index));

        }

        public bool Contains(object value)
        {
            return InnerList.Contains(value);
        }

        public new void Clear()
        {
            while (this.Count > 0)
            {
                this.Remove(this[0]);
            }
        }

        public int IndexOf(object value)
        {
            return InnerList.IndexOf(value);
        }

        public int Add(object value)
        {
            ((BaseObject)value).Parent = this;
            int i = InnerList.Add(value);
            if ((onListChanged != null) && !this.IsFiltering)
                OnListChanged(new ListChangedEventArgs(ListChangedType.ItemAdded, IndexOf(value)));
            return i;
        }

        //AddCollection
        public void AddCollection(CustomCollection CCollectionObj)
        {
            foreach (BaseObject BaseObj in CCollectionObj)
                this.Add(BaseObj);
        }

        public bool IsFixedSize
        {
            get
            {
                return false;
            }
        }

        #endregion
        #region ICollection Members

        public bool IsSynchronized
        {
            get
            {
                return false;
            }
        }

        public new int Count
        {
            get
            {
                return InnerList.Count;
            }
        }

        public void CopyTo(Array array, int index)
        {
            InnerList.CopyTo(array, index);
        }

        public object SyncRoot
        {
            get
            {
                return InnerList.SyncRoot;
            }
        }

        #endregion
        #region IEnumerable Members

        public new IEnumerator GetEnumerator()
        {
            return InnerList.GetEnumerator();
        }

        #endregion$(-è_
        #region Collection Base
        protected override void OnClearComplete()
        {
            OnListChanged(resetEvent);
        }

        protected override void OnInsertComplete(int index, object value)
        {

            BaseObject obj = (BaseObject)value;
            obj.Parent = this;
            if ((onListChanged != null) && !this.IsFiltering)
                OnListChanged(new ListChangedEventArgs(ListChangedType.ItemAdded, index));
        }

        protected override void OnSetComplete(int index, object oldValue, object newValue)
        {
            if (oldValue != newValue)
            {
                BaseObject oldobj = (BaseObject)oldValue;
                BaseObject newobj = (BaseObject)newValue;

                oldobj.Parent = null;
                newobj.Parent = this;
                if ((onListChanged != null) && !this.IsFiltering)
                    OnListChanged(new ListChangedEventArgs(ListChangedType.ItemAdded, index));
            }
        }
        #endregion
        #region IBindingList Members

        // Implements IBindingList.
        bool IBindingList.AllowEdit
        {
            get { return true; }
        }

        bool IBindingList.AllowNew
        {
            get { return true; }
        }

        bool IBindingList.AllowRemove
        {
            get { return true; }
        }

        bool IBindingList.SupportsChangeNotification
        {
            get { return true; }
        }


        bool IBindingList.SupportsSearching
        {
            get { return false; }
        }

        bool IBindingList.SupportsSorting
        {
            get { return true; }
        }

        object IBindingList.AddNew()
        {
            object obj = Activator.CreateInstance(this.ItemType);
            this.Add(obj);
            return obj;
        }

        private bool isSorted = false;

        bool IBindingList.IsSorted
        {
            get { return isSorted; }
        }

        private ListSortDirection listSortDirection = ListSortDirection.Ascending;

        ListSortDirection IBindingList.SortDirection
        {
            get { return listSortDirection; }
        }

        PropertyDescriptor sortProperty = null;

        PropertyDescriptor IBindingList.SortProperty
        {
            get { return sortProperty; }
        }

        void IBindingList.AddIndex(PropertyDescriptor property)
        {
            throw new NotSupportedException();
        }
        int IBindingList.Find(PropertyDescriptor property, object key)
        {
            throw new NotSupportedException();
        }

        void IBindingList.ApplySort(PropertyDescriptor property, ListSortDirection direction)
        {
            isSorted = true;
            sortProperty = property;
            listSortDirection = direction;

            ArrayList a = new ArrayList();

            base.InnerList.Sort(new ObjectPropertyComparer(property.Name));
            if (direction == ListSortDirection.Descending) base.InnerList.Reverse();
        }

        void IBindingList.RemoveIndex(PropertyDescriptor property)
        {
            throw new NotSupportedException();
        }

        void IBindingList.RemoveSort()
        {
            isSorted = false;
            sortProperty = null;
        }
        #endregion
        #region ListChanged Events
        internal ListChangedEventArgs resetEvent = new ListChangedEventArgs(ListChangedType.Reset, -1);
        private ListChangedEventHandler onListChanged;
        protected virtual void OnListChanged(ListChangedEventArgs ev)
        {
            if (onListChanged != null)
            {
                onListChanged(this, ev);
            }
        }
        internal void CollectionChanged(object obj)
        {
            int index = List.IndexOf(obj);
            OnListChanged(new ListChangedEventArgs(ListChangedType.ItemChanged, index));
        }
        // Events.
        public event ListChangedEventHandler ListChanged
        {
            add
            {
                onListChanged += value;
            }
            remove
            {
                onListChanged -= value;
            }
        }
        #endregion
        #region events
        private EventHandler _ItemDeleted;
        public event EventHandler ItemDeleted
        {
            add
            {
                _ItemDeleted += value;
            }
            remove
            {
                _ItemDeleted -= value;
            }
        }
        protected virtual void OnItemDeleted(EventArgs args, int index)
        {
            if (_ItemDeleted != null)
            {
                _ItemDeleted(this, args);
            }
        }
        #endregion

        #region IComponent members
        // Added to implement Site property correctly.
        private ISite _site = null;

        /// <summary>
        /// Notify those that care when we dispose.
        /// </summary>
        public event System.EventHandler Disposed;

        /// <summary>
        /// Get / Set the site where this data is 
        /// located.
        /// </summary>
        public ISite Site
        {
            get
            {
                return _site;
            }
            set
            {
                _site = value;
            }
        }

        #endregion
        #region IDisposable Members
        /// <summary>
        /// Clean up. Nothing here though.
        /// </summary>
        public void Dispose()
        {
            // Nothing to clean.
            if (Disposed != null)
                Disposed(this, EventArgs.Empty);
        }
        #endregion
    }
}
