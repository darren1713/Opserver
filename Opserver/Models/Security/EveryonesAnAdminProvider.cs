namespace StackExchange.Opserver.Models.Security
{
    /// <summary>
    /// Does this REALLY need an explanation?
    /// </summary>
    public class EveryonesAnAdminProvider : SecurityProvider
    {
        public override bool IsAdmin
        {
            get
            {
                return Current.User.AccountName.Equals(System.Configuration.ConfigurationManager.AppSettings["AdminUsername"], System.StringComparison.CurrentCulture);
            }
        }

        public override bool IsViewer => true;

        public override bool InGroups(string groupNames, string accountName) { return true; }

        //internal override bool InAdminGroups(ISecurableModule settings) {
        //    return IsAdmin || (settings != null && InGroups(settings.AdminGroups));
        //}
        //public override bool InGroups(string groupNames, string accountName) {
        //    switch (groupNames)
        //    {
        //        case SiteSettings.AdminGroups:
        //            break;
        //        case SiteSettings.ViewGroups:
        //            break;
        //    }
        //}

        //private bool InGroups(string groupNames)
        //{
        //    if (groupNames.IsNullOrEmpty() || Current.User.AccountName.IsNullOrEmpty()) return false;
        //    return groupNames == "*" || InGroups(groupNames, Current.User.AccountName);
        //}

        public override bool ValidateUser(string userName, string password)
        {
            return ((userName.Equals(System.Configuration.ConfigurationManager.AppSettings["AdminUsername"], System.StringComparison.CurrentCulture)
                && password.Equals(System.Configuration.ConfigurationManager.AppSettings["AdminPassword"], System.StringComparison.CurrentCulture))
                || (userName.Equals(System.Configuration.ConfigurationManager.AppSettings["MonitoringUsername"], System.StringComparison.CurrentCulture)
                && password.Equals(System.Configuration.ConfigurationManager.AppSettings["MonitoringPassword"], System.StringComparison.CurrentCulture)));
        }
    }
}
