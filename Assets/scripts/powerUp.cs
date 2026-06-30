using UnityEngine;
public class powerUp : MonoBehaviour
{

    [SerializeField] private GameObject[] powUp;
    [SerializeField] private Transform[] positions;
    [SerializeField] private float spawnInterval = 0.1f;


    private float timer;
    void Start()
    {
        timer = spawnInterval;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            Spawn();
            timer = spawnInterval;
        }
    }

    private void Spawn()
    {
        int randomPos = Random.Range(0, positions.Length);
        Transform Sposition = positions[randomPos];

        int randomU = Random.Range(0, powUp.Length);
        GameObject RanPoUp = powUp[randomU];
        int ranUP = Random.Range(0, 100);
        if (ranUP < 50 && ranUP % 2==0  &&  ranUP % 3 !=0 )
        {
        Debug.Log(ranUP);
        Instantiate(RanPoUp, Sposition.position, Sposition.rotation);
        }        

    }

}
