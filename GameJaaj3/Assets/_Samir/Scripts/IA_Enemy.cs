using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IA_Enemy : MonoBehaviour
{
    //Movimentação
    
    public Vector2 EndPosition;

    public int Point = 0;
    public Transform PointPosition;
    private Vector2 target;

    private float distacePerFrame = 5f;    
       
    // Quebra de rota
    public bool isFighting = false;



    void Start()
    {
        //Debug.Log(target);
        EndPosition = target;        
    }

    void Update()
    {
        if (isFighting == false)
        {
            Debug.Log(target);
            transform.position = Vector2.MoveTowards(transform.position, EndPosition, distacePerFrame * Time.deltaTime);                
           
        } 
    }
    /*
    void OnTriggerEnter2D(Collider2D Ally)
    {
        Debug.Log("!");
        isFighting = true;
    }
     */

    


    public Vector2 SetTarget
    {
        set
        {
            target = value;
        }
    }
}
