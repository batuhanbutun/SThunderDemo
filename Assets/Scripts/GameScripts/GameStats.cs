using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Game/GameStats")]

public class GameStats : ScriptableObject
{
    [SerializeField] private bool _isGameActive = true;
    [SerializeField] private bool _isfinish = false;
    [SerializeField] private int _health = 2;
    [SerializeField] private bool _isSpawnActive = true;

    public bool isSpawnActive { get { return _isSpawnActive; } set { _isSpawnActive = value; } }
    public bool isGameActive { get { return _isGameActive; } set { _isGameActive = value; } }
    public int Health { get { return _health; } set { _health = value; } }
    public bool isFinish { get { return _isfinish; } set { _isfinish = value; } }

}
