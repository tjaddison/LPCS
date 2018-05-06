using System;
using System.Collections.Generic;

namespace LPCS.Server.Providers.DomainModels
{
    public class ProfileModel
    {
        public string ID { get; set; }     
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public bool? IsActive { get; set; }
        public bool? SendHtmlEmail { get; set; }
        public string TitleType { get; set; }
        public SupervisorProfile Supervisor { get; set; }
    }

    public class SupervisorProfile
    {
        public string Website { get; set; }
        public string BusinessName { get; set; }
        public bool? UseBusinessNameForListing { get; set; }
        public bool? IsActive { get; set; }
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
        public ICollection<AddressModel> Addresses { get; set; }
        public ICollection<LicenseCredentialModel> LicenseCredentials { get; set; }
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

    public class AddressModel
    {
        public bool IsPrivate { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Type { get; set; }
    }

    public class LicenseCredentialModel
    {
        public string IssuedBy { get; set; }
        public string Identifier { get; set; }
        public int? Year { get; set; }
        public string Type { get; set; }
    }
}
