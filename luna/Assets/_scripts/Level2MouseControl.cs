using UnityEngine;
using System.Collections;

public class Level2MouseControl : MonoBehaviour {

// <sausage>
	public Sprite actSausage;
	public Sprite deactSausage;

	SpriteRenderer sausageRenderer;
	BoxCollider sausageCollider;

	bool refillSausage = false;
	bool firstSausageAbsent = false;
	bool firstSausageDead = false;

	const int ACTIVE = 0;
	const int INACTIVE = 1;
	int[] sausageStatus = {ACTIVE, INACTIVE, INACTIVE, INACTIVE, INACTIVE};
	public GameObject[] sausageGOs;
// <sausage>

	Vector3 mouseScreenPos;
	Vector3 mouseWorldPos;
	RaycastHit hit;
	string hitGOTag = "";
	GameObject hitGO = null;
	GameObject fallingGO = null;

	Vector3 SAUSAGE_DIST = new Vector3(-1, 0, 0);
	Vector3 FOURTH_SAUSAGE_POS = new Vector3(1, 5, 0);
	Vector3 FIFTH_SAUSAGE_POS = new Vector3(1, 10, 0);
	const int SAUSAGE_ROTATION_Z = 300;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		// mouse
		if(Input.GetMouseButton(0))
		{ // left click
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if(Physics.Raycast(ray, out hit))
			{
				hitGO = hit.collider.gameObject;
				if(hitGOTag != null)
				{
					if(hitGO != null)
					{
						hitGOTag = hitGO.tag;
					}
					
				}

			}
		}	
		if(Input.GetMouseButtonUp(0))
		{
			if(hitGOTag == "sausage")
			{
				firstSausageAbsent = false;
				if(hitGO != null)
				{
					hitGO.AddComponent("Rigidbody");
				}
				
			}
			hitGO = null;
		}


		if(hitGO != null)
		{
			if(hitGOTag == "sausage")
			{
				if( (hitGO.transform.position.x < -3 
					|| hitGO.transform.position.y < 3)
					&& !firstSausageAbsent )
				{
					refillSausage = true;
					firstSausageAbsent = true;
				}

				mouseScreenPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
				mouseWorldPos = Camera.main.ScreenToWorldPoint( mouseScreenPos );
				hitGO.transform.position = 
					new Vector3(mouseWorldPos.x, mouseWorldPos.y, hitGO.transform.position.z);

			}  			
		}

		if(refillSausage)
		{

			// move left the other 3 sausages by 1 unit
			sausageGOs[1].transform.position += SAUSAGE_DIST;
			sausageGOs[2].transform.position += SAUSAGE_DIST;
			sausageGOs[3].transform.position += SAUSAGE_DIST;
			sausageGOs[4].transform.position = FOURTH_SAUSAGE_POS;

			// pop the out-of-plate sausage from the stack
			for(int i = 1; i < 5; i++)
			{
				sausageGOs[i-1] = sausageGOs[i];
			}
			sausageGOs[4] = new GameObject("_sausage");
			sausageRenderer = sausageGOs[4].AddComponent("SpriteRenderer") as SpriteRenderer;
			sausageRenderer.sprite = deactSausage;
			sausageGOs[4].transform.position = FIFTH_SAUSAGE_POS;
			sausageGOs[4].transform.rotation = Quaternion.Euler(0, 0, SAUSAGE_ROTATION_Z);
			sausageGOs[4].gameObject.tag = null;
			sausageCollider = sausageGOs[4].AddComponent("BoxCollider") as BoxCollider;
			sausageCollider.isTrigger = true;

			sausageRenderer = sausageGOs[0].GetComponent("SpriteRenderer") as SpriteRenderer;
			sausageRenderer.sprite = actSausage;
			sausageGOs[0].gameObject.tag = "sausage";

			refillSausage = false;
		}

	}
}
