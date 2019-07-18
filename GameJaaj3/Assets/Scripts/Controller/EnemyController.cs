using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This object is responsible to manage all the enemies
public class EnemyController : MonoBehaviour
{
    private List<GameObject> enemies;

    // Start is called before the first frame update
    void Start()
    {
        enemies = new List<GameObject>();

        //Find all enemies in the sceane, only necessary in the test fase
        //-----------------------
        GameObject[] tempEnemies;
        tempEnemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (var enemy in tempEnemies)
        {
            enemies.Add(enemy);
        }

        tempEnemies = null;
        //-----------------------
    }

    public void AddEnemy(GameObject enemy)
    {
        enemies.Add(enemy);
    }

    public void RemoveEnemy(GameObject enemy)
    {
        enemies.Remove(enemy);
    }

    // Find all enemies that is in the range of the tower
    public void FindNearEnemies(Vector2 towerPosition, float towerRange, List<GameObject> enemiesInRange)
    {
        enemiesInRange.Clear();

        foreach (var enemy in enemies)
        {
            if(Vector2.Distance(enemy.transform.position, towerPosition) <= towerRange)
                enemiesInRange.Add(enemy);
        }
    }


}
