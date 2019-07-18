using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerShoot : MonoBehaviour
{
    [SerializeField] private GameObject projectile = null;
    [SerializeField] private float cooldownToShoot = 1f;

    private Cooldown cdShoot;

    private float attackRange = 1.5f;
    private GameObject enemyToAttack = null;

    private EnemyController enemyController;

    private void Start()
    {
        cdShoot = new Cooldown(cooldownToShoot);
        cdShoot.Start();

        enemyController = GameObject.FindGameObjectWithTag("GameController").GetComponent<EnemyController>();
    }

    private void Update()
    {
        if(cdShoot.IsFinished)
        {
            if (Shoot())
                cdShoot.Start();
        }
    }

    private bool Shoot()
    {
        FindEnemies();
        if(enemyToAttack != null)
        {
            Debug.Log(gameObject.name + " shooted");
            return true;
        }

        return false;
    }

    private void FindEnemies()
    {
        enemyController.FindNearEnemy(transform.position, attackRange, ref enemyToAttack);
    }


    //Draw the Range of the attack
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
