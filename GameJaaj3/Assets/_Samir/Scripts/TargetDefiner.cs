using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetDefiner : MonoBehaviour
{
    [SerializeField]    private Transform [] nextTarget;
    


    void OnTriggerEnter2D(Collider2D collider)
    {
        
        if(collider.CompareTag("Enemy"))
        {
            int idx = Random.Range(0, nextTarget.Length);   
            collider.GetComponent<IA_Enemy>().SetTarget = nextTarget[idx].position;
        }
    }
}
