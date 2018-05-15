
using System;
using System.Collections.Generic;

namespace LPCS.Server.Data.Mongo.Entities
{
    public class Supervisor
    {
        public string Website { get; set; }
        public string BusinessName { get; set; }
        public bool? UseBusinessNameForListing { get; set; }
        public bool IsActive { get; set; }
        public int? YearStarted { get; set; }
        public string LicenseNumber { get; set; }
        public string[] CredentialInitials { get; set; }
        public string LicenseState { get; set; }
        public DateTime? LicenseExpirationDate { get; set; }
        public bool? UseVideoCounseling { get; set; }
        public string ClientDescription { get; set; }
        public string SpecialtyDescription { get; set; }
        public string UniqueDescription { get; set; }
        public string TwitterUrl { get; set; }
        public string InstagramUrl { get; set; }
        public string LinkedInUrl { get; set; }
        public string FacebookUrl { get; set; }
        public ICollection<Address> Addresses { get; set; }
        public ICollection<LicenseCredential> LicenseCredentials { get; set; }
        public string[] AgeSpecialties { get; set; }
        public string[] Ethnicities { get; set; }
        public string[] Events { get; set; }
        public string[] Languages { get; set; }
        public string[] Modalities { get; set; }
        public string[] Religions { get; set; }
        public string[] SpecialInterests { get; set; }
        public string[] Specialties { get; set; }
        public string[] Treatments { get; set; }
    }
}