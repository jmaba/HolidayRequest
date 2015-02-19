namespace Domain.Storage
{
    public static class StorageLocator
    {
        private static IRepository repository;

        public static IRepository Get()
        {
            return repository ?? (repository = new EntityFrameworkRepository());
        }

        public static void Set(IRepository newRepository)
        {
            repository = newRepository;
        }
    }
}