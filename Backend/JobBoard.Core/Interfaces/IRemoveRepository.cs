namespace JobBoard.Core.Interfaces
{
    using System.Collections.Generic;

    public interface IRemoveRepository<T> where T : class
    {
        /// <summary>
        /// Remove as logic level
        /// </summary>
        /// <param name="t"></param>
        void Remove(T t);

        /// Remove collection as logic level
        void Remove(IEnumerable<T> t);
    }
}