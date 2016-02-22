using UnityEngine;
using System.Collections;

public class BabyGrassControl : MonoBehaviour {

	float maxHeight = 1;
	int spriteIndex = 0; // 0-3
	bool isThisGrassGrowing = false;
	float growTime = 1;

	public Sprite[] grassSprite;
	//public GameObject[] grassGO;
	SpriteRenderer spriteRenderer;
	GrassObject[] grass;
	int lenOfGrass = 0;
	float randomMaxHeight = 1;
	int randomSpriteIndex = 0;
	bool isGrassGrowing = false;
	float currGrassScale = 0;
	float growTimeFactor = 10;
	int growFlag = 0;
	float newGrowTime = 0;
	float oldGrowTime = 0;
	float randomGrowTime = 1;
	float growRate = 0.5f;

	BoxCollider boxCollider;

	void Start () {
		newGrowTime = Time.time;
		oldGrowTime = newGrowTime;

		randomMaxHeight = Random.Range(1f, 2f);
			
		randomSpriteIndex = Random.Range(0, 4);
			
		isThisGrassGrowing = false;
			
		randomGrowTime = Random.Range(0.1f, 2f);

		spriteRenderer = GetComponent("SpriteRenderer") as SpriteRenderer;
		spriteRenderer.sprite = grassSprite[ randomSpriteIndex ];

		boxCollider = GetComponent("BoxCollider") as BoxCollider;
	}
	
	void Update () {
	
		newGrowTime = Time.time;

		if(isGrassGrowing)
		{
			growRate = 0.5f;
			transform.localScale += 
				new Vector3(0, 10 * growRate * randomMaxHeight /** Time.deltaTime */, 0);

			isGrassGrowing = false;
						
		} // end isGrassGrowing
	}

	void OnTriggerEnter(Collider coll)
	{
		if(coll.gameObject.tag == "rain")
		{
			transform.localScale += new Vector3(0, growRate, 0);
			boxCollider.size += new Vector3(0, growRate, 0);
		}
		else if(coll.gameObject.tag == "sun")
		{
			transform.localScale -= new Vector3(0, growRate, 0);
			boxCollider.size -= new Vector3(0, growRate, 0);
		}
	}

	void OnTriggerStay(Collider coll)
	{
		if(coll.gameObject.tag == "sun")
		{
			transform.localScale -= new Vector3(0, growRate, 0);
			boxCollider.size -= new Vector3(0, growRate, 0);
		}
	}
}
