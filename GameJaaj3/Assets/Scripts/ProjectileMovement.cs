﻿using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    [SerializeField] private bool spawnOther = false;
    [SerializeField] private GameObject spawnObject = null;

    [SerializeField] private float speed = 10f;
    [SerializeField] private int damage = 10;

    private GameObject target = null;

    private Vector2 targetPos;

    void FixedUpdate()
    {
        if(target != null)
        {
            targetPos = target.transform.position;
            transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.fixedDeltaTime);
        }
        else
        {
            if (Vector2.Distance(targetPos, transform.position) <= 0.1f)
                Destroy(gameObject);
            transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.fixedDeltaTime);
        }
    }

    public GameObject SetTarget
    {
        set
        {
            target = value;
        }
    }

    public int SetDamage
    {
        set
        {
            if(spawnObject != null)
            {
                DpsPool dpsPool = spawnObject.GetComponent<DpsPool>();
                if (dpsPool != null)
                    dpsPool.SetDamage = damage;
            }
            else
                damage = value;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == target)
        {
            target.GetComponent<EnemyReceiveDamage>().Damage = damage;
            if (spawnOther)
                Instantiate(spawnObject, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
