using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public int speedDivider = 1;
    public Vector3 maxLeftRight = new Vector3(-3.2f, 3.4f);

    private Vector3 positionLeft = new Vector3(1, 0, 0);
    private Vector3 positionRight = new Vector3(1, 0, 0);
    private char dir = 'R';

    void Start()
    {
        positionLeft = new Vector3(positionLeft.x * maxLeftRight.x, transform.position.y, transform.position.z);
        positionRight = new Vector3(positionRight.x * maxLeftRight.y, transform.position.y, transform.position.z);
    }

    void Update()
    {
        //Move Up
        if (dir == 'R')
        {
            transform.position = Vector3.MoveTowards(transform.position, positionRight, Time.deltaTime / speedDivider);
            if (transform.position.x == positionRight.x)
            {
                dir = 'L';
                transform.Rotate(new Vector3(0, 180, 0));
            }
        }
        //Move Down
        else if (dir == 'L')
        {
            transform.position = Vector3.MoveTowards(transform.position, positionLeft, Time.deltaTime / speedDivider);
            if (transform.position.x == positionLeft.x)
            {
                dir = 'R';
                transform.Rotate(new Vector3(0, 180, 0));
            }
        }
    }
}
