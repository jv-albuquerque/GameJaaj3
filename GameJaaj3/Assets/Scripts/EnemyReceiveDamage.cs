using UnityEngine;

public class EnemyReceiveDamage : MonoBehaviour
{
    [SerializeField] private int hp = 100;
    [SerializeField] private int shild = 0;

    private bool active = true;
    private EnemyController enemyController;

    private void Start()
    {
        enemyController = GameObject.FindGameObjectWithTag("GameController").GetComponent<EnemyController>();
        // todo: get move component
    }

    //todo: Create a health bar in the enemy
    //This is the function that receve the damage
    public int Damage
    {
        set
        {
            if (value > shild)
                hp -= value - shild;

            Debug.Log(hp);

            //todo: Unable the object until it needs to be called again;
            if (hp <= 0)
            {
                //todo: stop componet to move
                active = false;
                enemyController.RemoveEnemy(gameObject);
                GameObject.Destroy(gameObject);
            }
        }        
    }

    public bool IsActive
    {
        get
        {
            return active;
        }
    }

    public int SetHP
    {
        set
        {
            hp = value;
        }
    }

    public int SetShild
    {
        set
        {
            shild = value;
        }
    }
}
