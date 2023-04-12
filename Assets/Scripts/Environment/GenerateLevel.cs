using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLevel : MonoBehaviour
{
    public GameObject outdoors;
    public GameObject indoors;
    public int zPos = 50;
    public bool creatingSection = false;
    public int secNum;
    public int totalsections = 0;
    public int countdownchange = 8;
    public bool worldState = false;
    private GameObject curObj;

    // Start is called before the first frame update
    void Start() 
    {
        GenerateSection();
    }

    // Update is called once per frame
    void Update()
    {
        if (creatingSection == false && totalsections < 10)
        {
            creatingSection = true;
            StartCoroutine(GenerateSection());
        }
    }

    public void NextSection()
    {
        if (creatingSection == false)
        {
            creatingSection = true;
            StartCoroutine(GenerateSection());
        }
    }

    IEnumerator GenerateSection()
    {
        // Will never generate last num, i.e. possible results with (0, 3) is 0, 1, 2
        totalsections++;
        countdownchange++;
        if (countdownchange > 4)
        {
            if (Random.value > 0.5f)
            {
                worldState = !worldState;
                countdownchange = 0;
            }
        }
        if (!worldState)
        {
            curObj = outdoors;
        }
        else
        {
            curObj = indoors;
        }
        secNum = Random.Range(1, curObj.transform.childCount);
        if (countdownchange == 0) { secNum = 0; }
        GameObject go;
        go = Instantiate(curObj.transform.GetChild(secNum).gameObject, new Vector3(0, 0, zPos), Quaternion.identity);
        go.transform.name = "Section " + totalsections + "(" + (worldState ? "Indoors " : "Outdoors ") + (secNum+1) + ")";
        go.transform.parent = GameObject.Find("Generated Sections").transform;
        zPos += 50;
        if (totalsections >= 8) { yield return new WaitForSeconds(5); }
        creatingSection = false;
    }
}
