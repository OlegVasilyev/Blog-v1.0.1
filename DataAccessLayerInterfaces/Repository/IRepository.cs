using DataAccessLayerInterfacesa.Interfaces;
using System;
using System.Collections.Generic;

namespace DataAccessLayerInterfaces.Repository
{
    /// <summary>
    /// Interface for implementation of generic repository pattern
    /// </summary>
    /// <typeparam name="T">Class of entitiy repository will work with</typeparam>
    public interface IRepository<T> : ICRUD<T> where T : class
    {
        /// <summary>
        /// Gets the items of current type from db using anon function for search
        /// </summary>
        /// <param name="predicate">Function for search</param>
        /// <returns>The found items of current type (T)</returns>
        IEnumerable<T> Find(Func<T, Boolean> predicate);
    }
}
