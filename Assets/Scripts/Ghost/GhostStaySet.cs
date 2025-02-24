using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph;
using UnityEngine;

public class GhostStaySet : MonoBehaviour
{
    public float[] GhostPosX = {};
    public float[] GhostPosY = {};

    public float detectDistance = 4f;

    private Color newColor;

    public bool isHidden = true;

    private SpriteRenderer spriteRenderer;

    private GhostScreamSound ghostScreamSound;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        ghostScreamSound = GetComponent<GhostScreamSound>();

        Color newColor = spriteRenderer.color;
        newColor.a = 0f;
        spriteRenderer.color = newColor;
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D isSkeleton = Physics2D.OverlapCircle(transform.position,detectDistance,LayerMask.GetMask("Skeleton"));

        if(isSkeleton != null)
        {
            Hide();
        }
        else
        {
            isHidden = false;
        }

        if(ghostScreamSound.canMove)
        {
            isHidden = false;
            
            newColor.a = 255f;
            newColor.r = 255f;
            newColor.g = 255f;
            newColor.b = 255f;
            spriteRenderer.color = newColor;

           StartCoroutine(waitforTenSec());
        }
    }

    void Hide()
    {
        isHidden = true;

        ghostScreamSound.canMove = false;

        detectDistance = 4f;

        newColor.a = 0f;
        spriteRenderer.color = newColor;
    }
    

    IEnumerator waitforTenSec()
    {
        yield return new WaitForSeconds(3);

        detectDistance = 10f;
    }
}
