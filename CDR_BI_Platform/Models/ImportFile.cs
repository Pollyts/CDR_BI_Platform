using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CDR_BI_Platform.Models
{
    public class ImportFile : IEntityDb
    {
        public int Id { get; set; }
        public byte[] DataFS { get; set; }
    }
}
