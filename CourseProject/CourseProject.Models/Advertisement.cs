using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject.Models
{
    public class Advertisement
    {
        private ICollection<User> usersSaved;
        private ICollection<User> usersReserved;
        
        public Advertisement()
        {
            this.usersSaved = new HashSet<User>();
            this.usersReserved = new HashSet<User>();
        }

        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string Name { get; set; }
        
        [Required]
        [Range(0, 1000)]
        public decimal Price { get; set; }

        [Required]
        [Range(0, 1000)]
        public int Places { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(500)]
        public string Description { get; set; }

        public string ImagePath { get; set; }

        public string SellerId { get; set; }
        public virtual User Seller { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public int CityId { get; set; }
        public virtual City City { get; set; }

        public virtual ICollection<User> UsersSaved
        {
            get
            {
                return this.usersSaved;
            }
            set
            {
                this.usersSaved = value;
            }
        }

        public virtual ICollection<User> UsersReserved
        {
            get
            {
                return this.usersReserved;
            }
            set
            {
                this.usersReserved = value;
            }
        }
    }
}
