﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RainyManager.Misc
{
    public static class DayZTediratorToolzHelperExtensions
    {
        public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> collection)
        {
            return new ObservableCollection<T>(collection);
        }

        #region IEnumerable Extensions

        public static void AddRange<T>(this ObservableCollection<T> collection, params T[] items)
        {
            foreach (var item in items)
            {
                if (!collection.Contains(item))
                    collection.Add(item);
            }
        }

        public static int DeepCount(this IEnumerable<IEnumerable<object>> collection)
        {
            var count = 0;
            foreach (var IenumCol in collection)
            {
                count += IenumCol.Count();
            }
            return count;
        }

        #endregion

        #region String Extensions

        public static T LoadFromRes<T>(this string value) => (T)Application.Current.Resources[value];

        public static bool In<T>(this object value, params T[] comparisonArray) => comparisonArray.Contains((T)value);

        public static bool NullOrEmpty(this string value) => string.IsNullOrEmpty(value);

        #endregion

        #region LinqExtensions

        public static IEnumerable<TSource> LocalDistinctBy<TSource, TKey>
            (this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            HashSet<TKey> seenKeys = new();
            foreach (TSource element in source)
            {
                if (seenKeys.Add(keySelector(element)))
                {
                    yield return element;
                }
            }
        }

        #endregion

        #region Reflection Extensions

        public static List<Type> GetTypesAssignableFrom<T1, T2>(this Assembly assembly)
        {
            return assembly.GetTypesAssignableFrom(typeof(T1), typeof(T2));
        }

        public static List<Type> GetTypesAssignableFrom(this Assembly assembly, Type compareType, Type excludeType)
        {
            List<Type> ret = new List<Type>();
            foreach (var type in assembly.DefinedTypes)
            {
                if (compareType.IsAssignableFrom(type) && compareType != type && excludeType != type)
                {
                    ret.Add(type);
                }
            }
            return ret;
        }


        #endregion
    }
}
