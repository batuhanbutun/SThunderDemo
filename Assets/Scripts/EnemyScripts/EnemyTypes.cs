using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Enemy/EnemyType")]

public class EnemyTypes : ScriptableObject
{

    [SerializeField] private int _enemyType = 0;


    public int EnemyType { get { return _enemyType; } }

    


}
