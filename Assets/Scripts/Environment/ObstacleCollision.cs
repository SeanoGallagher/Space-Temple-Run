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
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        thePlayer.GetComponent<PlayerMovement>().enabled = false;
        PlayerMovement.canMove = false;
        charModel.GetComponent<Animator>().Play("Stumble Backwards");
        levelControl.GetComponent<LevelDistance>().enabled = false;
        crashThud.Play();
        camAnim.GetComponent<Animator>().enabled = true;
        levelControl.GetComponent<EndRunSequence>().enabled = true;
    }
}
