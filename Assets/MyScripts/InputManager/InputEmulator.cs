using UnityEngine;
using System.Collections;

public class InputEmulator
{

		public static bool getTouchDown ()
		{
				if (Constants.BUILD_MOBILE == 0)
						return Input.GetMouseButtonDown (0);
				else
						return (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began);
		}

}
