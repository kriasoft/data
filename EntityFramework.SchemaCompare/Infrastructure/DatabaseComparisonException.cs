//-------------------------------------------------------------------------------
// <copyright file="DatabaseComparisonException.cs" company="KriaSoft, LLC">
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

namespace System.Data.Entity.SchemaCompare.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.SchemaCompare.Resources;

    /// <summary>
    /// Exception thrown by <see cref="T:DatabaseExtensions"/> if compatibility issues
    /// were found after the database schema and entity model comparison operation.
    /// </summary>
    public class DatabaseComparisonException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Data.Entity.SchemaCompare.Infrastructure.DatabaseComparisonException"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="compatibilityIssues">A list of compatibility issues.</param>
        public DatabaseComparisonException(DbContext context, IList<CompatibilityIssue> compatibilityIssues)
            : base(string.Format(Errors.CompatibilityIssuesFound, context.GetType().Name))
        {
            this.CompatibilityIssues = compatibilityIssues;
        }

        /// <summary>
        /// Gets a list of <see cref="T:CompatibilityIssue"/>.
        /// </summary>
        public IList<CompatibilityIssue> CompatibilityIssues { get; private set; }
    }
}
