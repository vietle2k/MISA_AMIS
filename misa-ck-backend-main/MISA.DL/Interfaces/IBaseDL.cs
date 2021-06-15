using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.DL.Interfaces
{
    public interface IBaseDL
    {
        IEnumerable<MISAEntity> GetAll<MISAEntity>();
        MISAEntity GetById<MISAEntity>(Guid id);
        int Insert<MISAEntity>(MISAEntity entity);
        int Update<MISAEntity>(MISAEntity entity, Guid id);
        int Delete<MISAEntity>(Guid id);
    }
}
