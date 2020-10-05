using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SpecificationPatternExample.Data.Models.ModelConfigs
{
    public class UserModelConfig : IEntityTypeConfiguration<UserModel>
    {
        public void Configure(EntityTypeBuilder<UserModel> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(m => m.Id);

            builder.Property(m => m.Name).IsRequired();
            builder.Property(m => m.Age).IsRequired();
            builder.Property(m => m.Height).IsRequired();

            builder.HasIndex(m => m.Height);
            builder.HasIndex(m => m.Age);
        }
    }
}