using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Domain.Entities
{
    public abstract class BaseEntity
    {
        public Guid id { get; set; }
    }
}
