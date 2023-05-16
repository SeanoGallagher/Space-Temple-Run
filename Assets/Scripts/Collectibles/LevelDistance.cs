using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelDistance : MonoBehaviour
{
    public GameObject disDisplay;
    public GameObject disEndDisplay;
    public int disRun;
    private int hiscore;
    public bool addingDis = false;
    public float disDelay = 0.35f;

    void Start()
    {
        hiscore = PlayerPrefs.GetInt("distanceCount");
    }
    void Update()
    {
        if(!addingDis && PlayerMovement.canMove){
            addingDis = true;
            StartCoroutine(AddingDis());
        }
    }

    IEnumerator AddingDis()
    {
        disRun += 1;
        disDisplay.GetComponent<TMPro.TextMeshProUGUI>().text = "" + disRun;
        disEndDisplay.GetComponent<TMPro.TextMeshProUGUI>().text = (disRun > hiscore) ? "" + disRun + "  <b><color=red>High Score!</color></b>" : "" + disRun;
        yield return new WaitForSeconds(disDelay / (PlayerMovement.moveSpeed / 5));
        addingDis = false;
    }

    void OnDisable()
    {
        if (disRun > hiscore) { PlayerPrefs.SetInt("distanceCount", disRun); }
    }

}
