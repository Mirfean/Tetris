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
        Shape shape = Instantiate(GetRandomShape(), transform.position, Quaternion.identity) as Shape;
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

    private void Start()
    {
        FillQueue();
    }

    void InitQueue()
    {
        for (int i = 0; i < queuedShapes.Length; i++)
        {
            queuedShapes[i] = null;
        }
    }

    void FillQueue()
    {
        for (int j = 0; j < queuedShapes.Length; j++)
        {
            if (queuedShapes[j] == null)
            {
                queuedShapes[j] = Instantiate(GetRandomShape(), transform.position, Quaternion.identity) as Shape;
                Vector3 vector3 = Camera.main.ScreenToWorldPoint(queue[j].position);
                vector3.z = 0;
                queuedShapes[j].transform.position = vector3;
                queuedShapes[j].transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            }
        }
    }
}