using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using SiarLibrary.NullTypes;
using System.Xml;
using System.Xml.XPath;
using SianWebSrv.Utils;


namespace SianWebSrv
{

    public struct TDestinazione
    {
        /// Codice macrouso, sempre presente
        public string codiceMacrouso;
        /// Codice qualità, non obbligatorio
        public string codiceQualita;
        /// Superficie in mq destinata allo specifico macrouso
        public int superficieUtilizzata;
        /// Superficie ammissibile calcolata per lo specifico macrouso
        public int superficieEligibile;
        public DatetimeNT dataInizioUtilizzo;
        public DatetimeNT dataFineUtilizzo;
        /// Dettagli destinazione
        public TDettagli Dettagli;
    }

    /// Lista di destinazioni
    public class TDestinazioni : System.Collections.CollectionBase
    {
        public void Add(TDestinazione Destinazione)
        {
            List.Add(Destinazione);
        }
        public void Remove(int index)
        {
            if (index > Count - 1 || index < 0)
            {
                throw new Exception("Collection index out of range");
            }
            else
            {
                List.RemoveAt(index);
            }
        }
        public TDestinazione Item(int Index)
        {
            return (TDestinazione)List[Index];
        }
    }

    public struct TDettaglio
    {
        /// Codice prodotto, sempre presente
        public string codiceProdotto;
        /// Codice varietà, non obbligatorio
        public string codiceVarieta;
        /// Superficie in mq destinata allo specifico prodotto
        public int superficieUtilizzata;
        /// Superficie in mq ammissibile calcolata per la coltura
        public int superficieEligibile;
        /// Numero piante per la varietà
        public string numeroPiante;
        /// 1 = coltura principale (indica varietà prevalente per olivo)
        /// 0 = Non è coltura principale (indica che non è varietà prevalente per olivo)
        public string flagColtPrincipale;
        /// Codice forma allevamento  
        public string formaAllevamento;
        /// Anno di impianto 
        public string annoImpianto;
        /// Distanza piante sulla fila (espresso in cm)
        public string sestoImpiantoSuFila;
        /// Distanza piante tra le fila (espresso in cm)
        public string sestoImpiantoTraFile;
        /// 0 = regolare; 1 = irregolare
        public string tipoImpianto;
        /// 1 = biologico; 2 = in conversione; 3 = coltivazione non biologica
        public string coltivazioneBiologica;
        /// 1 = TRADIZIONALE; 2 = SU SODO; 3 = MINIMUM TILLAGE; 4 = PRATICHE EQUIVALENTI
        public string tipologiaSemina;
        /// 1 = SOMMERSIONE; 2 = SCORRIMENTO; 3 = ASPERSIONE O A PIOGGIA; 4 = MICROPORTATE O A GOCCIA; 5 = SUBIRRIGAZIONE
        public string tipologiaIrrigazione;
        /// 1 = RETI ANTIGRANDINE; 2 = RETI ANTIACQUA; 3 = SERRE E TUNNEL FISSI; 4 = OMBRAI; 5 = IMPIANTI ANTIBRINA
        public string protezioneColture;
        /// 1 = PRODUTTIVO; 2 = NON PRODUTTIVO
        public string faseAllevamento;
        /// 1 = Pascolamento con animali propri; 2 = Pascolamento con animali di terzi; 3 = Sfalcio manuale; 4 = Sfalcio meccanizzato; 5 = Pratiche colturali volte al miglioramento
        /// 6 = Sfalcio con cadenza biennale; 7 = Pascolamento e sfalcio; 8 = nessuna pratica; 10 = Pratica stabilita nell’ambito delle misure di conservazione
        public string mantPratiPermanente;
        /// 1 = Nessuna pratica; 2 = Pratica ordinaria
        public string mantenSupAgricola;
        /// 0 = nessuna; 1 = DOP; 2 = IGP
        public string tipoCertificazione;
        /// Percentuale stimata presente sulla particella
        public string percentuale;
        /// Codice Menzione DOP 
        public string menzione;
        /// 0 = promiscuo; 1 = specializzato
        public string tipoUtilizzoOlivo;
        /// capacità per Kg/Ha
        public string capacitaProduttiva;
        /// Altitudine (espressa in mt)
        public string altitudine;
    }

    /// Lista dei dettagli
    public class TDettagli : System.Collections.CollectionBase
    {
        public void Add(TDettaglio Destinazione)
        {
            List.Add(Destinazione);
        }
        public void Remove(int index)
        {
            if (index > Count - 1 || index < 0)
            {
                throw new Exception("Collection index out of range");
            }
            else
            {
                List.RemoveAt(index);
            }
        }
        public TDettaglio Item(int Index)
        {
            return (TDettaglio)List[Index];
        }
    }


