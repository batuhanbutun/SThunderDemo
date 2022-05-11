using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatGround : MonoBehaviour
{
    [SerializeField] private GameObject finishGround;
    [SerializeField] GameStats _gameStats;
    [SerializeField] private Animator myAnim;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "finishline")
        {
            _gameStats.isGameActive = false;
            _gameStats.isFinish = true;
        }
        else if (collider.gameObject.tag == "enemy")
        {
            myAnim.SetTrigger("slap");
            collider.transform.gameObject.GetComponent<EnemyController>().Die();
            Destroy(collider.transform.gameObject, 0.2f);
        }
    }

}
