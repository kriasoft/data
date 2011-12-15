//-------------------------------------------------------------------------------
// <copyright file="CheckCompatibilityWithModel.cs" company="KriaSoft, LLC">
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

namespace System.Data.Entity
{
    using System.Data.Entity.SchemaCompare.Infrastructure;
    using System.Linq;
    using System.Transactions;

    /// <summary>
    /// An implementation of <see cref="T:IDatabaseInitializer"/> that will compare
    /// database schema with the entity model and throw an exception if critical
    /// conflicts are found.
    /// </summary>
    /// <typeparam name="TContext">The type of the context.</typeparam>
    public class CheckCompatibilityWithModel<TContext> : IDatabaseInitializer<TContext> where TContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Data.Entity.CheckCompatibilityWithModel`1"/> class.
        /// </summary>
        public CheckCompatibilityWithModel()
        {
            this.CreateDatabaseIfNotExists = true;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the database should be re-created
        /// and optionally re-seeded if it does not exist. To seed the database,
        /// create a derived class and override the Seed method. Default is True.
        /// </summary>
        public bool CreateDatabaseIfNotExists { get; set; }

        /// <summary>
        /// Executes the strategy to initialize the database for the given context.
        /// </summary>
        /// <param name="context">The context.</param>
        public void InitializeDatabase(TContext context)
        {
            bool exists;

            using (new TransactionScope(TransactionScopeOption.Suppress))
            {
                exists = context.Database.Exists();
            }

            if (exists)
            {
                var compatibilityIssues = context.Database.FindCompatibilityIssues();

                if (compatibilityIssues.Any(x => x.IsCritical))
                {
                    throw new DatabaseComparisonException(context, compatibilityIssues);
                }
            }
            else if (this.CreateDatabaseIfNotExists)
            {
                context.Database.Create();
                this.Seed(context);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// A that should be overridden to actually add data to the context for
        /// seeding. The default implementation does nothing.
        /// </summary>
        /// <param name="context">The context to seed.</param>
        protected virtual void Seed(TContext context)
        {
        }
    }
}
