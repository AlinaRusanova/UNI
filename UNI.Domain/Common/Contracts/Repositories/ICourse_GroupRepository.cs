using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UNI.Domain.Entities;

namespace UNI.Domain.Contracts
{
    public interface ICourse_GroupRepository: IAsyncRepository<Course_Group>
    {
    }
}
