using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PrototypeAdal5.Models.ReleaseViewModels
{
    public class SubmissionDateGroup
    {
        [DataType(DataType.Date)]
        public DateTime? SubmissionDate { get; set; }

        public int ReleaseCount { get; set; }

    }
}
