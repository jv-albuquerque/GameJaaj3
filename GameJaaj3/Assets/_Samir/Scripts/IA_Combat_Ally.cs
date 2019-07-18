using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IA_Combat_Ally : MonoBehaviour
{
    public List<Collider2D> enemies;

    private Cooldown cooldownAtk;

    public bool isFighting = false;

    public float enemieCount = 0f;


    //Enemy interation
    public bool checkArea = false;

    public bool vivo = true; // Variável que verifica se o personagem está vivo ou não

    void Start() 
    {
        enemies = new List<Collider2D>();
        cooldownAtk = new Cooldown(1.5f);
    }
    // Update is called once per frame
    void Update()
    {
        if(vivo == true)
        {
            Attack();
        } 
        else
        {
            //Animação dps de
            Destroy(gameObject);
        }
        
    }

    

    void Attack()
    {
        
    }
    

    void OnTriggerEnter2D(Collider2D collider)
    {        
        if(collider.CompareTag("Enemy"))
        {
            isFighting = true;
            collider.GetComponent<IA_Enemy>().isFighting = true;

            enemies.Add(collider);
            enemieCount += 1;
        }        
    }

    void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("Enemy"))
        {
            enemies.Remove(other);
            enemieCount -= 1;
        }        
    }
}