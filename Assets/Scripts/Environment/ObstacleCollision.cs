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
    public AudioSource crashThud;

    void Start(){}
    void Update(){}

    void OnTriggerEnter(Collider other)
    {
        bool jumping = PlayerMovement.jumping;
        PlayerMovement.canMove = false;
        thePlayer.GetComponent<PlayerMovement>().enabled = false;

        StopCoroutine("JumpSequence");
        StopCoroutine("SlideSequence");
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        if(jumping){
            charModel.GetComponent<Animator>().Play("Astronaut_AirCrash");
        }
        else{
            charModel.GetComponent<Animator>().Play("Astronaut_GroundCrash");
        }
        levelControl.GetComponent<LevelDistance>().enabled = false;
        crashThud.Play();
        camAnim.GetComponent<Animator>().enabled = false;
        levelControl.GetComponent<EndRunSequence>().enabled = true;
    }
}
