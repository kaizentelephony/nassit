using System;
using System.ComponentModel.DataAnnotations;

namespace nassit.Models
{
    public class TBL_ENROLLMENT
    {
        [Key]
        public int VAR_SNO { get; set; }   // Primary Key

        public DateTime? VAR_CALLED_DATE { get; set; }

        public string? VAR_CALLER_ID { get; set; }

        public string? VAR_UNIQUE_ID { get; set; }

        public string? VAR_ENROLL_STATUS { get; set; }

        public string? VAR_FILEPATH { get; set; }
    }
}
