namespace WebApi.Core.Services
{
    using System.Threading.Tasks;
    using WebApi.Core.Dto;
    using WebApi.Domain;

    public interface IClientService: IServiceBase<Client, ClientDto>
    {
        Task<string> GenerateHeaderAsync(string userName);
    }
}
