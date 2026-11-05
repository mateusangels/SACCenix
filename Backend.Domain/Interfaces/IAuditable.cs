using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Domain.Interfaces
{
    public interface IAuditable
    {
        DateTime? Created_At { get; set; }
        DateTime? Updated_At { get; set; }
    }
}
