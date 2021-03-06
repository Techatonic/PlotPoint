#pragma strict


/* Thanks you for downloading this asset. We've tried to make this as similar to use as the PlayerPrefs
 * already in Unity, thus all you need to do to access it is use "PlayerPrefsPlus" instead of "PlayerPrefs";
 * you then have the ability to save and retreive any of the following data types.
 * - int		\
 * - float		|-- Just so your code isn't so messy ;)
 * - String		/
 * - bool
 * - Color
 * - Color32
 * - Vector2
 * - Vector3
 * - Vector4
 * - Quaternion
 * - Rect
 * 
 * We hope this is as simple to use as we'd like and, whilst we'll continually update this with more types,
 * if you have any suggestions as to what we should add or find any problems you can reach us here:
 * 		assets@ninjapokestudios.net76.net
 * Or on the asset store
 * 
 * Thanks again,
 * -The NinjaPoke Studios team
*/

//	Copyright NinjaPoke Studios, You can change things but please don't redistrubute in any shape or form 
//	because we lose out :(

/* As a (rather pointless) example:
 * 	function Start(){
 * 		PlayerPrefsPlus.SetBool("TestBoolean",true);
 * 	}
 *
 * 	function Update(){
 * 		print( PlayerPrefsPlus.GetBool("TestBoolean") );
 * 	}
*/ 

/* This asset was formerly known as PlayerPrefsX but we changed it's name as there was already a well known 
 * tool (that annoyingly did everything this one did) on the internet and we didn't want 
 *
*/

//############################################# HasKey #############################################
	
//A has key method for PlayerPrefsPlus
public static function HasKey(key : String){
	var types : String[] = ["{0}","PlayerPrefsPlus:bool:{0}","PlayerPrefsPlus:Colour:{0}-r","PlayerPrefsPlus:Colour32:{0}-r","PlayerPrefsPlus:Vector2:{0}-x","PlayerPrefsPlus:Vector3:{0}-x","PlayerPrefsPlus:Vector4:{0}-x","PlayerPrefsPlus:Vector3:Quaternion:{0}-x","PlayerPrefsPlus:Vector4:Rect:{0}-x"];
	var flag : boolean = false;
	for( var type : String in types ){
		if( PlayerPrefs.HasKey(String.Format(type,key)) )
			flag = true;
	}
	return flag;
}

//############################################### int ##############################################

//Ints stored normally just to make things nice and similar in user projects
public static function SetInt(key : String, value : int){
	PlayerPrefs.SetInt(key, value);
}

public static function GetInt(key : String){
	return PlayerPrefs.GetInt(key);
}

public static function GetInt(key : String, defaultValue : int){
	return PlayerPrefs.GetInt(key, defaultValue);
}
//############################################### float ##############################################

//Floats also stored normally just to make things nice and similar in user projects
public static function SetFloat(key : String, value : float){
	PlayerPrefs.SetFloat(key, value);
}

public static function GetFloat(key : String){
	return PlayerPrefs.GetFloat(key);
}

public static function GetFloat(key : String, defaultValue : float){
	return PlayerPrefs.GetFloat(key, defaultValue);
}
//############################################### String ##############################################

//And strings
public static function SetString(key : String, value : String){
	PlayerPrefs.SetString(key, value);
}

public static function GetString(key : String){
	return PlayerPrefs.GetString(key);
}

public static function GetString(key : String, defaultValue : String){
	return PlayerPrefs.GetString(key, defaultValue);
}

//############################################## bool ##############################################

//Store bool as 0 or 1
public static function SetBool(key : String, value : boolean){
	if( value )
		PlayerPrefs.SetInt("PlayerPrefsPlus:bool:"+key,1);
	else
		PlayerPrefs.SetInt("PlayerPrefsPlus:bool:"+key,0);
}

public static function GetBool(key : String){
	return GetBool(key,false);
}

