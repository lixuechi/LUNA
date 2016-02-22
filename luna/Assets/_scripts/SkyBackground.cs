using UnityEngine;
using System.Collections;

public class SkyBackground : MonoBehaviour {

	GUITexture guiTexture;
	int currScreenWidth;
	int currScreenHeight;

	void Start () {
		guiTexture = GetComponent("GUITexture") as GUITexture;
		currScreenWidth = Screen.width;
		currScreenHeight = Screen.height;
		guiTexture.pixelInset = new Rect(0, 0, currScreenWidth, currScreenHeight);
	}
	
	void Update () {
		if(guiTexture != null 
			&& currScreenHeight != Screen.height 
			&& currScreenWidth != Screen.width)
		{
			currScreenWidth = Screen.width;
			currScreenHeight = Screen.height;
			guiTexture.pixelInset = new Rect(0, 0, currScreenWidth, currScreenHeight);
		}
	}
}
