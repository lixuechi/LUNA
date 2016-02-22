using UnityEngine;
using System.Collections;

public class RaindropControl : MonoBehaviour {

	public Sprite[] raindrop;
	int index = 0;
	int framesPerSecond = 20;
	SpriteRenderer spriteRenderer;

	void Start () {
		spriteRenderer = GetComponent("SpriteRenderer") as SpriteRenderer;
	}
	
	void Update () {
		if(raindrop != null)
		{
			index = (int)(framesPerSecond * Time.timeSinceLevelLoad % raindrop.Length);
		}
		spriteRenderer.sprite = raindrop[index];
	}
}
