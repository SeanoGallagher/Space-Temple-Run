using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectableControl : MonoBehaviour
{
    public static int coinCount;
    public GameObject coinCountDisplay;
    public GameObject coinEndDisplay;


    // Start is called before the first frame update
    void Start(){}

    // Update is called once per frame
    void Update()
    {
        coinCountDisplay.GetComponent<TMPro.TextMeshProUGUI>().text = "" + coinCount;
        coinEndDisplay.GetComponent<TMPro.TextMeshProUGUI>().text = "" + coinCount;
    }
}
