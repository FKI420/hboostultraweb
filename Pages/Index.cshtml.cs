using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace HBoostUltra.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            // Aquí puedes inicializar datos si quieres pasar algo al HTML.
            // Por ejemplo, podrías cargar configuraciones desde la base de datos.
        }
    }
}
