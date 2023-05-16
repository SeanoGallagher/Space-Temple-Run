using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObstacleCollision : MonoBehaviour
{
    public GameObject thePlayer;
    public GameObject charModel;
    public GameObject camAnim;
    public GameObject levelControl;
    public GameObject alienObject;
    public AudioSource crashThud;

    public bool inPanic = false;
    public int panicCount = 0;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("SObstacle") && inPanic == false && panicCount < 3)
        {
            inPanic = true;
            panicCount += 1;
            StartCoroutine(Panic());
        }
        else if (other.gameObject.CompareTag("LObstacle") || (other.gameObject.CompareTag("SObstacle") && (inPanic || panicCount == 3)))
        {
            bool jumping = PlayerMovement.jumping;
            PlayerMovement.canMove = false;
            thePlayer.GetComponent<PlayerMovement>().enabled = false;
            StopCoroutine("JumpSequence");
            StopCoroutine("SlideSequence");
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
            if (jumping)
            {
                charModel.GetComponent<Animator>().Play("Astronaut_AirCrash");
            }
            else
            {
                charModel.GetComponent<Animator>().Play("Astronaut_GroundCrash");
            }
            levelControl.GetComponent<LevelDistance>().enabled = false;
            crashThud.Play();
            camAnim.GetComponent<Animator>().enabled = false;
            levelControl.GetComponent<EndRunSequence>().enabled = true;
        }
    }

    IEnumerator Panic()
    {
        alienObject.transform.localPosition = new Vector3(0f, -0.51f, -1.14f);
        yield return new WaitForSeconds(10);
        inPanic = false;
        alienObject.transform.localPosition = new Vector3(0f, -0.51f, -3f);
    }
}
