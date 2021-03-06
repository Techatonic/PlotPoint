#pragma strict

public class PlayerPrefsArray extends MonoBehaviour {
	
	//############################################### int ##############################################
	
	//Set an array of ints
	public static function SetIntArray( key : String, value : int[] ){
	    PlayerPrefs.SetInt("PlayerPrefsArray:Int:L:"+key, value.Length);
	    var i : int = 0;
	    while(i < value.Length){
	        PlayerPrefs.SetInt("PlayerPrefsArray:Int:"+key + i.ToString(), value[i]);
	        ++i;
	    }
	}
	
	//Get an array of ints
	public static function GetIntArray( key : String ){
	    var returns : int[] = new int[PlayerPrefs.GetInt("PlayerPrefsArray:Int:L:"+key)];
	    
	   	var i : int = 0;
	    
	    while(i < PlayerPrefs.GetInt("PlayerPrefsArray:Int:L:"+key)){
	        returns.SetValue(PlayerPrefs.GetInt("PlayerPrefsArray:Int:"+key + i.ToString()), i);
	        ++i;
	    }
	    return returns;
	}
	
	//############################################### float ##############################################
	
	//Set an array of floats
	public static function SetFloatArray( key : String, value : int[] ){
	    PlayerPrefs.SetInt("PlayerPrefsArray:Float:L:"+key, value.Length);
	    var i : int = 0;
	    while(i < value.Length){
	        PlayerPrefs.SetFloat("PlayerPrefsArray:Float:"+key + i.ToString(), value[i]);
	        ++i;
	    }
	}
	
	//Get an array of floats
	public static function GetFloatArray( key : String ){
	    var returns : float[] = new float[PlayerPrefs.GetInt("PlayerPrefsArray:Float:L:"+key)];
	    
	   	var i : int = 0;
	    
	    while(i < PlayerPrefs.GetInt("PlayerPrefsArray:Float:L:"+key)){
	        returns.SetValue(PlayerPrefs.GetFloat("PlayerPrefsArray:Float:"+key + i.ToString()), i);
	        ++i;
	    }
	    return returns;
	}
	
	//############################################### String ##############################################
	
	//Set an array of strings
	public static function SetStringArray( key : String, value : String[] ){
	    PlayerPrefs.SetInt("PlayerPrefsArray:String:L:"+key, value.Length);
	    var i : int = 0;
	    while(i < value.Length){
	        PlayerPrefs.SetString("PlayerPrefsArray:String:"+key + i.ToString(), value[i]);
	        ++i;
	    }
	}
	
		//Get an array of strings
	public static function GetStringArray( key : String ){
	    var returns : String[] = new String[PlayerPrefs.GetInt("PlayerPrefsArray:String:L:"+key)];
	    
	   	var i : int = 0;
	    
	    while(i < PlayerPrefs.GetInt("PlayerPrefsArray:String:L:"+key)){
	        returns.SetValue(PlayerPrefs.GetString("PlayerPrefsArray:String:"+key + i.ToString()), i);
	        ++i;
	    }
	    return returns;
	}
	
	//############################################### bool ##############################################
	
	//Set an array of bool
	public static function SetBoolArray( key : String, value : boolean[] ){
	    PlayerPrefs.SetInt("PlayerPrefsArray:Bool:L:"+key, value.Length);
	    var i : int = 0;
	    while(i < value.Length){
	        PlayerPrefsPlus.SetBool("PlayerPrefsArray:Bool:"+key + i.ToString(), value[i]);
	        ++i;
	    }
	}
	
	//Get an array of bools
	public static function GetBoolArray( key : String ){
	    var returns : boolean[] = new boolean[PlayerPrefs.GetInt("PlayerPrefsArray:Bool:L:"+key)];
	    
	   	var i : int = 0;
	    
	    while(i < PlayerPrefs.GetInt("PlayerPrefsArray:Bool:L:"+key)){
	        returns.SetValue(PlayerPrefsPlus.GetBool("PlayerPrefsArray:Bool:"+key + i.ToString()), i);
	        ++i;
	    }
	    return returns;
	}
	
	//############################################### Color ##############################################
	
	//Set an array of Colours
	public static function SetColourArray( key : String, value : Color[] ){
	    PlayerPrefs.SetInt("PlayerPrefsArray:Colour:L:"+key, value.Length);
	    var i : int = 0;
	    while(i < value.Length){
	        PlayerPrefsPlus.SetColour("PlayerPrefsArray:Colour:"+key + i.ToString(), value[i]);
	        ++i;
	    }
	}
	
	//Get an array of Colours
	public static function GetColourArray( key : String ){
	    var returns : Color[] = new Color[PlayerPrefs.GetInt("PlayerPrefsArray:Colour:L:"+key)];
	    
	   	var i : int = 0;
	    
	    while(i < PlayerPrefs.GetInt("PlayerPrefsArray:Colour:L:"+key)){
	        returns.SetValue(PlayerPrefsPlus.GetColour("PlayerPrefsArray:Colour:"+key + i.ToString()), i);
	        ++i;
	    }
	    return returns;
	}
	
	//############################################### Color32 ##############################################
	
	//Set an array of Colour32s
	public static function SetColour32Array( key : String, value : Color32[] ){
	    PlayerPrefs.SetInt("PlayerPrefsArray:Colour32:L:"+key, value.Length);
	    var i : int = 0;
	    while(i < value.Length){
	        PlayerPrefsPlus.SetColour32("PlayerPrefsArray:Colour32:"+key + i.ToString(), value[i]);
	        ++i;
	    }
	}
	
