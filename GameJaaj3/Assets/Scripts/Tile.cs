using UnityEngine;

public class Tile : MonoBehaviour
{
    private bool occupied = false;

    [Header("Tile Buttons")]
    [SerializeField] private GameObject Acid = null;
    [SerializeField] private GameObject Espermicide = null;
    [SerializeField] private GameObject Condom = null;
    [SerializeField] private GameObject DIU = null;

    [Header("Tower Buttons")]
    [SerializeField] private GameObject upgrade = null;
    [SerializeField] private GameObject sell = null;

    private GameObject ActiveTower = null;

    public void ActiveUI()
    {
        if(ActiveTower == null)
        {
            Acid.SetActive(true);
            Espermicide.SetActive(true);
            Condom.SetActive(true);
            DIU.SetActive(true);
        }
        else
        {
            upgrade.SetActive(true);
            sell.SetActive(true);
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
        ActiveTower = Instantiate(tower, transform.position, Quaternion.identity);
    }

    public void SellTower()
    {
        GameObject.Destroy(ActiveTower);
        ActiveTower = null;
    }
}
