param($installPath, $toolsPath, $package, $project)

function OpenFile($fileName)
{
	$projectFullPath = $project.Properties.Item("FullPath").Value
	$fileAbsolutePath = (Join-Path $projectFullPath $fileName)
	$project.DTE.ItemOperations.OpenFile($fileAbsolutePath)
}

$migrationsProjectItems = $project.ProjectItems.Item("Migrations").ProjectItems

if ($project.CodeModel.Language -eq [EnvDTE.CodeModelLanguageConstants]::vsCMLanguageVB)
{
	$migrationsProjectItems.Item("Configuration.cs").Delete()
	OpenFile("Migrations\Configuration.vb")
}
else
{
	$migrationsProjectItems.Item("Configuration.vb").Delete()
	OpenFile("Migrations\Configuration.cs")
}
