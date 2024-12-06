using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AssetManagementSystem.Models
{
    public partial class AssetBorrowing
    {
        public int BorrowId { get; set; }
        public int? EmployeeId { get; set; }
        public int? AssetId { get; set; }
        public DateTime? BorrowDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public string? Status { get; set; }
        [JsonIgnore]
        public virtual Asset? Asset { get; set; }
        public virtual Employee? Employee { get; set; }
    }
}
