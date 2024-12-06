using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AssetManagementSystem.Models
{
    public partial class Asset
    {
        public Asset()
        {
            AssetAudits = new HashSet<AssetAudit>();
            AssetBorrowings = new HashSet<AssetBorrowing>();
            AssetServiceRequests = new HashSet<AssetServiceRequest>();
        }

        public int AssetId { get; set; }
        public string AssetName { get; set; } = null!;
        public string? AssetCategory { get; set; }
        public string? AssetModel { get; set; }
        public DateTime? ManufacturingDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public decimal? AssetValue { get; set; }
        public string? Status { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<AssetAudit>? AssetAudits { get; set; }
        [JsonIgnore]
        public virtual ICollection<AssetBorrowing>? AssetBorrowings { get; set; }
        public virtual ICollection<AssetServiceRequest>? AssetServiceRequests { get; set; }
    }
}
