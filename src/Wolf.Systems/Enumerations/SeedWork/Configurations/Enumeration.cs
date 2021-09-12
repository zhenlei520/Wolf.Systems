namespace Wolf.Systems.Enumerations.SeedWork.Configurations;

/// <summary>
///
/// </summary>
/// <typeparam name="T1"></typeparam>
/// <typeparam name="T2"></typeparam>
public abstract class Enumeration<T1, T2> : IComparable
    where T1 : IComparable
    where T2 : IComparable
{
    /// <summary>
    ///
    /// </summary>
    public T1 Id { get; private set; }

    /// <summary>
    ///
    /// </summary>
    public T2 Name { get; private set; }

    /// <summary>
    ///
    /// </summary>
    public Enumeration()
    {

    }
    /// <summary>
    ///
    /// </summary>
    /// <param name="id"></param>
    /// <param name="name"></param>
    protected Enumeration(T1 id, T2 name)
    {
        Id = id;
        Name = name;
    }

    /// <summary>
    ///
    /// </summary>
    /// <returns></returns>
    public override string ToString() => Name?.ToString() ?? string.Empty;

    /// <summary>
    /// 得到所有的
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static IEnumerable<T> GetAll<T>() where T : Enumeration<T1, T2>
    {
        var fields = typeof(T).GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly);

        return fields.Select(f => f.GetValue(null)).Cast<T>();
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public override bool Equals(object obj)
    {
        var otherValue = obj as Enumeration<T1, T2>;

        if (otherValue == null)
            return false;

        var typeMatches = GetType() == obj.GetType();
        var valueMatches = Id.Equals(otherValue.Id);

        return typeMatches && valueMatches;
    }

    /// <summary>
    /// 得到HashCode
    /// </summary>
    /// <returns></returns>
    public override int GetHashCode() => GetHashCode(Id.ToString());

    /// <summary>
    /// 根据值获取对象
    /// </summary>
    /// <param name="value"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static T FromValue<T>(T1 value) where T : Enumeration<T1, T2>
    {
        var matchingItem = Parse<T, T1>(value, "value", item => item.Id.Equals(value));
        return matchingItem;
    }

    /// <summary>
    /// 根据描述获取对象
    /// </summary>
    /// <param name="displayName"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static T FromDisplayName<T>(string displayName) where T : Enumeration<T1, T2>
    {
        var matchingItem = Parse<T, string>(displayName, "display name", item => item.Name.Equals(displayName));
        return matchingItem;
    }

    private static T Parse<T, TK>(TK value, string description, Func<T, bool> predicate)
        where T : Enumeration<T1, T2>
    {
        var matchingItem = GetAll<T>().FirstOrDefault(predicate);
        return matchingItem;
    }

    /// <summary>
    /// 比较
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public int CompareTo(object other) => Id.CompareTo(((Enumeration<T1, T2>)other).Id);

    #region 重写HashCode方法

    /// <summary>
    /// 重写HashCode方法
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    internal static int GetHashCode(string str)
    {
        unchecked
        {
            int hash1 = (5381 << 16) + 5381;
            int hash2 = hash1;

            for (int i = 0; i < str.Length; i += 2)
            {
                hash1 = ((hash1 << 5) + hash1) ^ str[i];
                if (i == str.Length - 1)
                    break;
                hash2 = ((hash2 << 5) + hash2) ^ str[i + 1];
            }

            return hash1 + (hash2 * 1566083941);
        }
    }

    #endregion
}
