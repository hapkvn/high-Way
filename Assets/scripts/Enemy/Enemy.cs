using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Transform player_Tranfrom;
    private bool has_pass = false;
    [SerializeField] private float speed = 10f;

    private void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("player");
        if (playerObj != null)
        {
            player_Tranfrom = playerObj.transform;
        }
    }

    void Update()
    {
        move();
        removeEnemey();
        pass_Player();
    }

    public void move()
    {
        float diff = 1f;
        if (SettingManager.Instance != null)
        {
            diff = SettingManager.Instance.GetDifficultyLevel();
        }

        float upSpeed = 1f;
        if (player.instance != null)
        {
            upSpeed = player.instance.up_speed();
        }

        float up_diff = 1f;
        if (Manager.instance != null)
        {
            up_diff = Manager.instance.up_difficulty();
        }

        Vector3 v3 = Vector3.down * speed * upSpeed * up_diff * diff * Time.deltaTime;
        transform.position += v3;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            
            if (player.instance.isShieldActive() || player.instance.isSpeedUpActive())
            {
                
                Debug.Log("Quái đã đập vào khiên và tự hủy!");
                Destroy(gameObject);
            }
            else
            {
                
                AudioManager.instance.playCrash();
                Time.timeScale = 0f;
                Manager.instance.ui();
                Debug.Log("Đã chạm người và Game Over!");
            }
        }
    }

    public bool pass_Player()
    {
        if (!gameObject.CompareTag("enemy"))
        {
            return false;
        }
        else if (player_Tranfrom != null && has_pass == false && transform.position.y < player_Tranfrom.position.y)
        {
            has_pass = true;

            if (Manager.instance != null)
            {
                Manager.instance.AddScore();
            }
            return true;
        }
        return false;
    }

    private void removeEnemey()
    {
        if (transform.position.y < -5f)
        {
            Destroy(gameObject);
        }
    }
}