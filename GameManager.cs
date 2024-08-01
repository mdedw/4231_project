using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    
    public static GameManager instance;
    [HideInInspector] public Transform player_transform;
    [HideInInspector] public Transform crystalTransform;
    [SerializeField] private Transform spawnPoint;
    //prefabs
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject enemy2Prefab;
    [SerializeField] private GameObject enemy3Prefab;
    [SerializeField] public GameObject plant1Prefab;
    [SerializeField] public GameObject plant2Prefab;
    [SerializeField] public GameObject plant3Prefab;
    [SerializeField] public GameObject projectilePrefab;
    [SerializeField] public GameObject potionEffectPrefab;

    private WaitForSeconds waitTime;
    private WaitForSeconds waitTime2;
     private WaitForSeconds waitTime3;
    public int seedAmount;
    public int seed2Amount;
    public int seed3Amount;
    //[SerializeField] public float player_health;
    [SerializeField] public GameObject UI;
    [SerializeField] public GameObject LoseScreen;
    //public int pause = 0;
    
    

    private void Awake() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else {
            Destroy (gameObject);
        }
        LoseScreen.active = false;
    }


    private void Start() {
        //spawnEnemy();
        //enemyList = new List<enemy_script>();
        waitTime = new WaitForSeconds(7.0f);
        waitTime2 = new WaitForSeconds(15.0f);
        waitTime3 = new WaitForSeconds(30.0f);
        seedAmount = 0;
        seed2Amount = 0;
        seed3Amount = 0;
        StartCoroutine(spawnEnemy());
        StartCoroutine(spawnEnemy2());
        StartCoroutine(spawnEnemy3());
    }


    public void GameOver() {  
        Debug.Log("Game Over");
        Time.timeScale = 0;
        UI.active = false;

        LoseScreen.active = true;
    }


    //enemy spawners
    public IEnumerator spawnEnemy() {
        yield return waitTime;
        //enemyList.Add(Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity).GetComponent<enemy_script>());
        Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
        StartCoroutine(spawnEnemy());
    }


    public IEnumerator spawnEnemy2() {
        yield return waitTime2;
        Instantiate(enemy2Prefab, spawnPoint.position, Quaternion.identity);
        StartCoroutine(spawnEnemy2());
    }


    public IEnumerator spawnEnemy3() {
        yield return waitTime3;
        Instantiate(enemy3Prefab, spawnPoint.position, Quaternion.identity);
        StartCoroutine(spawnEnemy3());
    }


    public void potionEffect(float x, float y, float z) {
        Vector3 potionSpawnPoint = new Vector3(x, y, z);
        Instantiate(potionEffectPrefab, potionSpawnPoint, Quaternion.identity);
    }
}
