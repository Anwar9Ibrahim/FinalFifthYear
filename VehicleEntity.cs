using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

namespace FinalFifthYear
{
    public class VehicleEntity
    {
        public VehicleEntity(Vehicle vehicle )
        {
            Id = Guid.NewGuid();
            CreationDate = DateTime.Now;
            Status = MyEnums.status.Active;
            Speed = (float)vehicle.Speed;
            VehicleType = vehicle.TrackingItem.Type;
            ImageURL = vehicle.ImagePath;
        }
        public Guid Id { get; set; }
        //public DateTime LastUpdateDate { get; set; }
        public DateTime CreationDate { get; set; }
        public string VehicleType { get; set;}
        public float Speed { get; set; }
        public string ImageURL { get; set; }
        public string VehicleColor { get; set; }
        public MyEnums.status Status { get; set; }
    }
}
