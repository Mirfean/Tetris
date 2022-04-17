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
        // Input init
        controls = new BasicControls();
        controls.Enable();

        // Prepare all core elements
        gameBoard = GameObject.FindWithTag("Board").GetComponent<Board>();
        gameSpawner = GameObject.FindWithTag("Spawner").GetComponent<Spawner>();


        activeShapeSpeed = 0.5f;
    }

    // Update is called once per frame
    private void Update()
    {
        if (gameSpawner)
        {
            if (!activeShape)
            {
                activeShape = gameSpawner.SpawnShape();
            }
        }

        //Control
        controls.Base.Movement.performed += ctx => MovingShapeByPlayer(ctx.ReadValue<Vector2>());
        controls.Base.Rotate.performed += _ => activeShape.RotateRight();

        MovingShapeDown();
    }

    private void MovingShapeByPlayer(Vector2 vector2)
    {
        switch (vector2)
        {
            case Vector2 v when v.Equals(Vector2.left):
                activeShape.MoveShape(MoveDirection.LEFT);
                CheckValidPosition(MoveDirection.LEFT);
                break;
            case Vector2 v when v.Equals(Vector2.right):
                activeShape.MoveShape(MoveDirection.RIGHT);
                CheckValidPosition(MoveDirection.RIGHT);
                break;
            case Vector2 v when v.Equals(Vector2.down):
                activeShape.MoveShape(MoveDirection.DOWN);
                CheckValidPosition(MoveDirection.DOWN);
                break;
        }
    }

    private void MovingShapeDown()
    {
        if (activeShape && nextMove<Time.time)
        {
            nextMove = Time.time + activeShapeSpeed;
            activeShape.MoveShape(MoveDirection.DOWN);
            CheckValidPosition(MoveDirection.DOWN);
        }
    }

    private void CheckValidPosition(MoveDirection md)
    {
        if (!gameBoard.IsValidPosition(activeShape))
        {
            switch (md)
            {
                case MoveDirection.DOWN:
                    activeShape.MoveShape(MoveDirection.UP);
                    gameBoard.StoreShapeInGrid(activeShape);
                    activeShape = gameSpawner.SpawnShape();
                    break;
                case MoveDirection.LEFT:
                    activeShape.MoveShape(MoveDirection.RIGHT);
                    break;
                case MoveDirection.RIGHT:
                    activeShape.MoveShape(MoveDirection.LEFT);
                    break;
            }
            
        }
    }

}