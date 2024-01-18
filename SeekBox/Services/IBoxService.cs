using SeekBox.DTOs;

namespace SeekBox.Services
{
    public interface IBoxService
    {
        bool AddEventBox(StatusBoxDto statusBoxDto);
        bool AddPackage(PackageDto packageDto);
        Task<object> GetPackage(Guid Number);
        bool RemovePackage(Guid packageNumber);
    }
}