using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class FucturaTools : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


	}
	[MenuItem ("Fuctura/DisableShadows")]
	public static void Disable ()
	{
		GameObject[] aux = FindObjectsOfType(typeof(GameObject)) as GameObject[];

		for (int i = 0; i < aux.Length; i++) {
			if (aux [i].GetComponent<SkinnedMeshRenderer> ())
				aux [i].GetComponent<SkinnedMeshRenderer> ().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
			else if (aux [i].GetComponent<MeshRenderer> ())
				aux [i].GetComponent<MeshRenderer> ().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
		}
	}

    [MenuItem("Fuctura/Delete PlayerPrefs (All)")]
    static void DeleteAllPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
    }

}
