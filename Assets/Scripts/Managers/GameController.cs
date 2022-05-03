using UnityEngine;
using UnityEngine.SceneManagement;

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

    private bool gameOver;

    [SerializeField]
    private GameObject gameOverPanel;

    [SerializeField]
    private SoundManager soundManager;

    // Start is called before the first frame update
    private void Start()
    {
        gameOver = false;
        if (gameOverPanel != null) { gameOverPanel.SetActive(false); }
        
        // Input init
        controls = new BasicControls();
        controls.Enable();

        // Prepare all core elements
        gameBoard = GameObject.FindWithTag("Board").GetComponent<Board>();
        gameSpawner = GameObject.FindWithTag("Spawner").GetComponent<Spawner>();
        soundManager = GameObject.FindObjectOfType<SoundManager>();

        gameSpawner.transform.position = VectorF.Round(gameSpawner.transform.position);

        verticalSpeed = 0.1f;
        horizontalSpeed = 0.1f;
        autoActiveShapeSpeed = 0.25f;

        if (soundManager.FxEnabled && soundManager.MoveShapeSound) { 
        }
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (!gameOver)
        {
            if (gameSpawner && !gameOver)
            {
                if (!activeShape)
                {
                    activeShape = gameSpawner.SpawnShape();
                }
            }
            if (!soundManager) { Debug.LogWarning("Sound not working!"); }

            //Control
            MovingShapeByPlayer(controls.Base.Movement.ReadValue<Vector2>());
            //controls.Base.Movement.performed += ctx => MovingShapeByPlayer(ctx.ReadValue<Vector2>());
            controls.Base.Rotate.performed += _ => activeShape.RotateRight();

            MovingShapeDown();
        }
            
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
            CheckCertainDirection(md);
        }
        if (md == MoveDirection.DOWN && nextMoveVertical < Time.time)
        {
            nextMoveVertical = Time.time + verticalSpeed;
            CheckCertainDirection(md);
        }
    }

    private void CheckCertainDirection(MoveDirection md)
    {
        activeShape.MoveShape(md);
        if (CheckValidPosition(md))
        {
            AudioSource.PlayClipAtPoint(soundManager.MoveShapeSound, Camera.main.transform.position, soundManager.FxVolume);
        }
    }

    private bool CheckValidPosition(MoveDirection md)
    {
        if (!gameBoard.IsValidPosition(activeShape))
        {
            switch (md)
            {
                case MoveDirection.DOWN:
                    if (gameBoard.IsOverLimit(activeShape))
                    {
                        activeShape.MoveShape(MoveDirection.UP);
                        gameOver = true;
                        gameOverPanel.SetActive(true);
                        soundManager.BGSound = null;
                        AudioSource.PlayClipAtPoint(soundManager.GameOverSound, Camera.main.transform.position, soundManager.FxVolume);
                        Debug.LogWarning("You lost!");
                    }
                    else
                    {
                        LandShape();
                    }
                    
                    break;
                case MoveDirection.LEFT:
                    activeShape.MoveShape(MoveDirection.RIGHT);
                    break;
                case MoveDirection.RIGHT:
                    activeShape.MoveShape(MoveDirection.LEFT);
                    break;
            }
            return false;
            
        }
        return true;
    }

    void LandShape()
    {
        activeShape.MoveShape(MoveDirection.UP);
        gameBoard.StoreShapeInGrid(activeShape);
        activeShape = gameSpawner.SpawnShape();

        gameBoard.ClearAllRows();
        if (soundManager.FxEnabled && soundManager.DropSound)
        {
            AudioSource.PlayClipAtPoint(soundManager.DropSound, Camera.main.transform.position, soundManager.FxVolume);
        }
    }

    public void Restart()
    {
        //TODO:
        //- Save score

        Debug.Log("Restart");
        SceneManager.LoadScene(0);
    }

}