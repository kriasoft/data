//-------------------------------------------------------------------------------
// <copyright file="Column.cs" company="KriaSoft, LLC">
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
    /// <summary>
    /// Represents column of a database table.
    /// </summary>
    public class Column
    {
        /// <summary>
        /// Gets or sets the ID of the column.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the name of the column.
        /// </summary>
        public string Name { get; set; }
    }
}
