using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIsland : Enemy
{
    public GameObject shootingPoint;
    // Start is called before the first frame update
    void Start()
    {
        _hp = 10;
        _value = 500;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(shootingPoint.transform.position, player.transform.position) < 20)
        {
            Fire();
        }   
    }

    private void Fire()
    {
        if (Time.time > _lastShoot + fireSpeed)
        {
            shootingPoint.transform.LookAt(player.transform.position);
            _newBullet = GameObject.Instantiate(bulletPrefab, shootingPoint.transform.position, Quaternion.identity);
            GameObject.Instantiate(smokePrefab, shootingPoint.transform.position, Quaternion.identity);
            _newBullet.GetComponent<Rigidbody>().AddForce((shootingPoint.transform.rotation * Vector3.forward) * 20, ForceMode.Impulse);
            _lastShoot = Time.time;
        }
    }
}
