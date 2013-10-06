using System;
using System.Collections.Generic;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventsSystem.Models
{
    // You can add profile data for the user by adding more properties to your User class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : User
    {
        public ApplicationUser()
            :this("")
        {
        }

        public ApplicationUser(string userName)
            :base(userName)
        {
            this.Events = new HashSet<Event>();
        }

        public byte[] ProfilePicture { get; set; }

        public bool IsDeleted { get; set; }

        [InverseProperty("Participants")]
        public virtual ICollection<Event> Events { get; set; }

        [InverseProperty("Creator")]
        public virtual ICollection<Event> OwnEvents { get; set; }

        [InverseProperty("Sender")]
        public virtual ICollection<Invite> SentInvites { get; set; }

        [InverseProperty("Recipient")]
        public virtual ICollection<Invite> ReceivedInvites { get; set; }
    }

    public class Event
    {
        public Event()
        {
            this.Participants = new HashSet<ApplicationUser>();
        }

        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required,MinLength(6),MaxLength(200)]
        public string Title { get; set; }

        public string Description { get; set; }

        [MaxLength(200)]
        public string Location { get; set; }

        [DataType(DataType.Date, ErrorMessage="The date format is invalid")]
        [Required, Range(typeof(DateTime), "1/9/2013", "1/1/2020")]
        public DateTime EventDate { get; set; }

        [ScaffoldColumn(false)]
        //public string CreatorId { get; set; }
        public virtual ApplicationUser Creator { get; set; }
        public virtual ICollection<ApplicationUser> Participants { get; set; }

    }

    public class Invite
    {
        [Key]
        public int Id { get; set; }

        //[Required]
        public virtual ApplicationUser Sender { get; set; }

        [Required]
        public virtual Event Event { get; set; }

        //[Required]
        public virtual ApplicationUser Recipient { get; set; }

        //[Required]
        public virtual Status InviteStatus {get;set;}

        [MinLength(50), MaxLength(200)]
        public string Message { get; set; }

        //[Required]
        public DateTime CreatedDate { get; set; }

    }

    public class Status
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string InviteStatus { get; set; }
    }


    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, UserClaim, UserSecret, UserLogin, Role, UserRole, Token, UserManagement>
    {
        public ApplicationDbContext()
            : base("EventsSystemEntities")
        {
        }

        public DbSet<Event> Events { get; set; }
        public DbSet<Invite> Invites { get; set; }
        public DbSet<Status> Status { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>().HasKey(x => x.Id);
            modelBuilder.Entity<Event>().Property(x => x.Title).IsUnicode(true);
            modelBuilder.Entity<Event>().Property(x => x.Description).IsUnicode(true);
            modelBuilder.Entity<ApplicationUser>().Property(x => x.IsDeleted).IsOptional();
            modelBuilder.Entity<Invite>().Property(x => x.Message).IsOptional();
            modelBuilder.Entity<Invite>().Property(x => x.Message).IsUnicode(true);
            modelBuilder.Entity<Status>().Property(x => x.InviteStatus).IsUnicode(true);
            //modelBuilder.Entity<Event>().Property(x => x.Title).HasMaxLength(255);
            //modelBuilder.Entity<Event>().Property(x => x.Title).IsRequired();
            //modelBuilder.Entity<Event>().Property(x=> x.Title).

            //// modelBuilder.Configurations.Add(new TagMappings());
        }
    }
}