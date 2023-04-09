using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    GenerateLevel sn;

    void Start()
    {
        sn = GameObject.Find("LevelControl").GetComponent<GenerateLevel>();
    }
    void Update(){}

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Passed through trigger");
        StartCoroutine(DestroyClone());
    }

    IEnumerator DestroyClone()
    {
        yield return new WaitForSeconds(5);
        Destroy(this.transform.parent.gameObject);
        sn.NextSection();
    }
}
