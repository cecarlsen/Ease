using UnityEngine;
using UnityEditor;

public class PackageTool
{
	[MenuItem("Package/Update Package")]
	static void UpdatePackage()
	{
		AssetDatabase.ExportPackage( "Assets/Ease", "Ease.unitypackage", ExportPackageOptions.Recurse );
		Debug.Log( "Updated packages\n" );
	}
}