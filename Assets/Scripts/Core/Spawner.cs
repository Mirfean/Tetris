using System.Security.Cryptography;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Shape[] t_Shapes;

    public Transform[] queue = new Transform[3];
     
    Shape[] queuedShapes = new Shape[3];
    private Shape GetRandomShape()
    {
        int i = Random.Range(0, t_Shapes.Length);
        if (t_Shapes[i])
        {
            return t_Shapes[i];
        }
        else
        {
            Debug.LogWarning("This Shape doesn't exist!");
            return null;
        }
    }

    public Shape SpawnShape()
    {
        //Shape shape = Instantiate(GetRandomShape(), transform.position, Quaternion.identity) as Shape;

        Shape shape = GetQueuedShape();

        shape.transform.position = transform.position;

        shape.transform.localScale = new Vector3(1f, 1f, 1f);

        if (shape)
        {
            return shape;
        }
        else
        {
            Debug.LogWarning("Invalid Shape to spawn!");
            return null;
        }
    }

    private void Awake()
    {
        InitQueue();
    }

    void InitQueue()
    {
        for (int i = 0; i < queuedShapes.Length; i++)
        {
            queuedShapes[i] = null;
        }
        FillQueue();
    }

    void FillQueue()
    {
        for (int j = 0; j < queuedShapes.Length; j++)
        {
            if (queuedShapes[j] == null)
            {
                queuedShapes[j] = Instantiate(GetRandomShape(), transform.position, Quaternion.identity) as Shape;
                queuedShapes[j].transform.position = ChangeZ(Camera.main.ScreenToWorldPoint(queue[j].position), 0f);
                queuedShapes[j].transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            }
        }
    }

    Shape GetQueuedShape()
    {
        Shape firstShape = null;

        if (queuedShapes[0])
        {
            firstShape = queuedShapes[0];
        }

        for (int i = 1; i < queuedShapes.Length; i++)
        {
            queuedShapes[i - 1] = queuedShapes[i];
            queuedShapes[i - 1].transform.position = ChangeZ(Camera.main.ScreenToWorldPoint(queue[i - 1].position), 0f);
        }

        queuedShapes[queuedShapes.Length - 1] = null;

        FillQueue();

        return firstShape;
    }

    Vector3 ChangeZ(Vector3 vector3, float position)
    {
        Vector3 temp = vector3;
        temp.z = position;
        return temp;
    }
}