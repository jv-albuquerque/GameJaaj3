using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DpsPool : MonoBehaviour
{
    [SerializeField] private float lifeTime = 5f;
    [SerializeField] private float tickDamage = .5f;

    private int damage = 10;

    private Cooldown cdLifeTime;
    private Cooldown cdTickDamage;

    private List<GameObject> enemies;

    private void Start()
    {
        enemies = new List<GameObject>();

        cdLifeTime = new Cooldown(lifeTime);
        cdTickDamage = new Cooldown(tickDamage);

        cdLifeTime.Start();
        cdTickDamage.Start();
    }

    private void Update()
    {
        if(cdTickDamage.IsFinished)
        {
            for (int i = 0; i < enemies.Count; i++)
            {
                if (enemies[i] != null)
                    enemies[i].GetComponent<EnemyReceiveDamage>().Damage = damage;
                else
                {
                    enemies.Remove(enemies[i]);
                    i--;
                }
            }

            cdTickDamage.Start();
        }


        if(cdLifeTime.IsFinished)
        {
            Destroy(gameObject);
        }
    }

    public int SetDamage
    {
        set
        {
            damage = value;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            enemies.Remove(collision.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            enemies.Add(collision.gameObject);
        }
    }
}
