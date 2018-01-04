using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {


    public GameObject GO;
    public Transform tr;
    public Vector3 Rotation;
	// Use this for initialization
	void Start ()
    {
        tr = GO.transform;
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (Input.GetKey(KeyCode.D))
        {
            tr.rotation = Quaternion.Euler(0, 100, 0);
            Rotation = tr.rotation.eulerAngles;
        }
	}
}
