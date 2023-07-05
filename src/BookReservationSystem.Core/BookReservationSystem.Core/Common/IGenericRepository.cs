﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReservationSystem.Core.Common
{
    /// <summary>
    /// Generic repository interface to implement repository pattern
    /// </summary>
    /// <typeparam name="T">Generic T type</typeparam>
    public interface IGenericRepository<T> where T : EntityBase
    {
        /// <summary>
        /// Get all generic objects of type T asynchronously
        /// </summary>
        /// <returns>Returns all generic objects of type T</returns>
        Task<IReadOnlyList<T>> GetAllAsync();

        /// <summary>
        /// Get generic object of type T by Id asynchronously
        /// </summary>
        /// <param name="id">Id of object needed to be returned</param>
        /// <returns>Returns object with specified Id if found</returns>
        Task<T> GetByIdAsync(int id);

        /// <summary>
        /// Adds the passed T type object to a collection asynchronously
        /// </summary>
        /// <param name="entity">T type object to be added to a collection</param>
        /// <returns>Returns added T type object to a collection</returns>
        Task<T> AddAsync(T entity);

        /// <summary>
        /// Deletes passed T type object from a collection asynchronously
        /// </summary>
        /// <param name="entity">T type object to be deleted from a collection</param>
        /// <returns>Returns whether T type object has been successfully deleted from a collection</returns>
        Task<bool> DeleteAsync(T entity);

        /// <summary>
        /// Updates passed T type object in a collection asynchronously
        /// </summary>
        /// <param name="entity">T type object to be updated in a collection</param>
        /// <returns>Returns updated T object</returns>
        Task<T> UpdateAsync(T entity);

        /// <summary>
        /// Adds the passed T type object to a collection
        /// </summary>
        /// <param name="entity">T type object to be added to a collection</param>
        void Add(T entity);

        /// <summary>
        /// Updates passed T type object in a collection
        /// </summary>
        /// <param name="entity">T type object to be updated in a collection</param>
        void Update(T entity);

        /// <summary>
        /// Deletes passed T type object from a collection
        /// </summary>
        /// <param name="entity">T type object to be deleted from a collection</param>
        void Delete(T entity);
    }
}
