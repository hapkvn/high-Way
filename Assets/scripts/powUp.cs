using UnityEngine;

public class powUp : MonoBehaviour
{
    
    [SerializeField] private float speed = 10f;

    private void Start()
    {
    }

    void Update()
    {
        move();
        removeEnemey();
      

    }

    public void move()
    {

        float diff = 1;
        if (SettingManager.Instance != null)
        {
            diff = SettingManager.Instance.GetDifficultyLevel();
        }

        float upSpeed = player.instance.up_speed();
        float up_diff = Manager.instance.up_difficulty();
        Vector3 v3 = Vector3.down * speed * upSpeed * up_diff * diff * Time.deltaTime;
        transform.position += v3;
    }
   


    private void removeEnemey()
    {
        if (transform.position.y < -5f)
        {
            Destroy(gameObject);
        }

    }
}
