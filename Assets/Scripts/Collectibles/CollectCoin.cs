using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoin : MonoBehaviour
{
    public AudioSource coinFX;
    private int addCoin = 1;
    // Start is called before the first frame update
    void Start() {
        if (!coinFX)
        {
            coinFX = this.transform.parent.GetComponent<CollectCoin>().coinFX;
        }
        if (PlayerPrefs.GetInt("doubleCoins") == 1) { addCoin = 2; }
    }
    // Update is called once per frame
    void Update() { }

    void OnTriggerEnter(Collider other)
    {
        coinFX.Play();
        CollectableControl.coinCount += addCoin;
        this.gameObject.SetActive(false);
    }
}
