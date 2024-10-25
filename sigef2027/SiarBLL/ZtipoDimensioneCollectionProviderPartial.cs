using System;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;
using System.Data;
using System.Data.SqlClient;

namespace SiarBLL
{
    public partial class ZtipoDimensioneCollectionProvider : IZtipoDimensioneProvider
    {
        public ZtipoDimensioneCollection GetAll()
        {
            ZtipoDimensioneCollection tdc = new ZtipoDimensioneCollection();
            IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT Cod_Dim, Descrizione FROM  zTIPO_DIMENSIONE ORDER BY Ordine";
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
            {
                tdc.Add(SiarDAL.ZtipoDimensioneDAL.GetFromDatareader(DbProviderObj));
            }
            DbProviderObj.Close();

            return tdc;
        }
    }
}
