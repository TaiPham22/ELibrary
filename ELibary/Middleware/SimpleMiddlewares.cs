using Microsoft.AspNetCore.Http;
namespace ELibary.Middleware
{
    public class SimpleMiddlewares
    {
        public void Invoke( HttpContext context)
        {
            context.Response.WriteAsync(text: "<div> He thong bao tri</div>");

        }
    }
}
