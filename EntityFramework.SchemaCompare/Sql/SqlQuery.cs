//-------------------------------------------------------------------------------
// <copyright file="SqlQuery.cs" company="KriaSoft, LLC">
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

namespace System.Data.Entity.SchemaCompare.Sql
{
    using System;
    using System.IO;
    using System.Reflection;
    using System.Text;

    /// <summary>
    /// Represents a T-SQL query responsible for obtaining a database schema.
    /// </summary>
    public class SqlQuery
    {
        /// <summary>
        /// The SQL Server version number.
        /// </summary>
        private string version;

        /// <summary>
        /// The current executing assembly.
        /// </summary>
        private Assembly assembly;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Data.Entity.SchemaCompare.Sql.SqlQuery"/> class.
        /// </summary>
        /// <param name="version">The SQL Server version number.</param>
        public SqlQuery(string version)
        {
            this.version = version;
            this.assembly = Assembly.GetExecutingAssembly();
        }

        /// <summary>
        /// Implicitly converts SqlQuery object to a string.
        /// </summary>
        /// <param name="sqlQuery">The SqlQuery object.</param>
        /// <returns>A T-SQL string.</returns>
        public static implicit operator string(SqlQuery sqlQuery)
        {
            return sqlQuery.ToString();
        }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents a T-SQL query.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents a T-SQL query.</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine(this.version.StartsWith("8.00") ? this.Read("SelectTables_8.00") : this.Read("SelectTables_9.00+"));
            
            return sb.ToString();
        }

        /// <summary>
        /// Reads T-SQL query from an embedded resource file.
        /// </summary>
        /// <param name="name">The file name.</param>
        /// <returns>A T-SQL query string.</returns>
        private string Read(string name)
        {
            using (var stream = this.assembly.GetManifestResourceStream(string.Format("System.Data.Entity.SchemaCompare.Sql.{0}.sql", name)))
            using (var reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }
    }
}
