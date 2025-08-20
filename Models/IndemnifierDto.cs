using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace casman_WEBAPI.Models
{
    public class IndemnifierDto
    {

        [Key]
        [Column("def_org")]
        public string DefOrg { get; set; }


        [Column("def_org_name")]
        public string DefOrgName { get; set; }

        [Column("valid")]
        public string Valid { get; set; }   
    }
}
