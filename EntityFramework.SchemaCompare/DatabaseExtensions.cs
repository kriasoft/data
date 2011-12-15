//-------------------------------------------------------------------------------
// <copyright file="DatabaseExtensions.cs" company="KriaSoft, LLC">
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
    using System.Collections.Generic;
    using System.Data.Entity.SchemaCompare.Infrastructure;
    using System.Data.Entity.SchemaCompare.Model;
    using System.Data.Entity.SchemaCompare.Sql;
    using System.Linq;

    /// <summary>
    /// Extension methods for <see cref="T:Database"/> class.
    /// </summary>
    public static class DatabaseExtensions
    {
        /// <summary>
        /// Compares database with the model and returns a list of <see cref="T:CompatibilityIssue"/>.
        /// </summary>
        /// <param name="database">Database context.</param>
        /// <returns>A list of compatibility issues.</returns>
        public static IList<CompatibilityIssue> FindCompatibilityIssues(this Database database)
        {
            //// Reads database schema

            List<Table> tables;

            using (var db = new DatabaseContext(database.Connection))
            {
                db.ObjectContext.Connection.Open();

                using (var cmd = db.Database.Connection.CreateCommand())
                {
                    cmd.CommandText = new SqlQuery(db.Database.Connection.ServerVersion);
                    
                    using (var reader = cmd.ExecuteReader())
                    {
                        tables = db.ObjectContext.Translate<Table>(reader).ToList();
                    }
                }
            }

            //// TODO: Compare database schema with the model and return a list of compatibility issues.

            return new List<CompatibilityIssue>();
        }
    }
}
