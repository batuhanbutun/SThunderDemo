using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireScript : MonoBehaviour
{
    [SerializeField] List<GameObject> _bulletCounter;

    [SerializeField] GameObject _bullet;
    [SerializeField] GameObject weaponBarell;
    [SerializeField] BulletController _bulletController; 
    [SerializeField] Text _scoreText;
    [SerializeField] Text _ammoText;

    [SerializeField] AudioSource playerAudio;
    [SerializeField] AudioClip fireSound;
    [SerializeField] AudioClip reloadSound;
    [SerializeField] AudioClip explosionSound;

    [SerializeField] ParticleSystem explosionParticle;
    [SerializeField] ParticleSystem powerupParticle;

    [SerializeField] Animator myAnim;
    [SerializeField] GameStats _gameStats;

    private int score = 0;
    private int ammo = 8;
    public Transform _enemyPos;

    private int bonusCount = 1;

    private float reloadCooldown=0f;
    private float triggerCooldown = 0f;

    private float powerupCooldown = 0f;
    private bool unlimitedAmmo = false;
    public EnemyController _enemyController;
    void Start()
    {
        _scoreText.text = score.ToString();
        _ammoText.text = ammo.ToString();

       
    }

    
    void Update()
    {
        if (_gameStats.isGameActive)
        {
            triggerCooldown -= Time.deltaTime;
            AmmoControl();
            UpdateScore();
            if (Input.GetMouseButtonDown(0) && ammo > 0 && reloadCooldown <= 0)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 100.0f) && hit.transform.gameObject != null)
                {
                    if (hit.transform.tag == "enemy")
                    {
                        playerAudio.time = 1f;
                        playerAudio.PlayOneShot(fireSound);
                        if (triggerCooldown <= 0f)
                        {
                            myAnim.SetTrigger("fire");
                            triggerCooldown = 0.5f;
                        }

                        Instantiate(_bullet, weaponBarell.transform.position, _bullet.transform.rotation);
                        _enemyPos = hit.transform;
                        hit.transform.gameObject.GetComponent<EnemyController>().Die();
                        Destroy(hit.transform.gameObject, 0.5f);
                        score += 5;
                        bonusCount = 1;
                        if (!unlimitedAmmo)
                            ammo--;
                    }
                    else if (hit.transform.tag == "powerup")
                    {
                        playerAudio.PlayOneShot(fireSound);
                        if (triggerCooldown <= 0f)
                        {
                            myAnim.SetTrigger("fire");
                            triggerCooldown = 0.5f;
                        }
                        Instantiate(_bullet, weaponBarell.transform.position, _bullet.transform.rotation);
                        _enemyPos = hit.transform;
                        Instantiate(powerupParticle, _enemyPos.position + new Vector3(0, 2, 0), powerupParticle.transform.rotation);
                        Destroy(hit.transform.gameObject);
                        powerupCooldown = 5f;
                        unlimitedAmmo = true;
                    }
                    else if (hit.transform.tag == "explosion")
                    {
                        playerAudio.PlayOneShot(fireSound);
                        if (triggerCooldown <= 0f)
                        {
                            myAnim.SetTrigger("fire");
                            triggerCooldown = 0.5f;
                        }
                        Instantiate(_bullet, weaponBarell.transform.position, _bullet.transform.rotation);
                        _enemyPos = hit.transform;
                        Destroy(hit.transform.gameObject);
                        playerAudio.PlayOneShot(explosionSound);
                        Instantiate(explosionParticle, _enemyPos.position + new Vector3(0, 2, 0), explosionParticle.transform.rotation);
                        if (!unlimitedAmmo)
                            ammo--;
                        Collider[] hitColliders = Physics.OverlapSphere(hit.point, 20f);
                        foreach (var hitCollider in hitColliders)
                        {
                            if (hitCollider.transform.tag == "enemy")
                            {
                                hitCollider.transform.gameObject.GetComponent<EnemyController>().Die();
                                Destroy(hitCollider.transform.gameObject, 0.2f);
                            }

                        }
                    }
                }
            }
        }
    }

    private void UpdateScore()
    {
        _scoreText.text = score.ToString();
    }

    private void AmmoControl()
    {
        for (int i = 7; i > ammo-1; i--)
        {
            _bulletCounter[i].gameObject.SetActive(false);
        }
        if(reloadCooldown > 0)
        reloadCooldown -= Time.deltaTime;
        else if (reloadCooldown <= 0)
            _ammoText.text = ammo.ToString();
        if (ammo <= 0)
        {
            reloadCooldown = 1f;
            ammo = 8;
            playerAudio.PlayOneShot(reloadSound);

            for(int i = 0; i < 7; i++)
            {
                _bulletCounter[i].gameObject.SetActive(true);
            }

        }
        if (unlimitedAmmo)
        {
            powerupCooldown -= Time.deltaTime;
            if (powerupCooldown <= 0)
                unlimitedAmmo = false;
        }
    }
}
