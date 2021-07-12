using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStat : MonoBehaviour
{
    public int money;
    public int hp;
    public int maxHp;

    public Text moneyCount;
    public Text healthCount;
    // Start is called before the first frame update
    void Start()
    {
        maxHp = 10;
        hp = maxHp;
        moneyCount.text = money.ToString();
        healthCount.text = hp.ToString();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void AddMoney(int i)
    {
        money += i;
        moneyCount.text = money.ToString();
    }

    public void LoseHealth()
    {
        hp -= 1;
        healthCount.text = hp.ToString();
        if (hp <= 0)
        {
            healthCount.text = "0";
            //loseGame
            Destroy(this.gameObject);
        }
    }

    public void Repair()
    {
            hp = maxHp;
    }

    public void IncreaseMaxHealth()
    {
            maxHp += 1;
    }

    public bool removeMoney(int moneyR)
    {
        if (money > moneyR)
            money -= moneyR;
        else
            return false;
        return true;
    }
}
