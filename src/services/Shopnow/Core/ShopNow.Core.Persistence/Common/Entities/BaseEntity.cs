using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopNow.Core.Persistence.Common.Entities
{
    public class BaseEntity
    {
        public int Id { get; protected internal set; }

        public Guid Uid { get; protected internal set; }

        public DateTime CreatedOn { get; protected internal set; }
    }
}