using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetDefiner : MonoBehaviour
{
    [SerializeField]    private Transform [] nextTarget;
    


    void OnTriggerEnter2D(Collider2D coll)
    {
        Debug.Log("!");
        if(coll.CompareTag("Enemy"))
        {
            int idx = Random.Range(0, nextTarget.Length-1);   
            coll.GetComponent<IA_Enemy>().SetTarget = nextTarget[idx].position;
        }
    }
}
