using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Holder : MonoBehaviour
{
    public Transform holderSpace;
    public Shape heldShape = null;
    float scale = 0.4f;
    public bool canRelease = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Catch(Shape shape)
    {
        if (heldShape)
        {
            Debug.LogWarning("Release a shape before trying to hold!");
            return;
        }
        
        if (!shape)
        {
            Debug.LogWarning("Invalid shape!");
            return;
        }

        if (holderSpace)
        {
            shape.transform.position = Spawner.ChangeZ(Camera.main.ScreenToWorldPoint(holderSpace.position), 0f) + shape.queueOffset;
            shape.transform.localScale = new Vector3(scale, scale, scale);
            heldShape = shape;
            canRelease = false;
        }
        else
        {
            Debug.LogWarning("Holder has no transform assigned!");
        }
    }

    public Shape Release()
    {
        heldShape.transform.localScale = Vector3.one;
        Shape shape = heldShape;
        heldShape = null;
        canRelease = false;    
        
        return shape;
            
    }


}
