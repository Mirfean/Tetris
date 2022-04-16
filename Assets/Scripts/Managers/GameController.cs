using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private BasicControls controls;

    private Board gameBoard;

    private Spawner gameSpawner;

    private Shape activeShape;
    private float activeShapeSpeed;
    private float nextMove;

    // Start is called before the first frame update
    private void Start()
    {
        controls = new BasicControls();
        controls.Enable();
        gameBoard = GameObject.FindWithTag("Board").GetComponent<Board>();
        gameSpawner = GameObject.FindWithTag("Spawner").GetComponent<Spawner>();
        activeShapeSpeed = 0.15f;
    }

    // Update is called once per frame
    private void Update()
    {
        controls.Base.Movement.performed += ctx => activeShape.MoveShape(ctx.ReadValue<Vector2>());
        controls.Base.Rotate.performed += _ => activeShape.RotateRight();

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