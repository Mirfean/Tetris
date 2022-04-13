using UnityEngine;

public class Board : MonoBehaviour
{
    [SerializeField]
    private Transform m_emptySprite;

    [SerializeField]
    private int m_height = 20;

    [SerializeField]
    private int m_width = 10;

    [SerializeField]
    private int m_header = 8;

    private Transform[,] m_grid;

    private void Awake()
    {
        m_grid = new Transform[m_width, m_height];
    }

    // Start is called before the first frame update
    private void Start()
    {
        DrawEmptyBoard();
    }

    // Update is called once per frame
    private void Update()
    {

    }

    bool IsWiththinBoard(Vector3 v)
    {
        return (v.x >= m_emptySprite.position.x && v.x < m_width + m_emptySprite.position.x && v.y >= m_emptySprite.position.y);
    }

    public bool IsValidPosition(Shape shape)
    {
        foreach (Transform s in shape.transform)
        {
            Vector2 pos = VectorF.Round(s.position);
            if (!IsWiththinBoard(s.position))
            {
                return false;
            }
            
        }
        return false;
    }


    private void DrawEmptyBoard()
    {
        for (int y = 0; y < m_height; y++)
        {
            for (int x = 0; x < m_width; x++)
            {
                Transform clone = Instantiate(m_emptySprite, new Vector3(x + m_emptySprite.position.x, y + m_emptySprite.position.y, 0), Quaternion.identity) as Transform;
                clone.name = $"Board Space {x} {y}";
                clone.transform.parent = transform;
            }
        }
    }
}