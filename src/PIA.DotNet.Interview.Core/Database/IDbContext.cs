using System.Collections.Generic;

namespace PIA.DotNet.Interview.Core.Database
{
    public interface IDbContext
    {
        ICollection<T> GetDataset<T>();
        bool Save();
    }
}
