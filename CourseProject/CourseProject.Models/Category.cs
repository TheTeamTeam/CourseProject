using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject.Models
{
    public class Category
    {
        private ICollection<Advertisement> advertisements;

        public Category()
        {
            this.advertisements = new HashSet<Advertisement>();
        }

        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string Name { get; set; }

        public virtual ICollection<Advertisement> Advertisements
        {
            get
            {
                return this.advertisements;
            }
            set
            {
                this.advertisements = value;
            }
        }
    }
}
