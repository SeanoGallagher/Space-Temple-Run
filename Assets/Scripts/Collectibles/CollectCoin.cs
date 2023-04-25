using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoin : MonoBehaviour
{
    public AudioSource coinFX;

    // Start is called before the first frame update
    void Start(){
     if (!coinFX)
        {
            coinFX = this.transform.parent.GetComponent<CollectCoin>().coinFX;
        }
    }
    // Update is called once per frame
    void Update(){}

    void OnTriggerEnter(Collider other)
    {
        coinFX.Play();
        CollectableControl.coinCount += 1;
        this.gameObject.SetActive(false);
    }
}
