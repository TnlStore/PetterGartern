using UnityEngine;
using System.Collections;

public class BottomUpBt : MonoBehaviour {

	GameObject BottomMenu;

	// Use this for initialization
	void Start () {
		BottomMenu = GameObject.FindGameObjectWithTag("BottomMenu");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void onClickTransvesre(){
		Debug.Log("onClickTransvesre() BottomMenu.transform.position.y => " + BottomMenu.transform.position.y);
		if(BottomMenu.transform.position.y<=Constants.BOTTOM_MENU_Y_HIDE){
			Debug.Log("onClickTransvesre()");
			iTween.MoveBy(BottomMenu, iTween.Hash("y", -Constants.BOTTOM_MENU_Y_HIDE, "easeType", "easeInOutExpo"));
		}
	}

}
