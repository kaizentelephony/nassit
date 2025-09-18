using System.ComponentModel.DataAnnotations;

namespace nassit.Models
{
    public class TBL_ENROLLMENT_Details
    {
        [Key]
        public string? VAR_CALLER_ID { get; set; }
        public DateTime? VAR_CALLED_DATE { get; set; }

        public string? VAR_ENROLL_STATUS { get; set; }

        public string? var_unique_id {  get; set; }
        public string? VAR_BLACK_LIST { get; set; }



    }

}
