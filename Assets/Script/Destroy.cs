using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour {

	// Use this for initialization
	public GameObject bullet;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		DestroyBullet ();
	}
	void DestroyBullet()
	{
		Destroy (bullet);
	}
}
