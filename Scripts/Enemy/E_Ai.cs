using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class E_Ai : MonoBehaviour
{
    public bool roaming = true;
    public Seeker seeker;
    Path path;
    Coroutine movecoroutine;
    public SpriteRenderer characterSR;
    bool reachDestination ;
    public float moveSpeed;
    public float nextWPD;
    public bool updateContinuePath;

    public bool isShootable =false;
    public GameObject bullet;
    public float bulletSpeed;
    public float timeBtwFire;
    private float fireCooldown;
    public Animator animator;
    public bool CanMove = true;
    
    
    
    private Rigidbody2D rb2d;
    
    public Transform target;
    private Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        if (CanMove == true)
        {
            InvokeRepeating("CaculatePath", 0f, 0.5f);
            reachDestination = true;
            animator = GetComponent<Animator>();
            rb2d = GetComponent<Rigidbody2D>();
        }
    }

    
    void Update()
    {
        fireCooldown -= Time.deltaTime;
        if(fireCooldown < 0)
        {
            fireCooldown = timeBtwFire;
            EFireBullet();
        }
        Vector2 direction = target.position - transform.position;
        direction.Normalize();
        movement = direction;

        // Kiểm tra nếu kẻ địch đang di chuyển
        if (movement != Vector2.zero)
        {
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }



    }
    void EFireBullet()
    {
        var bulletTMP = Instantiate(bullet, transform.position, Quaternion.identity);
        Rigidbody2D rb = bulletTMP.GetComponent<Rigidbody2D>();
        Vector3 playerPos = FindObjectOfType<Player>().CR.transform.position;
        Vector3 direction = playerPos - transform.position;
        rb.AddForce (direction.normalized * bulletSpeed, ForceMode2D.Impulse);
    }

    void CaculatePath()
    {
        Vector2 target = FindTarget();
        if (seeker.IsDone()&& (reachDestination || updateContinuePath ))
        {
            seeker.StartPath(transform.position, target, OnPathComplete);
        }
        MoveToTarget();
    }

    void MoveToTarget()
    {
        if(movecoroutine != null) StopCoroutine(movecoroutine);
        movecoroutine = StartCoroutine(MoveToTargetCoroutine());
    }
    IEnumerator MoveToTargetCoroutine()
    {
        int currentWP =0;
        reachDestination = false;
        while (currentWP <path.vectorPath.Count)
        {
            Vector2 dir = ((Vector2)path.vectorPath[currentWP]-(Vector2)transform.position).normalized;
            Vector2 force = dir*moveSpeed*Time.deltaTime;
            transform.position += (Vector3)force;
            float distance = Vector2.Distance(transform.position, path.vectorPath[currentWP]);
            if (distance < nextWPD)
            {
                currentWP++;
                
            }
            if (force.x != 0)
                if (force.x < 0)
                    characterSR.transform.localScale = new Vector3(-1, 1, 0);
                else
                    characterSR.transform.localScale = new Vector3(1, 1, 0);
            yield return null;
        }
        reachDestination =true;
    }

    void OnPathComplete(Path p) 
    {
        if (p.error)
        {
            return;
        }
        path = p;


    }

    Vector2 FindTarget()
    {
        Vector3 playerPos = FindObjectOfType<Player>().CR.transform.position;
        if(roaming ==  true)
        {
            return (Vector2)playerPos + (Random.Range(100f, 500f) * new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized);
        }

        else
        {
            return (Vector2)playerPos; 
        }
    }
}
