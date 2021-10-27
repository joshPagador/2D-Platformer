using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
	
	public  Transform follow;
	float myZ;

	// Use this for initialization
	void Start () {
		myZ = transform.position.z;	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (follow.position.x, follow.position.y, myZ);
	}
}
