using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace HelpI.API.SeedWork.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void ApplySnakeCaseNamingConvention(this ModelBuilder builder)
        {
            foreach (var entity in builder.Model.GetEntityTypes())
            {
                foreach (var key in entity.GetKeys())
                    key.SetName(key.GetName().ToSnakeCase());

                foreach (var foreignKey in entity.GetForeignKeys())
                    foreignKey.SetConstraintName(foreignKey.GetConstraintName().ToSnakeCase());
                
                foreach (var property in entity.GetProperties())
                {
                    var tableIdentifier = StoreObjectIdentifier.Table(entity.GetTableName(), null);
                    property.SetColumnName(property.GetColumnName(tableIdentifier).ToSnakeCase());
                }
                foreach (var index in entity.GetIndexes())
                    index.SetDatabaseName(index.GetDatabaseName().ToSnakeCase());
                
                entity.SetTableName(entity.GetTableName().ToSnakeCase());
            }
        }
    }
}
