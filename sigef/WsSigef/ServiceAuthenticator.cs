using System;
using System.Collections.Generic;
using System.Linq;
using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;
using System.ServiceModel;


namespace WsSigef
{
    public partial class ServiceAuthenticator : UserNamePasswordValidator
    {
        public override void Validate(string userName, string password)
        {
            var op = new SigefServiceOperazioni();
            if (null == userName || null == password)
            {
                //throw new ArgumentNullException("Credenziali non presenti");
                throw new FaultException("Credenziali non presenti");
            }

            var auth = op.GetCredentials(userName, password);
            if (auth == null)
            {
                //throw new SecurityTokenValidationException("credenziali non valide");
                throw new FaultException("credenziali non valide");
            }
            //try
            //{
            //    var op = new SigefServiceOperazioni();
            //    if (null == userName || null == password)
            //    {
            //        throw new ArgumentNullException(ex);
            //    }

            //}
            //catch(ArgumentNullException ex) 
            //{
            //    return new AuthInfoResult("KO", null, "Credenziali non presenti");
            //}
            //catch (SecurityTokenValidationException ex)
            //{
            //    throw;
            //}
            //var op = new SigefServiceOperazioni();
            //if (null == userName || null == password)
            //{
            //    throw new ArgumentNullException(ex);
            //}

            //var auth = op.GetCredentials(userName, password);
            //if (auth == null)
            //{
            //    throw new SecurityTokenValidationException("credenziali non valide");
            //}

        }
    }
}