public static function GetBool(key : String, defaultValue : boolean){
	var value : int = PlayerPrefs.GetInt("PlayerPrefsPlus:bool:"+key, 2);
	if( value == 2 )		//Return default
		return defaultValue;
	else if( value == 1 )	//Return true
		return true;
	else					//Return false
		return false;
}

//############################################## Color ##############################################

//Store Color data as RGBA floats
public static function SetColour(key : String, value : Color){
	PlayerPrefs.SetFloat("PlayerPrefsPlus:Colour:"+key+"-r",value.r);
	PlayerPrefs.SetFloat("PlayerPrefsPlus:Colour:"+key+"-g",value.g);
	PlayerPrefs.SetFloat("PlayerPrefsPlus:Colour:"+key+"-b",value.b);
	PlayerPrefs.SetFloat("PlayerPrefsPlus:Colour:"+key+"-a",value.a);
}

//Rebuild Color data from RGBA floats
public static function GetColour(key : String){
	return GetColour(key,Color.clear);
}

public static function GetColour(key : String, defaultValue : Color){
	var returnValue : Color;
	returnValue.r = PlayerPrefs.GetFloat("PlayerPrefsPlus:Colour:"+key+"-r",defaultValue.r);
	returnValue.g = PlayerPrefs.GetFloat("PlayerPrefsPlus:Colour:"+key+"-g",defaultValue.g);
	returnValue.b = PlayerPrefs.GetFloat("PlayerPrefsPlus:Colour:"+key+"-b",defaultValue.b);
	returnValue.a = PlayerPrefs.GetFloat("PlayerPrefsPlus:Colour:"+key+"-a",defaultValue.a);
	return returnValue;
}

//############################################ Color 32 #############################################

//Store Color32 data RGBA Ints
public static function SetColour32(key : String, value : Color32){
	PlayerPrefs.SetInt("PlayerPrefsPlus:Colour32:"+key+"-r",value.r);
	PlayerPrefs.SetInt("PlayerPrefsPlus:Colour32:"+key+"-g",value.g);
	PlayerPrefs.SetInt("PlayerPrefsPlus:Colour32:"+key+"-b",value.b);
	PlayerPrefs.SetInt("PlayerPrefsPlus:Colour32:"+key+"-a",value.a);
}

//Rebuild Color32 data from RGBA Ints
public static function GetColour32(key : String){
	return GetColour32(key,Color32(0,0,0,0));
}

public static function GetColour32(key : String, defaultValue : Color32){
	var returnValue : Color32;
	returnValue.r = PlayerPrefs.GetInt("PlayerPrefsPlus:Colour32:"+key+"-r",defaultValue.r);
	returnValue.g = PlayerPrefs.GetInt("PlayerPrefsPlus:Colour32:"+key+"-g",defaultValue.g);
	returnValue.b = PlayerPrefs.GetInt("PlayerPrefsPlus:Colour32:"+key+"-b",defaultValue.b);
	returnValue.a = PlayerPrefs.GetInt("PlayerPrefsPlus:Colour32:"+key+"-a",defaultValue.a);
	return returnValue;
}

//############################################# Vector2 #############################################

//Store Vector2 data as as x & y floats
public static function SetVector2(key : String, value : Vector2){
	PlayerPrefs.SetFloat("PlayerPrefsPlus:Vector2:"+key+"-x",value.x);
	PlayerPrefs.SetFloat("PlayerPrefsPlus:Vector2:"+key+"-y",value.y);
}

//Rebuild Vector2 from floats
public static function GetVector2(key : String){
	return GetVector2(key,Vector2.zero);
}

public static function GetVector2(key : String, defaultValue : Vector2){
	var returnValue : Vector2;
	returnValue.x = PlayerPrefs.GetFloat("PlayerPrefsPlus:Vector2:"+key+"-x",defaultValue.x);
	returnValue.y = PlayerPrefs.GetFloat("PlayerPrefsPlus:Vector2:"+key+"-y",defaultValue.y);
	return returnValue;
}

//############################################# Vector3 #############################################

