using UnityEngine;

public class bg : MonoBehaviour
{
    private Material material;
    [SerializeField] float parallaxFactor = 0.01f;
    private float offset;
    public float gameSpeed = 10f;

    void Start()
    {
        material = GetComponent<Renderer>().material;
    }

    void Update()
    {
        ParallaxSroll();
    }

    private void ParallaxSroll()
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

        float speed = gameSpeed * parallaxFactor * diff * upSpeed* up_diff;

        offset += Time.deltaTime * speed;

        offset = Mathf.Repeat(offset, 1f);

        material.SetTextureOffset("_MainTex", Vector2.up * offset);
    }
}