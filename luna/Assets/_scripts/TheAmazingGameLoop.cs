using UnityEngine;
using System.Collections;

public class TheAmazingGameLoop : MonoBehaviour {

	public GameObject gameWinO;
	public Transform Dick;
	public Transform[] Grass;
	int lenOfGrass = 20;
	int goodLenOfGrass = 10;
	int currHighGrass = 0;
	bool dickWin = false;
	bool grassWin = false;
	bool gameWin = false;

	const float HIGH_GRASS_THRESHOLD = 1.5f;
	const float DICK_WIN_THRESHOLD = 0.8f;

	void Start () {
		if(Grass != null)
		{
			lenOfGrass = Grass.Length;
			goodLenOfGrass = lenOfGrass >> 1;
		}
	}
	
	void Update () {

		currHighGrass = 0;
		for(int i = 0; i < lenOfGrass; i++)
		{
			if(Grass[i].localScale.y > HIGH_GRASS_THRESHOLD)
			{
				currHighGrass++;
			}
		}
		if(currHighGrass > goodLenOfGrass)
		{
			grassWin = true;
		}
		
		if(gameWin)
		{
			if(!gameWinO.activeInHierarchy)
			{
				gameWinO.SetActive(true);
			}
		}

		if(dickWin && grassWin)
		{
			gameWin = true;
		}

		if(Dick.localScale.y >= DICK_WIN_THRESHOLD)
		{
			if(!dickWin)
			{
				dickWin = true;
			}
			
		}
		else
		{
			dickWin = false;
		}

	}
}
