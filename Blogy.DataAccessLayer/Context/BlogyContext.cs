using Blogy.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.DataAccessLayer.Context
{
    public class BlogyContext:IdentityDbContext<AppUser,AppRole,int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-JI387RJ\\SQLEXPRESS;initial catalog=BlogyDb;integrated security=true");
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Message>().HasOne(x => x.SenderUser)
                .WithMany(y => y.SenderUsers)
                .HasForeignKey(z => z.SenderUserId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.Entity<Message>().HasOne(x => x.ReceiverUser)
                .WithMany(y => y.ReceiverUsers)
                .HasForeignKey(z => z.ReceiverUserId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            base.OnModelCreating(builder);
        }


        public DbSet<Category> Categories{ get; set; }
        public DbSet<Article> Articles{ get; set; }
        public DbSet<Comment> Comments{ get; set; }
        public DbSet<Tag> Tags{ get; set; }
        public DbSet<ContactInfo> ContactInfos{ get; set; }
        public DbSet<SendMessage> SendMessages{ get; set; }
        public DbSet<About> Abouts{ get; set; }
        public DbSet<SocialMedia> SocialMedias{ get; set; }
        public DbSet<Message> Messages{ get; set; }
    }
}
