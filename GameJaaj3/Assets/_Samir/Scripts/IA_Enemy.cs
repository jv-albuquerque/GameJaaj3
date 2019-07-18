﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IA_Enemy : MonoBehaviour
{
    //Movimentação
    

    private Vector2 target;

    private float distacePerFrame = 5f;    
       
    // Quebra de rota
    public bool isFighting = false;




    void Update()
    {
        if (isFighting == false)
        {
            Move();                       
           
        } 
    }

    void Move()
    {

        transform.position = Vector2.MoveTowards(transform.position, target, distacePerFrame * Time.deltaTime);
    }


    public Vector2 SetTarget
    {
        set
        {
            target = value;
        }
    }
}
