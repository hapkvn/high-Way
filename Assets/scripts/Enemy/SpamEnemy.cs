
using UnityEngine;


public class SpamEnemy : MonoBehaviour
{
    [SerializeField] private GameObject[] enemy;
    [SerializeField] private Transform[] positions;
    private float timer;
    private float minTime = 1f;
    private float maxTime = 20f;

    void Start()
    {
        timer = Random.Range(minTime, maxTime)/10;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        float upSpeed = player.instance.up_speed();
        if (timer <= 0f)
        {              
            Spawn();
            timer = Random.Range(minTime, maxTime)/(10* upSpeed);    
        }
    }

    private void Spawn()
    {
        int randomPos = Random.Range(0, positions.Length);
        Transform Sposition = positions[randomPos];

        int randomE = Random.Range(0, enemy.Length);
        GameObject RanEnemy = enemy[randomE];

        Instantiate(RanEnemy, Sposition.position, Sposition.rotation);       

    }   


}
