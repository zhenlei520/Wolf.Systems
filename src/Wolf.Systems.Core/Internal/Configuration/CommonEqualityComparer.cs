// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Wolf.Systems.Core.Internal.Configuration;

/// <summary>
///
/// </summary>
/// <typeparam name="T"></typeparam>
/// <typeparam name="TV"></typeparam>
internal class CommonEqualityComparer<T, TV> : IEqualityComparer<T>
{
    private readonly Func<T, TV> _keySelector;
    private readonly IEqualityComparer<TV> _comparer;

    /// <summary>
    ///
    /// </summary>
    /// <param name="keySelector"></param>
    /// <param name="comparer"></param>
    public CommonEqualityComparer(Func<T, TV> keySelector, IEqualityComparer<TV> comparer)
    {
        this._keySelector = keySelector;
        this._comparer = comparer;
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="keySelector"></param>
    public CommonEqualityComparer(Func<T, TV> keySelector)
        : this(keySelector, EqualityComparer<TV>.Default)
    {
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    public bool Equals(T x, T y) => _comparer.Equals(_keySelector(x), _keySelector(y));

    /// <summary>
    ///
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public int GetHashCode(T obj) => _comparer.GetHashCode(_keySelector(obj));
}
