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

    private Vector3Int modifier;

    private void Awake()
    {
        m_grid = new Transform[m_width, m_height];
    }

    // Start is called before the first frame update
    private void Start()
    {
        DrawEmptyBoard();
        modifier = getModifier();
        Debug.Log("Modifier " + modifier);
    }

    // Update is called once per frame
    private void Update()
    {

    }

    bool IsWiththinBoard(Vector3 v)
    {
        return (
            v.x >= m_emptySprite.position.x &&
            v.x < m_width + m_emptySprite.position.x &&
            v.y >= m_emptySprite.position.y);
    }

    public bool IsValidPosition(Shape shape)
    {
        foreach (Transform s in shape.transform)
        {
            Vector2 pos = VectorF.Round(s.position);
            //Vector2 pos = new Vector2Int((int)s.position.x, (int)s.position.y);
            if (!IsWiththinBoard(pos))
            {
                Debug.Log($"Not in Board! {pos}");
                return false;
            }
            if (pos.y <= m_emptySprite.position.y + m_height)
            {
                if (IsOccupied((int)pos.x - modifier.x, (int)pos.y - modifier.y, shape))
                {
                    Debug.Log($"Occupied! {pos.x} - {modifier.x}, {pos.y} - {modifier.y}");
                    return false;
                }
            }
        }
        return true;
    }

    public bool IsOccupied(int x, int y, Shape shape)
    {
/*        if (m_grid[x,y] != null)
        {
            Debug.Log($"not null in{x} {y}");
        }
        if (m_grid[x, y].parent != shape.transform)
        {
            Debug.Log($"parent in{x} {y} " + m_grid[x, y].parent);
        }*/
        return m_grid[x, y] != null && m_grid[x, y].parent != shape.transform;
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

    public void StoreShapeInGrid(Shape shape)
    {
        if (shape == null)
        {
            return;
        }
        try
        {
            foreach (Transform child in shape.transform)
            {
                Vector2 pos = VectorF.Round(child.position);
                Debug.Log($"Filling {pos.x} {pos.y}");
                m_grid[(int)pos.x, (int)pos.y] = child;
            }
        }
        catch (System.IndexOutOfRangeException e)
        {
            Debug.Log($"Out of range - {e}");
        }

    }

    Vector3Int getModifier()
    {
        return new Vector3Int((int)m_emptySprite.position.x, (int)m_emptySprite.position.y, (int)m_emptySprite.position.z);
    }

}