using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostShape : MonoBehaviour
{
    Shape ghostSprite = null;
    bool hitBottom = false;
    [SerializeField]
    Color color = new Color(1f, 1f, 1f, 0.2f);

    public void ProjectGhost(Shape originalShape, Board gameboard)
    {
        if (!ghostSprite)
        {
            ghostSprite = Instantiate(originalShape, originalShape.transform.position, originalShape.transform.rotation) as Shape;
            ghostSprite.gameObject.name = "GhostShape";

            SpriteRenderer[] allRenderers = ghostSprite.GetComponentsInChildren<SpriteRenderer>();

            foreach (SpriteRenderer renderer in allRenderers)
            {
                renderer.color = color;
            }
        }

        else
        {
            ghostSprite.transform.position = originalShape.transform.position;
            ghostSprite.transform.rotation = originalShape.transform.rotation;
        }

        hitBottom = false;

        while (!hitBottom)
        {
            ghostSprite.MoveShape(MoveDirection.DOWN);
            if (!gameboard.IsValidPosition(ghostSprite))
            {
                ghostSprite.MoveShape(MoveDirection.UP);
                hitBottom = true;
            }
        }

    }

    public void Killghost()
    {
        if (ghostSprite != null)
        {
            Destroy(ghostSprite.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
