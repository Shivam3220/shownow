using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopNow.Core.Contracts.Interfaces.Settings
{
    public interface IDbConnectionSetting
    {
        /// <summary>
        /// Gets the connection string for the database.
        /// </summary>
        string ConnectionString { get; }
    }
}