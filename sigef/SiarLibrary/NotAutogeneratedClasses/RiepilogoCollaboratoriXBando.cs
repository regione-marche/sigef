using System;
using System.Collections.Generic;
using System.Text;

namespace SiarLibrary.NotAutogeneratedClasses
{
    public class RiepilogoCollaboratoriXBando:BaseObject
    {
        public RiepilogoCollaboratoriXBando() { }

        private NullTypes.IntNT _IdUtente;
        private NullTypes.StringNT _CfUtente;
        private NullTypes.IntNT _IdProfilo;
        private NullTypes.StringNT _Nominativo;
        private NullTypes.StringNT _CodEnte;
        private NullTypes.StringNT _Provincia;

        private NullTypes.IntNT _progettiAssegnati;
        private NullTypes.IntNT _progettiRicevibili;
        private NullTypes.IntNT _progettiNonRicevibili;
        private NullTypes.IntNT _progettiAmmissibili;
        private NullTypes.IntNT _progettiNonAmmissibili;
        private NullTypes.IntNT _progettiIstruitiDaAltri;


        public NullTypes.IntNT IdUtente
        {
            get { return _IdUtente; }
            set { _IdUtente = value; }
        }
        public NullTypes.StringNT CfUtente
        {
            get { return _CfUtente; }
            set { _CfUtente = value; }
        }
        public NullTypes.IntNT IdProfilo
        {
            get { return _IdProfilo; }
            set { _IdProfilo = value; }
        }
        public NullTypes.StringNT Nominativo
        {
            get { return _Nominativo; }
            set { _Nominativo = value; }
        }
        public NullTypes.StringNT CodEnte
        {
            get { return _CodEnte; }
            set { _CodEnte = value; }
        }
        public NullTypes.StringNT Provincia
        {
            get { return _Provincia; }
            set { _Provincia = value; }
        }

        public NullTypes.IntNT ProgettiAssegnati
        {
            get { return _progettiAssegnati; }
            set { _progettiAssegnati = value; }
        }
        public NullTypes.IntNT ProgettiRicevibili
        {
            get { return _progettiRicevibili; }
            set { _progettiRicevibili = value; }
        }
        public NullTypes.IntNT ProgettiNonRicevibili
        {
            get { return _progettiNonRicevibili; }
            set { _progettiNonRicevibili = value; }
        }
        public NullTypes.IntNT ProgettiAmmissibili
        {
            get { return _progettiAmmissibili; }
            set { _progettiAmmissibili = value; }
        }
        public NullTypes.IntNT ProgettiNonAmmissibili
        {
            get { return _progettiNonAmmissibili; }
            set { _progettiNonAmmissibili = value; }
        }
        public NullTypes.IntNT ProgettiIstruitiDaAltri
        {
            get { return _progettiIstruitiDaAltri; }
            set { _progettiIstruitiDaAltri = value; }
        }

        public void GetFromDatareader(DbProvider db)
        {
            _IdUtente = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_UTENTE"]);
            _CfUtente = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_UTENTE"]);
            _IdProfilo = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROFILO"]);
            _Nominativo = new SiarLibrary.NullTypes.StringNT(db.DataReader["NOMINATIVO"]);
            _CodEnte = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_ENTE"]);
            _Provincia = new SiarLibrary.NullTypes.StringNT(db.DataReader["PROVINCIA"]);
            _progettiAssegnati = new SiarLibrary.NullTypes.IntNT(db.DataReader["PROGETTI_ASSEGNATI"]);
            _progettiRicevibili = new SiarLibrary.NullTypes.IntNT(db.DataReader["PROGETTI_RICEVIBILI"]);
            _progettiNonRicevibili = new SiarLibrary.NullTypes.IntNT(db.DataReader["PROGETTI_NON_RICEVIBILI"]);
            _progettiAmmissibili = new SiarLibrary.NullTypes.IntNT(db.DataReader["PROGETTI_AMMISSIBILI"]);
            _progettiNonAmmissibili = new SiarLibrary.NullTypes.IntNT(db.DataReader["PROGETTI_NON_AMMISSIBILI"]);
            _progettiIstruitiDaAltri = new SiarLibrary.NullTypes.IntNT(db.DataReader["PROGETTI_ISTRUITI_DA_ALTRI"]);
        }
    }
    public class RiepilogoCollaboratoriXBandoCollection : CustomCollection
    {
        public RiepilogoCollaboratoriXBandoCollection()
        {
            this.ItemType = typeof(RiepilogoCollaboratoriXBando);
        }
        //Get e Set
        public new RiepilogoCollaboratoriXBando this[int index]
        {
            get { return (RiepilogoCollaboratoriXBando)(base[index]); }
            set
            {
                base[index] = value;
            }
        }

        //Add
        public int Add(RiepilogoCollaboratoriXBando DisposizioniAttuativeObj)
        {
            return base.Add(DisposizioniAttuativeObj);
        }

        public void FindManifestazione(NullTypes.IntNT idbando)
        {
            DbProvider db = new DbProvider();
            System.Data.IDbCommand cmd = db.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpRiepilogoCollaboratoriXManifestazione";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_BANDO", idbando.Value));
            db.InitDatareader(cmd);
            while (db.DataReader.Read())
            {
                RiepilogoCollaboratoriXBando rcxb = new RiepilogoCollaboratoriXBando();
                rcxb.GetFromDatareader(db);
                this.Add(rcxb);
            }
            db.Close();
        }
    }
}
