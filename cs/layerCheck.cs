using System;
using UnityEngine;
using System.Collections;
using System.Reflection;
using UnityEditorInternal;
using UnityEditor;

[CustomEditor( typeof(layerCheck) )]
public class layerCheck : Editor 
{
	int layer = 0;
	string[] IList = null;

	public override void OnInspectorGUI() {
		layerCheck obj = target as layerCheck;
		EditorUtility.SetDirty( target );
	}

	// Use this for initialization
	void Start ()
	{
		log ();
	//	foreach( string layerName in GetSortingLayerNames()){
	//		Debug.Log ( layerName );
	//	}

	}
	
	// Update is called once per frame
	void Update ()
	{
		Debug.Log ( "layerCheck" );
	}

	void log(){
		Debug.Log ( "layerCheck" );
	}

	void getChildLayer( Transform transform ){
		Debug.Log (transform.gameObject.layer);
		if (transform.childCount > 0) {
			for (int i = 0; i < transform.childCount; i++) {
				getChildLayer (transform.GetChild (i).transform);
			}
		}
	}

	private string[] GetSortingLayerNames() {
		Type internalEditorUtilityType = typeof(InternalEditorUtility);
		PropertyInfo sortingLayersProperty = internalEditorUtilityType.GetProperty("sortingLayerNames", BindingFlags.Static | BindingFlags.NonPublic);
		return (string[])sortingLayersProperty.GetValue(null, new object[0]);
	}
}


