using UnityEngine;

public class Tile : MonoBehaviour
{
    [Header("Tile Buttons")]
    [SerializeField] private GameObject Acid = null;
    [SerializeField] private GameObject Espermicide = null;
    [SerializeField] private GameObject Condom = null;
    [SerializeField] private GameObject DIU = null;

    [Header("Tower Buttons")]
    [SerializeField] private GameObject upgrade = null;
    [SerializeField] private GameObject sell = null;

    private GameObject ActiveTower = null;

    private ResourceController resource;

    private void Start()
    {
        resource = GameObject.FindGameObjectWithTag("GameController").GetComponent<ResourceController>();
    }

    public void ActiveUI()
    {
        if(ActiveTower == null)
        {
            Acid.SetActive(true);
            Espermicide.SetActive(true);
            Condom.SetActive(true);
            DIU.SetActive(true);

            TileButton tb = Acid.GetComponent<TileButton>();
            if (tb.canBuy())
                tb.SetGrey = false;
            else
                tb.SetGrey = true;

            tb = Espermicide.GetComponent<TileButton>();
            if (tb.canBuy())
                tb.SetGrey = false;
            else
                tb.SetGrey = true;

            tb = Condom.GetComponent<TileButton>();
            if (tb.canBuy())
                tb.SetGrey = false;
            else
                tb.SetGrey = true;

            tb = DIU.GetComponent<TileButton>();
            if (tb.canBuy())
                tb.SetGrey = false;
            else
                tb.SetGrey = true;
        }
        else
        {
            upgrade.SetActive(true);
            sell.SetActive(true);

            TowerUpgrade tu = ActiveTower.GetComponent<TowerUpgrade>();
            if (tu.CanUpgrade && resource.Money >= tu.Cost)
                upgrade.GetComponent<TileButton>().SetGrey = false;
            else
                upgrade.GetComponent<TileButton>().SetGrey = true;
        }
    }

    public void DeactiveUI()
    {
        if (ActiveTower == null)
        {
            Acid.SetActive(false);
            Espermicide.SetActive(false);
            Condom.SetActive(false);
            DIU.SetActive(false);
        }
        else
        {
            upgrade.SetActive(false);
            sell.SetActive(false);
        }
    }

    public void SpawnTower(GameObject tower)
    {
        TowerUpgrade tu = tower.GetComponent<TowerUpgrade>();

        if (tu.CanUpgrade && resource.Money >= tu.Cost)
        {
            ActiveTower = Instantiate(tower, transform.position, Quaternion.identity);
            tu = ActiveTower.GetComponent<TowerUpgrade>();
            resource.Money -= tu.Cost;
        }
        else
        {
            Debug.Log("Don't have money to do this");
        }
    }

    public void SellTower()
    {
        resource.Money += ActiveTower.GetComponent<TowerUpgrade>().SellCost / 2;
        GameObject.Destroy(ActiveTower);
        ActiveTower = null;
    }

    public void Upgrade()
    {
        TowerUpgrade tu = ActiveTower.GetComponent<TowerUpgrade>();
        if(tu.CanUpgrade && resource.Money >= tu.Cost)
        {
            resource.Money -= tu.Cost;
            tu.Upgrade();
            upgrade.GetComponent<TileButton>().SetUpgradeImage();
        }
        else
        {
            Debug.Log("Don't have money to do this");
        }
    }
}
