using System.Data;
using System.Data.SqlClient;
using SiarLibrary;

namespace SiarBLL
{
    public partial class ZdimensioniCollectionProvider : IZdimensioniProvider
    {
        private string SqlCode()
        {
            string _sqlCode = string.Empty;

            _sqlCode = @"SELECT dim.ID,
                                dim.CODICE,
                                dim.COD_DIM,
                                dim.DESCRIZIONE,
                                dim.METODO,
                                dim.VALORE,
                                dim.RICHIEDIBILE,
                                dim.UM,
                                dim.PROCEDURA_CALCOLO,
                                dim.ORDINE,
                                dim.VALORE_BASE,
                                tdm.DESCRIZIONE   AS DES_DIM ";
            
            _sqlCode += @"FROM zDIMENSIONI AS dim
                               INNER JOIN 
                               zTIPO_DIMENSIONE AS tdm ON dim.COD_DIM = tdm.COD_DIM ";

            return _sqlCode;
        }


        public ZdimensioniCollection GetAll()
        {
            string _sqlCode = SqlCode();
            ZdimensioniCollection dims = new ZdimensioniCollection();
            IDbCommand cmd = DbProviderObj.GetCommand();

            _sqlCode += @" ORDER BY DES_DIM, dim.ORDINE, dim.CODICE";
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = _sqlCode;
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
            {
                dims.Add(SiarDAL.ZdimensioniDAL.GetFromDatareader(DbProviderObj));
            }
            DbProviderObj.Close();

            return dims;
        }


        public ZdimensioniCollection GetByCodDim(string codDim)
        {
            string _sqlCode = SqlCode();
            ZdimensioniCollection dims = new ZdimensioniCollection();
            IDbCommand cmd = DbProviderObj.GetCommand();

            _sqlCode += @" WHERE tdm.COD_DIM = @CodDim ";
            _sqlCode += @" ORDER BY DES_DIM, dim.ORDINE, dim.CODICE";
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = _sqlCode;
            cmd.Parameters.Add(new SqlParameter("@CodDim", codDim));
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
            {
                dims.Add(SiarDAL.ZdimensioniDAL.GetFromDatareader(DbProviderObj));
            }
            DbProviderObj.Close();

            return dims;
        }


        public ZdimensioniCollection GetByIdProgramCodTipo(int IdProgrammazione, string CodTipo)
        {
            string _sqlCode = SqlCode();
            ZdimensioniCollection dims = new ZdimensioniCollection();
            IDbCommand cmd = DbProviderObj.GetCommand();

            _sqlCode += @" INNER JOIN zDIMENSIONI_X_PROGRAMMAZIONE dxp ON dim.Id = dxp.Id_Dimensione ";
            _sqlCode += @" WHERE dxp.Id_Programmazione = @IdProgrammazione AND tdm.Cod_Dim = @CodDim ";
            _sqlCode += @" ORDER BY DES_DIM, dim.ORDINE, dim.CODICE";
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = _sqlCode;
            cmd.Parameters.Add(new SqlParameter("@IdProgrammazione", IdProgrammazione));
            cmd.Parameters.Add(new SqlParameter("@CodDim", CodTipo));
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
            {
                dims.Add(SiarDAL.ZdimensioniDAL.GetFromDatareader(DbProviderObj));
            }
            DbProviderObj.Close();

            return dims;
        }


        public ZdimensioniCollection GetByIdProgramCodiceInd(int IdProgrammazione, string CodiceInd)
        {
            string _sqlCode = SqlCode();
            ZdimensioniCollection dims = new ZdimensioniCollection();
            IDbCommand cmd = DbProviderObj.GetCommand();

            _sqlCode += @" INNER JOIN zDIMENSIONI_X_PROGRAMMAZIONE dxp ON dim.Id = dxp.Id_Dimensione ";
            _sqlCode += @" WHERE dxp.Id_Programmazione = @IdProgrammazione AND dim.CODICE = @CodDim ";
            //_sqlCode += @" ORDER BY DES_DIM, dim.ORDINE, dim.CODICE";
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = _sqlCode;
            cmd.Parameters.Add(new SqlParameter("@IdProgrammazione", IdProgrammazione));
            cmd.Parameters.Add(new SqlParameter("@CodDim", CodiceInd));
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
            {
                dims.Add(SiarDAL.ZdimensioniDAL.GetFromDatareader(DbProviderObj));
            }
            DbProviderObj.Close();

            return dims;
        }
    }
}
