using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/* STORIA
 * Data: 2016-05-27; Stato: Creazione; Autore: 
*/

namespace SiarLibrary
{

        // interfaccia provider per Allegati
        // Interfaccia Autogenerata
        // Inserire eventuali operazioni aggiuntive
        public interface IAteco2007Provider
        {
            int Save(Ateco2007 Ateco2007Obj);
            int SaveCollection(Ateco2007Collection collectionObj);
            int Delete(Ateco2007 Ateco2007Obj);
            int DeleteCollection(Ateco2007Collection collectionObj);
        }
        /// <summary>
        /// Summary description for Ateco2007
        /// Class Autogenerata
        /// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
        /// con delle partial class contenenti i metodi aggiunti, in questo modo 
        /// non verranno sovrascritti quando si rigenera la classe 
        /// </summary>

        [Serializable]
        [System.Xml.Serialization.XmlType(Namespace = "")]

        public partial class Ateco2007 : BaseObject
        {

            //Definizione dei campi 'base'
            private NullTypes.StringNT _IdAteco2007;
            private NullTypes.StringNT _Sezione;
            private NullTypes.StringNT _Divisione;
            private NullTypes.StringNT _Gruppo;
            private NullTypes.StringNT _Classe;
            private NullTypes.StringNT _Categoria;
            private NullTypes.StringNT _Sottocategoria;
            private NullTypes.StringNT _Descrizione;
            [NonSerialized]
            private IAteco2007Provider _provider;
            [System.Xml.Serialization.XmlIgnore]
            public IAteco2007Provider Provider
            {
                get { return _provider; }
                set { _provider = value; }
            }


            //Costruttore
            public Ateco2007()
            {
                //
                // TODO: Add constructor logic here
                //
            }

            //Get e Set dei campi 'base'
            /// <summary>
            /// Corrisponde al campo:COD_TIPO_ATECO2007
            /// Tipo sul db:CHAR(9)
            /// </summary>
            public NullTypes.StringNT IdAteco2007
            {
                get { return _IdAteco2007; }
                set
                {
                    if (IdAteco2007 != value)
                    {
                        _IdAteco2007 = value;
                        SetDirtyFlag();
                    }
                }
            }

            public NullTypes.StringNT CodiceAteco
            {
                get { return _IdAteco2007.ToString().Replace("X", "").Substring(1); }
            }

            /// <summary>
            /// Corrisponde al campo:Sezione
            /// Tipo sul db:VARCHAR(8)
            /// </summary>
            public NullTypes.StringNT Sezione
            {
                get { return _Sezione; }
                set
                {
                    if (Sezione != value)
                    {
                        _Sezione = value;
                        SetDirtyFlag();
                    }
                }
            }

            /// <summary>
            /// Corrisponde al campo: Divisione
            /// Tipo sul db:VARCHAR(8)
            /// </summary>
            public NullTypes.StringNT Divisione
            {
                get { return _Divisione; }
                set
                {
                    if (Divisione != value)
                    {
                        _Divisione = value;
                        SetDirtyFlag();
                    }
                }
            }

            /// <summary>
            /// Corrisponde al campo: Gruppo
            /// Tipo sul db:VARCHAR(8)
            /// </summary>
            public NullTypes.StringNT Gruppo
            {
                get { return _Gruppo; }
                set
                {
                    if (Gruppo != value)
                    {
                        _Gruppo = value;
                        SetDirtyFlag();
                    }
                }
            }

            /// <summary>
            /// Corrisponde al campo: Classe
            /// Tipo sul db:VARCHAR(8)
            /// </summary>
            public NullTypes.StringNT Classe
            {
                get { return _Classe; }
                set
                {
                    if (Classe != value)
                    {
                        _Classe = value;
                        SetDirtyFlag();
                    }
                }
            }

            /// <summary>
            /// Corrisponde al campo: Categoria
            /// Tipo sul db:VARCHAR(8)
            /// </summary>
            public NullTypes.StringNT Categoria
            {
                get { return _Categoria; }
                set
                {
                    if (Categoria != value)
                    {
                        _Categoria = value;
                        SetDirtyFlag();
                    }
                }
            }

