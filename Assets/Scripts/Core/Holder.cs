using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Holder : MonoBehaviour
{
    public Transform holderSpace;
    public Shape heldShape = null;
    float scale = 0.4f;

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

            return;
        }
        
        if (!shape)
        {
            Debug.LogWarning("Invalid shape!");
            return;
        }

        if (holderSpace)
        {
            //shape.transform.position = holderSpace.position + shape.
        }
    }


}
