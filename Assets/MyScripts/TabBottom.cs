using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TabBottom : MonoBehaviour {

	private string tab_name;
	private GameObject tabContent;
	private List<GameObject> otherTabContents;
	private List<GameObject> otherTabs;
	public bool isActive;	

	void OnEnable(){
		setUpTab ();
	}

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		
	}

	private void setUpTab(){
		otherTabContents = new List<GameObject>();
		otherTabs = new List<GameObject>();
		tab_name = gameObject.name.ToString();
		isActive = false;
		if(tab_name.Equals(Constants.TAB_STATUS_BT_NAME)){
			tabContent = GameObject.Find(Constants.TAB_STATUS_NAME);
			otherTabContents.Add(GameObject.Find(Constants.TAB_STORE_NAME));
			otherTabContents.Add(GameObject.Find(Constants.TAB_SETTING_NAME));
			otherTabs.Add(GameObject.Find(Constants.TAB_STORE_BT_NAME));
			otherTabs.Add(GameObject.Find(Constants.TAB_SETTING_BT_NAME));
		}
		else if(tab_name.Equals(Constants.TAB_STORE_BT_NAME)){
			tabContent = GameObject.Find(Constants.TAB_STORE_NAME);
			otherTabContents.Add(GameObject.Find(Constants.TAB_STATUS_NAME));
			otherTabContents.Add(GameObject.Find(Constants.TAB_SETTING_NAME));
			otherTabs.Add(GameObject.Find(Constants.TAB_STATUS_BT_NAME));
			otherTabs.Add(GameObject.Find(Constants.TAB_SETTING_BT_NAME));
		}
		else if(tab_name.Equals(Constants.TAB_SETTING_BT_NAME)){
			tabContent = GameObject.Find(Constants.TAB_SETTING_NAME);
			otherTabContents.Add(GameObject.Find(Constants.TAB_STATUS_NAME));
			otherTabContents.Add(GameObject.Find(Constants.TAB_STORE_NAME));
			otherTabs.Add(GameObject.Find(Constants.TAB_STATUS_BT_NAME));
			otherTabs.Add(GameObject.Find(Constants.TAB_STORE_BT_NAME));
		}
	}

	public void onClickActive(){
		if(!isActive){
			isActive = true;
			transform.Find("Background").gameObject.GetComponent<UISprite>().setDepth(Constants.BOTTOM_TAB_SHOW_DEPTH);
			tabContent.SetActive(true);
			foreach(GameObject thisTab in otherTabContents){
				thisTab.SetActive(false);
			}
			foreach(GameObject thisTab in otherTabs){
				thisTab.GetComponent<TabBottom>().setActive(false);
				thisTab.transform.Find ("Background").gameObject.GetComponent<UISprite>().setDepth(Constants.BOTTOM_TAB_HIDE_DEPTH);				
			}
		}
	}

	public void setActive(bool active){
		isActive = active;
	}
}
