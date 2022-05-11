using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;
    [SerializeField] private GameStats _gameStats;
    [SerializeField] private List<Scene> scenes;
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _restartButton;
    [SerializeField] private GameObject _endPanel;
    [SerializeField] Text _scoreText;
    [SerializeField] Text endPanelText;
    [SerializeField] private GameObject player;

    private float spawnRate = 5f;
    private float xRange = 2.5f;
    private float zPos;


    void Start()
    {
        _gameStats.Health = 2;
        _gameStats.isGameActive = false;
        _gameStats.isFinish = false;
        _restartButton.gameObject.SetActive(false);
    }

   
    void Update()
    {
       
        if (_gameStats.Health <= 0)
        {
            _restartButton.gameObject.SetActive(true);
        }

        if (_gameStats.isFinish == true)
        {
            _endPanel.gameObject.SetActive(true);
            endPanelText.text = _scoreText.text;
        }
    }

    IEnumerator SpawnEnemy()
    {
        while (_gameStats.isSpawnActive)
        {
            yield return new WaitForSeconds(spawnRate);
            Instantiate(_enemy, RandomSpawnPos(), _enemy.transform.rotation);
        }
    }

    private Vector3 RandomSpawnPos()
    {
        zPos = player.transform.position.z + 20f;
        return new Vector3(Random.Range(-xRange, xRange), -0.55f,zPos);
    }

    public void SetStart()
    {
        
        _startButton.gameObject.SetActive(false);
        _gameStats.isGameActive = true;
        _gameStats.Health = 6;
        _gameStats.isSpawnActive = true;
        StartCoroutine(SpawnEnemy());
    }

    public void RestartGame()
    {
        int index = Random.Range(0, 3);
        if (index == 1)
            SceneManager.LoadScene("SampleScene");
        else
            SceneManager.LoadScene("SampleScene1");

    }

}
