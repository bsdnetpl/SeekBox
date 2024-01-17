using SeekBox.DB;
using SeekBox.DTOs;
using SeekBox.Models;

namespace SeekBox.Services
{
    
    public class BoxService
    {
        private readonly MsConnect _msConnect;

        public BoxService(MsConnect msConnect)
        {
            _msConnect = msConnect;
        }

        public Package GetPackage(Guid Number)
        {
            var Box = _msConnect.packages.Where( f => f.packageNumber == Number).FirstOrDefault();
            return Box;
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
        public bool RemoveBox(Guid packageNumber)
        {
            
            var result = _msConnect.Remove(packageNumber);
            if(result is null)
            {
                return false;
            }
            _msConnect.SaveChanges(false);
            return true;
        }

    }
}
