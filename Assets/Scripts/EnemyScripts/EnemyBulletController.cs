using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour
{
    private float _bulletSpeed = 0.7f;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _bulletPos;
    [SerializeField] private PlayerController _playerController;
    Vector3 moveDirection;
    public float distance = 0f;

    void Start()
    {
        _bulletPos = GameObject.Find("bulletPos");
        _player = GameObject.Find("Player");
        _playerController = _player.GetComponent<PlayerController>();
        moveDirection = new Vector3(_bulletPos.transform.position.x - transform.position.x, (_bulletPos.transform.position.y - transform.position.y ), _bulletPos.transform.position.z - transform.position.z);
    }


    void Update()
    {
        Movement();
        Die();
    }

    private void Movement()
    {
        transform.Translate(moveDirection * Time.deltaTime * _bulletSpeed);
        distance = Mathf.Abs(transform.position.z - _player.transform.position.z);
        if (Mathf.Abs(transform.position.z - _player.transform.position.z) < 3f)
        {
            _playerController.Crouch();
            Destroy(gameObject,5f);
        }
            
    }

    private void Die()
    {
        if(transform.position.z < -25f)
        {
            Destroy(gameObject);
        }
    }


}
