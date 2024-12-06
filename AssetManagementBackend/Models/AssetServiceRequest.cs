using System;
using System.Collections.Generic;

namespace AssetManagementSystem.Models
{
    public partial class AssetServiceRequest
    {
        public int RequestId { get; set; }
        public int? AssetId { get; set; }
        public int? EmployeeId { get; set; }
        public string? IssueType { get; set; }
        public string? Description { get; set; }
        public DateTime? RequestDate { get; set; }
        public string? Status { get; set; }

        public virtual Asset? Asset { get; set; }
        public virtual Employee? Employee { get; set; }
    }
}
