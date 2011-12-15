Imports System
Imports System.Data.Entity
Imports System.Data.Entity.Migrations
Imports System.Linq

Namespace $rootnamespace$.Migrations

    Friend NotInheritable Class Configuration
        ' TODO: replace [[type name]] with your Code First context type name
        Inherits DbMigrationsConfiguration(Of [[type name]])

        Public Sub New()
            AutomaticMigrationsEnabled = False
            
            ' Seed data: 
            '   Override the Seed method in this class to add seed data.
            '    - The Seed method will be called after migrating to the latest version.
            '    - You can use the DbContext.AddOrUpdate() helper extension method to avoid creating
            '      duplicate seed data. E.g.
            '
            '        myContext.AddOrUpdate(Function(c) c.FullName, _
            '           New Customer() With { _
	        '            .FullName = "Andrew Peters", _
	        '            .CustomerNumber = 123 _
            '        }, New Customer() With { _
	        '            .FullName = "Brice Lambson", _
	        '            .CustomerNumber = 456 _
            '        }, New Customer() With { _
	        '            .FullName = "Rowan Miller", _
	        '            .CustomerNumber = 789 _
            '        })
            '
        End Sub

    End Class

End Namespace
