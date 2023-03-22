using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 10;
    public float leftRightSpeed = 4;
    static public bool canMove = false;
    public bool jumping = false;
    public bool comingDown = false;
    public GameObject playerObject;

    // Start is called before the first frame update
    void Start(){}

    // Update is called once per frame
    void Update()
    {
        // Vector3.forward is movement along the z-axis
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);
        if(canMove == true)
        {
            // Move left button pressed
            if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                if(this.gameObject.transform.position.x > LevelBoundary.leftSide)
                {
                    transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed);
                }
            }
            // Move left button pressed
            if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                if (this.gameObject.transform.position.x < LevelBoundary.rightSide)
                {
                    transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed * -1);
                }
            }
            // Jump
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Space))
            {
                if (jumping == false)
                {
                    jumping = true;
                    playerObject.GetComponent<Animator>().Play("Jump");
                    StartCoroutine(JumpSequence());
                }
            }
            if (jumping == true)
            {
                if(comingDown == false)
                {
                    transform.Translate(Vector3.up * Time.deltaTime * 3, Space.World);
                }
                if(comingDown == true)
                {
                    transform.Translate(Vector3.up * Time.deltaTime * -3, Space.World);
                }
            }
        }
    }

    IEnumerator JumpSequence()
    {
        yield return new WaitForSeconds(0.45f);
        comingDown = true;
        yield return new WaitForSeconds(0.45f);
        jumping = false;
        comingDown = false;
        playerObject.GetComponent<Animator>().Play("Standard Run");
    }

}
