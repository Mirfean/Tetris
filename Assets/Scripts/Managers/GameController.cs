using UnityEngine;

public class GameController : MonoBehaviour
{
    private Board gameBoard;

    private Spawner gameSpawner;

    private Shape activeShape;
    private float activeShapeSpeed;
    private float nextMove;

    // Start is called before the first frame update
    private void Start()
    {
        gameBoard = GameObject.FindWithTag("Board").GetComponent<Board>();
        gameSpawner = GameObject.FindWithTag("Spawner").GetComponent<Spawner>();
        activeShapeSpeed = 0.15f;
    }

    // Update is called once per frame
    private void Update()
    {
        Debug.Log(Input.GetAxis("MoveRight"));
        switch (Input.inputString)
        {
            case "MoveRight":
                activeShape.MoveShape(MoveDirection.RIGHT);
                if (!gameBoard.IsValidPosition(activeShape))
                {
                    activeShape.MoveShape(MoveDirection.LEFT);
                }
                break;
            case "MoveLeft":
                activeShape.MoveShape(MoveDirection.LEFT);
                break;
            case "MoveDown":
                activeShape.MoveShape(MoveDirection.DOWN);
                break;
            case "Horizontal":
                break;
            case "Vertical":
                break;
            case "Submit":
                break;
            case "Cancel":
                break;
            default:
                Debug.Log("Nothing");
                break;
        }


        if (gameSpawner)
        {
            if (!activeShape)
            {
                activeShape = gameSpawner.SpawnShape();
            }
        }
        else
        {
            Debug.Log("Dupa");
        }

        if (activeShape && nextMove < Time.time)
        {
            nextMove = Time.time + activeShapeSpeed;
            activeShape.MoveShape(MoveDirection.DOWN);

            if (!gameBoard.IsValidPosition(activeShape))
            {
                activeShape.MoveShape(MoveDirection.UP);
                gameBoard.StoreShapeInGrid(activeShape);
                activeShape = gameSpawner.SpawnShape();
            }
        }
    }
}