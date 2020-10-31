using System.Linq;

namespace KitBook.Helpers.Extensions
{
    public static class IQueryableExtensions
    {
        /// <summary>
        /// Gets a certain amount of values, specified by the input integer. By default, gets the first page
        /// of values, containing 10 elements.
        /// </summary>
        /// <typeparam name="T">Entity type.</typeparam>
        /// <param name="list">List of records to be paged.</param>
        /// <param name="amount">How many records to take.</param>
        /// <param name="pageNumber">Which page to get.</param>
        /// <returns>A new query with amount of values specified by the <paramref name="amount"/> input variable.</returns>
        public static IQueryable<T> Paged<T>(this IQueryable<T> list, int amount = 10, int pageNumber = 1)
        {
            return list
                .Skip((pageNumber - 1) * amount)
                .Take(amount);
        }
    }
}
