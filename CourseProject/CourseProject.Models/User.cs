using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject.Models
{
    public class User
    {
        private ICollection<Advertisement> savedAds;
        private ICollection<Advertisement> upcomingAds;
        private ICollection<User> followedUsers;

        public User()
        {
            this.savedAds = new HashSet<Advertisement>();
            this.upcomingAds = new HashSet<Advertisement>();
            this.followedUsers = new HashSet<User>();
        }

        public int Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [MinLength(6)]
        [MaxLength(20)]
        public string Username { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string LastName { get; set; }
        
        [Range(12,120)]
        public int? Age { get; set; }

        [Required]
        public string Password { get; set; }

        public virtual ICollection<Advertisement> SavedAds
        {
            get
            {
                return this.savedAds;
            }
            set
            {
                this.savedAds = value;
            }
        }

        public virtual ICollection<Advertisement> UpcomingAds
        {
            get
            {
                return this.upcomingAds;
            }
            set
            {
                this.upcomingAds = value;
            }
        }

        public virtual ICollection<User> FollowedUsers
        {
            get
            {
                return this.followedUsers;
            }
            set
            {
                this.followedUsers = value;
            }
        }
    }
}
