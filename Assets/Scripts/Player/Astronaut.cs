using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astronaut : MonoBehaviour
{
    public static Vector3 origin;
    // Start is called before the first frame update
    void Start()
    {
        origin = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if((PlayerMovement.sliding == false && PlayerMovement.jumping == false && PlayerMovement.comingDown == false && transform.position.y != origin.y) || PlayerMovement.gettingup == true)
        {
            Vector3 gotofloor = new Vector3(transform.position.x, origin.y, transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, gotofloor, Time.deltaTime * PlayerMovement.verticalSpeed);
        }
    }
}
