using SiarLibrary;
using System;
using System.Linq;

namespace SiarBLL
{
    public static class EmailUtility
    {
        public static void SendEmailToTeamSigef(Exception ex, string oggettoEmail, string testoEmail)
        {
            var teamSigefList = new TeamSigefCollectionProvider()
                .FindAttivi(true)
                .ToArrayList<TeamSigef>();
            var firstOrDefaultTeam = teamSigefList.FirstOrDefault();
            string istanza = "";
            if (firstOrDefaultTeam != null)
                istanza = firstOrDefaultTeam.Istanza;
            else
                throw new Exception("Non è stato trovato nessun membro del team a cui mandare email di errore");
            var emailTeamList = teamSigefList
                .Select(t => t.Email.ToString())
                .ToList();

            new Email(oggettoEmail, testoEmail).SendAlertToTeamSigef(ex, emailTeamList, istanza);
        }
    }
}
