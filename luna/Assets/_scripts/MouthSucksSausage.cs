using UnityEngine;
using System.Collections;

public class MouthSucksSausage : MonoBehaviour {

	bool isSucking = false;
	public GameObject handGO;

	Quaternion ZERO_QUATERNION = new Quaternion(0, 0, 0, 0);
	Vector3 START_SUCK_POS = new Vector3(-3f, -4.5f, 0);
	Vector3 END_SUCK_POS = new Vector3(-1.5f, -4.5f, 0);
	Vector3 BIG_SCALE = new Vector3(1.2f, 1.2f, 1);

	void Awake()
	{
		if(handGO.activeInHierarchy)
		{
			handGO.SetActive(false);
		}
	}

	void Start () {
	
	}
	
	void Update () {

	}

	void OnTriggerEnter(Collider coll)
	{
		if(coll.gameObject.tag == "sausage")
		{
			// suck
			if(coll.gameObject.GetComponent("Rigidbody") != null)
			{
				Destroy(coll.gameObject.GetComponent("Rigidbody") as Rigidbody);
			}
			
			coll.gameObject.transform.rotation = ZERO_QUATERNION;
			coll.gameObject.transform.localPosition = START_SUCK_POS;

			//isSucking = true;

			coll.gameObject.transform.localPosition = END_SUCK_POS;
			coll.gameObject.transform.localScale = BIG_SCALE;
			coll.gameObject.tag = null; // cannot move sausage anymore

			if(!handGO.activeInHierarchy)
			{
				handGO.SetActive(true);
				Destroy(coll.gameObject);
			}
		}
	}
}
