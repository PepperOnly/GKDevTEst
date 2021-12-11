namespace API.Repository
{
    /// <summary>
    /// Ensure there is no data on startup of application
    /// </summary>
    public static class DbInitializer
    {
        public static void Initialize(DataContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }
    }
}
