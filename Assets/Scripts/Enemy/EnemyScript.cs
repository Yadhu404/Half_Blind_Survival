using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.EventSystems;

public class EnemyScript : MonoBehaviour
{
    public float enemySpeed;
    public float detectDistance;
    public float jitterDistance;
    public LayerMask obstacleLayer;
    private GameObject Player;
    private GameObject ghost;
    private MapTwoObjectSpawner mapTwoObjectSpawner;
    public float enemyHealth = 120f;

    private ShootPointsc shootPointcs;
    private bool enemyFlag;
    private bool needNewDirection = true;

    private bool[] hitPointer = { false, false, false, false }; // 0-right, 1-left, 2-up, 3-down
    private int[] availableDirections = new int[4];
    private int directionCount;
    
    private Vector3 moveDirection;
    private int previousDirection = 0;


    private bool recGhost = true;

    private GhostStaySet ghostStaySet;

    void Start()
    {
        shootPointcs = GetComponentInChildren<ShootPointsc>();
        Player = GameObject.Find("Player");
        mapTwoObjectSpawner = GameObject.Find("Map Objects Spawner/Map2").GetComponent<MapTwoObjectSpawner>();

        
    }

    void Update()
    {
        // if(mapTwoObjectSpawner.isGhostSpawn && recGhost1)
        // {
        //     ghostStaySet = GameObject.Find("Ghost Object/").GetComponent<GhostStaySet>();
        //     recGhost1 = false;
        // }
        if(mapTwoObjectSpawner.isGhostSpawn && recGhost)
        {
            ghost = GameObject.Find("Ghost Object/Ghost(Clone)");
            ghostStaySet = GameObject.Find("Ghost Object/Ghost(Clone)").GetComponent<GhostStaySet>();

            recGhost = false;
        }
        
        if (enemyHealth <= 0)
        {
            gameObject.SetActive(false);
            return;
        }

        if (shootPointcs != null)
        {
            enemyFlag = shootPointcs.flag; // True if enemy sees the player
        }

        if (!enemyFlag)
        {
            DetectObstacles();
            MoveEnemy(); // Normal movement
        }
        else
        {
            if(shootPointcs.victimName == "Player")
            {
                FacePlayer(Player);
                FollowPlayer(Player); // Chase the player
            }
            else  if(shootPointcs.victimName.Contains("Ghost"))
            {
                Debug.Log("Is Hidden : "+ ghostStaySet.isHidden);
                if(!ghostStaySet.isHidden)
                {
                    FacePlayer(ghost);
                    FollowPlayer(ghost); // Chase the ghost
                }
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Catridge"))
        {
            enemyHealth -= 10;
        }
    }

    // Detect obstacles only in the movement direction, unless stuck
    void DetectObstacles()
    {
        if (needNewDirection)
        {
            CheckAllDirections(); // If stuck, check all directions
            ChooseDirection();
        }
        else
        {
            CastRay(moveDirection, previousDirection - 1);
            if (hitPointer[previousDirection - 1]) // If blocked, find a new direction
            {
                needNewDirection = true;
            }
        }
    }

    // Cast a single ray in the given direction
    void CastRay(Vector3 direction, int index)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, detectDistance, obstacleLayer);
        hitPointer[index] = hit.collider != null;
    }

    // Cast rays in all 4 directions
    void CheckAllDirections()
    {
        ResetDetection();
        CastRay(Vector3.right, 0);
        CastRay(Vector3.left, 1);
        CastRay(Vector3.up, 2);
        CastRay(Vector3.down, 3);
    }

    void ChooseDirection()
    {
        directionCount = FindAvailableDirections();
        if (directionCount > 0)
        {
            int randomIndex = Random.Range(0, directionCount);
            int chosenDirection = availableDirections[randomIndex];

            if (previousDirection != GetOppositeDirection(chosenDirection))
            {
                SetDirection(chosenDirection);
                previousDirection = chosenDirection;
                needNewDirection = false; // Reset
            }
        }
    }

    int FindAvailableDirections()
    {
        int count = 0;
        for (int i = 0; i < hitPointer.Length; i++)
        {
            if (!hitPointer[i])
            {
                availableDirections[count] = i + 1; // Store direction (1-right, 2-left, 3-up, 4-down)
                count++;
            }
        }
        return count;
    }

    int GetOppositeDirection(int direction)
    {
        switch (direction)
        {
            case 1: return 2; // Right -> Left
            case 2: return 1; // Left -> Right
            case 3: return 4; // Up -> Down
            case 4: return 3; // Down -> Up
            default: return 0;
        }
    }

    void SetDirection(int direction)
    {
        switch (direction)
        {
            case 1:
                moveDirection = Vector3.right;
                transform.rotation = Quaternion.Euler(0, 0, -90);
                break;
            case 2:
                moveDirection = Vector3.left;
                transform.rotation = Quaternion.Euler(0, 0, 90);
                break;
            case 3:
                moveDirection = Vector3.up;
                transform.rotation = Quaternion.Euler(0, 0, 0);
                break;
            case 4:
                moveDirection = Vector3.down;
                transform.rotation = Quaternion.Euler(0, 0, 180);
                break;
        }
    }

    void ResetDetection()
    {
        for (int i = 0; i < hitPointer.Length; i++)
        {
            hitPointer[i] = false;
            availableDirections[i] = 0;
        }
    }

    void MoveEnemy()
    {
        transform.position += moveDirection * enemySpeed * Time.deltaTime;
    }

    void FacePlayer(GameObject Victim)
    {
        Vector2 directionToPlayer = Victim.transform.position - transform.position;
        float angle = Mathf.Atan2(directionToPlayer.y, directionToPlayer.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle - 90);
    }

    void FollowPlayer(GameObject Victim)
    {
        float distanceToPlayer = Vector3.Distance(transform.position, Victim.transform.position);
        
        if (distanceToPlayer > jitterDistance) // Prevents jitter when very close
        {
            Vector3 targetPosition = Victim.transform.position;
            Vector3 moveDirection = (targetPosition - transform.position).normalized;
            
            // Move towards the player smoothly
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, enemySpeed * Time.deltaTime);
        }
    }

    // void OnDrawGizmosSelected()
    // {
    //     Gizmos.color = Color.green;
    //     Gizmos.DrawLine(transform.position, transform.position + moveDirection * 2);
    // }
}





// void DetectObstacleUD(){
    //     RaycastHit2D hitup = Physics2D.Raycast(transform.position,Vector2.up, detectDistance, obstacleLayer);
    //     RaycastHit2D hitdown = Physics2D.Raycast(transform.position,Vector2.down, detectDistance, obstacleLayer);


    //     if(hitup) {
    //         MoveDir = false;
    //         Debug.Log("/|");
    //     }
    //     else{
    //         if(hitdown){
    //             MoveDir = true;
    //             Debug.Log("|/");
    //         }
    //     }
        
    //     Vector3 directionUD = MoveDir? Vector2.up : Vector2.down;

    //     transform.position = transform.position + (directionUD * enemySPeed) * Time.deltaTime;

    // }