            /// <summary>
            /// Corrisponde al campo: Sottocategoria
            /// Tipo sul db:VARCHAR(8)
            /// </summary>
            public NullTypes.StringNT Sottocategoria
            {
                get { return _Sottocategoria; }
                set
                {
                    if (Sottocategoria != value)
                    {
                        _Sottocategoria = value;
                        SetDirtyFlag();
                    }
                }
            }

            /// <summary>
            /// Corrisponde al campo:DESCRIZIONE
            /// Tipo sul db:VARCHAR(255)
            /// </summary>
            public NullTypes.StringNT Descrizione
            {
                get { return _Descrizione; }
                set
                {
                    if (Descrizione != value)
                    {
                        _Descrizione = value;
                        SetDirtyFlag();
                    }
                }
            }




            //Get e Set dei campi 'ForeignKey'

            public int Save()
            {
                if (this.IsDirty)
                {
                    return _provider.Save(this);
                }
                else
                {
                    return 0;
                }
            }

            public int Delete()
            {
                return _provider.Delete(this);
            }

            //Get e Set dei campi 'aggiuntivi'

        }
    }

    namespace SiarLibrary
    {

        /// <summary>
        /// Summary description for Ateco2007Collection
        /// Class Autogenerata
        /// Inserire eventuali operazioni aggiuntive
        /// </summary>

        [Serializable]

        public partial class Ateco2007Collection : CustomCollection, System.Runtime.Serialization.ISerializable
        {

            //Serializzazione xml
            public void GetObjectData(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
            {
                info.AddValue("_count", this.Count);
                for (int i = 0; i < this.Count; i++)
                {
                    info.AddValue(i.ToString(), this[i]);
                }
            }
            private Ateco2007Collection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
                : this()
            {
                int c = info.GetInt32("_count");
                for (int i = 0; i < c; i++)
                {
                    this.Add((Ateco2007)info.GetValue(i.ToString(), typeof(Ateco2007)));
                }
            }

            //Costruttore
            public Ateco2007Collection()
            {
                this.ItemType = typeof(Ateco2007);
            }

            //Costruttore con provider
            public Ateco2007Collection(IAteco2007Provider providerObj)
            {
                this.ItemType = typeof(Ateco2007);
                this.Provider = providerObj;
            }

            //Get e Set
            public new Ateco2007 this[int index]
            {
                get { return (Ateco2007)(base[index]); }
                set
                {
                    base[index] = value;
                }
            }

            public new Ateco2007Collection GetChanges()
            {
                return (Ateco2007Collection)base.GetChanges();
            }

            [NonSerialized]
            private IAteco2007Provider _provider;
            [System.Xml.Serialization.XmlIgnore]
            public IAteco2007Provider Provider
            {
                get { return _provider; }
                set
                {
                    _provider = value;
                    for (int i = 0; i < this.Count; i++)
                    {
                        this[i].Provider = value;
                    }
                }
            }

            public int SaveCollection()
            {
                return _provider.SaveCollection(this);
            }
            public int DeleteCollection()
            {
                return _provider.DeleteCollection(this);
            }
            //Add
            public int Add(Ateco2007 Ateco2007Obj)
            {
                if (Ateco2007Obj.Provider == null) Ateco2007Obj.Provider = this.Provider;
                return base.Add(Ateco2007Obj);
            }

            //AddCollection
            public void AddCollection(Ateco2007Collection Ateco2007CollectionObj)
            {
                foreach (Ateco2007 Ateco2007Obj in Ateco2007CollectionObj)
                    this.Add(Ateco2007Obj);
            }

            //Insert
            public void Insert(int index, Ateco2007 Ateco2007Obj)
            {
                if (Ateco2007Obj.Provider == null) Ateco2007Obj.Provider = this.Provider;
                base.Insert(index, Ateco2007Obj);
            }

            //CollectionGetById
            public Ateco2007 CollectionGetById(NullTypes.StringNT IdAllegatoValue)
            {
                int i = 0;
                bool find = false;
                while ((i < this.Count) && (!find))
                {
                    if ((this[i].IdAteco2007 == IdAllegatoValue))
                        find = true;
                    else
                        i++;
                }
                if (find)
                    return this[i];
                else
                    return null;
            }


        }
}
