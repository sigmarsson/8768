using System;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;

namespace ClassLibrary1
{
    public class Class1
    {
        public Class1()
        {
            var g = new Geolocator();
        }

        public async Task<(double, double)> MyHomeLocation()
        {
            try
            {
                var status = await Geolocator.RequestAccessAsync();

                if (status == GeolocationAccessStatus.Allowed)
                {
                    await Geolocator.RequestAccessAsync();

                    var location = await new Geolocator().GetGeopositionAsync();

                    return (location.Coordinate.Point.Position.Latitude, location.Coordinate.Point.Position.Longitude);
                }
            }
            catch (Exception ex)
            {
            }

            return (0D,0D);
        }
    }

}
