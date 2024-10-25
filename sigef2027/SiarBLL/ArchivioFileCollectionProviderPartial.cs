using System;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarBLL
{
    public partial class ArchivioFileCollectionProvider : IArchivioFileProvider
    {
        public ArchivioFile GetSenzaContenutoById(int _idFile)
        {
            ArchivioFile f = null;
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "SELECT TOP 1 ID,TIPO,NOME_FILE,NOME_COMPLETO,DIMENSIONE,HASH_CODE FROM ARCHIVIO_FILE WHERE ID=@ID";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID", _idFile));
            DbProviderObj.InitDatareader(cmd);
            if (DbProviderObj.DataReader.Read())
            {
                f = new ArchivioFile();
                f.Id = new SiarLibrary.NullTypes.IntNT(DbProviderObj.DataReader["ID"]);
                f.Tipo = new SiarLibrary.NullTypes.StringNT(DbProviderObj.DataReader["TIPO"]);
                f.NomeFile = new SiarLibrary.NullTypes.StringNT(DbProviderObj.DataReader["NOME_FILE"]);
                f.NomeCompleto = new SiarLibrary.NullTypes.StringNT(DbProviderObj.DataReader["NOME_COMPLETO"]);
                f.Dimensione = new SiarLibrary.NullTypes.IntNT(DbProviderObj.DataReader["DIMENSIONE"]);
                f.HashCode = new SiarLibrary.NullTypes.StringNT(DbProviderObj.DataReader["HASH_CODE"]);
            }
            DbProviderObj.Close();
            return f;
        }

        public ArchivioFile GetSenzaContenutoByHashCode(string hash_code)
        {
            ArchivioFile f = null;
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "SELECT TOP 1 ID,TIPO,NOME_FILE,NOME_COMPLETO,DIMENSIONE,HASH_CODE FROM ARCHIVIO_FILE WHERE HASH_CODE=@HASH_CODE";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@HASH_CODE", hash_code));
            DbProviderObj.InitDatareader(cmd);
            if (DbProviderObj.DataReader.Read())
            {
                f = new ArchivioFile();
                f.Id = new SiarLibrary.NullTypes.IntNT(DbProviderObj.DataReader["ID"]);
                f.Tipo = new SiarLibrary.NullTypes.StringNT(DbProviderObj.DataReader["TIPO"]);
                f.NomeFile = new SiarLibrary.NullTypes.StringNT(DbProviderObj.DataReader["NOME_FILE"]);
                f.NomeCompleto = new SiarLibrary.NullTypes.StringNT(DbProviderObj.DataReader["NOME_COMPLETO"]);
                f.Dimensione = new SiarLibrary.NullTypes.IntNT(DbProviderObj.DataReader["DIMENSIONE"]);
                f.HashCode = new SiarLibrary.NullTypes.StringNT(DbProviderObj.DataReader["HASH_CODE"]);
            }
            DbProviderObj.Close();
            return f;
        }
    }
}