    public class TParticellaInUso
    {
        /// Sezione catastale di solito non è presente
        public string Sezione;
        /// Foglio catastale è sempre presente, tranne i casi particolari
        public string Foglio;
        /// Particella catastale è sempre presente, tranne i casi particolari
        public string Particella;
        /// Subalterno catastale di solito non è presente
        public string Subalterno;
        /// Tipo titolo di possesso: 1 proprietà, 2 affitto, 3 mezzadria, 4 altro
        public string codiceTipoConduzione;
        /// Data a partire dalla quale l'azienda dispone della particella
        public DatetimeNT DataInizioConduzione;
        /// Data fino alla quale l'azienda dispone della particella
        public DatetimeNT DataFineConduzione;
        /// Lista dei codici fiscali dei proprietari della particella, non sempre sono presenti.
        public StringCollection Proprietari = new StringCollection();
        /// Superficie in mq risultante al catasto
        public int SuperficieCatastale;
        /// Superficie in mq su in uso presso l'azienda
        public int SuperficieCondotta;
        /// Codice fiscale azienda
        public string CUAA;
        /// Codice ISTAT comune dove si trova la particella
        public string Comune;
        /// Codice ISTAT provincia dove si trova la particella
        public string Provincia;
        /// Lista delle destinazioni d'uso della particella
        public TDestinazioni Destinazioni = new TDestinazioni();
        /// <summary>
        /// Tipo del documento giustificativo del titolo di possesso. Vedi allegato 
        /// "Conduzione particella". Obbligatorio nel caso di CodiceTipoConduzione diverso da 1
        /// </summary>
        public string TipoDocumento;
        /// Numero di protocollo del documento giustificativo del titolo di possesso
        public string NumeroDocumento;
        /// Data del documento giustificativo del titolo di possesso
        public DatetimeNT DataDocumento;
        /// vale True se la particella è irrigabile
        public bool FlagIrrigua;
        /// vale True per particella con terrazzamenti
        public bool FlagTerrazzata;
        /// <summary>
        /// vale 0 se non è presente rotazione di colture ortive, altrimenti riporta
        /// il numero di rotazioni 1..n
        /// </summary>
        public int RotazioneColtureOrtive;
        /// ???????????????????
        public bool EffluentiZootecnici;
        /// vale True se la particella ha Sostanze Pericolose
        public bool SostanzePericolose;
        /// Se presente specifica il motivo dell'assenza dei riferimenti catastali
        public string CasiParticolari;
        /// <summary>
        /// Presenza di documentazione giustificativa della presenza a catasto (es. visura)
        /// Puo’ assumere i seguenti valori :1 Presenza di documentazione giustificativa
        /// </summary>
        public bool FlagGiust;

    }

    public class TConsistenza : System.Collections.CollectionBase
    {
        public void Add(TParticellaInUso Destinazione)
        {
            List.Add(Destinazione);
        }
        public void Remove(int index)
        {
            if (index > Count - 1 || index < 0)
            {
                throw new Exception("Collection index out of range");
            }
            else
            {
                List.RemoveAt(index);
            }
        }
        public TParticellaInUso Item(int Index)
        {
            return (TParticellaInUso)List[Index];
        }

        /// <summary>
        /// Cerca una particella che abbia i riferimenti catastali richiesti, se
        /// la trova la restituisce, altrimenti restituisce null
        /// </summary>
        public TParticellaInUso Find(
            string Provincia,
            string Comune,
            string Sezione,
            string Foglio,
            string Particella,
            string Subalterno)
        {
            string _Provincia = Provincia.Trim();
            string _Comune = Comune.Trim();
            string _Sezione = Sezione.Trim();
            string _Foglio = Foglio.Trim();
            string _Particella = Particella.Trim();
            string _Subalterno = Subalterno.Trim();

            if ((_Provincia == "") ||
                 (_Comune == "") ||
                 (_Foglio == "") ||
                 (_Particella == ""))
            {
                // inutile sprecare tempo
                return null;
            }

            for (int i = 1; this.Count >= i; ++i)
            {
                TParticellaInUso p = this.Item(i - 1);
                if (
                     (p.Provincia == _Provincia) &&
                     (p.Comune == _Comune) &&
                     (p.Foglio == _Foglio) &&
                     (p.Particella == _Particella) &&
                     (p.Subalterno == _Subalterno) &&
                     (p.Sezione == _Sezione)
                    )
                {
                    return p;
                }
            }

            return null;
        }

