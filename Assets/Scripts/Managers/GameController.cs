using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private BasicControls controls;

    private Board gameBoard;

    private Spawner gameSpawner;

    private Shape activeShape;
    
    private float autoActiveShapeSpeed;
    private float autoNextMoveDown;
    
    private float horizontalSpeed;
    private float nextMoveHorizontal;

    private float verticalSpeed;
    private float nextMoveVertical;

    // Start is called before the first frame update
    private void Start()
    {
        // Input init
        controls = new BasicControls();
        controls.Enable();

        // Prepare all core elements
        gameBoard = GameObject.FindWithTag("Board").GetComponent<Board>();
        gameSpawner = GameObject.FindWithTag("Spawner").GetComponent<Spawner>();
        gameSpawner.transform.position = VectorF.Round(gameSpawner.transform.position);

        verticalSpeed = 0.1f;
        horizontalSpeed = 0.1f;
        autoActiveShapeSpeed = 0.25f;
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
        MovingShapeByPlayer(controls.Base.Movement.ReadValue<Vector2>());
        //controls.Base.Movement.performed += ctx => MovingShapeByPlayer(ctx.ReadValue<Vector2>());
        controls.Base.Rotate.performed += _ => activeShape.RotateRight();

        MovingShapeDown();
    }

    private void MovingShapeByPlayer(Vector2 vector2)
    {
        
        switch (vector2)
        {
            case Vector2 v when v.Equals(Vector2.left):
                MoveAndCheck(MoveDirection.LEFT);
                break;
            case Vector2 v when v.Equals(Vector2.right):
                MoveAndCheck(MoveDirection.RIGHT);
                break;
            case Vector2 v when v.Equals(Vector2.down):
                MoveAndCheck(MoveDirection.DOWN);
                break;
            default:
                break;
        }

    }

    private void MovingShapeDown()
    {
        if (activeShape && autoNextMoveDown<Time.time)
        {
            autoNextMoveDown = Time.time + autoActiveShapeSpeed;
            activeShape.MoveShape(MoveDirection.DOWN);
            CheckValidPosition(MoveDirection.DOWN);
        }
    }

    private void MoveAndCheck(MoveDirection md)
    {
        if ((md == MoveDirection.LEFT || md == MoveDirection.RIGHT) && nextMoveHorizontal < Time.time)
        {
            nextMoveHorizontal = Time.time + horizontalSpeed;
            activeShape.MoveShape(md);
            CheckValidPosition(md);
        }
        if (md == MoveDirection.DOWN && nextMoveVertical < Time.time)
        {
            nextMoveVertical = Time.time + verticalSpeed;
            activeShape.MoveShape(md);
            CheckValidPosition(md);
        }
    }

    private void CheckValidPosition(MoveDirection md)
    {
        if (!gameBoard.IsValidPosition(activeShape))
        {
            switch (md)
            {
                case MoveDirection.DOWN:
                    LandShape();
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

    void LandShape()
    {
        activeShape.MoveShape(MoveDirection.UP);
        gameBoard.StoreShapeInGrid(activeShape);
        activeShape = gameSpawner.SpawnShape();

        gameBoard.ClearAllRows();
    }

}