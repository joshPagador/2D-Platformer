using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCube : MonoBehaviour {

	// Use this for initialization
	void Start () {
	//	transform.position = new Vector3 (10f, 10f, 10f);
	}
	
	// Update is called once per frame
	void Update () {
		// x moves right or left, y moves up and down, z moves forward or backwards
		// Time.deltaTime corresponds with the axis in accordance to the fps
		transform.Translate (0, 0, 2f * Time.deltaTime);
		
	}
}