//Store Vector3 data as as x, y & z floats
public static function SetVector3(key : String, value : Vector3){
	PlayerPrefs.SetFloat("PlayerPrefsPlus:Vector3:"+key+"-x",value.x);
	PlayerPrefs.SetFloat("PlayerPrefsPlus:Vector3:"+key+"-y",value.y);
	PlayerPrefs.SetFloat("PlayerPrefsPlus:Vector3:"+key+"-z",value.z);
}

//Rebuild Vector3 from floats
public static function GetVector3(key : String){
	return GetVector3(key,Vector3.zero);
}

public static function GetVector3(key : String, defaultValue : Vector3){
	var returnValue : Vector3;
	returnValue.x = PlayerPrefs.GetFloat("PlayerPrefsPlus:Vector3:"+key+"-x",defaultValue.x);
	returnValue.y = PlayerPrefs.GetFloat("PlayerPrefsPlus:Vector3:"+key+"-y",defaultValue.y);
	returnValue.z = PlayerPrefs.GetFloat("PlayerPrefsPlus:Vector3:"+key+"-z",defaultValue.z);
	return returnValue;
}

//############################################# Vector4 #############################################

//Store Vector4 data as as x, y, z & w floats
public static function SetVector4(key : String, value : Vector4){
	PlayerPrefs.SetFloat("PlayerPrefsPlus:Vector4:"+key+"-x",value.x);
	PlayerPrefs.SetFloat("PlayerPrefsPlus:Vector4:"+key+"-y",value.y);
	PlayerPrefs.SetFloat("PlayerPrefsPlus:Vector4:"+key+"-z",value.z);
	PlayerPrefs.SetFloat("PlayerPrefsPlus:Vector4:"+key+"-w",value.w);
}

//Rebuild Vector4 from floats
public static function GetVector4(key : String){
	return GetVector4(key,Vector4.zero);
}

public static function GetVector4(key : String, defaultValue : Vector4){
	var returnValue : Vector4;
	returnValue.x = PlayerPrefs.GetFloat("PlayerPrefsPlus:Vector4:"+key+"-x",defaultValue.x);
	returnValue.y = PlayerPrefs.GetFloat("PlayerPrefsPlus:Vector4:"+key+"-y",defaultValue.y);
	returnValue.z = PlayerPrefs.GetFloat("PlayerPrefsPlus:Vector4:"+key+"-z",defaultValue.z);
	returnValue.w = PlayerPrefs.GetFloat("PlayerPrefsPlus:Vector4:"+key+"-w",defaultValue.w);
	return returnValue;
}

//############################################ Quaternion ############################################

//For simplicity we are just going to put Quaternions into Vector3s with "Quaternion" before the key
public static function SetQuaternion(key : String, value : Quaternion){
	SetVector3("Quaternion:"+key,value.eulerAngles);
}

public static function GetQuaternion(key : String){
	return Quaternion.Euler( GetVector3("Quaternion:"+key,Quaternion.identity.eulerAngles) );
}

public static function GetQuaternion(key : String, defaultValue : Quaternion){
	return Quaternion.Euler( GetVector3("Quaternion:"+key,defaultValue.eulerAngles) );
}

//############################################### Rect ###############################################

//Similar to Quaternions we are just going to put Rects into Vector4s with "Rect" before the key
public static function SetRect(key : String, value : Rect){
	SetVector4("Rect:"+key,Vector4( value.x, value.y, value.width, value.height ));
}

public static function GetRect(key : String){
	var v4 : Vector4 = GetVector4("Rect:"+key, Vector4.zero );
	return Rect( v4.x, v4.y, v4.z, v4.w );
}

public static function GetRect(key : String, defaultValue : Rect){
	var v4 : Vector4 = GetVector4("Rect:"+key,Vector4( defaultValue.x, defaultValue.y, defaultValue.width, defaultValue.height ) );
	return Rect( v4.x, v4.y, v4.z, v4.w );
}