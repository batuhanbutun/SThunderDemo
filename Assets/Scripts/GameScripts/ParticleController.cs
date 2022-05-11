using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    private float speed = 3f;
    void Start()
    {
    }

    private void Update()
    {
        transform.Translate(0, 1 * speed * Time.deltaTime, 0);
        Die();
    }

    public void Die()
    {
        Destroy(gameObject,1f);
    }
}
