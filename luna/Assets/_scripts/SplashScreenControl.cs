using UnityEngine;
using System.Collections;

public class SplashScreenControl : MonoBehaviour {

	public GameObject Sun;
	float newTime;
	float baseTime;
	GUITexture guiTexture;
	Color guiColor;
	bool toNextLevel = false;

	void Awake()
	{
	}

	void Start () {
		newTime = Time.time;
		baseTime = newTime;

		guiTexture = GetComponent("GUITexture") as GUITexture;
		guiColor = guiTexture.color;

		if(Sun != null)
		{
			Sun.SetActive(false);
		}
	}
	
	void Update () {
		newTime = Time.time;
		if(!toNextLevel && newTime - baseTime > 3f)
		{
			toNextLevel = true;
		}

		if(toNextLevel)
		{
			if(guiColor.a > 0)
			{
				guiColor.a -= 0.01f;
				guiTexture.color = guiColor;
			}
			else
			{
				Sun.SetActive(true);
				this.gameObject.SetActive(false);
			}
		}
	}
}
