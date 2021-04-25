using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject barrier;
    public Animator animator;
    public float gravityScale;
    public float moveSpeed;
    public static int maxGravityAmmo = 1;
    public float jumpForce ;
    public static bool rewindUsed = false;
    public bool isRewinding = false;
    public static int canRewindTime = 0;
    public SpriteRenderer body;
    int gravityAmmo;
    List<Vector2> positionsPlayer;
    List<Vector2> positionsBarrier;
    Vector2 movement;
    private void Awake()
    {
        canRewindTime = PlayerPrefs.GetInt("RewindActivated");
        maxGravityAmmo = PlayerPrefs.GetInt("JumpCount");
        if (maxGravityAmmo == 0) maxGravityAmmo = 1;
        gravityAmmo = maxGravityAmmo;
        rb = transform.GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        positionsPlayer = new List<Vector2>();
        positionsBarrier = new List<Vector2>();
    }
    void Update()
    {
        if (canRewindTime == 1)
        {
            if (Input.GetKeyDown(KeyCode.Return) && !rewindUsed)
            {
                StartRewinding();
            }
            if (Input.GetKeyUp(KeyCode.Return))
            {
                StopRewinding();
            }
        }
        bool death = FindObjectOfType<DeathScreen>().deathActive;
        if (Input.GetKeyDown(KeyCode.Space) && gravityAmmo > 0 && !PauseMenu.GamePaused && !death)
        {
            rb.velocity = Vector2.down * jumpForce;
            FindObjectOfType<AudioManager>().Play("Jump");
            gravityAmmo--;
            animator.SetTrigger("Jump");
        }

        movement.x = Input.GetAxis("Horizontal");

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Platform")
        {
            gravityAmmo = maxGravityAmmo;
            animator.SetTrigger("TouchGround");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Barriers")
        {
            FindObjectOfType<AudioManager>().Play("Fall");
            
            float highscore = PlayerPrefs.GetFloat("Highscore");
            if (highscore > Score.score)  PlayerPrefs.SetFloat("Highscore", Score.score);
            FindObjectOfType<DeathScreen>().Death();
        }
    }
    private void FixedUpdate()
    {
        if (isRewinding)
            Rewind();
        else
            Record();
       transform.Translate( movement * moveSpeed/2);
    }
    void StartRewinding()
    {
        isRewinding = true;
    }
    void StopRewinding()
    {
        isRewinding = false;
        rewindUsed = true;
    }
    void Record()
    {
        positionsPlayer.Insert(0, transform.position);
        positionsBarrier.Insert(0, barrier.transform.position);
    }
    void Rewind()
    {
        if (positionsPlayer.Count > 0 && positionsBarrier.Count > 0)
        {
            transform.position = positionsPlayer[0];
            positionsPlayer.RemoveAt(0);
            barrier.transform.position = positionsBarrier[0];
            positionsBarrier.RemoveAt(0);
        }
        else
        {
            StopRewinding();
            return;
        }
        
    }
}
