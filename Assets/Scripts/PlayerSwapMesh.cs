using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PlayerSwapMesh : MonoBehaviour
{
	
	public GameObject MarbleInnerBit;
	private Mesh HeartObject;
	private Mesh HeartMesh;
	private Mesh AdaObject;
	private Mesh AdaMesh;
	private Mesh DiamondObject;
	private Mesh DiamondMesh;
	private Mesh DuckObject;
	private Mesh DuckMesh;
	
	void Start()
	{
		HeartObject = Resources.Load<Mesh>("HeartCore");
		DuckObject = Resources.Load<Mesh>("duck");
		AdaObject = Resources.Load<Mesh>("AdaCore");
		DiamondObject = Resources.Load<Mesh>("DiamondCore");
		
	
	}
	
    
    void Update()
	{
		if (Input.GetKey(KeyCode.H))
		{
			
			HeartMesh = Instantiate(HeartObject, MarbleInnerBit.transform.position, Quaternion.identity);
			
			MarbleInnerBit.GetComponent<MeshFilter>().mesh = HeartMesh;
		}
		
		
		if (Input.GetKey(KeyCode.J))
		{
			
			AdaMesh = Instantiate(AdaObject, MarbleInnerBit.transform.position, Quaternion.identity);
			
			MarbleInnerBit.GetComponent<MeshFilter>().mesh = AdaMesh;
		}
		
		
		if (Input.GetKey(KeyCode.K))
		{
			
			DiamondMesh = Instantiate(DiamondObject, MarbleInnerBit.transform.position, Quaternion.identity);
			
			MarbleInnerBit.GetComponent<MeshFilter>().mesh = DiamondMesh;
		}
		
		
		if (Input.GetKey(KeyCode.L))
		{
			
			DuckMesh = Instantiate(DuckObject, MarbleInnerBit.transform.position, Quaternion.identity);
			
			MarbleInnerBit.GetComponent<MeshFilter>().mesh = DuckMesh;
		}
	}


    
}
