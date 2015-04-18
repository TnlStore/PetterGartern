using UnityEngine;
using System.Collections;

public class BarBottom : MonoBehaviour {
	GameObject BottomMenu;
	UIButton myBt;

	// Use this for initialization
	void Start () {
		BottomMenu = GameObject.FindGameObjectWithTag("BottomMenu");
//		UIEventListener.Get(gameObject).onClick += onClickTransvesre();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void onClickTransvesre(){
		Debug.Log("onClickTransvesre() BottomMenu.transform.position.y => " + BottomMenu.transform.position.y);
		if(BottomMenu.transform.position.y>=Constants.BOTTOM_MENU_Y_SHOW){
			Debug.Log("onClickTransvesre()");
			iTween.MoveBy(BottomMenu, iTween.Hash("y", Constants.BOTTOM_MENU_Y_HIDE, "easeType", "easeInOutExpo"));
		}
	}


}
