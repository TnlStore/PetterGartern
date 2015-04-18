using UnityEngine;
using System.Collections;

public class StatusBarController : MonoBehaviour {
	private int sum = 0;

	public float status_health_value = 1;
	public float status_happy_value = 1;
	public float status_clean_value = 1;
	public float status_hungry_value = 1;
	public float status_sleepy_value = 1;

	// Status bars
	private GameObject healthBar;
	private GameObject happyBar;
	private GameObject cleanBar;
	private GameObject hungryBar;
	private GameObject sleepyBar;


	// --- Static key ---	
	public static int STATUS_HEALTH_KEY = 1;
	public static int STATUS_HAPPY_KEY = 2;
	public static int STATUS_CLEAN_KEY = 3;
	public static int STATUS_HUNGRY_KEY = 4;
	public static int STATUS_SLEEPY_KEY = 5;

	#if UNITY_EDITOR
	
	#elif UNITY_IPHONE
	
	#else
		AndroidJavaClass ClassReferences;
		AndroidJavaClass UtilsClass;
		AndroidJavaObject jo;
	#endif

	// Use this for initialization
	void Start () {
		#if UNITY_EDITOR
		Debug.Log("Unity Editor");
		
		#elif UNITY_IPHONE
		Debug.Log("Unity iPhone");
		
		#else
			AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer"); 
			jo = jc.GetStatic<AndroidJavaObject>("currentActivity"); 
			UtilsClass = new AndroidJavaClass("tnlstore.game.pettergarten.Utils");

		// **** Get class References , set up ()  *****
		ClassReferences = new AndroidJavaClass("tnlstore.game.pettergarten.Preferences");
		ClassReferences.CallStatic("setUpStatus", jo);
	//		sum = UtilsClass.CallStatic<int>("testUnityInteraction", 1, 2);

		// ** Start Service **
		UtilsClass.CallStatic("startMyService", jo);

		#endif

		healthBar = transform.Find ("Health Bar").Find("Foreground").gameObject;
		happyBar = transform.Find ("Happy Bar").Find("Foreground").gameObject;
		cleanBar = transform.Find ("Clean Bar").Find("Foreground").gameObject;
		hungryBar = transform.Find ("Hungry Bar").Find("Foreground").gameObject;
		sleepyBar = transform.Find ("Sleep Bar").Find("Foreground").gameObject;

	}
	
	// Update is called once per frame
	void Update () {
		#if UNITY_EDITOR
//		Debug.Log("Unity Editor");
		
		#elif UNITY_IPHONE
		Debug.Log("Unity iPhone");
		
		#else
		status_health_value = ClassReferences.CallStatic<float>("getFloat", null, jo, Constants.KEY_STATUS_HEALTH_VALUE);
		status_happy_value = ClassReferences.CallStatic<float>("getFloat", null, jo, Constants.KEY_STATUS_HAPPY_VALUE);
		status_clean_value = ClassReferences.CallStatic<float>("getFloat", null, jo, Constants.KEY_STATUS_CLEAN_VALUE);
		status_hungry_value = ClassReferences.CallStatic<float>("getFloat", null, jo, Constants.KEY_STATUS_HUNGRY_VALUE);
		status_sleepy_value = ClassReferences.CallStatic<float>("getFloat", null, jo, Constants.KEY_STATUS_SLEEPY_VALUE);
		#endif

		// Amount of Status Bar
		fillStatusBar ();

	}

	// Controll Status Bar Amount
	private void fillStatusBar(){
		healthBar.GetComponent<UISprite> ().fillAmount = status_health_value;
		happyBar.GetComponent<UISprite> ().fillAmount = status_happy_value;
		cleanBar.GetComponent<UISprite> ().fillAmount = status_clean_value;
		hungryBar.GetComponent<UISprite> ().fillAmount = status_hungry_value;
		sleepyBar.GetComponent<UISprite> ().fillAmount = status_sleepy_value;
	}

	public float getStatusValue(int key){
		if(key==STATUS_HAPPY_KEY)
			return status_happy_value;
		else if(key==STATUS_CLEAN_KEY)
			return status_clean_value;
		else if(key==STATUS_HUNGRY_KEY)
			return status_hungry_value;
		else if(key==STATUS_SLEEPY_KEY)
			return status_sleepy_value;
		else
			return status_health_value;
	}

	void OnGUI(){
		GUI.Label (new Rect (10, 10, 100, 20), status_health_value + "");
	}

}
