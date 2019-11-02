using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	private static GameManager _instance;

	public static GameManager Instance
	{
		get { return _instance; }
	}


	public int level = 1;//第一关
	public int food = 100;
	

    // Use this for initialization
    void Awake ()
    {
	    _instance = this;
    }

	public void ReduceFood(int count)
	{
		food -= count;
	}

	public void AddFood(int count)
	{
		food += count;
	}
}
