using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IA_Combat_Ally : MonoBehaviour
{
    public float hp = 100f;
    public float atkDamage = 25f;

    public bool isFighting = false;



    //Enemy interation
    public bool checkArea = false;

    public Transform attackPos; // Posição do ataque
    public LayerMask whatIsEnemy; // O que é inimigo (Quem eu vou atacar)
    public float attackRange = 2f; // Alcance do ataque
    public bool vivo = true; // Variável que verifica se o personagem está vivo ou não


    // Update is called once per frame
    void Update()
    {
        if (isFighting == true)
        {
            Attack();
        }
        else
        {
            Patrol();
        }
    }

    void Attack()
    {
        Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemy); // Cria um trigger para verificar quantos inimigos estão na área de contato e coloca todos eles dentro de um vetor Collider
        
        if (enemiesToDamage.Length > 0) // Se a quantidade de inimigos dentro da área for maior que 0
        {
            for (int i = 0; i < enemiesToDamage.Length; i++)
            {
                 /*
                 while (enemy.hp > 0)
                 {
                    enemy.hp -= atkDamage;
                    cd(1);
                 }
                 */

            }
        }
        
    }

    void Patrol()
    {
        // Quando não tiver inimigos, entrar em modo patrulha
    }

    void OnDrawGizmosSelected() // Cria um Gizmo na tela apra que seja possivel ver o a área do colisor mesmo quando ele estiver desativado
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}