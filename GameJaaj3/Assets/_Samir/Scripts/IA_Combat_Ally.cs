using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IA_Combat_Ally : MonoBehaviour
{
    public List<Collider2D> enemies;

    private Cooldown cooldownAtk;

    public bool isFighting = false;


    //Enemy interation
    public bool checkArea = false;

    public Transform attackPos = null; // Posição do ataque
    public LayerMask whatIsEnemy; // O que é inimigo (Quem eu vou atacar)
    public float attackRange = 2f; // Alcance do ataque
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
        Debug.Log(enemies.Count);
        foreach (var target in enemies)
        {
            if(target ==  null)
            {
                enemies.Remove(target);
            }
            
        }
    }
    

    void OnTriggerEnter2D(Collider2D collider)
    {        
        if(collider.CompareTag("Enemy"))
        {
            isFighting = true;
            collider.GetComponent<IA_Enemy>().isFighting = true;

            enemies.Add(collider);
        }

        
    }


    void OnDrawGizmosSelected() // Cria um Gizmo na tela apra que seja possivel ver o a área do colisor mesmo quando ele estiver desativado
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}