using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private GameObject dpsPool = null;

    private GameObject target = null;

    private Vector2 targetPos;

    void FixedUpdate()
    {
        if (target != null)
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
            dpsPool.GetComponent<DpsPool>().SetDamage = value;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == target)
        {
            Instantiate(dpsPool);
            Destroy(gameObject);
        }
    }
}
