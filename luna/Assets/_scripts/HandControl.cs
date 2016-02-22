using UnityEngine;
using System.Collections;

public class HandControl : MonoBehaviour {

	bool isHandAppearing = !false;

	float handMaxY = -1.8f;
	float handMinY = -3.3f;

	public GameObject sausageHalvesGO;
	public GameObject sausageLeftHalfGO;
	public GameObject sausageRightHalfGO;

	public GameObject vProgressGO;
	int masturCounter = 0; 
	public GameObject faceGO;
	SpriteRenderer faceRenderer;
	public Sprite faceSuck;
	public Sprite faceClose1;
	public Sprite faceOpen1;
	public Sprite faceClose2;
	public Sprite faceOpen2;
	public Sprite faceEcstasy;
	Sprite faceClose;
	Sprite faceOpen;

	int masturRate = 1;
	const int RATE_1X = 1;
	const int RATE_2X = 2;

	bool canMasturbate = true;

	float beginEcstasyTime = 0;
	float endEcstasyTime = 0;

	bool isInEcstasy = false;

	Vector3 sLeftHalfVelocity = new Vector3(-0.05f, 0, 0);
	Vector3 sRightHalfVelocity = new Vector3(0.05f, 0, 0);

	const float BASE_HAND_SPEED = 0.05f;
	Vector3 HAND_APPEAR_SPEED = new Vector3(-0.1f, 0, 0);
	const int MASTUR_COUNT_1X = 10;
	const int MASTUR_COUNT_2X = 20;
	Vector3 SAUSAGE_HALF_BASE_POS = new Vector3(-1.5f, 0, 0);
	const int ECSTASY_LASTING_TIME = 3;
	const float HAND_APPEAR_DEST_X = 1.2f;

	void Start () {
		faceRenderer = faceGO.GetComponent("SpriteRenderer") as SpriteRenderer;
		faceClose = faceClose1;
		faceOpen = faceOpen1;

		masturRate = RATE_1X;

		if(!sausageHalvesGO.activeInHierarchy)
		{
			sausageHalvesGO.SetActive(true);
		}
	}

	void OnEnable()
	{
		if(!sausageHalvesGO.activeInHierarchy)
		{
			sausageHalvesGO.SetActive(true);
		}
	}
	
	void Update () {

		if(isInEcstasy)
		{
			endEcstasyTime = Time.time;

			sausageLeftHalfGO.transform.position += sLeftHalfVelocity;
			sausageRightHalfGO.transform.position += sRightHalfVelocity;
			//Debug.Log(endEcstasyTime + " - " + beginEcstasyTime);
			if(endEcstasyTime - beginEcstasyTime >= ECSTASY_LASTING_TIME)
			{
				isInEcstasy = false;
				faceRenderer.sprite = faceSuck;
				canMasturbate = true;

				Destroy( sausageLeftHalfGO.GetComponent("Rigidbody") as Rigidbody );
				Destroy( sausageRightHalfGO.GetComponent("Rigidbody") as Rigidbody );
				sausageLeftHalfGO.transform.localPosition = SAUSAGE_HALF_BASE_POS;
				sausageRightHalfGO.transform.localPosition = SAUSAGE_HALF_BASE_POS;
				sausageHalvesGO.SetActive(false);

				this.gameObject.SetActive(false);
			}
		}
		else
		{
			if(masturCounter < MASTUR_COUNT_1X)
			{
				if(faceClose != faceClose1)
				{
					faceClose = faceClose1;
				}
				if(faceOpen != faceOpen1)
				{
					faceOpen = faceOpen1;
				}

				if(masturRate != RATE_1X)
				{
					masturRate = RATE_1X;
				}
			}
			else if(masturCounter < MASTUR_COUNT_2X)
			{
				if(faceClose != faceClose2)
				{
					faceClose = faceClose2;
				}
				if(faceOpen != faceOpen2)
				{
					faceOpen = faceOpen2;
				}

				if(masturRate != RATE_2X)
				{
					masturRate = RATE_2X;
				}
			}
			else
			{
				//faceClose = faceEcstasy;
				//faceOpen = faceEcstasy;
				faceRenderer.sprite = faceEcstasy;
				canMasturbate = false;

				isInEcstasy = true;
				masturCounter = 0;
				beginEcstasyTime = Time.time;
				endEcstasyTime = beginEcstasyTime;

				// the 2 halves of the sausage falls
				if(sausageHalvesGO.activeInHierarchy
					&& sausageLeftHalfGO.activeInHierarchy
					&& sausageRightHalfGO.activeInHierarchy)
				{
					Rigidbody sRG = sausageLeftHalfGO.AddComponent("Rigidbody") as Rigidbody;
					sRG = sausageRightHalfGO.AddComponent("Rigidbody") as Rigidbody;
				}
			}
		}

		// Entering hand
		if(isHandAppearing)
		{
			if(this.transform.position.x > HAND_APPEAR_DEST_X)
			{
				this.transform.position += HAND_APPEAR_SPEED;
			}
			else
			{
				isHandAppearing = false;
			}
		}

		if(canMasturbate)
		{
			if(Input.GetKey(KeyCode.UpArrow))
			{ // move hand up
				if(this.transform.position.y < handMaxY)
				{
					this.transform.position += new Vector3(0, BASE_HAND_SPEED * masturRate, 0);
				}
				else
				{
					masturCounter++;
				}
				faceRenderer.sprite = faceClose;
				
			}
			if(Input.GetKey(KeyCode.DownArrow))
			{ // move hand down
				if(this.transform.position.y > handMinY)
				{
					this.transform.position -= new Vector3(0, BASE_HAND_SPEED * masturRate, 0);
				}
				else
				{
					masturCounter++;
				}
				faceRenderer.sprite = faceOpen;
				
			}	
		}


	}
}
