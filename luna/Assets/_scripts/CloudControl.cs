using UnityEngine;
using System.Collections;

public class CloudControl : MonoBehaviour {

	public GameObject RaindropPrefab;
	public AudioSource rainSfx;
	public Sprite[] cloudSprite;
	GameObject[] RaindropInstance = new GameObject[5];
	float newRainTime;
	float oldRainTime;
	int currRainIdx = 0;
	Vector3 raindropOffset = new Vector3(0, 3, 0);
	Vector3 cloudShrinkOffset = new Vector3(0.01f, 0.01f, 0);
	bool cloudShrink = false;
	bool cloudFade = false;
	bool killCloud = false;
	bool cloudExist = true;
	bool awaitRespawn = false;
	SpriteRenderer spriteRenderer;
	Color cloudColor;
	Color cloudFadeOffset = new Color(0, 0, 0, 0.01f);
	float cloudScaleFactor;
	float respawnCurrTime;
	float respawnBaseTime;
	int randomCloudType = 0;
	Vector3 originalScale;

	void Start () {
		newRainTime = Time.time;
		oldRainTime = newRainTime;

		spriteRenderer = GetComponent("SpriteRenderer") as SpriteRenderer;
		cloudColor = spriteRenderer.color;

		cloudScaleFactor = transform.localScale.x * 0.6f;

		originalScale = transform.localScale;

		cloudExist = true;
	}
	
	void Update () {
		newRainTime = Time.time;
		
		if(awaitRespawn)
		{
			respawnCurrTime = Time.time;

			if(respawnCurrTime - respawnBaseTime >= 1f)
			{
				if(cloudColor.a < 1)
				{
					cloudColor += cloudFadeOffset;
					spriteRenderer.color = cloudColor;
				}
				else
				{
					awaitRespawn = false;
					cloudExist = true;
				}
			}
		}

		if(cloudShrink)
		{
			if(transform.localScale.x > cloudScaleFactor)
			{
				transform.localScale -= cloudShrinkOffset;
			}
			else
			{
				cloudShrink = false;
				cloudFade = true;
			}
		}
		else if(cloudFade)
		{
			if(cloudColor.a > 0)
			{
				cloudColor -= cloudFadeOffset;
				spriteRenderer.color = cloudColor;
			}
			else
			{
				cloudFade = false;
				killCloud = true;
			}
		}
		else if(killCloud)
		{
			rainSfx.Stop();
			cloudExist = false;
			killCloud = false;
			awaitRespawn = true;

			respawnBaseTime = Time.time;
			respawnCurrTime = respawnBaseTime;

			randomCloudType = Random.Range(0, 4);
			spriteRenderer.sprite = cloudSprite[ randomCloudType ];

			transform.localScale = originalScale;
		}


		//if(cloudExist)
		{
			for(int i = 0; i < RaindropInstance.Length; i++)
			{
				if(RaindropInstance[i] != null && RaindropInstance[i].transform.position.y < -6)
				{
					Destroy(RaindropInstance[i], 0f);
				}			
			}			
		}

	}

	void OnTriggerEnter(Collider coll)
	{
		if(coll.gameObject.tag == "sun")
		{
			// rain
			//Debug.Log("Rain!");
			if(cloudExist)
			{
				if(!rainSfx.isPlaying)
				{
					rainSfx.Play();
				}
				
				RaindropInstance[currRainIdx] = Instantiate(RaindropPrefab, transform.position - raindropOffset, transform.rotation) as GameObject;
				IncrementRainIndex();
				cloudShrink = true;
			}

		}
		
	}

	void OnTriggerStay(Collider coll)
	{
		if(coll.gameObject.tag == "sun")
		{
			// constantly raining
			if(cloudExist && newRainTime - oldRainTime >= 0.6f)
			{
				if(!rainSfx.isPlaying)
				{
					rainSfx.Play();
				}
				
				RaindropInstance[currRainIdx] = Instantiate(RaindropPrefab, transform.position - raindropOffset, transform.rotation) as GameObject;
				oldRainTime = newRainTime;
				IncrementRainIndex();
				cloudShrink = true;
			}
			
		}
	}

	void IncrementRainIndex()
	{
		if(currRainIdx < RaindropInstance.Length - 1)
		{
			currRainIdx++;
		}
		else if(currRainIdx == RaindropInstance.Length - 1)
		{
			currRainIdx = 0;
		}
		else
		{
			// invalid
		}
	}
	/*
	IEnumerator AWait(int numOfSeconds)
	{
		print(Time.time);
		yield return new WaitForSeconds(numOfSeconds);
		print(Time.time);
	}
	*/
}
