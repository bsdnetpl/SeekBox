using SeekBox.DB;
using SeekBox.DTOs;
using SeekBox.Models;

namespace SeekBox.Services
{
    public class UserService : IUserService
    {
        private readonly MsConnect _msConnect;

        public UserService(MsConnect msConnect)
        {
            _msConnect = msConnect;
        }
        public async Task<bool> AddUser(ClientDto clientDto)
        {
            Client client = new();
            client.State = clientDto.State;
            client.Street = clientDto.Street;
            client.City = clientDto.City;
            client.Country = clientDto.Country;
            client.Phone = clientDto.Phone;
            client.PostalCode = clientDto.PostalCode;
            client.Description = clientDto.Description;
            client.email = clientDto.email;
            client.Name = clientDto.Name;
            await _msConnect.clients.AddAsync(client);
            await _msConnect.SaveChangesAsync();
            return true;
        }
        public Client SeekClient(string Name)
        {
            var client = _msConnect.clients.Where(x => x.Name == Name).FirstOrDefault();
            if (client == null)
            {
                throw new Exception("No user in DB");
            }
            return client;
        }
        public async Task<Client> EditClient(ClientDto clientDto, int id)
        {
            var ClientToEdit = _msConnect.clients.Find(id);
            if (ClientToEdit != null)
            {
                Client client = new();
                client.State = clientDto.State;
                client.Street = clientDto.Street;
                client.City = clientDto.City;
                client.Country = clientDto.Country;
                client.Phone = clientDto.Phone;
                client.PostalCode = clientDto.PostalCode;
                client.Description = clientDto.Description;
                client.email = clientDto.email;
                client.Name = clientDto.Name;
                await _msConnect.SaveChangesAsync();
                return client;
            }
            throw new Exception("No user in DB");
        }
        public async Task<bool> DeleteUser(int id)
        {
            var clientToDel = _msConnect.clients.Find(id);
            if (clientToDel is not null)
            {
                _msConnect.clients.Remove(clientToDel);
                await _msConnect.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
