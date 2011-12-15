//-------------------------------------------------------------------------------
// <copyright file="DatabaseContext.cs" company="KriaSoft, LLC">
//   Copyright (c) 2011 Konstantin Tarkus, KriaSoft LLC
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//       http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
// </copyright>
//-------------------------------------------------------------------------------

namespace System.Data.Entity.SchemaCompare.Model
{
    using System.Data.Entity.Infrastructure;
    using System.Data.Objects;

    /// <summary>
    /// Represents a database context.
    /// </summary>
    public class DatabaseContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Data.Entity.SchemaCompare.Model.DatabaseContext"/> class.
        /// </summary>
        /// <param name="connection">An existing connection to use for the new context.</param>
        public DatabaseContext(Common.DbConnection connection)
            : base(connection, true)
        {
        }

        /// <summary>
        /// Gets or sets a list of database tables.
        /// </summary>
        public DbSet<Table> Tables { get; set; }

        /// <summary>
        /// Gets or sets a list of database columns.
        /// </summary>
        public DbSet<Column> Columns { get; set; }

        /// <summary>
        /// Gets the object context.
        /// </summary>
        public ObjectContext ObjectContext
        {
            get { return ((IObjectContextAdapter)this).ObjectContext; }
        }

        /// <summary>
        /// Configures and customizes the model for the context being created.
        /// </summary>
        /// <param name="modelBuilder">The builder that defines the model for the context being created.</param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<IncludeMetadataConvention>();
        }
    }
}
