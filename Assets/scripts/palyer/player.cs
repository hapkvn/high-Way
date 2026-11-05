using UnityEngine;

public class player : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D boxCollider2D;

    [Header("Player Movement")]
    [SerializeField] private float speed = 10f;
    [SerializeField] private float MaxX = 2f;
    [SerializeField] private float MinX = -2f;
    [SerializeField] private float MaxY = 4.4f;
    [SerializeField] private float MinY = -4.4f;

    [Header("Power-ups")]
    [SerializeField] private float flyTime = 2f;
    [SerializeField] private float SP_Time = 10f;

    private float ui_moveX;
    private float ui_moveY;

    private int count_down_shield = 0;
    private float speed_upp = 1f;
    private float timer;
    private float timer_sp;

    private bool isSpeedUp = false;
    private bool isShield = false;
    private bool isFlying = false;

    private Vector2 moveDirection;
    private Animator animator;

    public static player instance;

    [SerializeField] private AudioManager audioManager;

    private void Awake()
    {
        if (instance == null) instance = this;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        timer = flyTime;
        timer_sp = SP_Time;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        MovePlayer();
        HandleSpeedUpTimer();
        HandleFlyTimer();
    }

    public void setMoveX(float value) { ui_moveX = value; }
    public void setMoveY(float value) { ui_moveY = value; }

    private void MovePlayer()
    {
        float MoveX = ui_moveX;
        float MoveY = ui_moveY;

        if (MoveX == 0) MoveX = Input.GetAxisRaw("Horizontal");
        if (MoveY == 0) MoveY = Input.GetAxisRaw("Vertical");

        if (transform.position.x >= MaxX && MoveX > 0) MoveX = 0;
        if (transform.position.x <= MinX && MoveX < 0) MoveX = 0;
        if (transform.position.y >= MaxY && MoveY > 0) MoveY = 0;
        if (transform.position.y <= MinY && MoveY < 0) MoveY = 0;

        moveDirection = new Vector2(MoveX, MoveY).normalized;
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = moveDirection * speed;

        Vector3 clampPosition = transform.position;
        clampPosition.x = Mathf.Clamp(clampPosition.x, MinX, MaxX);
        clampPosition.y = Mathf.Clamp(clampPosition.y, MinY, MaxY);
        transform.position = clampPosition;
    }

    private void HandleSpeedUpTimer()
    {
        if (isSpeedUp)
        {
            timer_sp -= Time.deltaTime;
            if (timer_sp <= 0)
            {
                speed_upp = 1f;
                isSpeedUp = false;
            }
        }
    }

    public void fly()
    {
        if (!isFlying)
        {
            audioManager.playFly();
            animator.SetBool("fly", true);
            isFlying = true;
            timer = flyTime;
            boxCollider2D.enabled = false;
        }
    }

    private void HandleFlyTimer()
    {
        if (Input.GetKeyDown(KeyCode.Space)) fly();

        if (isFlying)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                animator.SetBool("fly", false);
                isFlying = false;
                boxCollider2D.enabled = true;
            }
        }
    }

    public void activeShield()
    {
        isShield = true;
        count_down_shield = 0;
        animator.SetBool("shield", true);
    }

    public void activeSpeed()
    {
        isSpeedUp = true;
        timer_sp = SP_Time;
        if (Manager.instance != null) speed_upp = Manager.instance.up_difficulty() * 2f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("shield"))
        {
            audioManager.playPowerUp();
            Destroy(collision.gameObject);
            animator.SetBool("shield", true);
            isShield = true;
            count_down_shield = 0;
        }
        else if (collision.gameObject.CompareTag("enemy"))
        {
            if (isShield)
            {
                count_down_shield++;
                audioManager.playcrash_S();
                Debug.Log("Khiên đã chặn quái! Số lần vỡ: " + count_down_shield);
                Destroy(collision.gameObject);

                if (count_down_shield >= 3)
                {
                    count_down_shield = 0;
                    isShield = false;
                    animator.SetBool("shield", false);
                }
            }
        }

        if (collision.gameObject.CompareTag("speedUp"))
        {
            audioManager.playPowerUp();
            Destroy(collision.gameObject);
            isSpeedUp = true;
            timer_sp = SP_Time;
            if (Manager.instance != null) speed_upp = Manager.instance.up_difficulty() * 2f;
        }
    }

    public float up_speed() { return speed_upp; }
    public bool isShieldActive() { return isShield; }
    public bool isSpeedUpActive() { return isSpeedUp; }
}