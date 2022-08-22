using System.Threading.Tasks;

namespace Wolf.Systems.Core
{
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
#if NET40
            return task.Result;
#elif !NET40
            return task.ConfigureAwait(false).GetAwaiter().GetResult();
#endif
        }
    }
}
