using System;
using System.Collections.Generic;

namespace BusinessLogic.Abstractions
{
    /// <summary>
    /// Provides extra methods for repositories such as filtering, searching, relationships operations.
    /// </summary>
    /// <typeparam name="TEntity">Type of the entity in the database.</typeparam>
    /// <typeparam name="TFilter">Filter to use. Must match <typeparamref name="TEntity"/> by the name.</typeparam>
    public interface IRepositoryAdvanced<T> : IRepository<T>
    {
        /// <summary>
        /// Gets a record from the database by the ID and includes all of its relationships.
        /// </summary>
        /// <param name="id">ID of the record.</param>
        /// <returns><typeparamref name="T"/> model with all of its relationships.</returns>
        T GetByIdWithRelationships(Guid id);

        /// <summary>
        /// Gets a list of the records from the database including all relationships for each record.
        /// </summary>
        /// <returns>First 10 records of type <typeparamref name="T"/> from the database including all relationships.</returns>
        IEnumerable<T> GetListWithRelationships(int pageSize = 10, int pageNumber = 1);
    }
}
