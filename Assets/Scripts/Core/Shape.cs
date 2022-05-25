using UnityEngine;

public class Shape : MonoBehaviour
{
    private bool rotatable = true;

    public Vector3 queueOffset;

    private bool Rotatable
    {
        get
        {
            return rotatable;
        }
        set
        {
            rotatable = value;
        }
    }

    private void Move(Vector3 moveDirection)
    {
        transform.position += moveDirection;
    }

    public void MoveShape(Vector2 vector2)
    {
        if (vector2.x != 0)
        {
            if (vector2.x < 0)
            {
                MoveShape(MoveDirection.LEFT);
            }
            else if (vector2.x > 0)
            {
                MoveShape(MoveDirection.RIGHT);
            }
        }
        else if (vector2.y < 0)
        {
            MoveShape(MoveDirection.DOWN);
        }
    }


    public void MoveShape(MoveDirection md)
    {
        switch (md)
        {
            case MoveDirection.LEFT:
                Move(new Vector3(-1, 0, 0));
                break;

            case MoveDirection.RIGHT:
                Move(new Vector3(1, 0, 0));
                break;

            case MoveDirection.DOWN:
                Move(new Vector3(0, -1, 0));
                break;

            case MoveDirection.UP:
                Move(new Vector3(0, 1, 0));
                break;
        }
    }

    public void RotateRight()
    {
        if (rotatable)
        {
            transform.Rotate(0, 0, -90);
        }
    }

    public void RotateLeft()
    {
        if (rotatable)
        {
            transform.Rotate(0, 0, 90);
        }
    }

    // Start is called before the first frame update
    private void Start()
    {
        // InvokeRepeating("Test", 0, 0.5f);
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void Test()
    {
        MoveShape(MoveDirection.DOWN);
    }
}