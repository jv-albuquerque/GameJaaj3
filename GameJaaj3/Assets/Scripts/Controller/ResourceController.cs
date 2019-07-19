using UnityEngine;
using TMPro;

public class ResourceController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textMoney = null;

    [SerializeField] private int money = 1000;

    private Cooldown moneyPerSec;

    private void Start()
    {
        moneyPerSec = new Cooldown(1);
        moneyPerSec.Start();

        textMoney.text = money.ToString();
    }

    private void Update()
    {
        if(moneyPerSec.IsFinished)
        {
            //Money += 1;
            moneyPerSec.Start();
        }
    }

    public int Money
    {
        set
        {
            money = value;
            Debug.Log(value);
            textMoney.text = money.ToString();
        }
        get
        {
            return money;
        }
    }
}
