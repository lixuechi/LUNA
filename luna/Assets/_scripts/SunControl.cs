using UnityEngine;
using System.Collections;

public class SunControl : MonoBehaviour {

	Vector3 moveHorizontalOffset = new Vector3(0.1f, 0, 0);
	Vector3 moveVerticalOffset = new Vector3(0, 0.1f, 0);

	public AudioSource bgm;

	Vector3 mouseScreenPos;
	Vector3 mouseWorldPos;

	const float MOUSE_DIST = 0.5f;

	RaycastHit hit;
	string hitGOTag = "";

	void Start () {
	
	}

	void OnEnable()
	{
		if(this.gameObject.activeInHierarchy && !bgm.isPlaying)
		{
			bgm.Play();
		}
	}
	
	void Update () {

		// keyboard
		if(Input.GetKey(KeyCode.RightArrow))
		{
			this.transform.position += moveHorizontalOffset;
		} 
		if(Input.GetKey(KeyCode.LeftArrow))
		{
			this.transform.position -= moveHorizontalOffset;
		}
		if(Input.GetKey(KeyCode.UpArrow))
		{
			this.transform.position += moveVerticalOffset;
		}
		if(Input.GetKey(KeyCode.DownArrow))
		{
			this.transform.position -= moveVerticalOffset;
		}

		// mouse
		if(Input.GetMouseButton(0))
		{ // left click
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if(Physics.Raycast(ray, out hit))
			{
				hitGOTag = hit.collider.gameObject.tag; 
			}

			if(hitGOTag == "sun")
			{
				mouseScreenPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
				mouseWorldPos = Camera.main.ScreenToWorldPoint( mouseScreenPos );
				transform.position = new Vector3(mouseWorldPos.x, mouseWorldPos.y, transform.position.z);
	
			}
			else if(mouseWorldPos.x - transform.position.x < MOUSE_DIST
				    && mouseWorldPos.y - transform.position.y < MOUSE_DIST)
			{
				mouseScreenPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
				mouseWorldPos = Camera.main.ScreenToWorldPoint( mouseScreenPos );
				transform.position = new Vector3(mouseWorldPos.x, mouseWorldPos.y, transform.position.z);
	
			}
			//mouseScreenPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
			//mouseWorldPos = Camera.main.ScreenToWorldPoint( mouseScreenPos );
			//transform.position = new Vector3(mouseWorldPos.x, mouseWorldPos.y, transform.position.z);
		}
	}
}
