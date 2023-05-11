using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutsideGravity : MonoBehaviour
{
    public GameObject playerObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("changing gravity value");
        if (playerObject.GetComponent<PlayerMovement>().gravityToggle)
        {
            //playerObject.GetComponent<PlayerMovement>().gravity = 6;
            playerObject.GetComponent<PlayerMovement>().reverseGravity = false;
        } else
        {
            //playerObject.GetComponent<PlayerMovement>().gravity = 3;
            playerObject.GetComponent<PlayerMovement>().reverseGravity = true;
        }
        playerObject.GetComponent<PlayerMovement>().gravityToggle = !playerObject.GetComponent<PlayerMovement>().gravityToggle;
    }
}
