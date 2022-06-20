using System.Text.Json;

namespace MyCoffeeShop.StorageApp.Entities
{
    public static class EntityExtensions
    {
        public static T? Copy<T>(this T itemToCopy) where T : IEntity
        {
            // creating json string from an object.
            var json = JsonSerializer.Serialize<T>(itemToCopy);
            return JsonSerializer.Deserialize<T>(json);

        }
    }
}