	//Get an array of Colour32s
	public static function GetColour32Array( key : String ){
	    var returns : Color32[] = new Color32[PlayerPrefs.GetInt("PlayerPrefsArray:Colour32:L:"+key)];
	    
	   	var i : int = 0;
	    
	    while(i < PlayerPrefs.GetInt("PlayerPrefsArray:Colour32:L:"+key)){
	        returns.SetValue(PlayerPrefsPlus.GetColour32("PlayerPrefsArray:Colour32:"+key + i.ToString()), i);
	        ++i;
	    }
	    return returns;
	}
	
	//############################################### Vector2 ##############################################
	
	//Set an array of Vector2s
	public static function SetVector2Array( key : String, value : Vector2[] ){
	    PlayerPrefs.SetInt("PlayerPrefsArray:Vector2:L:"+key, value.Length);
	    var i : int = 0;
	    while(i < value.Length){
	        PlayerPrefsPlus.SetVector2("PlayerPrefsArray:Vector2:"+key + i.ToString(), value[i]);
	        ++i;
	    }
	}
	
	//Get an array of Vector2s
	public static function GetVector2Array( key : String ){
	    var returns : Vector2[] = new Vector2[PlayerPrefs.GetInt("PlayerPrefsArray:Vector2:L:"+key)];
	    
	   	var i : int = 0;
	    
	    while(i < PlayerPrefs.GetInt("PlayerPrefsArray:Vector2:L:"+key)){
	        returns.SetValue(PlayerPrefsPlus.GetVector2("PlayerPrefsArray:Vector2:"+key + i.ToString()), i);
	        ++i;
	    }
	    return returns;
	}
	
	//############################################### Vector3 ##############################################
	
	//Set an array of Vector3s
	public static function SetVector3Array( key : String, value : Vector3[] ){
	    PlayerPrefs.SetInt("PlayerPrefsArray:Vector3:L:"+key, value.Length);
	    var i : int = 0;
	    while(i < value.Length){
	        PlayerPrefsPlus.SetVector3("PlayerPrefsArray:Vector3:"+key + i.ToString(), value[i]);
	        ++i;
	    }
	}
	
	//Get an array of Vector3s
	public static function GetVector3Array( key : String ){
	    var returns : Vector3[] = new Vector3[PlayerPrefs.GetInt("PlayerPrefsArray:Vector3:L:"+key)];
	    
	   	var i : int = 0;
	    
	    while(i < PlayerPrefs.GetInt("PlayerPrefsArray:Vector3:L:"+key)){
	        returns.SetValue(PlayerPrefsPlus.GetVector3("PlayerPrefsArray:Vector3:"+key + i.ToString()), i);
	        ++i;
	    }
	    return returns;
	}
	
	//############################################### Vector4 ##############################################
	
	//Set an array of Vector4s
	public static function SetVector4Array( key : String, value : Vector4[] ){
	    PlayerPrefs.SetInt("PlayerPrefsArray:Vector4:L:"+key, value.Length);
	    var i : int = 0;
	    while(i < value.Length){
	        PlayerPrefsPlus.SetVector4("PlayerPrefsArray:Vector4:"+key + i.ToString(), value[i]);
	        ++i;
	    }
	}
	
	//Get an array of Vector4s
	public static function GetVector4Array( key : String ){
	    var returns : Vector4[] = new Vector4[PlayerPrefs.GetInt("PlayerPrefsArray:Vector4:L:"+key)];
	    
	   	var i : int = 0;
	    
	    while(i < PlayerPrefs.GetInt("PlayerPrefsArray:Vector4:L:"+key)){
	        returns.SetValue(PlayerPrefsPlus.GetVector4("PlayerPrefsArray:Vector4:"+key + i.ToString()), i);
	        ++i;
	    }
	    return returns;
	}
	
	//############################################### Quaternion ##############################################
	
	//Set an array of Quaternions
	public static function SetQuaternionArray( key : String, value : Quaternion[] ){
	    PlayerPrefs.SetInt("PlayerPrefsArray:Quaternion:L:"+key, value.Length);
	    var i : int = 0;
	    while(i < value.Length){
	        PlayerPrefsPlus.SetQuaternion("PlayerPrefsArray:Quaternion:"+key + i.ToString(), value[i]);
	        ++i;
	    }
	}
	
	//Get an array of Quaternions
	public static function GetQuaternionArray( key : String ){
	    var returns : Quaternion[] = new Quaternion[PlayerPrefs.GetInt("PlayerPrefsArray:Quaternion:L:"+key)];
	    
	   	var i : int = 0;
	    
	    while(i < PlayerPrefs.GetInt("PlayerPrefsArray:Quaternion:L:"+key)){
	        returns.SetValue(PlayerPrefsPlus.GetQuaternion("PlayerPrefsArray:Quaternion:"+key + i.ToString()), i);
	        ++i;
	    }
	    return returns;
	}
	
	//############################################### Rect ##############################################
	
	//Set an array of Rects
	public static function SetRectArray( key : String, value : Rect[] ){
	    PlayerPrefs.SetInt("PlayerPrefsArray:Rect:L:"+key, value.Length);
	    var i : int = 0;
	    while(i < value.Length){
	        PlayerPrefsPlus.SetRect("PlayerPrefsArray:Rect:"+key + i.ToString(), value[i]);
	        ++i;
	    }
	}
	
	//Get an array of Rects
	public static function GetRectArray( key : String ){
	    var returns : Rect[] = new Rect[PlayerPrefs.GetInt("PlayerPrefsArray:Rect:L:"+key)];
	    
	   	var i : int = 0;
	    
	    while(i < PlayerPrefs.GetInt("PlayerPrefsArray:Rect:L:"+key)){
	        returns.SetValue(PlayerPrefsPlus.GetRect("PlayerPrefsArray:Rect:"+key + i.ToString()), i);
	        ++i;
	    }
	    return returns;
	}
	
}

public class PPA extends PlayerPrefsArray{}