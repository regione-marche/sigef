using System.Data;
using System.Data.SqlClient;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarBLL
{
    public partial class IgrueInvioCollectionProvider : IIgrueInvioProvider
    {

        //GetDataInvioDaA: popola la collection senza file
        public IgrueInvioCollection GetDataInvioDaASenzaFile(DatetimeNT DatainvioEqGreaterThanThis, DatetimeNT DatainvioEqLessThanThis, string CodiceFondoEqualThis)
        {
            IgrueInvioCollection igruee_invii_collection = new IgrueInvioCollection();
            IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ZIgrueInvioFindGetdatainviodaaSenzaFile";

            if (DatainvioEqGreaterThanThis != null) 
                cmd.Parameters.Add(new SqlParameter("@DataInvioeqgreaterthanthis", DatainvioEqGreaterThanThis));
            if (DatainvioEqLessThanThis != null) 
                cmd.Parameters.Add(new SqlParameter("@DataInvioeqlessthanthis", DatainvioEqLessThanThis));
            if (CodiceFondoEqualThis != null && CodiceFondoEqualThis != "")
                cmd.Parameters.Add(new SqlParameter("@CodiceFondoEqualThis", CodiceFondoEqualThis));

            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read()) 
                igruee_invii_collection.Add(IgrueInvioDAL.GetFromDatareader(DbProviderObj));
            DbProviderObj.Close();

            return igruee_invii_collection;
        }
    }
}
