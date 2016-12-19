using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Misho.Collections
{
    /// <summary>
    /// ArrayList class for Java compatibility
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ArrayList<T> : List<T>
    {
        /// <summary>
        /// Initializes a new instance of the ArrayList
        /// </summary>
        public ArrayList()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the ArrayList and filling with IEnumerable
        /// </summary>
        /// <param name="collection"></param>
        public ArrayList(IEnumerable<T> collection)
            : base(collection)
        { }

        /// <summary>
        /// Initializes a new instance of the ArrayList class that
        /// is empty and has the specified initial capacity.
        /// </summary>
        /// <param name="capacity"></param>
        public ArrayList(int capacity)
            : base(capacity)
        { }

        /// <summary>
        /// Initializes a new instance of the ArrayList and filling with List
        /// </summary>
        /// <param name="list"></param>
        public ArrayList(List<T> list)
            : this(list as IEnumerable<T>)
        { }

        /// <summary>
        /// Convert to classic List
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public List<T> ToList()
        {
            return new List<T>(this as IEnumerable<T>);
        }
    }
}