using System;
using System.Collections.Generic;

namespace AssetManagementSystem.Models
{
    public partial class Employee
    {
        public Employee()
        {
            AssetAudits = new HashSet<AssetAudit>();
            AssetBorrowings = new HashSet<AssetBorrowing>();
            AssetServiceRequests = new HashSet<AssetServiceRequest>();
        }

        public int EmployeeId { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Gender { get; set; }
        public string? ContactNumber { get; set; }
        public string? Address { get; set; }
        public string PasswordHash { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<AssetAudit>? AssetAudits { get; set; }
        public virtual ICollection<AssetBorrowing>? AssetBorrowings { get; set; }
        public virtual ICollection<AssetServiceRequest>? AssetServiceRequests { get; set; }
    }
}
