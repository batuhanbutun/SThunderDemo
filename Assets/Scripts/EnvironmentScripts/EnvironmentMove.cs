using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentMove : MonoBehaviour
{

    [SerializeField] private float speed = 20f;

    [SerializeField] GameStats _gameStats;

    void Update()
    {
        Move();
    }


    private void Move()
    {
        if(_gameStats.isGameActive)
        transform.Translate(0, 0, -1 * speed * Time.deltaTime);

        //if (gameObject.transform.position.z < -80)
           // Destroy(gameObject);
    }
}
