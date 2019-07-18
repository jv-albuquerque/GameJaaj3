using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerShoot : MonoBehaviour
{
    [SerializeField] private GameObject projectile = null;
    [SerializeField] private float cooldownToShoot = 1f;

    private Cooldown cdShoot;

    private float attackRange = 1.5f;
    private List<GameObject> enemiesInRange = null;

    private EnemyController enemyController;

    private void Start()
    {
        cdShoot = new Cooldown(cooldownToShoot);
        cdShoot.Start();

        enemiesInRange = new List<GameObject>();

        enemyController = GameObject.FindGameObjectWithTag("GameController").GetComponent<EnemyController>();
    }

    private void Update()
    {
        if(cdShoot.IsFinished)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        FindEnemies();
        if(enemiesInRange.Count > 0)
            Debug.Log(gameObject.name + " shooted");
    }

    private void FindEnemies()
    {
        enemyController.FindNearEnemies(transform.position, attackRange, enemiesInRange);
    }


    //Draw the Range of the attack
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
