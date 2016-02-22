using UnityEngine;
using System.Collections;

public class MountainControl : MonoBehaviour {

	SpriteRenderer spriteRenderer;
	Vector3 scaleYOffset = new Vector3(0, 0.05f, 0);
	string thisTag;

	void Start () {
		spriteRenderer = GetComponent("SpriteRenderer") as SpriteRenderer;

		thisTag = this.gameObject.tag;
	}
	
	void Update () {
	
	}

	void OnTriggerEnter(Collider coll)
	{
		if(coll.gameObject.tag == "rain")
		{
			transform.localScale += scaleYOffset;
		}
		else if(coll.gameObject.tag == "sun" && thisTag != "dick")
		{
			transform.localScale -= scaleYOffset;
		}
	}

	void OnTriggerStay(Collider coll)
	{
		if(coll.gameObject.tag == "sun" && thisTag != "dick")
		{
			transform.localScale -= scaleYOffset;
		}
	}
}
