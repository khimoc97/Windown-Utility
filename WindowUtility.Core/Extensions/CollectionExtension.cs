using System.Collections.ObjectModel;

namespace WindowUtility.Core.Extensions
{
    public static class CollectionExtension
    {
        public static ObservableCollection<T> AsObservableCollection<T>(this IEnumerable<T> collection)
        {
            return new ObservableCollection<T>(collection);
        }
    }
}
