using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private float height = 0;
    private float posY;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        posY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 spriteSize = spriteRenderer.size;

        height += (2f);
         if(height < 50)
         {
            spriteRenderer.size = new Vector2(spriteSize.x, height);

            // posY  = 9.6713f * height;
            // transform.position = new Vector2(transform.position.x,posY);
         }

         Destroy(gameObject, 0.5f);
    }
}
