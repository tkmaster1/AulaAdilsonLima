namespace TKMaster.ProjetoAulaAdilson.Core.Domain.Notifications
{
    public class DomainNotification
    {
        #region Properties

        public string Key { get; set; }

        public string Value { get; set; }

        #endregion

        #region Constructor

        public DomainNotification(string key, string value)
        {
            Key = key;
            Value = value;
        }

        #endregion

    }
}
