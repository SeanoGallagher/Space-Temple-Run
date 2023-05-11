using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5;
    static public bool canMove = false;
    public static bool jumping = false;
    public static bool sliding = false;
    public static bool comingDown = false;
    public static bool gettingup = false;
    public GameObject playerObject;
    public GameObject alienObject;

    public Vector3 LeftMiddleRight = new Vector3(-2.5f, 0f, 2.5f);
    private Vector3 turnLeft = new Vector3(0, -25f, 0);
    private Vector3 turnRight = new Vector3(0, 25f, 0);
    private Vector3 turnDirection;
    public static Vector3 floor = new Vector3(-0.6f, 1.25f, -0.5f); //Astronaut, Player, Alien
    public float laneChangeSpeed = 3;
    public static float verticalSpeed = 2;
    public int gravity = 3;
    public bool gravityToggle = false;
    public bool reverseGravity = false;
    private char moveTo = 'm';
    private Vector3 newLane;
    private bool changinglanes = false;

    // Start is called before the first frame update
    void Start(){}

    // Update is called once per frame
    void Update()
    {
        // Move Player Forward
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);
        if(canMove == true)
        {
            // Move left button pressed
            if((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) & changinglanes == false)
            {
                //Right Lane -> Middle Lane
                if(moveTo == 'r' & changinglanes == false)
                {
                    moveTo = 'm';
                    changinglanes = true;
                }
                //Middle Lane -> Left Lane
                if (moveTo == 'm' & changinglanes == false)
                {
                    moveTo = 'l';
                    changinglanes = true;
                }
                turnDirection = turnLeft;
            }
            // Move Right button pressed
            if((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) & changinglanes == false)
            {
                //Left Lane -> Middle Lane
                if (moveTo == 'l' & changinglanes == false)
                {
                    moveTo = 'm';
                    changinglanes = true;
                }
                //Middle Lane -> Right Lane
                if (moveTo == 'm' & changinglanes == false)
                {
                    moveTo = 'r';
                    changinglanes = true;
                }
                turnDirection = turnRight;
            }
            // Jump
            if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Space)) && sliding == false)
            {
               if (jumping == false)
                {
                    jumping = true;
                    playerObject.GetComponent<Animator>().Play("Astronaut_Jump");
                    StartCoroutine(JumpSequence());
                }
            }
            if (jumping == true)
            {
                if(comingDown == false)
                {
                    transform.Translate(Vector3.up * Time.deltaTime * gravity, Space.World);
                }
            }

            //Slide
            if ((Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) && jumping == false)
            {
                if (sliding == false)
                {
                    sliding = true;
                    playerObject.GetComponent<Animator>().Play("Astronaut_Slide");
                    StartCoroutine(SlideSequence());
                }
            }
            if (sliding == true)
            {
                if (gettingup == false)
                {
                    transform.Translate(Vector3.up * Time.deltaTime * 3, Space.World);
                }
            }

            if (changinglanes == true)
            {
                if(moveTo == 'l')
                {
                    if (transform.position.x == LeftMiddleRight.x)
                    {
                        changinglanes = false;
                    }
                    else
                    {
                        newLane = new Vector3(LeftMiddleRight.x, transform.position.y, transform.position.z);
                    }
                }
                else if (moveTo == 'm')
                {
                    if (transform.position.x == LeftMiddleRight.y)
                    {
                        changinglanes = false;
                    }
                    else
                    {
                        newLane = new Vector3(LeftMiddleRight.y, transform.position.y, transform.position.z);
                    }
                }
                else if(moveTo == 'r')
                {
                    if (transform.position.x == LeftMiddleRight.z)
                    {
                        changinglanes = false;
                    }
                    else
                    {
                        newLane = new Vector3(LeftMiddleRight.z, transform.position.y, transform.position.z);
                    }
                }

                if (changinglanes == true)
                {
                    transform.position = Vector3.MoveTowards(transform.position, newLane, Time.deltaTime * laneChangeSpeed);
                    playerObject.transform.eulerAngles = turnDirection;
                } else
                {
                    playerObject.transform.eulerAngles = Vector3.zero;
                }
            }

            //Return Player to floor (fixes player flying/sinking after multiple jumps/slides)
            if((jumping == false && transform.position.y != floor.y) || comingDown == true)
            {
                Vector3 gotofloor = new Vector3(transform.position.x, floor.y, transform.position.z);
                transform.position = Vector3.MoveTowards(transform.position, gotofloor, Time.deltaTime * verticalSpeed);
            }
        }
    }

    IEnumerator JumpSequence()
    {
        if (gravityToggle)
        { 
            yield return new WaitForSeconds(0.45f); 
        } else 
        {
            yield return new WaitForSeconds(.45f);
        }
        alienObject.GetComponent<Animator>().Play("Jump");
        comingDown = true;
        if (gravityToggle)
        {
            yield return new WaitForSeconds(0.8f);
        } else
        {
            yield return new WaitForSeconds(0.8f);
        }
        alienObject.GetComponent<Animator>().Play("Run");
        jumping = false;
        comingDown = false;
        if (canMove == true) { playerObject.GetComponent<Animator>().Play("Astonaut_Run"); }
    }

    IEnumerator SlideSequence()
    {
        yield return new WaitForSeconds(0.6f);
        alienObject.GetComponent<Animator>().Play("Slide");
        gettingup = true;
        yield return new WaitForSeconds(0.45f);
        alienObject.GetComponent<Animator>().Play("Run");
        sliding = false;
        gettingup = false;
        if (canMove == true) { playerObject.GetComponent<Animator>().Play("Astonaut_Run"); }
    }
}
