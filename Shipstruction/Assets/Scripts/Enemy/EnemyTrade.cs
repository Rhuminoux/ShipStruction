using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrade : Enemy
{
    // Start is called before the first frame update
    public GameObject left;
    public GameObject right;

    void Start()
    {
        _hp = 20;
        _value = 2000;
        _rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(this.transform.position, player.transform.position) < 30)
        {
            Fire();
        }
    }

    private void Fire()
    {
        if (Time.time > _lastShoot + fireSpeed)
        {
            if (player.transform.position.x < this.transform.position.x)
            {
                Shoot(left);
            }
            else
            {
                Shoot(right);
            }
            _lastShoot = Time.time;
        }
    }

    private void Shoot(GameObject cannons)
    {
        for (int i = 0; i < cannons.transform.childCount; ++i)
        {
            _newBullet = GameObject.Instantiate(bulletPrefab, cannons.transform.GetChild(i).transform.position, Quaternion.identity);
            GameObject.Instantiate(smokePrefab, cannons.transform.GetChild(i).transform.position, Quaternion.identity);
            _newBullet.GetComponent<Rigidbody>().AddForce((cannons.transform.GetChild(i).transform.rotation * Vector3.forward) * 20, ForceMode.Impulse);
        }
    }

    private void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + (transform.rotation * Vector3.forward) * 6 * Time.fixedDeltaTime);
    }
}
