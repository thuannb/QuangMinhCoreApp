using System.Threading.Tasks;

namespace KBStarCoreApp.Services
{
    public interface IViewRenderService
    {
        /// <summary>
        ///     Render Razor View as String 
        /// </summary>
        /// <param name="viewName"></param>
        /// <param name="model">   </param>
        /// <returns></returns>
        Task<string> RenderToStringAsync(string viewName, object model);
    }
}
