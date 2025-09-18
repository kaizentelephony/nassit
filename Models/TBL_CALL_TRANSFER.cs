using System;
using System.ComponentModel.DataAnnotations;

namespace nassit.Models
{
    public class TBL_CALL_TRANSFER
    {
        [Key]
        public int VAR_SNO { get; set; }

        public DateTime? VAR_CALLED_DATE { get; set; }

        public string? VAR_CALLER_ID { get; set; }

        public string? VAR_UNIQUE_ID { get; set; }

        public DateTime? VAR_PATCH_START_TIME { get; set; }

        public DateTime? VAR_PATCH_END_TIME { get; set; }

        public string? VAR_PATCH_DURATION { get; set; }

        public string? VAR_IVR_DISCONNECT_TRACE { get; set; }

        public string? VAR_TRANSFERVDN { get; set; }

        public string? VAR_PATCH_CHANNEL_ID { get; set; }

        public string? VAR_TRANSFERSTATUS { get; set; }

        public string? VAR_RECORDINGPATH { get; set; }

        public string? VAR_FLOW { get; set; }

        public string? VAR_STATUS { get; set; }
    }
}
