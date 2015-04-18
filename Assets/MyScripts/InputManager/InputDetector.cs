using UnityEngine;
using System.Collections;

public class InputDetector : MonoBehaviour {

	private float timeTouchDown;
	private float timeTouchUp;
	private Vector3 firstVectorFingerDown;
	private Vector3 lastVectorFingerUp;
	public Camera myCamera; 

	public Transform testCube;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		touchActionDetect ();
		if(getObjectTouch()!=null){
			Debug.Log("Object Touch : " + getObjectTouch().tag);
		}
	}

	private void touchActionDetect(){
		if (InputEmulator.getTouchDown()) {
			firstVectorFingerDown = Utils.convertInputVector(myCamera.ScreenToWorldPoint( Input.mousePosition ));

//			Debug.Log("Finger Position Down : " + firstVectorFingerDown);
		}
		if(InputEmulator.getTouchDown()){
			lastVectorFingerUp = Input.mousePosition;
//			Debug.Log("Finger Position Up : " + lastVectorFingerUp);
		}

	}

	private GameObject getObjectTouch(){

		if (InputEmulator.getTouchDown()) {
			RaycastHit hit;
			Ray ray = myCamera.ScreenPointToRay(myCamera.WorldToScreenPoint(firstVectorFingerDown));
			Debug.DrawRay(ray.origin, ray.direction * 10, Color.red);	
//			Instantiate(testCube, firstVectorFingerDown, Quaternion.identity );
			if (Physics.Raycast(ray, out hit)) {
//				Transform objectHit = hit.transform;
				
				// Do something with the object that was hit by the raycast.
				return hit.transform.gameObject;
			}
			return null;
		}
		return null;
	}
	

}
