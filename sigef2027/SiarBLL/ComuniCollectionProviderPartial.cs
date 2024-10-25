using System;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarBLL
{
    public partial class ComuniCollectionProvider : IComuniProvider
    {
        public SiarLibrary.ComuniCollection RicercaComune(string tipo_ricerca, string sigla_provincia, string cap_comune, string denominazione_comune,
            string cod_provincia, string istat_comune, string cod_belfiore, BoolNT attivo)
        {
            SiarLibrary.ComuniCollection cc = new ComuniCollection();
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpRicercaComune";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("TIPO_RICERCA", tipo_ricerca));
            if (!string.IsNullOrEmpty(sigla_provincia)) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("SIGLA_PROVINCIA", sigla_provincia));
            if (!string.IsNullOrEmpty(cap_comune)) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("CAP_COMUNE", cap_comune));
            if (!string.IsNullOrEmpty(denominazione_comune)) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("DENOMINAZIONE_COMUNE", denominazione_comune));
            if (!string.IsNullOrEmpty(cod_provincia)) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("COD_PROVINCIA", cod_provincia));
            if (!string.IsNullOrEmpty(istat_comune)) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ISTAT_COMUNE", istat_comune));
            if (!string.IsNullOrEmpty(cod_belfiore)) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("COD_BELFIORE", cod_belfiore));
            if (attivo != null) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ATTIVO", attivo.Value));
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read()) cc.Add(SiarDAL.ComuniDAL.GetFromDatareader(DbProviderObj));
            DbProviderObj.Close();
            return cc;
        }

        public SiarLibrary.ComuniCollection FindXLocalizzazioniBando(int idBandoequalthis, StringNT CodbelfioreEqualThis, StringNT CodprovinciaEqualThis, StringNT CodregioneEqualThis,
                StringNT SiglaProvinciaequalthis, StringNT CapEqualThis, StringNT IstatEqualThis,
                BoolNT AttivoEqualThis, StringNT DenominazioneLikeThis)
        {
            SiarLibrary.ComuniCollection cc = new ComuniCollection();
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpRicercaComuneXLocalizzazioniBando";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("idBandoequalthis", idBandoequalthis));
            if (!string.IsNullOrEmpty(CodbelfioreEqualThis)) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("CodBelfioreequalthis", CodbelfioreEqualThis.ToString()));
            if (!string.IsNullOrEmpty(CodprovinciaEqualThis)) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("CodProvinciaequalthis", CodprovinciaEqualThis.ToString()));
            if (!string.IsNullOrEmpty(CodregioneEqualThis)) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("CodRegioneequalthis", CodregioneEqualThis.ToString()));
            if (!string.IsNullOrEmpty(SiglaProvinciaequalthis)) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("SiglaProvinciaequalthis", SiglaProvinciaequalthis.ToString()));
            if (!string.IsNullOrEmpty(CapEqualThis)) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("Capequalthis", CapEqualThis.ToString()));
            if (!string.IsNullOrEmpty(IstatEqualThis)) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("Istatequalthis", IstatEqualThis.ToString()));
            if (AttivoEqualThis != null) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("Attivoequalthis", (AttivoEqualThis.Value ? 1 : 0)));
            if (!string.IsNullOrEmpty(DenominazioneLikeThis)) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("Denominazionelikethis", DenominazioneLikeThis.ToString()));
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read()) cc.Add(SiarDAL.ComuniDAL.GetFromDatareader(DbProviderObj));
            DbProviderObj.Close();
            return cc;
        }

        public SiarLibrary.ComuniCollection FindXLocalizzazioniBandoCovid(StringNT CodbelfioreEqualThis, StringNT CodprovinciaEqualThis, StringNT CodregioneEqualThis,
                StringNT SiglaProvinciaequalthis, StringNT CapEqualThis, StringNT IstatEqualThis,
                BoolNT AttivoEqualThis, StringNT DenominazioneLikeThis)
        {
            SiarLibrary.ComuniCollection cc = new ComuniCollection();
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpRicercaComuneXLocalizzazioniBandoCovid";
            if (!string.IsNullOrEmpty(CodbelfioreEqualThis)) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("CodBelfioreequalthis", CodbelfioreEqualThis.ToString()));
            if (!string.IsNullOrEmpty(CodprovinciaEqualThis)) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("CodProvinciaequalthis", CodprovinciaEqualThis.ToString()));
            if (!string.IsNullOrEmpty(CodregioneEqualThis)) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("CodRegioneequalthis", CodregioneEqualThis.ToString()));
            if (!string.IsNullOrEmpty(SiglaProvinciaequalthis)) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("SiglaProvinciaequalthis", SiglaProvinciaequalthis.ToString()));
            if (!string.IsNullOrEmpty(CapEqualThis)) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("Capequalthis", CapEqualThis.ToString()));
            if (!string.IsNullOrEmpty(IstatEqualThis)) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("Istatequalthis", IstatEqualThis.ToString()));
            if (AttivoEqualThis != null) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("Attivoequalthis", (AttivoEqualThis.Value ? 1 : 0)));
            if (!string.IsNullOrEmpty(DenominazioneLikeThis)) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("Denominazionelikethis", DenominazioneLikeThis.ToString()));
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read()) cc.Add(SiarDAL.ComuniDAL.GetFromDatareader(DbProviderObj));
            DbProviderObj.Close();
            return cc;
        }

        //Find per autocomplete dei comuni in anagrafica impresa
        // se attivo = 1 -> probabilmente sto cercando i comuni di residenza che dovrebbero essere solo attivi
        // se attivo = null -> probabilmente sto cercando i comuni di nascita che potrebbero essere non attivi
        public ComuniCollection FindComuniAttivi(BoolNT AttivoEqualThis, StringNT DenominazioneLikeThis)
        {
            ComuniCollection cc = new ComuniCollection();
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpFindComuniAttivi";

            if (AttivoEqualThis != null) 
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("Attivoequalthis", (AttivoEqualThis.Value ? 1 : 0)));
            if (!string.IsNullOrEmpty(DenominazioneLikeThis)) 
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("Denominazionelikethis", DenominazioneLikeThis.ToString()));

            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read()) 
                cc.Add(SiarDAL.ComuniDAL.GetFromDatareader(DbProviderObj));
            DbProviderObj.Close();
            return cc;
        }
    }
}
