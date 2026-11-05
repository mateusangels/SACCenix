using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Domain.Interfaces
{
    public interface ISoftDelete
    {
        DateTime? Deleted_At { get; set; }
    }
}
