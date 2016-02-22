using UnityEngine;
using System.Collections;

public class SausageControl : MonoBehaviour {

	const int BOTTOM_LINE = -20;

	void Start () {
	
	}
	
	void Update () 
	{

		if(this.transform.position.y < BOTTOM_LINE)
		{
			Destroy(this.gameObject);
		}

	} // end Update
}
