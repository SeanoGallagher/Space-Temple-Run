using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLevel : MonoBehaviour
{
    public GameObject outdoors;
    public GameObject indoors;
    public GameObject[] Section;
    public int zPos = 50;
    public bool creatingSection = false;
    public int secNum;
    public int totalsections = 0;

    // Start is called before the first frame update
    void Start() 
    {
        GenerateSection();
    }

    // Update is called once per frame
    void Update()
    {
        if (creatingSection == false && totalsections < 8)
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
        secNum = Random.Range(0, outdoors.transform.childCount);
        GameObject go;
        go = Instantiate(Section[secNum], new Vector3(0, 0, zPos), Quaternion.identity);
        go.transform.name = "Section " + totalsections + "(Outdoors " + (secNum+1) + ")";
        go.transform.parent = GameObject.Find("Generated Sections").transform;
        zPos += 50;
        if (totalsections >= 8) { yield return new WaitForSeconds(5); }
        creatingSection = false;
    }
}
