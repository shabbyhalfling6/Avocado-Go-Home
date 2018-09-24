using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public Transform target;

    public float cameraSmooth = 0.75f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(target != null)
             transform.position = new Vector3(Mathf.Lerp(transform.position.x, target.position.x, cameraSmooth),
                                             transform.position.y, 
                                             transform.position.z);
    }
}
