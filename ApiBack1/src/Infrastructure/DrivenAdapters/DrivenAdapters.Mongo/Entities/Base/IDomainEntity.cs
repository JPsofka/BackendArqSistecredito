using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrivenAdapters.Mongo.Entities.Base
{
    public interface IDomainEntity<out T> where T : class
    {
        T asEntity();
    }
}
