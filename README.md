EntityFramework.SchemaCompare v0.0.1-alpha
==========================================

An alternative to [EntityFramework.Migrations](https://nuget.org/packages/EntityFramework.Migrations). It allows to compare database schema with EF Code-First entities model during database initialization or manually on request. Then having all the differences / incompatibility issues between the model and db schema on hands you can update either database schema or code-first classes to get them back in sync.

The latest version is at [http://github.com/kriasoft/data](http://github.com/kriasoft/data)

How to use it?
--------------

    Database.SetInitializer(new CheckCompatibilityWithModel<DatabaseContext>());

or

    Database.SetInitializer(new CheckCompatibilityWithModel<DatabaseContext> { CreateDatabaseIfNotExists = false });

This will run database schema and model comparison during database initialization. If any compatibility issues found it will throw an exception describing the differences between db schema and model.

Alternatively you can call

    using (var db = new DatabaseContext())
    {
        var issues = db.Database.FindCompatibilityIssues();
    }

..to find all the differences between db schema and entities model.

Credits
-------

EntityFramework.SchemaCompare is Open Source, released under the terms of the Apache License 2.0; see the [LICENSE.md](https://github.com/kriasoft/data/blob/master/LICENSE.md) file.