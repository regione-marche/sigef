using System;
using System.Collections.Generic;
using System.Text;
using SiarLibrary.NullTypes;

namespace SiarLibrary.NotAutogeneratedClasses
{
    public class AnticipiRichiestiCollectionProvider
    {
        public AnticipiRichiestiCollectionProvider() { }

        public AnticipiRichiestiCollection CalcoloAmmontareAnticipo(IntNT idBando, IntNT idDomandaPagamento)
        {
            AnticipiRichiestiCollection return_collection = new AnticipiRichiestiCollection();
            DbProvider db = new DbProvider();
            System.Data.IDbCommand cmd = db.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpPsrCalcoloAmmontareAnticipo";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_BANDO", idBando.Value));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_ANTICIPO", idDomandaPagamento.Value));
            db.InitDatareader(cmd);
            while (db.DataReader.Read()) return_collection.Add(new AnticipiRichiesti(db));
            db.Close();
            return return_collection;
        }
    }



    public class AnticipiRichiesti : BaseObject
    {
        private IntNT _IdBando;
        private BoolNT _MisuraPrevalente;
        private StringNT _Misura;
        private StringNT _CodTipo;
        private DecimalNT _QuotaMin;
        private DecimalNT _QuotaMax;
        private DecimalNT _ImportoMin;
        private DecimalNT _ImportoMax;
        private StringNT _Descrizione;
        private StringNT _CodFase;
        private StringNT _Fase;
        private IntNT _Ordine;
        private IntNT _IdProgetto;
        private DecimalNT _CostoDiMisura;
        private DecimalNT _ContributoDiMisura;
        private DecimalNT _AmmontareRichiesto;
        private DecimalNT _AmmontareAmmesso;
        private BoolNT _Ammesso;
        private StringNT _Istruttore;

        public AnticipiRichiesti() { }
        public AnticipiRichiesti(DbProvider db)
        {
            IdBando = new IntNT(db.DataReader["ID_BANDO"]);
            MisuraPrevalente = new BoolNT(db.DataReader["MISURA_PREVALENTE"]);
            this.Misura = new StringNT(db.DataReader["MISURA"]);
            CodTipo = new StringNT(db.DataReader["COD_TIPO"]);
            Descrizione = new StringNT(db.DataReader["DESCRIZIONE"]);
            QuotaMin = new DecimalNT(db.DataReader["QUOTA_MIN"]);
            QuotaMax = new DecimalNT(db.DataReader["QUOTA_MAX"]);
            ImportoMin = new DecimalNT(db.DataReader["IMPORTO_MIN"]);
            ImportoMax = new DecimalNT(db.DataReader["IMPORTO_MAX"]);
            CodFase = new StringNT(db.DataReader["COD_FASE"]);
            Fase = new StringNT(db.DataReader["FASE"]);
            Ordine = new IntNT(db.DataReader["ORDINE"]);
            IdProgetto = new IntNT(db.DataReader["ID_PROGETTO"]);
            //Istruttore = new StringNT(db.DataReader["ISTRUTTORE"]);
            Ammesso = new BoolNT(db.DataReader["AMMESSO"]);
            CostoDiMisura = new DecimalNT(db.DataReader["COSTO_DI_MISURA"]);
            ContributoDiMisura = new DecimalNT(db.DataReader["CONTRIBUTO_DI_MISURA"]);
            AmmontareRichiesto = new DecimalNT(db.DataReader["AMMONTARE_RICHIESTO"]);
            AmmontareAmmesso = new DecimalNT(db.DataReader["AMMONTARE_AMMESSO"]);
        }

        public IntNT IdBando
        {
            get { return _IdBando; }
            set
            {
                _IdBando = value;
            }
        }
        public BoolNT MisuraPrevalente
        {
            get { return _MisuraPrevalente; }
            set
            {
                _MisuraPrevalente = value;
            }
        }
        public StringNT Misura
        {
            get { return _Misura; }
            set
            {
                _Misura = value;
            }
        }
        public StringNT CodTipo
        {
            get { return _CodTipo; }
            set { _CodTipo = value; }
        }
        public StringNT Descrizione
        {
            get { return _Descrizione; }
            set
            {
                _Descrizione = value;
            }
        }
        public DecimalNT QuotaMin
        {
            get { return _QuotaMin; }
            set
            {
                _QuotaMin = value;
            }
        }
        public DecimalNT QuotaMax
        {
            get { return _QuotaMax; }
            set
            {
                _QuotaMax = value;
            }
        }
        public DecimalNT ImportoMin
        {
            get { return _ImportoMin; }
            set
            {
                _ImportoMin = value;
            }
        }
        public DecimalNT ImportoMax
        {
            get { return _ImportoMax; }
            set
            {
                _ImportoMax = value;
            }
        }
        public StringNT CodFase
        {
            get { return _CodFase; }
            set
            {
                _CodFase = value;
            }
        }
        public StringNT Fase
        {
            get { return _Fase; }
            set
            {
                _Fase = value;
            }
        }
        public IntNT Ordine
        {
            get { return _Ordine; }
            set
            {
                _Ordine = value;
            }
        }
        public IntNT IdProgetto
        {
            get { return _IdProgetto; }
            set
            {
                _IdProgetto = value;
            }
        }
        public StringNT Istruttore
        {
            get { return _Istruttore; }
            set
            {
                _Istruttore = value;
            }
        }
        public BoolNT Ammesso
        {
            get { return _Ammesso; }
            set
            {
                _Ammesso = value;
            }
        }
        public DecimalNT CostoDiMisura
        {
            get { return _CostoDiMisura; }
            set
            {
                _CostoDiMisura = value;
            }
        }
        public DecimalNT ContributoDiMisura
        {
            get { return _ContributoDiMisura; }
            set
            {
                _ContributoDiMisura = value;
            }
        }

        public DecimalNT AmmontareRichiesto
        {
            get { return _AmmontareRichiesto; }
            set
            {
                _AmmontareRichiesto = value;
            }
        }

        public DecimalNT AmmontareAmmesso
        {
            get { return _AmmontareAmmesso; }
            set
            {
                _AmmontareAmmesso = value;
            }
        }
    }

    public class AnticipiRichiestiCollection : CustomCollection
    {
        private AnticipiRichiestiCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
            : this()
        {
            int c = info.GetInt32("_count");
            for (int i = 0; i < c; i++)
            {
                this.Add((AnticipiRichiesti)info.GetValue(i.ToString(), typeof(AnticipiRichiesti)));
            }
        }

        //Costruttore
        public AnticipiRichiestiCollection()
        {
            this.ItemType = typeof(AnticipiRichiesti);
        }

        //Get e Set
        public new AnticipiRichiesti this[int index]
        {
            get { return (AnticipiRichiesti)(base[index]); }
            set
            {
                base[index] = value;
            }
        }

        public new AnticipiRichiestiCollection GetChanges()
        {
            return (AnticipiRichiestiCollection)base.GetChanges();
        }

        //Add
        public int Add(AnticipiRichiesti AnticipiRichiestiObj)
        {
            return base.Add(AnticipiRichiestiObj);
        }

        //AddCollection
        public void AddCollection(AnticipiRichiestiCollection AnticipiRichiestiCollectionObj)
        {
            foreach (AnticipiRichiesti AnticipiRichiesti in AnticipiRichiestiCollectionObj)
                this.Add(AnticipiRichiesti);
        }

        public void Insert(int index, AnticipiRichiesti AnticipiRichiestiObj)
        {

            base.Insert(index, AnticipiRichiestiObj);
        }


    }
}
