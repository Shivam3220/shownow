namespace ShopNow.Core.Contracts.Interfaces.Settings
{
    public interface ICacheSettings
    {
        /// <summary>
        /// Cache Connection String
        /// </summary>
        string ConnectionString { get; }

        /// <summary>
        /// Local Cache Instance Name
        /// </summary>
        string InstanceName { get; }

    }
}