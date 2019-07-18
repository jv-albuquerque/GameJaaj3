using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileButton : MonoBehaviour
{
    [SerializeField] private Tile tile = null;
    [SerializeField] private GameObject tower = null;

    //todo: try to put this in the editor.
    //when a select one, the other is automatic unselected
    public bool towerSpawn = true;
    public bool sell = false;
    public bool upgrade = false;

    public void Action()
    {
        if (towerSpawn)
            SpawnTower();
        else if (upgrade)
            Upgrade();
        else
            Sell();
    }

    private void SpawnTower()
    {
        tile.SpawnTower(tower);
    }

    private void Upgrade()
    {
        
    }

    private void Sell()
    {
        tile.SellTower();
    }
}
