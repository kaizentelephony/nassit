using System;
using System.ComponentModel.DataAnnotations;

namespace nassit.Models
{
    public class TBL_CALLDETAILS
    {
        [Key]
        public int VAR_SNO { get; set; }

        public DateTime? VAR_CALLED_DATE { get; set; }

        public string? VAR_UNIQUE_ID { get; set; }

        public string? VAR_CALLER_ID { get; set; }

        public DateTime? VAR_IVR_START_TIME { get; set; }

        public DateTime? VAR_IVR_END_TIME { get; set; }

        public string? VAR_DURATION { get; set; }

        public string? VAR_IVR_DISCONNECT_TREE { get; set; }

        public string? VAR_IVR_DISCONNECT_TRACE { get; set; }

        public string? VAR_DNIS { get; set; }

        public string? VAR_CHANNEL_ID { get; set; }

        public string? VAR_REGISTEREDSTATUS { get; set; }

        public string? VAR_RMNIN_STATUS { get; set; }

        public string? VAR_BLACK_LIST { get; set; }

        public string? VAR_ENROLL_STATUS { get; set; }

        public string? VAR_CALL_TYPE { get; set; }

        public string? VAR_STATUS { get; set; }
    }
}
