// ReSharper disable VirtualMemberCallInConstructor
namespace TaxiDinamica.Data.Models
{
    using System;
    using System.Collections.Generic;

    using TaxiDinamica.Data.Common.Models;

    using Microsoft.AspNetCore.Identity;

    public class ApplicationUser : IdentityUser, IAuditInfo, IDeletableEntity
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Roles = new HashSet<IdentityUserRole<string>>();
            this.Claims = new HashSet<IdentityUserClaim<string>>();
            this.Logins = new HashSet<IdentityUserLogin<string>>();
            this.Appointments = new HashSet<Appointment>();
            this.Partners = new HashSet<Partner>();
        }
        // Personal Data
        [PersonalData]
        public string Names { get; set; }

        [PersonalData]
        public string LastNames { get; set; }
        
        [PersonalData]
        public int DocumentId { get; set; }

        // Audit info
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        // Deletable entity
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public int? AmountLogins { get; set; }

        public DateTime? LastLogin { get; set; }

        public virtual ICollection<IdentityUserRole<string>> Roles { get; set; }

        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }

        public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }

        public virtual ICollection<Partner> Partners { get; set; }
    }
}
