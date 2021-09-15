namespace Wolf.Systems.Core;

/// <summary>
/// Task扩展
/// </summary>
public partial class Extensions
{
    /// <summary>
    /// 得到同步结果
    /// </summary>
    /// <returns></returns>
    public static TResult GetResultSync<TResult>(this Task<TResult> task)
    {
        return task.ConfigureAwait(false).GetAwaiter().GetResult();
    }
}
