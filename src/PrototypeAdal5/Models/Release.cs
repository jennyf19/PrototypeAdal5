using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrototypeAdal5.Models
{
    public enum ApprovalStatus

    {
        Pending, Approved, Denied
    }

    public class Release
    {
        public int ID { get; set; }

        [Required]
        public string ProductName { get; set; }

        [Required]
        [RegularExpression(@"^v[1-9]{1,2}\.([0-9]{1,2}\.)([0-9]{1,3})$", ErrorMessage = "The version number must be in the following format: v0.00.00")]
        [Display(Name = "Version Number")]
        public string VersionNumber { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Release Notes")]
        public string ReleaseNotes { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Submission Date")]
        public DateTime SubmissionDate { get; set; }

        [DisplayFormat(NullDisplayText = "No Status")]
        [Display(Name = "Approval Status")]
        public ApprovalStatus? ApprovalStatus { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Enter a name less than 50 characters")]
        [Display(Name = "Approved by")]
        public string ApprovedBy { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date Approved")]
        public DateTime ApprovedDate { get; set; }
    }
}
