using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLevel : MonoBehaviour
{
    public GameObject[] Section;
    public int zPos = 50;
    public bool creatingSection = false;
    public int secNum;

    // Start is called before the first frame update
    void Start(){}

    // Update is called once per frame
    void Update()
    {
        if(creatingSection == false)
        {
            creatingSection = true;
            StartCoroutine(GenerateSection());
        }
    }

    IEnumerator GenerateSection()
    {
        // Will never generate last num, i.e. possible results with (0, 3) is 0, 1, 2
        secNum = Random.Range(0, 3);
        Instantiate(Section[secNum], new Vector3(0, 0, zPos), Quaternion.identity);
        zPos += 50;
        yield return new WaitForSeconds(5);
        creatingSection = false;
    }
}
