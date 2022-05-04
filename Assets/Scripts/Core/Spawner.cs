using System.Security.Cryptography;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Shape[] t_Shapes;

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

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }
}