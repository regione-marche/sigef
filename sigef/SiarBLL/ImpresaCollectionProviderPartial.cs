using System;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;
using System.Data;
using System.Collections.Generic;
using System.Diagnostics;

namespace SiarBLL
{
    public partial class ImpresaCollectionProvider : IImpresaProvider
    {
        public Impresa GetByCuaa(string cuaa)
        {
            if (!string.IsNullOrEmpty(cuaa))
            {
                ImpresaCollection imprese = ImpresaDAL.Find(_dbProviderObj, cuaa, null, null);
                if (imprese.Count == 0) imprese = ImpresaDAL.Find(_dbProviderObj, null, cuaa, null);
                if (imprese.Count > 0) return imprese[0];
            }
            return null;
        }

        public ImpresaCollection GetImpresaSenzaStoricoByCuaa(string cuaa)
        {
            if (string.IsNullOrEmpty(cuaa)) return null;
            ImpresaCollection ic = new ImpresaCollection();
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpGetImpresaSenzaStoricoByCuaa";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CUAA", cuaa));
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read()) ic.Add(SiarDAL.ImpresaDAL.GetFromDatareader(DbProviderObj));
            DbProviderObj.Close();
            return ic;
        }

        public ImpresaCollection RicercaImpresa(IntNT IdUtente, IntNT IdimpresaEqualThis, StringNT CuaaEqualThis, StringNT RagionesocialeLikeThis,
            StringNT CodTipoMandato)
        {
            ImpresaCollection imprese = new ImpresaCollection();
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpRicercaImpresa";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_UTENTE", IdUtente.Value));
            if (IdimpresaEqualThis != null) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_IMPRESA", IdimpresaEqualThis.Value));
            if (CuaaEqualThis != null) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CUAA", CuaaEqualThis.Value));
            if (RagionesocialeLikeThis != null) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RAGIONE_SOCIALE", RagionesocialeLikeThis.Value));
            if (CodTipoMandato != null) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@COD_TIPO_MANDATO", CodTipoMandato.Value));
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
            {
                Impresa i = new Impresa();
                i.IdImpresa = new IntNT(DbProviderObj.DataReader["ID_IMPRESA"]);
                i.Cuaa = new StringNT(DbProviderObj.DataReader["CUAA"]);
                i.CodiceFiscale = new StringNT(DbProviderObj.DataReader["CODICE_FISCALE"]);
                i.IdStoricoImpresa = new IntNT(DbProviderObj.DataReader["ID_STORICO_IMPRESA"]);
                i.RagioneSociale = new StringNT(DbProviderObj.DataReader["RAGIONE_SOCIALE"]);
                i.IdRapprlegaleUltimo = new IntNT(DbProviderObj.DataReader["ID_RAPPRLEGALE_ULTIMO"]);
                i.IdSedelegaleUltimo = new IntNT(DbProviderObj.DataReader["ID_SEDELEGALE_ULTIMO"]);
                i.Attiva = new BoolNT(DbProviderObj.DataReader["ATTIVA"]);
                imprese.Add(i);
            }
            DbProviderObj.Close();
            return imprese;
        }

        public ImpresaCollection RicercaImpresaSenzaUtente(IntNT IdimpresaEqualThis, StringNT CuaaEqualThis, StringNT RagionesocialeLikeThis)
        {
            ImpresaCollection imprese = new ImpresaCollection();
            IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SpRicercaImpresaSenzaUtente";
            if (IdimpresaEqualThis != null) 
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_IMPRESA", IdimpresaEqualThis.Value));
            if (CuaaEqualThis != null) 
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CUAA", CuaaEqualThis.Value));
            if (RagionesocialeLikeThis != null) 
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RAGIONE_SOCIALE", RagionesocialeLikeThis.Value));
            
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
            {
                imprese.Add(ImpresaDAL.GetFromDatareader(DbProviderObj));
            }

            DbProviderObj.Close();
            return imprese;
        }

        public Impresa GetImpresaAbilitataById(IntNT IdUtente, IntNT IdimpresaEqualThis, StringNT CodTipoMandato)
        {
            ImpresaCollection imprese = RicercaImpresa(IdUtente, IdimpresaEqualThis, null, null, CodTipoMandato);
            if (imprese.Count > 0) return imprese[0];
            return null;
        }

        public Impresa GetImpresaAbilitataUmaById(IntNT IdUtente, IntNT IdimpresaEqualThis)
        {
            ImpresaCollection imprese = RicercaImpresa(IdUtente, IdimpresaEqualThis, null, null, "UMA");
            if (imprese.Count > 0) return imprese[0];
            return null;
        }

        public void AggiornaAnagraficaImpresa(SiarLibrary.Impresa impresa, StringNT cod_forma_giuridica, IntNT id_dimensione, StringNT cod_classificazione_uma,
            StringNT telefono, StringNT email, StringNT pec)
        {
            AggiornaAnagraficaImpresa(impresa, cod_forma_giuridica, id_dimensione, cod_classificazione_uma, telefono, email, pec, null, null, null, null, null, null, null, null, null, null,
                null, null,null);
        }

        public void AggiornaAnagraficaImpresa(SiarLibrary.Impresa impresa, StringNT cod_forma_giuridica, IntNT id_dimensione, StringNT cod_classificazione_uma,
            StringNT telefono, StringNT email, StringNT pec, StringNT numero_registro_imprese, StringNT numero_rea, IntNT anno_rea)
        {
            AggiornaAnagraficaImpresa(impresa, cod_forma_giuridica, id_dimensione, cod_classificazione_uma, telefono, email, pec, numero_registro_imprese, numero_rea, anno_rea, null, null,
                null, null, null, null, null, null, null,null);
        }

        public void AggiornaAnagraficaImpresa(SiarLibrary.Impresa impresa, StringNT cod_forma_giuridica, IntNT id_dimensione, StringNT cod_classificazione_uma,
            StringNT telefono, StringNT email, StringNT pec, StringNT numero_registro_imprese, StringNT numero_rea, IntNT anno_rea, StringNT cc_cod_paese,
            StringNT cc_cin_euro, StringNT cc_cin, StringNT abi, StringNT cab, StringNT cc_numero, StringNT cc_istituto, StringNT cc_agenzia, IntNT cc_id_comune, StringNT Ateco)
        {
            try
            {
                DbProviderObj.BeginTran();
                // impresa storico
                if (!string.IsNullOrEmpty(cod_forma_giuridica) || id_dimensione != null || !string.IsNullOrEmpty(numero_registro_imprese) ||
                    !string.IsNullOrEmpty(numero_rea) || anno_rea != null)
                {
                    ImpresaStoricoCollectionProvider storico_provider = new ImpresaStoricoCollectionProvider(DbProviderObj);
                    ImpresaStorico storico = storico_provider.GetById(impresa.IdStoricoUltimo);
                    if (storico.CodFormaGiuridica != cod_forma_giuridica || storico.IdDimensione != id_dimensione ||
                        (cod_classificazione_uma != null && storico.CodClassificazioneUma != cod_classificazione_uma) ||
                        (anno_rea != null && storico.ReaAnno != anno_rea) || (numero_registro_imprese != null &&
                        storico.RegistroImpreseNumero != numero_registro_imprese) || (numero_rea != null && storico.ReaNumero != numero_rea) ||
                        (storico.CodAteco2007 != Ateco && Ateco != null) )
                    {
                        storico.DataFineValidita = DateTime.Now;
                        storico_provider.Save(storico);

                        storico.MarkAsNew();
                        storico.DataInizioValidita = null;
                        storico.DataFineValidita = null;
                        storico.CodFormaGiuridica = cod_forma_giuridica;
                        storico.CodClassificazioneUma = cod_classificazione_uma;
                        storico.IdDimensione = id_dimensione;
                        storico.CodAteco2007 = Ateco;
                        if (anno_rea != null) storico.ReaAnno = anno_rea;
                        if (numero_registro_imprese != null) storico.RegistroImpreseNumero = numero_registro_imprese;
                        if (numero_rea != null) storico.ReaNumero = numero_rea;
                        storico_provider.Save(storico);
                        impresa.IdStoricoUltimo = storico.IdStoricoImpresa;
                    }
                }
                // telefono e sede legale
                if (!string.IsNullOrEmpty(telefono) || !string.IsNullOrEmpty(email) || !string.IsNullOrEmpty(email))
                {
                    IndirizzarioCollectionProvider indiririzzario_provider = new IndirizzarioCollectionProvider(DbProviderObj);
                    Indirizzario sede_legale = indiririzzario_provider.GetById(impresa.IdSedelegaleUltimo);
                    if (sede_legale.Email != email || sede_legale.Telefono != telefono || sede_legale.Pec != pec)
                    {
                        sede_legale.DataFineValidita = DateTime.Now;
                        sede_legale.FlagAttivo = false;
                        indiririzzario_provider.Save(sede_legale);

                        sede_legale.MarkAsNew();
                        sede_legale.DataInizioValidita = null;
                        sede_legale.DataFineValidita = null;
                        sede_legale.FlagAttivo = true;
                        sede_legale.Telefono = telefono;
                        sede_legale.Email = email;
                        sede_legale.Pec = pec;
                        indiririzzario_provider.Save(sede_legale);
                        impresa.IdSedelegaleUltimo = sede_legale.IdIndirizzario;
                    }
                }
                // conto corrente
                if (!string.IsNullOrEmpty(cc_numero))
                {
                    ContoCorrenteCollectionProvider cc_provider = new ContoCorrenteCollectionProvider(DbProviderObj);
                    ContoCorrente cc;
                    if (impresa.IdContoCorrenteUltimo == null)
                    {
                        cc = new ContoCorrente();
                        cc.IdImpresa = impresa.IdImpresa;
                    }
                    else
                    {
                        cc = cc_provider.GetById(impresa.IdContoCorrenteUltimo);
                        if (cc.CodPaese != cc_cod_paese || cc.CinEuro != cc_cin_euro || cc.Cin != cc_cin || cc.Abi != abi || cc.Cab != cab ||
                            cc.Numero != cc_numero || cc.Istituto != cc_istituto || cc.Agenzia != cc_agenzia || cc.IdComune != cc_id_comune)
                        {
                            cc.DataFineValidita = DateTime.Now;
                            cc_provider.Save(cc);
                            cc.MarkAsNew();
                            cc.DataInizioValidita = null;
                            cc.DataFineValidita = null;
                        }
                    }
                    cc.CodPaese = cc_cod_paese;
                    cc.CinEuro = cc_cin_euro;
                    cc.Cin = cc_cin;
                    cc.Abi = abi;
                    cc.Cab = cab;
                    cc.Numero = cc_numero;
                    cc.Note = null;
                    cc.Istituto = cc_istituto;
                    cc.Agenzia = cc_agenzia;
                    cc.IdComune = cc_id_comune;
                    cc_provider.Save(cc);
                    impresa.IdContoCorrenteUltimo = cc.IdContoCorrente;
                }
                if (impresa.ObjectState == BaseObject.ObjectStateType.Changed) Save(impresa);
                DbProviderObj.Commit();
            }
            catch (Exception ex) { DbProviderObj.Rollback(); throw ex; }
        }

        public void AggiornaAnagraficaImpresa(SiarLibrary.Impresa impresa, StringNT cod_forma_giuridica, IntNT id_dimensione, StringNT cod_classificazione_uma,
            StringNT telefono, StringNT email, StringNT pec, StringNT numero_registro_imprese, StringNT numero_rea, IntNT anno_rea, StringNT cc_cod_paese,
            StringNT cc_cin_euro, StringNT cc_cin, StringNT abi, StringNT cab, StringNT cc_numero, StringNT cc_istituto, StringNT cc_agenzia, IntNT cc_id_comune, StringNT Ateco, DbProvider impresaProvider)
        {
            try
            {                
                // impresa storico
                if (!string.IsNullOrEmpty(cod_forma_giuridica) || id_dimensione != null || !string.IsNullOrEmpty(numero_registro_imprese) ||
                    !string.IsNullOrEmpty(numero_rea) || anno_rea != null)
                {
                    ImpresaStoricoCollectionProvider storico_provider = new ImpresaStoricoCollectionProvider(impresaProvider);
                    ImpresaStorico storico = storico_provider.GetById(impresa.IdStoricoUltimo);
                    if (storico.CodFormaGiuridica != cod_forma_giuridica || storico.IdDimensione != id_dimensione ||
                        (cod_classificazione_uma != null && storico.CodClassificazioneUma != cod_classificazione_uma) ||
                        (anno_rea != null && storico.ReaAnno != anno_rea) || (numero_registro_imprese != null &&
                        storico.RegistroImpreseNumero != numero_registro_imprese) || (numero_rea != null && storico.ReaNumero != numero_rea) ||
                        (storico.CodAteco2007 != Ateco && Ateco != null))
                    {
                        storico.DataFineValidita = DateTime.Now;
                        storico_provider.Save(storico);

                        storico.MarkAsNew();
                        storico.DataInizioValidita = null;
                        storico.DataFineValidita = null;
                        storico.CodFormaGiuridica = cod_forma_giuridica;
                        storico.CodClassificazioneUma = cod_classificazione_uma;
                        storico.IdDimensione = id_dimensione;
                        storico.CodAteco2007 = Ateco;
                        if (anno_rea != null) storico.ReaAnno = anno_rea;
                        if (numero_registro_imprese != null) storico.RegistroImpreseNumero = numero_registro_imprese;
                        if (numero_rea != null) storico.ReaNumero = numero_rea;
                        storico_provider.Save(storico);
                        impresa.IdStoricoUltimo = storico.IdStoricoImpresa;
                    }
                }
                // telefono e sede legale
                if (!string.IsNullOrEmpty(telefono) || !string.IsNullOrEmpty(email) || !string.IsNullOrEmpty(email))
                {
                    IndirizzarioCollectionProvider indiririzzario_provider = new IndirizzarioCollectionProvider(impresaProvider);
                    Indirizzario sede_legale = indiririzzario_provider.GetById(impresa.IdSedelegaleUltimo);
                    if (sede_legale.Email != email || sede_legale.Telefono != telefono || sede_legale.Pec != pec)
                    {
                        sede_legale.DataFineValidita = DateTime.Now;
                        sede_legale.FlagAttivo = false;
                        indiririzzario_provider.Save(sede_legale);

                        sede_legale.MarkAsNew();
                        sede_legale.DataInizioValidita = null;
                        sede_legale.DataFineValidita = null;
                        sede_legale.FlagAttivo = true;
                        sede_legale.Telefono = telefono;
                        sede_legale.Email = email;
                        sede_legale.Pec = pec;
                        indiririzzario_provider.Save(sede_legale);
                        impresa.IdSedelegaleUltimo = sede_legale.IdIndirizzario;
                    }
                }
                // conto corrente
                if (!string.IsNullOrEmpty(cc_numero))
                {
                    ContoCorrenteCollectionProvider cc_provider = new ContoCorrenteCollectionProvider(impresaProvider);
                    ContoCorrente cc;
                    if (impresa.IdContoCorrenteUltimo == null)
                    {
                        cc = new ContoCorrente();
                        cc.IdImpresa = impresa.IdImpresa;
                    }
                    else
                    {
                        cc = cc_provider.GetById(impresa.IdContoCorrenteUltimo);
                        if (cc.CodPaese != cc_cod_paese || cc.CinEuro != cc_cin_euro || cc.Cin != cc_cin || cc.Abi != abi || cc.Cab != cab ||
                            cc.Numero != cc_numero || cc.Istituto != cc_istituto || cc.Agenzia != cc_agenzia || cc.IdComune != cc_id_comune)
                        {
                            cc.DataFineValidita = DateTime.Now;
                            cc_provider.Save(cc);
                            cc.MarkAsNew();
                            cc.DataInizioValidita = null;
                            cc.DataFineValidita = null;
                        }
                    }
                    cc.CodPaese = cc_cod_paese;
                    cc.CinEuro = cc_cin_euro;
                    cc.Cin = cc_cin;
                    cc.Abi = abi;
                    cc.Cab = cab;
                    cc.Numero = cc_numero;
                    cc.Note = null;
                    cc.Istituto = cc_istituto;
                    cc.Agenzia = cc_agenzia;
                    cc.IdComune = cc_id_comune;
                    cc_provider.Save(cc);
                    impresa.IdContoCorrenteUltimo = cc.IdContoCorrente;
                }
                if (impresa.ObjectState == BaseObject.ObjectStateType.Changed) Save(impresa);                
            }
            catch (Exception ex) { throw ex; }
        }

        public enum TipoRicerca { EROA, PUA };

        public ImpresaCollection EroaRicercaImpresaByTipo(IntNT IdUtente, IntNT IdimpresaEqualThis, StringNT CuaaEqualThis,
           StringNT RagionesocialeLikeThis, StringNT CodTipoMandato, TipoRicerca TipoRicerca)
        {
            string strSpName = "";
            if (TipoRicerca == TipoRicerca.EROA) strSpName = "SpEroaRicercaImpresa";
            else if (TipoRicerca == TipoRicerca.PUA) strSpName = "SpPuaRicercaImpresa";
            return EroaRicercaImpresa(IdUtente, IdimpresaEqualThis, CuaaEqualThis, RagionesocialeLikeThis, CodTipoMandato, strSpName);
        }

        private ImpresaCollection EroaRicercaImpresa(IntNT IdUtente, IntNT IdimpresaEqualThis, StringNT CuaaEqualThis,
            StringNT RagionesocialeLikeThis, StringNT CodTipoMandato, string strSpName)
        {
            ImpresaCollection imprese = new ImpresaCollection();
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = strSpName;
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_UTENTE", IdUtente.Value));
            if (IdimpresaEqualThis != null) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_IMPRESA", IdimpresaEqualThis.Value));
            if (CuaaEqualThis != null) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CUAA", CuaaEqualThis.Value));
            if (RagionesocialeLikeThis != null) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RAGIONE_SOCIALE", RagionesocialeLikeThis.Value));
            if (CodTipoMandato != null) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@COD_TIPO_MANDATO", CodTipoMandato.Value));
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
            {
                Impresa i = new Impresa();
                i.IdImpresa = new IntNT(DbProviderObj.DataReader["ID_IMPRESA"]);
                i.Cuaa = new StringNT(DbProviderObj.DataReader["CUAA"]);
                i.CodiceFiscale = new StringNT(DbProviderObj.DataReader["CODICE_FISCALE"]);
                i.IdStoricoImpresa = new IntNT(DbProviderObj.DataReader["ID_STORICO_IMPRESA"]);
                i.RagioneSociale = new StringNT(DbProviderObj.DataReader["RAGIONE_SOCIALE"]);
                i.IdRapprlegaleUltimo = new IntNT(DbProviderObj.DataReader["ID_RAPPRLEGALE_ULTIMO"]);
                i.IdSedelegaleUltimo = new IntNT(DbProviderObj.DataReader["ID_SEDELEGALE_ULTIMO"]);
                i.Attiva = new BoolNT(DbProviderObj.DataReader["ATTIVA"]);
                i.ReaAnno = new IntNT(DbProviderObj.DataReader["NUM_DOMANDE"]);  //campo custom per esigenze eroa
                imprese.Add(i);
            }
            DbProviderObj.Close();
            return imprese;
        }

        public bool VerificaBeneficiarioEntePubblico(IntNT IdImpresa)
        {
            bool result = false;
            try
            {
                System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "SpVerificaBeneficiarioEntePubblico";
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IdImpresa", IdImpresa.Value));
                DbProviderObj.InitDatareader(cmd);
                if (DbProviderObj.DataReader.Read())
                {
                    result = new BoolNT(DbProviderObj.DataReader["RESULT"]);
                    
                }
                DbProviderObj.Close();
            }
            catch { throw; }
            return result;
        }

        public Impresa GetImpresaDaInfocamere(string cuaa)
        {
            try
            {
                DbProviderObj.BeginTran();

                ImpresaCollection imprese = ImpresaDAL.Find(_dbProviderObj, cuaa, null, null);
                if (imprese.Count == 0) imprese = ImpresaDAL.Find(_dbProviderObj, null, cuaa, null);
                if (imprese.Count > 0) return imprese[0];

                InfocamereImpresa infocamereImpresa = null;
                InfocamereImpresaCollectionProvider info_prov = new InfocamereImpresaCollectionProvider();
                InfocamereImpresaCollection info_coll = info_prov.Find(null, cuaa, null);
                if(info_coll.Count == 0) info_coll = info_prov.Find(null, null, cuaa);
                if (info_coll.Count > 0) infocamereImpresa = info_coll[0];
                else throw new Exception("Impresa non trovata nel database Infocamere");
                Impresa impresa = new Impresa();
                impresa.Cuaa = infocamereImpresa.Cuaa;
                impresa.CodiceFiscale = infocamereImpresa.CodiceFiscale;
                impresa.DataInizioAttivita = infocamereImpresa.DataInizioAttivita;
                Save(impresa);

                //Storico
                ImpresaStoricoCollectionProvider storico_provider = new ImpresaStoricoCollectionProvider(DbProviderObj);
                ImpresaStorico storico = new ImpresaStorico();
                storico.IdImpresa = impresa.IdImpresa;
                storico.DataFineValidita = null;
                storico.DataInizioValidita = DateTime.Now;
                storico.RagioneSociale = infocamereImpresa.RagioneSociale;
                storico_provider.Save(storico);

                //Sede Legale
                Indirizzo indirizzo = new Indirizzo();
                IndirizzoCollectionProvider indirizzo_provider = new IndirizzoCollectionProvider(DbProviderObj);
                indirizzo.Via = infocamereImpresa.Via;
                indirizzo.IdComune = TrovaComune("DENOMINAZIONE",null,null,infocamereImpresa.Comune , null, null);
                indirizzo_provider.Save(indirizzo);

                Indirizzario  indirizzario = new Indirizzario();
                IndirizzarioCollectionProvider indirizzario_provider = new IndirizzarioCollectionProvider(DbProviderObj);
                indirizzario.CodTipoSede = "S";
                indirizzario.IdIndirizzo = indirizzo.IdIndirizzo;
                indirizzario.IdImpresa = impresa.IdImpresa;
                indirizzario.DataInizioValidita  = DateTime.Now;
                indirizzario.DataFineValidita = null;
                indirizzario.FlagAttivo = true;
                indirizzario_provider.Save(indirizzario);

                //Rappresentante legale
                SiarBLL.PersonaFisicaCollectionProvider pf_provider = new SiarBLL.PersonaFisicaCollectionProvider(DbProviderObj);
                SiarLibrary.PersonaFisicaCollection persone = pf_provider.Find(infocamereImpresa.CodiceFiscaleRappr);
                SiarLibrary.PersonaFisica persona;
                if (persone.Count == 0)
                {
                    persona = new PersonaFisica();
                    persona.Nome = infocamereImpresa.Nome;
                    persona.Cognome = infocamereImpresa.Cognome;
                    persona.Sesso = infocamereImpresa.Sesso;
                    persona.DataNascita = infocamereImpresa.DataNascita;
                    persona.IdComuneNascita = TrovaComune("DENOMINAZIONE", null , null, infocamereImpresa.ComuneNascita, null, null);
                    pf_provider.Save(persona);
                }
                else persona = persone[0];

                SiarBLL.PersoneXImpreseCollectionProvider pxi_provider = new SiarBLL.PersoneXImpreseCollectionProvider(DbProviderObj);
                SiarLibrary.PersoneXImprese persona_impresa = new PersoneXImprese(); ;

                persona_impresa = new SiarLibrary.PersoneXImprese();
                persona_impresa.IdImpresa = impresa.IdImpresa;
                persona_impresa.IdPersona = persona.IdPersona;
                persona_impresa.CodRuolo = "R";
                persona_impresa.DataInizio = DateTime.Now;
                persona_impresa.Attivo = true;
                pxi_provider.Save(persona_impresa);


                impresa.IdStoricoUltimo = storico.IdStoricoImpresa;
                impresa.IdSedelegaleUltimo = indirizzario.IdIndirizzario;
                impresa.IdRapprlegaleUltimo = persona_impresa.IdPersoneXImprese;
                Save(impresa);


                DbProviderObj.Commit();
                return impresa;
            }
            catch (Exception ex) { DbProviderObj.Rollback(); throw ex; }
        }

        private int TrovaComune(string tipo_ricerca, string sigla_provincia, string cap_comune, string denominazione_comune,
            string cod_provincia, string istat_comune)
        {
            SiarBLL.ComuniCollectionProvider comuni_provider = new SiarBLL.ComuniCollectionProvider();
            if (sigla_provincia == "PS") sigla_provincia = "PU";
            SiarLibrary.ComuniCollection cc = comuni_provider.RicercaComune(tipo_ricerca, sigla_provincia, cap_comune, denominazione_comune,
                cod_provincia, istat_comune, null, null);
            if (cc.Count == 0) throw new Exception("Comune non trovato.");
            return cc[0].IdComune;
        }

        //Restituisce una mappa<descrizione, id_dimensione> con le dimensioni impresa 
        public static Dictionary<string, int> GetMapDimensioniImprese()
        {
            var strSql = @"SELECT ID_DIMENSIONE, DESCRIZIONE 
                        FROM DIMENSIONE_IMPRESA";
            //DataTextField = "DESCRIZIONE";
            //DataValueField = "ID_DIMENSIONE";
            //base.OnDataBinding(e);
            var map = new Dictionary<string, int>();

            DbProvider dbPro = new DbProvider();
            IDbCommand cmd = dbPro.GetCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strSql;
            dbPro.InitDatareader(cmd);
            while (dbPro.DataReader.Read())
            {
                var id_dimensione = (int) dbPro.DataReader["ID_DIMENSIONE"];
                var descrizione = dbPro.DataReader["DESCRIZIONE"].ToString();

                map.Add(descrizione, id_dimensione);
            }
            dbPro.Close();

            return map;
        }

        public bool IsRapprLegale(int IdImpresa,StringNT cfUtente)
        {
            var impresa = GetById(IdImpresa);
            var personaXimprese = new SiarBLL.PersoneXImpreseCollectionProvider().GetById(impresa.IdRapprlegaleUltimo);

            if (personaXimprese.CodiceFiscale == cfUtente) return true;
            else return false;
        }
    }
}
