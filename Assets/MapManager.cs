using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class MapManager : MonoBehaviour
{

	public GameObject[] outWallArray;
	public GameObject[] floorArray;

	public int rows=10;
	public int cols=10;
	

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		
		
	}

	private void InitMap()
	{


		for (int x=0;x<cols;x++ )

		for (int y = 0; y < rows; y++)
		{
			if (x == 0 || y == 0 || x == cols - 1 || y == rows - 1)
			{
				int index = Random.Range(0, outWallArray.Length);
				GameObject.Instantiate(outWallArray[index], new Vector3(x, y, 0), Quaternion.identity);
			}
		} ;
		
		
	}
	
	
}
