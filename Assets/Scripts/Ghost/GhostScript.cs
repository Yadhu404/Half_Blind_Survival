using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostScript : MonoBehaviour
{
    //Ghost Properties
    public float ghostSpeed = 7f;

    //Movement
    private bool needNewDirection = true;
    private int directionCount;
    private Vector3 moveDirection;
    private int previousDirection = 0;
    public LayerMask obstacleLayer;
    public float detectDistance;

    private bool[] hitPointer = { false, false, false, false }; // 0-right, 1-left, 2-up, 3-down
    private int[] availableDirections = new int[4];

    //Flags
    

    //Scripts
    private GhostScreamSound ghostScreamSound;

    //GameObjects
    private GameObject ParentObj;

    // Start is called before the first frame update
    void Start()
    {
        ParentObj = GameObject.Find("Ghost Object");
        transform.SetParent(ParentObj.transform);

        ghostScreamSound = GetComponent<GhostScreamSound>();
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D isPlayer = Physics2D.OverlapCircle(transform.position,4f,LayerMask.GetMask("Player"));

        if(isPlayer != null && !ghostScreamSound.canMove)
        {
            StartCoroutine(ghostScreamSound.CallScreamFn());
        }

        if(ghostScreamSound.canMove)
        {
            MoveGhost();
            DetectObstacles();
        }
    }


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

    void MoveGhost()
    {
        transform.position += moveDirection * ghostSpeed * Time.deltaTime;
    }

    // void OnDrawGizmosSelected()
    // {
    //     Gizmos.color = Color.green;
    //     Gizmos.DrawLine(transform.position, transform.position + moveDirection * 2);
    // }
}
