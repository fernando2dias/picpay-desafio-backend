namespace PicPaySimplificado.Application.Interfaces
{
    public interface IAuthorizationService
    {
        Task<bool> Authorize();
    }
}
