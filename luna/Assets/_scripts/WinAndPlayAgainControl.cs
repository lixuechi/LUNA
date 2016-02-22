using UnityEngine;
using System.Collections;

public class WinAndPlayAgainControl : MonoBehaviour {

	public GameObject quote;
	public GameObject playAgain;
	public GameObject splashScreen;
	int maxQuoteY = 6;
	int minQuoteY = -8;
	SpriteRenderer paSpriteRenderer;
	bool showPlayAgain = false;
	bool canPlayAgain = false;

	void Start () {
		paSpriteRenderer = playAgain.GetComponent("SpriteRenderer") as SpriteRenderer;

	}
	
	void Update () {
		
		// show quote
		if(quote.transform.position.y < maxQuoteY)
		{
			quote.transform.position += new Vector3(0, 0.05f, 0);
		}
		else
		{
			showPlayAgain = true;
		}
		

		// show playAgain
		if(paSpriteRenderer.color.a < 1)
		{
			if(showPlayAgain)
			{
				paSpriteRenderer.color += new Color(0, 0, 0, 0.005f);
			}
			
		}
		else
		{
			canPlayAgain = true;
		}

		if(canPlayAgain)
		{
			if(Input.GetKey(KeyCode.Space)
				|| Input.GetMouseButton(0))
			{
				Application.LoadLevel("level1");
				if(splashScreen.activeInHierarchy)
				{
					splashScreen.SetActive(false);
				}
			}
		}
	}
}
