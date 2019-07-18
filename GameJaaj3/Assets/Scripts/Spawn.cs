using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    private List<GameObject> enemies;

    // Start is called before the first frame update
    void Start()
    {
        GameObject[] tempEnemies;
        tempEnemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (var enemy in tempEnemies)
        {
            enemies.Add(enemy);
        }

        tempEnemies = null;
    }

    public void RemoveEnemy(GameObject enemy)
    {
        enemies.Remove(enemy);
    }
}
