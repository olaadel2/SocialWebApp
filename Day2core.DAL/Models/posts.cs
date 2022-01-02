using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Day2core.DAL.Models
{
    public class post
    {
        
        public int id { get; set; }
        //[Required]
        //[StringLength(100, ErrorMessage = "The title must be at least 6 characters.", MinimumLength = 6)]
        public string title { get; set; }
        public string bref { get; set; }
        public string desc { get; set; }
        public DateTime date { get; set; }
        [ForeignKey("Blog")]
        public int? blog_id { get; set; }
        public virtual blog Blog { get; set; }
        [ForeignKey("Group")]
        public int? group_id { get; set; }
        public virtual group Group { get; set; }
        [ForeignKey("ApplicationUser")]
        public string user_Id { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public byte[] image { get; set; }
        public string ProfilePicture { get; set; }


    }
}
