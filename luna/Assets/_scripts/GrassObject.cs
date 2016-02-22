using UnityEngine;
using System.Collections;

public class GrassObject : Object {

	float maxHeight = 1;
	int spriteIndex = 0; // 0-3
	bool isThisGrassGrowing = false;
	float growTime = 1;

	public void SetMaxHeight(float mh)
	{
		maxHeight = mh;
	}

	public float GetMaxHeight()
	{
		return maxHeight;
	}

	public void SetSpriteIndex(int si)
	{
		spriteIndex = si;
	}

	public int GetSpriteIndex()
	{
		return spriteIndex;
	}

	public void SetIsThisGrassGrowing(bool sitgg)
	{
		isThisGrassGrowing = sitgg;
	}

	public bool GetIsThisGrassGrowing()
	{
		return isThisGrassGrowing;
	}

	public void SetGrowTime(float gt)
	{
		growTime = gt;
	}

	public float GetGrowTime()
	{
		return growTime;
	}
}
