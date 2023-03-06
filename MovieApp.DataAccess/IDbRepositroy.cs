using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.DataAccess
{
    public interface IDbRepository
    {
        void Insert();
        void Delete();
        void Update();
    }
}
