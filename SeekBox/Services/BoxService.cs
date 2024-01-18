using SeekBox.DB;
using SeekBox.DTOs;
using SeekBox.Models;

namespace SeekBox.Services
{

    public class BoxService : IBoxService
    {
        private readonly MsConnect _msConnect;

        public BoxService(MsConnect msConnect)
        {
            _msConnect = msConnect;
        }

        public async Task<object> GetPackage(Guid Number)
        {

            var box = (
             from ep in _msConnect.packages
             join p in _msConnect.statusBox on ep.packageNumber equals p.boxGuid
             where p.boxGuid == Number
             select new
             {
                 ep.packageNumber,
                 ep.dateOfPosting,
                 ep.shippingPointId,
                 ep.destinationCountry,
                 p.EventName,
                 p.DateTime,
                 p.postalUnitId
             });
            return box;
        }
        public bool AddPackage(PackageDto packageDto)
        {
            Package package = new();
            package.shippingPointId = packageDto.shippingPointId;
            package.ClientId = packageDto.ClientId;
            package.packageNumber = Guid.NewGuid();
            package.countryOfOrigin = packageDto.countryOfOrigin;
            package.dimensionsX = packageDto.dimensionsX;
            package.dimensionsY = packageDto.dimensionsY;
            package.dimensionsZ = packageDto.dimensionsZ;
            package.mass = packageDto.mass;
            package.dateOfPosting = DateTime.Now.ToString();
            package.description = packageDto.description;
            package.posId = packageDto.posId;
            _msConnect.packages.Add(package);
            _msConnect.SaveChanges();
            return true;
        }
        public bool RemovePackage(Guid packageNumber)
        {

            var result = _msConnect.Remove(packageNumber);
            if (result is null)
            {
                return false;
            }
            _msConnect.SaveChanges(false);
            return true;
        }
        public bool AddEventBox(StatusBoxDto statusBoxDto)
        {
            var isBox = _msConnect.packages.Where(f => f.packageNumber == statusBoxDto.boxGuid).FirstOrDefault();
            if (isBox is not null)
            {
                StatusBox statusBox = new();
                statusBox.boxGuid = statusBoxDto.boxGuid;
                statusBox.EventName = statusBoxDto.EventName;
                statusBox.DateTime = DateTime.Now;
                statusBox.postalUnitId = statusBoxDto.postalUnitId;
                _msConnect.statusBox.Add(statusBox);
                _msConnect.SaveChanges();
                return true;
            }
            throw new Exception($"No Package on this {statusBoxDto.boxGuid} in DB");
        }
    }
}
