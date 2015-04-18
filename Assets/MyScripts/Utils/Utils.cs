using UnityEngine;
using System.Collections;

public class Utils {

	public static void Log(string content){
		if (Constants.DEBUG_KEY == 0)
			Debug.Log (content);
	}

	public static void getSceneWidth(){
	
	}

	public static Vector3 randomDirection(){
		return new Vector3 (Random.Range(-10,10),Random.Range(-10,10), 0).normalized;
	}

	/// <summary>
	/// Convert Input vector to new Vector with oposite direction
	/// </summary>
	/// <returns>Vector with oposite direction.</returns>
	/// <param> Origin vector. </param>
	public static Vector3 opositeDirection(Vector3 originVector){
		return originVector*-1;
	}

	/// <summary>
	/// Gets the vector direction from an Object to other Object.
	/// </summary>
	/// <returns>Vector direction</returns>
	/// <param name="from">From Object.</param>
	/// <param name="to">To Object.</param>
	public static Vector3 getDirectionFromTo(GameObject from, GameObject to){
		return new Vector3(to.transform.position.x - from.transform.position.x,
		                   	to.transform.position.y - from.transform.position.y,
		                     to.transform.position.z - from.transform.position.z).normalized;
	}

	// ** Convert Input from mouse or touch into default z position
	public static Vector3 convertInputVector(Vector3 inputPosition){
		return new Vector3 (inputPosition.x, inputPosition.y, 1);
	}
}
