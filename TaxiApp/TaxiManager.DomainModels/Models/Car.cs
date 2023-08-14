using TaxiManager.DomainModels.Enums;

namespace TaxiManager.DomainModels.Models
{
    public class Car : BaseEntity
    {
        public Car()
        {
            
        }

        public Car(string model , string licensePlate , DateTime licensePlateExpieryDate)
        {
            Model = model;
            LicensePlate = licensePlate;
            LicensePlateExpieryDate = licensePlateExpieryDate;
            AssignedDrivers = new List<Driver>();
        }

        public string Model { get; set; }
        public string LicensePlate { get; set; }
        public DateTime LicensePlateExpieryDate { get; set; }
        public List<Driver> AssignedDrivers { get; set; }


        public ExpieryStatus IsLicenseExpired()
        {
            if (DateTime.Today >= LicensePlateExpieryDate)
                return ExpieryStatus.Expired;
            else if (DateTime.Today.AddMonths(3) >= LicensePlateExpieryDate)
                return ExpieryStatus.Warning;
            return ExpieryStatus.Valid;
        }

        public override string Print()
        {
            int assignedPercent = AssignedDrivers.Count == 0 ? 0 : AssignedDrivers.Count / 3 * 100;
            return $"{Model} with License Plate {LicensePlate} and utilized {string.Format("0:P" , assignedPercent)}";
        }
    }
}
