using SeekBox.DTOs;
using SeekBox.Models;

namespace SeekBox.Services
{
    public interface IUserService
    {
        Task<bool> AddUser(ClientDto clientDto);
        Task<bool> DeleteUser(int id);
        Task<Client> EditClient(ClientDto clientDto, int id);
        Client SeekClient(string Name);
    }
}