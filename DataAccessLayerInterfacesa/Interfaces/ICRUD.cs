using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayerInterfacesa.Interfaces
{
    public interface ICRUD<T>
    {
        void Create(T item);
        /// <summary>
        /// Updates a line in db table for item of type T
        /// May throw ValidationException if smth goes wrong
        /// </summary>
        /// <param name="item">Item of type T to update</param>
        void Update(T item);
        /// <summary>
        /// Deletes a line from db table by specified id
        /// May throw ValidationException if smth goes wrong
        /// </summary>
        /// <param name="id">Id of item to delete</param>
        void Delete(int Id);
        /// <summary>
        /// Gets all the items of current type from db
        /// </summary>
        /// <returns>All the items of current type (T)</returns>
        IEnumerable<T> GetAll();
        /// <summary>
        /// Gets the item of current type from db with specified id
        /// </summary>
        /// <param name="id">Id of the item to get</param>
        /// <returns>The item of current type (T)</returns>
        T Get(int Id);
    }
}
