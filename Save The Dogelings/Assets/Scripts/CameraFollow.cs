using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public GameObject ToFollow;
    public Vector3 offset;

	
	// Update is called once per frame
	void Update () {

        if (ToFollow.GetComponent<DogeMovement>().enabled == true)
        {
            if (ToFollow.transform.position.y > transform.position.y)
            {
                transform.position = new Vector3(transform.position.x, ToFollow.transform.position.y, transform.position.z) + offset;

            }
        }   
        else
        {
            transform.position = new Vector3(transform.position.x, ToFollow.transform.position.y, transform.position.z) + offset;

        }




    }
}
