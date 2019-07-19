using UnityEngine;

public class TileButton : MonoBehaviour
{
    [SerializeField] private Tile tile = null;
    [SerializeField] private GameObject tower = null;

    [SerializeField] private ResourceController resource = null;
    private Color originalColor;

    //todo: try to put this in the editor.
    //when a select one, the other is automatic unselected
    public bool towerSpawn = true;
    public bool sell = false;
    public bool upgrade = false;

    private void Start()
    {
        originalColor = GetComponent<SpriteRenderer>().color;
        gameObject.SetActive(false);
    }

    public void Action()
    {
        if (towerSpawn)
            SpawnTower();
        else if (upgrade)
            Upgrade();
        else
            Sell();
    }

    public bool canBuy()
    {
        if (towerSpawn && tower.GetComponent<TowerUpgrade>().Cost < resource.Money)
            return true;
        return false;
    }

    public bool SetGrey
    {
        set
        {
            if (value)
                GetComponent<SpriteRenderer>().color = Color.grey;
            else
                GetComponent<SpriteRenderer>().color = originalColor;
        }
    }

    private void SpawnTower()
    {
        tile.SpawnTower(tower);
    }

    private void Upgrade()
    {
        tile.Upgrade();
    }

    private void Sell()
    {
        tile.SellTower();
    }
}
