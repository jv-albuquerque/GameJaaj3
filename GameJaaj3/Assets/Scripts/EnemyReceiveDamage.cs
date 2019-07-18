using UnityEngine;

public class EnemyReceiveDamage : MonoBehaviour
{
    [SerializeField] private int hp = 100;
    [SerializeField] private int defense = 0;

    private EnemyController enemyController;

    private void Start()
    {
        enemyController = GameObject.FindGameObjectWithTag("GameController").GetComponent<EnemyController>();
    }

    //todo: Create a health bar in the enemy
    //This is the function that receve the damage
    public void Damage(int damage)
    {
        if(damage > defense)
            hp -= damage - defense;

        Debug.Log(hp);

        //todo: Unable the object until it needs to be called again;
        if(hp <= 0)
        {
            enemyController.RemoveEnemy(gameObject);
            GameObject.Destroy(gameObject);
        }
    }
}
