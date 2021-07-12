using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject player;
    public GameObject shopButton;

    public GameObject boatPrefab;
    public GameObject islandPrefab;
    public GameObject tradePrefab;
    public GameObject shopPrefab;

    private List<GameObject> _boats;
    private List<GameObject> _islands;
    private GameObject _trade;
    private GameObject _shop;

    private float _boatSpawnTime = 10;
    private float _lastBoatSpawn = -5;

    private Vector3 _spawnPoint;

    private GameObject _newObj;
    // Start is called before the first frame update
    void Start()
    {
        _boats = new List<GameObject>();
        _islands = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckBoat();
        CheckIsland();
        CheckTrade();
        CheckShop();
    }

    private void CheckBoat()
    {
        foreach (GameObject boat in _boats)
        {
            if (boat == null)
                _boats.Remove(boat);
            else if (Vector3.Distance(boat.transform.position, player.transform.position) > 110)
            {
                _boats.Remove(boat);
                Destroy(boat);
            }
        }

        if (_boats.Count < 10 && Time.time > _lastBoatSpawn + _boatSpawnTime)
        {
            _spawnPoint = Random.insideUnitCircle.normalized * Random.Range(50, 100);
            _newObj = Instantiate(boatPrefab, new Vector3(player.transform.position.x + _spawnPoint.x, 0, player.transform.position.z + _spawnPoint.y), Quaternion.identity);
            _newObj.GetComponent<EnemyBoat>().player = player;
            _boats.Add(_newObj);
            _lastBoatSpawn = Time.time;
        }
    }

    private void CheckIsland()
    {
        foreach (GameObject island in _islands)
        {
            if (island == null)
                _islands.Remove(island);
            else if (Vector3.Distance(island.transform.position, player.transform.position) > 110)
            {
                _islands.Remove(island);
                Destroy(island);
            }
        }

        if (_islands.Count < 10)
        {
            _spawnPoint = Random.insideUnitCircle.normalized * Random.Range(50, 100);
            _newObj = Instantiate(islandPrefab, new Vector3(player.transform.position.x + _spawnPoint.x, 0, player.transform.position.z + _spawnPoint.y), Quaternion.identity);
            _newObj.GetComponent<EnemyIsland>().player = player;
            _islands.Add(_newObj);
        }
    }

    private void CheckTrade()
    {
        if (_trade == null)
        {
            _spawnPoint = Random.insideUnitCircle.normalized * Random.Range(50, 100);
            _trade = Instantiate(tradePrefab, new Vector3(player.transform.position.x + _spawnPoint.x, 0, player.transform.position.z + _spawnPoint.y), Quaternion.identity);
            _trade.GetComponent<EnemyTrade>().player = player;
            
        }

        if (Vector3.Distance(_trade.transform.position, player.transform.position) > 110)
        {
            Destroy(_trade);
        }
    }

    private void CheckShop()
    {
        if (_shop == null)
        {
            _spawnPoint = Random.insideUnitCircle.normalized * Random.Range(50, 100);
            _shop = Instantiate(shopPrefab, new Vector3(player.transform.position.x + _spawnPoint.x, 0, player.transform.position.z + _spawnPoint.y), Quaternion.identity);
            _shop.GetComponent<ShopObj>().shopButton = shopButton;
        }

        if (Vector3.Distance(_shop.transform.position, player.transform.position) > 110)
        {
            Destroy(_shop);
        }
    }
}
