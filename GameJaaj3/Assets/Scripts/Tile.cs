using UnityEngine;

public class Tile : MonoBehaviour
{
    private bool occupied = false;

    [SerializeField] private GameObject Acid = null;
    [SerializeField] private GameObject Espermicide = null;
    [SerializeField] private GameObject Condom = null;
    [SerializeField] private GameObject DIU = null;

    public void ActiveUI()
    {
        Acid.SetActive(true);
        Espermicide.SetActive(true);
        Condom.SetActive(true);
        DIU.SetActive(true);
    }

    public void DeactiveUI()
    {
        Acid.SetActive(false);
        Espermicide.SetActive(false);
        Condom.SetActive(false);
        DIU.SetActive(false);
    }
}
