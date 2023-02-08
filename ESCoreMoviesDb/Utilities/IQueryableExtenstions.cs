namespace ESCoreMovies.Utilities
{
    public static class IQueryableExtenstions
    {
        public static IQueryable<T> Paginate<T>(this IQueryable<T> source, int page, int recordsToTake)
        {
            return source.Skip(page - 1).Take(recordsToTake);
        }
    }
}
