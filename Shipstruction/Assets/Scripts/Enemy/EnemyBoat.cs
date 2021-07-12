using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoat : Enemy
{
    public GameObject explosionPrefab;
    // Start is called before the first frame update
    void Start()
    {
        _speed = 10.5f;
        _value = 100;
        _hp = 2;
        _rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        transform.LookAt(player.transform);
        _rb.MovePosition(_rb.position + (transform.rotation * Vector3.forward) * _speed * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag.StartsWith("Player"))
        {
            Instantiate(explosionPrefab, this.transform.position, Quaternion.identity);
            collision.collider.gameObject.GetComponent<PlayerStat>().LoseHealth();
            Destroy(this.gameObject);
        }
        if (collision.collider.tag.StartsWith("Enemy"))
        {
            Instantiate(explosionPrefab, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
