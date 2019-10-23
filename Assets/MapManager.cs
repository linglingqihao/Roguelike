using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityScript.Scripting.Pipeline;
using UnityScript.Steps;
 
public class MapManager : MonoBehaviour
{

	public GameObject[] outWallArray;
	public GameObject[] floorArray;
	public GameObject[] wallArray;
	public GameObject[] foodArray;
	public GameObject[] enemyArray;
	public GameObject exitPrefab;

	public int rows=10;
	public int cols=10;
    public int minCountWall = 2;
	public int maxCountwall = 8;
	
	private Transform mapHolder;
	private List<Vector2> positionList = new List<Vector2>();
    private GameManager game001Manager;

	// Use this for initialization
	void Awake ()
	{
	game001Manager = this.GetComponent<GameManager>();   
	InitMap();
	}
	
	// Update is called once per frame
	void Update () {
		
		
		
	}

	private void InitMap()
	{
		mapHolder = new GameObject("Map").transform;

		for (int y = 0; y < rows; y++)
		{
			for (int x = 0; x < cols; x++)
			
			 
			if (x == 0 || y == 0 || x == cols - 1 || y == rows - 1)
			{
				int index = Random.Range(0, outWallArray.Length);
				GameObject go=GameObject.Instantiate(outWallArray[index], new Vector3(x, y, 0), Quaternion.identity)as GameObject ;
				go.transform.SetParent(mapHolder ); 
			}
			else
			{
				int index = Random.Range(0, outWallArray.Length);                                       
				GameObject go=GameObject.Instantiate(floorArray [index], new Vector3(x, y, 0), Quaternion.identity)as GameObject ;
				go.transform.SetParent(mapHolder);
			}
               };
		 positionList.Clear();
		for (int x = 2; x < cols - 2; x++)
		{
			for (int y = 2; y < rows - 2; y++)
			{
				positionList.Add(new Vector2(x, y));

				int wallCount = Random.Range(minCountWall, maxCountwall+1);//障碍物个数
				for (int i = 0; i < wallCount; i++)
				{
				//位置	
					Vector2 pos = Randomposition();
					
					
					//障碍物
					GameObject wallPrefab = RandomPrefab(wallArray); 
					GameObject go1 = GameObject.Instantiate(wallPrefab, pos, Quaternion.identity) as GameObject;
					go1.transform.SetParent(mapHolder);
				}
    //创建食物
				int foodCount = Random.Range(2, game001Manager.level * 2 + 1);
				for (int i = 0; i < foodCount; i++)
				{
					Vector2 pos = Randomposition();
					GameObject foodPrefab = RandomPrefab(foodArray);
					GameObject go2=Instantiate(foodPrefab, pos, Quaternion.identity)as GameObject ;
					go2.transform.SetParent(mapHolder);
               } 
				//敌人个数
				int enemyCount = game001Manager.level / 2;
				for (int i = 0; i < enemyCount; i++)
				{
					Vector2 pos = Randomposition();
					GameObject enemyPrefab = RandomPrefab(enemyArray );
					GameObject go3 = Instantiate(enemyPrefab, pos, Quaternion.identity) as GameObject;
					go3.transform.SetParent(mapHolder);

				} 
				//创建出口
				GameObject go4=Instantiate(exitPrefab, new Vector2(cols - 2, rows - 2), Quaternion.identity) as GameObject;
				go4.transform.SetParent(mapHolder);
			} 
		} 
   }
	private Vector2 Randomposition()
	{
		int positionIndex = Random.Range(0, positionList.Count);
		Vector2 pos = positionList[positionIndex];
		positionList.RemoveAt(positionIndex);
		return pos;
	}

	private GameObject RandomPrefab(GameObject[] prefabs)
	{
		int index = Random.Range(0, prefabs.Length);
		return prefabs[index];
	}
	
}

	