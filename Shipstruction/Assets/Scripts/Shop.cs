using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public PlayerStat _playerStat;
    public CannonsManager _cannons;

    public Text maxHealth;
    public Text curentHealth;
    public Text currentCannons;
    public Text money;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        maxHealth.text = _playerStat.maxHp.ToString();
        curentHealth.text = _playerStat.hp.ToString() + "/" + _playerStat.maxHp.ToString();
        currentCannons.text = _cannons.GetCannons().ToString() + "/12";
        money.text = _playerStat.money.ToString();
    }

    private void OnEnable()
    {
        Time.timeScale = 0f;
    }

    private void OnDisable()
    {
        Time.timeScale = 1f;
    }

    public void AddLife()
    {
        if (_playerStat.removeMoney(3000))
            _playerStat.IncreaseMaxHealth();
    }

    public void Repair()
    {
        if (_playerStat.removeMoney(2000))
            _playerStat.Repair();
    }

    public void AddCannon()
    {
        if (_cannons.GetCannons() < 12 && _playerStat.removeMoney(4000))
        {
            _cannons.AddCannon();
        }
    }
}
