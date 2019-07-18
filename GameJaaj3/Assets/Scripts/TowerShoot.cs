using UnityEngine;

public class TowerShoot : MonoBehaviour
{
    [SerializeField] private GameObject projectile = null;
    [SerializeField] private Transform shootPosition = null;
    [SerializeField] private float cooldownToShoot = 1f;

    private Cooldown cdShoot;

    [SerializeField] private float attackRange = 1.5f;
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
        if( enemyToAttack != null &&
            Vector2.Distance(enemyToAttack.transform.position, transform.position) <= attackRange &&
            enemyToAttack.GetComponent<EnemyReceiveDamage>().IsActive)
        {
            //todo: shoot form shootPosition and rotate the tower
            GameObject proj = Instantiate(projectile, transform.position, transform.rotation);
            proj.GetComponent<ProjectileMovement>().SetTarget = enemyToAttack;
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
