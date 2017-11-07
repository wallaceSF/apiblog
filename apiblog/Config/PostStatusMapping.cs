using apiblog.Entities;

namespace apiblog.Config
{
    public class PostStatusMapping : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<PostStatus>
    {
        public PostStatusMapping()
        {
            ToTable("post_status", "dbo");
            HasKey(p => p.IdPostStatus);
            Property(p => p.IdPostStatus).HasColumnName("idpost_status");
            Property(p => p.Status).HasColumnName("status");            
        }
    }
}