        public TConsistenza(SIANGateway.SianResult SianData)
        {
            XPathNodeIterator Particelle = SianData.getIterator(SIANGateway.XPathFascicolo20.risposta21.Root);
            for (int i = 1; i <= Particelle.Count; ++i)
            {
                Particelle.MoveNext();
                TParticellaInUso newItem = new TParticellaInUso();

                // recupero le destinazioni della particella
                XPathNodeIterator DestinazioniXml = SianData.getIterator(
                     SIANGateway.XPathFascicolo20.risposta21.Destinazione.Root,
                     Particelle, false
                );
                for (int nDest = 1; nDest <= DestinazioniXml.Count; ++nDest)
                {
                    DestinazioniXml.MoveNext();
                    TDestinazione Destinazione = new TDestinazione();
                    Destinazione.codiceMacrouso = SianData.getValue(
                        SIANGateway.XPathFascicolo20.risposta21.Destinazione.codiceMacrouso,
                        DestinazioniXml
                    );
                    Destinazione.codiceQualita = SianData.getValue(
                        SIANGateway.XPathFascicolo20.risposta21.Destinazione.codiceQualita,
                        DestinazioniXml
                    );
                    Destinazione.superficieUtilizzata = Utils.SianConvert.SianValueToInt(
                        SianData.getValue(SIANGateway.XPathFascicolo20.risposta21.Destinazione.superficieUtilizzata,
                                            DestinazioniXml
                        )
                    );
                    Destinazione.superficieEligibile = Utils.SianConvert.SianValueToInt(
                        SianData.getValue(SIANGateway.XPathFascicolo20.risposta21.Destinazione.superficieEligibile,
                                            DestinazioniXml
                        )
                    );
                    string dataInizioUt = SianData.getValue(
                            SIANGateway.XPathFascicolo20.risposta21.Destinazione.dataInizioUtilizzo,
                            DestinazioniXml
                        );
                    Destinazione.dataInizioUtilizzo = new DataSIAN(dataInizioUt).getDatetimeNT();

                    string dataFineUt = SianData.getValue(
                            SIANGateway.XPathFascicolo20.risposta21.Destinazione.dataFineUtilizzo,
                            DestinazioniXml
                        );
                    Destinazione.dataFineUtilizzo = new DataSIAN(dataFineUt).getDatetimeNT();

                    // recupero il dettaglio della coltura impiantata
                    Destinazione.Dettagli = new TDettagli();
                    XPathNodeIterator DettagliXml = SianData.getIterator(
                         SIANGateway.XPathFascicolo20.risposta21.Destinazione.Dettagli.Root,
                         DestinazioniXml, false
                    );
                    for (int nDett = 1; nDett <= DettagliXml.Count; ++nDett)
                    {
                        DettagliXml.MoveNext();
                        TDettaglio Dettaglio = new TDettaglio();
                        Dettaglio.codiceProdotto = SianData.getValue(
                            SIANGateway.XPathFascicolo20.risposta21.Destinazione.Dettagli.codiceProdotto,
                            DettagliXml
                        );
                        Dettaglio.codiceVarieta = SianData.getValue(
                            SIANGateway.XPathFascicolo20.risposta21.Destinazione.Dettagli.codiceVarieta,
                            DettagliXml
                        );
                        Dettaglio.superficieUtilizzata = Utils.SianConvert.SianValueToInt(
                            SianData.getValue(
                                SIANGateway.XPathFascicolo20.risposta21.Destinazione.Dettagli.superficieUtilizzata,
                                DettagliXml
                            )
                        );
                        Dettaglio.superficieEligibile = Utils.SianConvert.SianValueToInt(
                            SianData.getValue(
                                SIANGateway.XPathFascicolo20.risposta21.Destinazione.Dettagli.superficieEligibile,
                                DettagliXml, false
                            )
                        );
                        Dettaglio.numeroPiante = SianData.getValue(
                            SIANGateway.XPathFascicolo20.risposta21.Destinazione.Dettagli.numeroPiante,
                            DettagliXml, false
                        );
                        Dettaglio.flagColtPrincipale = SianData.getValue(
                            SIANGateway.XPathFascicolo20.risposta21.Destinazione.Dettagli.flagColtPrincipale,
                            DettagliXml, false
                        );
                        Dettaglio.formaAllevamento = SianData.getValue(
                            SIANGateway.XPathFascicolo20.risposta21.Destinazione.Dettagli.formaAllevamento,
                            DettagliXml, false
                        );
                        Dettaglio.annoImpianto = SianData.getValue(
                            SIANGateway.XPathFascicolo20.risposta21.Destinazione.Dettagli.annoImpianto,
                            DettagliXml, false
                        );
                        Dettaglio.sestoImpiantoSuFila = SianData.getValue(
                            SIANGateway.XPathFascicolo20.risposta21.Destinazione.Dettagli.sestoImpiantoSuFila,
                            DettagliXml, false
                        );
                        Dettaglio.sestoImpiantoTraFile = SianData.getValue(
                            SIANGateway.XPathFascicolo20.risposta21.Destinazione.Dettagli.sestoImpiantoTraFile,
                            DettagliXml, false
                        );
                        Dettaglio.tipoImpianto = SianData.getValue(
                            SIANGateway.XPathFascicolo20.risposta21.Destinazione.Dettagli.tipoImpianto,
                            DettagliXml, false
                        );
                        Dettaglio.coltivazioneBiologica = SianData.getValue(
                            SIANGateway.XPathFascicolo20.risposta21.Destinazione.Dettagli.coltivazioneBiologica,
                            DettagliXml, false
                        );
                        Dettaglio.tipologiaSemina = SianData.getValue(
                            SIANGateway.XPathFascicolo20.risposta21.Destinazione.Dettagli.tipologiaSemina,
                            DettagliXml, false
                        );
                        Dettaglio.tipologiaIrrigazione = SianData.getValue(
                            SIANGateway.XPathFascicolo20.risposta21.Destinazione.Dettagli.tipologiaIrrigazione,
                            DettagliXml, false
                        );
                        Dettaglio.protezioneColture = SianData.getValue(
                            SIANGateway.XPathFascicolo20.risposta21.Destinazione.Dettagli.protezioneColture,
                            DettagliXml, false
                        );
                        Dettaglio.faseAllevamento = SianData.getValue(
                            SIANGateway.XPathFascicolo20.risposta21.Destinazione.Dettagli.faseAllevamento,
                            DettagliXml, false
                        );
                        Dettaglio.mantPratiPermanente = SianData.getValue(
                            SIANGateway.XPathFascicolo20.risposta21.Destinazione.Dettagli.mantPratiPermanente,
                            DettagliXml, false
                        );
                        Dettaglio.mantenSupAgricola = SianData.getValue(
                            SIANGateway.XPathFascicolo20.risposta21.Destinazione.Dettagli.mantenSupAgricola,
                            DettagliXml, false
                        );
                        Dettaglio.tipoCertificazione = SianData.getValue(
                            SIANGateway.XPathFascicolo20.risposta21.Destinazione.Dettagli.tipoCertificazione,
                            DettagliXml, false
                        );
                        Dettaglio.percentuale = SianData.getValue(
                            SIANGateway.XPathFascicolo20.risposta21.Destinazione.Dettagli.percentuale,
                            DettagliXml, false
                        );
                        Dettaglio.menzione = SianData.getValue(
                            SIANGateway.XPathFascicolo20.risposta21.Destinazione.Dettagli.menzione,
                            DettagliXml, false
                        );
                        Dettaglio.tipoUtilizzoOlivo = SianData.getValue(
                            SIANGateway.XPathFascicolo20.risposta21.Destinazione.Dettagli.tipoUtilizzoOlivo,
                            DettagliXml, false
                        );
                        Dettaglio.capacitaProduttiva = SianData.getValue(
                            SIANGateway.XPathFascicolo20.risposta21.Destinazione.Dettagli.capacitaProduttiva,
                            DettagliXml, false
                        );
                        Dettaglio.altitudine = SianData.getValue(
                            SIANGateway.XPathFascicolo20.risposta21.Destinazione.Dettagli.altitudine,
                            DettagliXml, false
                        );
                        Destinazione.Dettagli.Add(Dettaglio);
                    }
                    newItem.Destinazioni.Add(Destinazione);
                }

                // recupero i proprietari della particella
                XPathNodeIterator ProprietariXml = SianData.getIterator(
                     SIANGateway.XPathFascicolo20.risposta21.Proprietari.Root,
                     Particelle, false
                );
                for (int nProp = 1; nProp <= ProprietariXml.Count; ++nProp)
                {
                    ProprietariXml.MoveNext();
                    string Proprietario = SianData.getValue(
                        SIANGateway.XPathFascicolo20.risposta21.Proprietari.proprietario,
                        ProprietariXml, false
                    );
                    newItem.Proprietari.Add(Proprietario);
                }

                newItem.CasiParticolari = SianData.getValue(
                        SIANGateway.XPathFascicolo20.risposta21.CasiParticolari,
                        Particelle, false
                    );
                newItem.codiceTipoConduzione = SianData.getValue(
                        SIANGateway.XPathFascicolo20.risposta21.codiceTipoConduzione,
                        Particelle, true
                    );
                newItem.Comune = SianData.getValue(
                        SIANGateway.XPathFascicolo20.risposta21.Comune,
                        Particelle, true
                    );
                newItem.CUAA = SianData.getValue(
                        SIANGateway.XPathFascicolo20.risposta21.CUAA,
                        Particelle, true
                    );

                string DtDocStr = SianData.getValue(
                        SIANGateway.XPathFascicolo20.risposta21.DataDocumento,
                        Particelle, false
                    );
                newItem.DataDocumento = new DataSIAN(DtDocStr).getDatetimeNT();

                string DtFineStr = SianData.getValue(
                        SIANGateway.XPathFascicolo20.risposta21.DataFineConduzione,
                        Particelle, false
                    );
                newItem.DataFineConduzione = new DataSIAN(DtFineStr).getDatetimeNT();

                string DtInizioStr = SianData.getValue(
                        SIANGateway.XPathFascicolo20.risposta21.DataInizioConduzione,
                        Particelle, false
                    );
                newItem.DataInizioConduzione = new DataSIAN(DtInizioStr).getDatetimeNT();

                newItem.EffluentiZootecnici = Utils.SianConvert.SianValueToBool(
                    SianData.getValue(
                        SIANGateway.XPathFascicolo20.risposta21.EffluentiZootecnici,
                        Particelle, false
                    ), ActionOnInvalidValue.acNullValue);

                newItem.FlagGiust = Utils.SianConvert.SianValueToBool(
                    SianData.getValue(
                        SIANGateway.XPathFascicolo20.risposta21.FlagGiust,
                        Particelle, false
                    ), ActionOnInvalidValue.acNullValue);

                newItem.FlagIrrigua = Utils.SianConvert.SianValueToBool(
                    SianData.getValue(
                        SIANGateway.XPathFascicolo20.risposta21.FlagIrrigua,
                        Particelle, false
                    ), ActionOnInvalidValue.acNullValue);

                newItem.FlagTerrazzata = Utils.SianConvert.SianValueToBool(
                    SianData.getValue(
                        SIANGateway.XPathFascicolo20.risposta21.FlagTerrazzata,
                        Particelle, false
                    ), ActionOnInvalidValue.acNullValue);

                newItem.Foglio = SianData.getValue(
                        SIANGateway.XPathFascicolo20.risposta21.Foglio,
                        Particelle, false
                        );

                newItem.NumeroDocumento = SianData.getValue(
                        SIANGateway.XPathFascicolo20.risposta21.NumeroDocumento,
                        Particelle, false
                        );

                newItem.Particella = SianData.getValue(
                        SIANGateway.XPathFascicolo20.risposta21.Particella,
                        Particelle, false
                        );

                newItem.Provincia = SianData.getValue(
                        SIANGateway.XPathFascicolo20.risposta21.Provincia,
                        Particelle, true
                        );

                newItem.RotazioneColtureOrtive = Utils.SianConvert.SianValueToInt(
                    SianData.getValue(
                        SIANGateway.XPathFascicolo20.risposta21.RotazioneColtureOrtive,
                        Particelle, true
                    ), ActionOnInvalidValue.acThrow);

                newItem.Sezione = SianData.getValue(
                        SIANGateway.XPathFascicolo20.risposta21.Sezione,
                        Particelle, false
                        );

                newItem.SostanzePericolose = Utils.SianConvert.SianValueToBool(
                    SianData.getValue(
                        SIANGateway.XPathFascicolo20.risposta21.SostanzePericolose,
                        Particelle, false
                    ), ActionOnInvalidValue.acNullValue);

                newItem.Subalterno = SianData.getValue(
                        SIANGateway.XPathFascicolo20.risposta21.Subalterno,
                        Particelle, false
                        );

                newItem.SuperficieCatastale = Utils.SianConvert.SianValueToInt(
                             SianData.getValue(
                             SIANGateway.XPathFascicolo20.risposta21.SuperficieCatastale,
                             Particelle, true)
                        );

                newItem.SuperficieCondotta = Utils.SianConvert.SianValueToInt(
                             SianData.getValue(
                             SIANGateway.XPathFascicolo20.risposta21.SuperficieCondotta,
                             Particelle, true)
                        );

                newItem.TipoDocumento = SianData.getValue(
                        SIANGateway.XPathFascicolo20.risposta21.TipoDocumento,
                        Particelle, false
                        );

                this.Add(newItem);
            }
        }

    }


}
