using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] FireScript _fireScript;

    Vector3 moveDirection= new Vector3(1, 0, 1);
    [SerializeField] private float _bulletSpeed = 50f;
   
    void Start()
    {
        _fireScript = GameObject.Find("Player").GetComponent<FireScript>();
        moveDirection = new Vector3(_fireScript._enemyPos.position.x - transform.position.x, _fireScript._enemyPos.position.y - transform.position.y, _fireScript._enemyPos.position.z - transform.position.z);

    }


    void Update()
    {
        Movement();
        Die();
    }

  

    private void Movement()//Su mermisi hareketi
    {
            transform.Translate(moveDirection * Time.deltaTime * _bulletSpeed);    
    }

    private void Die()
    {
        Destroy(gameObject, 0.1f);
    }

}
