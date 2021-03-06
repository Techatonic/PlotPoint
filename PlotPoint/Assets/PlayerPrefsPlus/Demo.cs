using UnityEngine;
using System.Collections;

/* This provides a demo of the PlayerPrefsPlus addon, it allows you to save values, read values and randomise
 * values on the screen so you can see it working. Also try starting and stopping the simulation to show that
 * data is retained, like PlayerPrefs, between sessions.
*/

public class Demo : MonoBehaviour {
	
	bool boolean;
	Color colour;
	Color32 colour32;
	Vector2 v2;
	Vector3 v3;
	Vector4 v4;
	Quaternion quat;
	Rect rect;
	
	string hasKey = "TestBool";
	
	void OnGUI(){
		//Here we're just displaying all the values returned.
		GUILayout.Label( "Boolean: "	+ boolean.ToString() );
		GUILayout.Label( "Colour: "		+ colour.ToString() );
		GUILayout.Label( "Colour32: "		+ colour32.ToString() );
		GUILayout.Label( "Vector2: "	+ v2.ToString() );
		GUILayout.Label( "Vector3: "	+ v3.ToString() );
		GUILayout.Label( "Vector4: "	+ v4.ToString() );
		GUILayout.Label( "Quaternion: "	+ quat.ToString() + " (Euler: " + quat.eulerAngles.ToString() +")" );
		GUILayout.Label( "Rect: "		+ rect.ToString() );
				
		//This messes things up
		if( GUILayout.Button("Mess everything up!") ){
			if( Random.Range(0,1) == 1 ) boolean = true; else boolean = false;
			colour = new Color( Random.Range(0f,1f),Random.Range(0f,1f),Random.Range(0f,1f),Random.Range(0f,1f) );
			colour32 = new Color( Random.Range(0,255),Random.Range(0,255),Random.Range(0,255),Random.Range(0,255) );
			v2 = new Vector2( Random.Range(-50,50), Random.Range(-50,50) );
			v3 = new Vector3( Random.Range(-50,50), Random.Range(-50,50), Random.Range(-50,50) );
			v4 = new Vector4( Random.Range(-50,50), Random.Range(-50,50), Random.Range(-50,50), Random.Range(-50,50) );
			quat = new Quaternion( Random.Range(0f,1f), Random.Range(0f,1f), Random.Range(0f,1f), Random.Range(0f,1f) );
			rect = new Rect( Random.Range(0,50), Random.Range(0,50), Random.Range(0,50), Random.Range(0,50) );
		}
			
		//This restore the values from the save
		if( GUILayout.Button("Restore from save!") ){
			boolean = PlayerPrefsPlus.GetBool("TestBool");
			colour = PlayerPrefsPlus.GetColour("TestColour");
			colour32 = PlayerPrefsPlus.GetColour("TestColour32");
			v2 = PlayerPrefsPlus.GetVector2("TestVector2");
			v3 = PlayerPrefsPlus.GetVector3("TestVector3");
			v4 = PlayerPrefsPlus.GetVector4("TestVector4");
			quat = PlayerPrefsPlus.GetQuaternion("TestQuaternion");
			rect = PlayerPrefsPlus.GetRect("TestRect");
		}
		
		//This section will save the values
		if( GUILayout.Button("Save!") ){
			PlayerPrefsPlus.SetString("TestString","hi");
			PlayerPrefsPlus.SetInt("TestInt",0);
			PlayerPrefsPlus.SetFloat("TestFloat",0f);
			PlayerPrefsPlus.SetBool("TestBool",boolean);
			PlayerPrefsPlus.SetColour("TestColour",colour);
			PlayerPrefsPlus.SetColour("TestColour32",colour32);
			PlayerPrefsPlus.SetVector2("TestVector2",v2);
			PlayerPrefsPlus.SetVector3("TestVector3",v3);
			PlayerPrefsPlus.SetVector4("TestVector4",v4);
			PlayerPrefsPlus.SetQuaternion("TestQuaternion",quat);
			PlayerPrefsPlus.SetRect("TestRect",rect);
		}
		
		GUILayout.Label("Type to see if key exists:");
		hasKey = GUILayout.TextField(hasKey);
		GUILayout.Label(PlayerPrefsPlus.HasKey(hasKey).ToString());
	}
}