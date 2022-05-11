using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    private float speed = 3f;

    [SerializeField] private GameStats _gameStats;


    [SerializeField] private GameObject _enemyBullet;

    [SerializeField] private GameObject _enemyWeapon;

    [SerializeField] private EnemyTypes _enemyTypes;

    [SerializeField] private Animator myAnim;


    private float time = 0f;

    private int count = 0;


    private void Start()
    {
        if(_enemyTypes.EnemyType == 0)
        myAnim = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (_gameStats.isGameActive && _enemyTypes.EnemyType == 0)
            transform.Translate(0, 0, -1 * speed * Time.deltaTime,Space.World);
        else if (_gameStats.isGameActive && _enemyTypes.EnemyType == 2)
            transform.Translate(0, 0, -2 * speed * Time.deltaTime, Space.World);
        else if (_gameStats.isGameActive && _enemyTypes.EnemyType == 1)
            transform.Translate(-1*speed*Time.deltaTime, 0, -1 * speed * Time.deltaTime, Space.World);
        else
            Destroy(gameObject);

        if (gameObject.transform.position.z < -23.90f)
        {
            Destroy(gameObject);
            _gameStats.Health--;
        }

        if(_gameStats.Health <= 0)
        {
            _gameStats.isGameActive = false;
        }

        time += Time.deltaTime;
        if (time > 0.5f && _enemyWeapon)
            Fire();
    }

    private void Fire()
    {
        if(count == 0)
        Instantiate(_enemyBullet, _enemyWeapon.gameObject.transform.position, _enemyBullet.transform.rotation);
        count++;
    }


    public void Die()
    {
        myAnim.SetTrigger("death");
        gameObject.GetComponent<CapsuleCollider>().enabled = false;
        if(_enemyTypes.EnemyType == 0)
        {
            _enemyWeapon.gameObject.SetActive(false);
        }
    }

}
