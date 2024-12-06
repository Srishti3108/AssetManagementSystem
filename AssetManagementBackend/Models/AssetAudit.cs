using System;
using System.Collections.Generic;

namespace AssetManagementSystem.Models
{
    public partial class AssetAudit
    {
        public int AuditId { get; set; }
        public int? AssetId { get; set; }
        public int? EmployeeId { get; set; }
        public DateTime? AuditDate { get; set; }
        public string? Status { get; set; }

        public virtual Asset? Asset { get; set; }
        public virtual Employee? Employee { get; set; }
    }
}
