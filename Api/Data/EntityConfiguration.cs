using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    class EntityConfiguration
    {
        public static void InformationConfiguration(ModelBuilder builder)
        {
            builder.Entity<DbInformation>()
                .HasOne(i => i.Place)
                .WithMany(p => p.Informations)
                .OnDelete(DeleteBehavior.Cascade)
                .HasForeignKey(i => i.PlaceId);
        }
    }

}