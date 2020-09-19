using System.Linq;

namespace KK.Cookbook.Helpers.Extensions
{
    public static class IQueryableExtension
    {
        private const int PAGE_SIZE = 10;

        /// <summary>
        /// Gets a certain amount of values, specified by the input integer. By default, gets the first page
        /// of values, containing 10 elements.
        /// </summary>
        /// <typeparam name="T">Entity type.</typeparam>
        /// <param name="list">List to be paged.</param>
        /// <param name="pageNumber">Number of the page to show.</param>
        /// <returns><see cref="IQueryable{T}"/> list, paged.</returns>
        public static IQueryable<T> Paged<T>(this IQueryable<T> list, int pageNumber = 1)
        {
            return list
                .Skip((pageNumber - 1) * PAGE_SIZE)
                .Take(PAGE_SIZE);
        }
    }
}
