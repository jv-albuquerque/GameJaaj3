using UnityEngine;

public class TowerUpgrade : MonoBehaviour
{
    [SerializeField] private int maxUpgrade = 3;

    [SerializeField] private int[] cost = null;
    [SerializeField] private int[] damages = null;
    [SerializeField] private float[] attackRanges = null;
    [SerializeField] private float[] cooldownsToShoot = null;

    private int lvl = 0;
    private TowerShoot towerShoot;

    private void Start()
    {
        towerShoot = GetComponent<TowerShoot>();
    }

    public void Upgrade()
    {
        if(CanUpgrade)
        {
            lvl++;
            towerShoot.Upgrade(damages[lvl], attackRanges[lvl], cooldownsToShoot[lvl]);
        }
    }

    public bool CanUpgrade
    {
        get
        {
            return lvl < maxUpgrade;
        }
    }

    public int Cost
    {
        get
        {
            return cost[lvl];
        }
    }
}
