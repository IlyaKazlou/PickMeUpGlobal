﻿using System.Data.Entity.ModelConfiguration;
using PickMeAppGlobal.Core;

namespace PickMeAppGlobal.Data.Mapping
{
  internal class UserMapConfiguration : EntityTypeConfiguration<User>
  {
    public UserMapConfiguration()
    {
      this.ToTable("Users").HasKey(m => m.Id);
      this.Property(m => m.UserName).HasMaxLength(50);

      this.HasMany(m => m.Points).WithRequired(m => m.User).HasForeignKey(m => m.UserId);

      this.HasMany(m => m.UserGroupInfos).WithRequired(m => m.User).HasForeignKey(m => m.UserId);
    }
  }
}