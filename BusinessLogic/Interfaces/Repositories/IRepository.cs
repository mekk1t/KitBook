using System;
using System.Collections.Generic;

namespace BusinessLogic.Abstractions
{
    /// <summary>
    /// Provides basic CRUD operations to perform on <typeparamref name="T"/> entities.
    /// </summary>
    /// <typeparam name="T">Type of the entity in the database. Ensure that it exists beforehand.
    /// </typeparam>
    public interface IRepository<T>
    {
        /// <summary>
        /// Creates a new record of type <typeparamref name="T"/> in the database.
        /// </summary>
        /// <param name="entity">A new record.</param>
        void Create(T entity);
        /// <summary>
        /// Gets the record of type <typeparamref name="T"/> specified by the ID.
        /// </summary>
        /// <param name="id">ID of the record.</param>
        /// <returns></returns>
        T GetById(Guid id);
        /// <summary>
        /// Gets a list of the records of type <typeparamref name="T"/>.
        /// </summary>
        /// <returns>List of the <typeparamref name="T"/> records, 10 values MAX.</returns>
        IEnumerable<T> GetList(int pageSize = 10, int pageNumber = 1);
        /// <summary>
        /// Updates a record in the database by overwriting it with provided entity.
        /// </summary>
        /// <param name="entity">Modified version of the current record.</param>
        void Update(T entity);
        /// <summary>
        /// Deletes a record in the database specified by the ID.
        /// </summary>
        /// <param name="id">ID of the record to delete.</param>
        void DeleteById(Guid id);
    }
}
