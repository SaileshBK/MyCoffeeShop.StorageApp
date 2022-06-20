namespace MyCoffeeShop.StorageApp.Repositories
{
    public static class RepositoryExtension
    {
        // This AddBatch method allows to add arrays of employees and also organization to the repositories.
        // here static means it only contains static members.
        // this key word before the first parameter tells that AddBatch an extension method for IWriteRepositories<T>
        public static void AddBatch<T>(this IWriteRepositories<T> repositories, T[] items)
        {
            foreach (var item in items)
            {
                repositories.Add(item);


            }
            repositories.Save();

        }
    }
}
