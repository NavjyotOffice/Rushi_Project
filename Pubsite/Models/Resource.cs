using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using System.Runtime.Serialization;
using System.Web;

namespace Pubsite.Models
{
    public enum ResourceType { Whitepaper, Video, Infographics, blog }
    public partial class Resource
    {
        [Key]
        public int ResourcesID { get; set; }

        [StringLength(1000)]
        public string ResourceFile { get; set; }

        public int? ContentID { get; set; }

        public virtual ContentDetail ContentDetail { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime DateTime { get; set; }

        [NotMapped]
        public HttpPostedFileBase Upload { get; set; }
        public string ResourceType
        {
            get
            {
                return this.R_Type.ToString();
            }
            set
            {
                R_Type = value.ParseEnum<ResourceType>();
            }
        }

        [NotMapped]
        public ResourceType R_Type { get; set; }
    }
}
