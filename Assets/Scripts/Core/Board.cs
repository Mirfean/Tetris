using System.Collections.Generic;
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
    private int m_header = 4;

    private Transform[,] m_grid;

    private Vector3Int modifier;

    public int Height { get => m_height; set => m_height = value; }
    public int Width { get => m_width; set => m_width = value; }

    private void Awake()
    {
        m_grid = new Transform[m_width, m_height + m_header];
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
                //Debug.Log($"Not in Board! {pos}");
                return false;
            }
            if (pos.y <= m_emptySprite.position.y + m_height)
            {
                if (IsOccupied((int)pos.x, (int)pos.y, shape))
                {
                    Debug.Log($"Occupied! {pos.x}, {pos.y}");
                    return false;
                }
            }
        }
        return true;
    }

    bool IsComplete(int y)
    {
        for (int x = 0; x < m_width; ++x)
        {
            if (m_grid[x, y] == null)
            {
                return false;
            }

        }
        return true;
    }

    void ClearRow(int y)
    {
        for (int x = 0; x < m_width; ++x)
        {
            if (m_grid[x, y] != null)
            {
                Destroy(m_grid[x, y].gameObject);

            }
            m_grid[x, y] = null;

        }

    }

    void ShiftOneRowDown(int y)
    {

        for (int x = 0; x < m_width; ++x)
        {
            if (m_grid[x, y] != null)
            {
                m_grid[x, y - 1] = m_grid[x, y];
                m_grid[x, y] = null;
                m_grid[x, y - 1].position += new Vector3(0, -1, 0);
            }
        }
    }

    void ShiftRowsDown(int startY)
    {
        for (int i = startY; i < m_height; ++i)
        {
            ShiftOneRowDown(i);
        }
    }

    public int ClearAllRows()
    {
        SoundManager soundManager = GameObject.FindObjectOfType<SoundManager>();
        int tetris = 0;
        for (int y = 0; y < m_height; ++y)
        {
            if (IsComplete(y))
            {
                ClearRow(y);

                ShiftRowsDown(y + 1);

                y--;

                tetris++;
            }

        }
        if (tetris > 0 && tetris < 4 && soundManager.FxEnabled)
        {
            soundManager.PlaySound(soundManager.ClearRowSound, soundManager.FxVolume);
        }
        else if (tetris == 4 && soundManager.FxEnabled)
        {
            soundManager.PlaySound(soundManager.TetrisSound, soundManager.FxVolume);
        }
        return tetris;
    }

    public bool IsOccupied(int x, int y, Shape shape)
    {
        try
        {
            return m_grid[x, y] != null && m_grid[x, y].parent != shape.transform;
        }
        catch
        {
            if (y <= m_emptySprite.position.y + m_height + 4)
            {
                return false;
            }
            else
            {
                throw new System.IndexOutOfRangeException("Occupied error");
            }
        }
    }


    private void DrawEmptyBoard()
    {
        for (int y = 0; y < m_height; y++)
        {
            for (int x = 0; x < m_width; x++)
            {
                if(y == 0 && x == 0)
                {
                    continue;
                }
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
           if (shape != null)
            {
                foreach (Transform child in shape.transform)
                {
                    Vector2 pos = VectorF.Round(child.position);
                    Debug.Log($"Filling {pos.x} {pos.y}");
                    m_grid[(int)pos.x, (int)pos.y] = child;
                }
            }
            
        }
        catch (System.IndexOutOfRangeException e)
        {
            Debug.Log($"Out of range - {e}");
        }
        List<string> table = new List<string>();
        for (int j = 0; j < m_height; j++)
        {
            string line = "";
            for  (int i = 0; i < m_width; i++)
            {
                if ((m_grid[i,j] != null))
                {
                    line += "x";
                }
                else
                {
                    line += "o";
                }
                
            }
            table.Add(line);

        }
        //table.ForEach(Debug.Log);

    }

    public bool IsOverLimit(Shape shape)
    {
        foreach (Transform child in shape.transform)
        {
            if (child.transform.position.y >= m_height)
            {
                return true;
            }
        }
        return false;
    }

    Vector3Int getModifier()
    {
        return new Vector3Int((int)m_emptySprite.position.x, (int)m_emptySprite.position.y, (int)m_emptySprite.position.z);
    }

}