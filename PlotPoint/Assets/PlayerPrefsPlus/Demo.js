#pragma strict

function Start(){
	//When we load the application we want to load our position and rotation
	transform.position = PlayerPrefsPlus.GetVector3("Position",Vector3(0,5,0));
	transform.rotation = PlayerPrefsPlus.GetQuaternion("Rotation",Quaternion.identity);
	Debug.Log(PlayerPrefsPlus.GetRect("Rect"));
	Debug.Log(PlayerPrefsPlus.GetColour32("Color32"));
}

function OnApplicationQuit(){
	//When we quit the application we want to save our position and rotation
	PlayerPrefsPlus.SetVector3("Position",transform.position);
	PlayerPrefsPlus.SetQuaternion("Rotation",transform.rotation);
	PlayerPrefsPlus.SetRect("Rect",Rect(1,2,3,4));
	PlayerPrefsPlus.SetColour32("Color32",Color32(100,200,130,40));
}

function Update(){
	//Lets move about
	transform.Translate(0,0,Input.GetAxis("Vertical")*0.2);
	//And turn
	transform.Rotate(0,Input.GetAxis("Horizontal")*5,0);
}