using UnityEngine;
using UnityEngine.InputSystem;
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

    private bool rotateClockwise;
    private bool forceDown;
    
    private bool gameOver;

    [SerializeField]
    private GameObject gameOverPanel;

    [SerializeField]
    private SoundManager soundManager;

    public bool isPaused;

    public GameObject pausePanel;

    public ScoreManager scoreManager;

    GhostShape ghostShape;

    Holder holder;



    // Start is called before the first frame update
    private void Start()
    {
        gameOver = false;
        isPaused = false;

        if (gameOverPanel != null) { gameOverPanel.SetActive(false); }

        rotateClockwise = true;
        forceDown = false;
        
        
        // Input init
        controls = new BasicControls();
        controls.Enable();


        // Prepare all core elements
        gameBoard = GameObject.FindWithTag("Board").GetComponent<Board>();
        gameSpawner = GameObject.FindWithTag("Spawner").GetComponent<Spawner>();
        soundManager = GameObject.FindObjectOfType<SoundManager>();
        scoreManager = GameObject.FindObjectOfType<ScoreManager>();
        ghostShape = GameObject.FindObjectOfType<GhostShape>();
        holder = GameObject.FindObjectOfType<Holder>();

        gameSpawner.transform.position = VectorF.Round(gameSpawner.transform.position);

        verticalSpeed = 0.05f;
        horizontalSpeed = 0.1f;
        autoActiveShapeSpeed = 0.25f;

        if (soundManager.MusicSlider.IsActive())
        {
            Debug.Log("Disabling Pause");
            soundManager.SetSliders();
            pausePanel.SetActive(false);
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

            //controls.Base.Movement.performed += ctx => MovingShapeByPlayer(ctx.ReadValue<Vector2>());
            if (!isPaused)
            {
                //Control PC
                MovingShapeByPlayer(controls.Base.Movement.ReadValue<Vector2>());
                controls.Base.Rotate.performed += _ => RotateAndCheck();
                controls.Base.Pause.performed += _ => TooglePause();
                controls.Base.Hold.performed += _ => Hold();

                controls.Touch.TouchPress.started += ctx => MovingShapeByTouch(ctx);
                
                
            }
            MovingShapeDown();
        }

    }

    private void LateUpdate()
    {
        ghostShape.ProjectGhost(activeShape, gameBoard);
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

    private void MovingShapeByPlayer(Vector2 vector2)
    {
        if (!isPaused) 
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
                    if (forceDown)
                    {
                        ForceLand();
                    }
                    else
                    {
                        MoveAndCheck(MoveDirection.DOWN);
                    }
                    break;
                default:
                    break;
            }
        }
    }

    private void MovingShapeByTouch(InputAction.CallbackContext context)
    {
        if (TouchWithin())
        {
            Debug.Log("Touch");
            float diff = Camera.main.ScreenToWorldPoint(controls.Touch.TouchPosition.ReadValue<Vector2>()).x - activeShape.transform.position.x;
            if (Mathf.Abs(diff) > 0.5f)
            {
                if (diff > 0) MoveAndCheck(MoveDirection.RIGHT);
                else MoveAndCheck(MoveDirection.LEFT);
            }
            
        }
        //if (activeShape.transform.position.x < )
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
        if (CheckValidPosition(md) && soundManager.FxEnabled)
        {
            AudioSource.PlayClipAtPoint(soundManager.MoveShapeSound, Camera.main.transform.position, soundManager.FxVolume / 10);
        }
        else if (soundManager.FxEnabled)
        {
            soundManager.PlaySound(soundManager.ErrorSound, soundManager.FxVolume);
        }
    }

    /* Check current shape position after movement
     * If it's in right position, return TRUE
     * Shape going down -> land it if it's not over game space, otherwise move it 1 unit up and make game over 
     * Shape going left/right -> move it in opposite
     */
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
                        if (soundManager.FxEnabled)
                        {
                            AudioSource.PlayClipAtPoint(soundManager.GameOverSound, Camera.main.transform.position, soundManager.FxVolume);
                        }
                        Debug.LogWarning("You lost!");
                    }
                    else
                    {
                        LandShape();
                    }
                    
                    break;
                case MoveDirection.LEFT:
                    activeShape.MoveShape(MoveDirection.RIGHT);
                    CheckValidPosition(md);
                    break;
                case MoveDirection.RIGHT:
                    activeShape.MoveShape(MoveDirection.LEFT);
                    CheckValidPosition(md);
                    break;
            }
            return false;
            
        }
        return true;
    }

    // Land shape and do all checks linked to it
    void LandShape()
    {
        activeShape.MoveShape(MoveDirection.UP);
        gameBoard.StoreShapeInGrid(activeShape);
        LandExecute();
    }

    void ForceLand()
    {
        if (nextMoveVertical < Time.time)
        {
            nextMoveVertical = Time.time + verticalSpeed;
            activeShape.transform.position = ghostShape.ghostSprite.transform.position;
            LandExecute();
        }
       
    }

    void LandExecute()
    {
        gameBoard.StoreShapeInGrid(activeShape);
        activeShape = gameSpawner.SpawnShape();
        if (ghostShape)
        {
            ghostShape.Killghost();
        }
        int linesCleared = gameBoard.ClearAllRows();
        int level = scoreManager.Level;
        scoreManager.SetScoreAndLines(linesCleared);
        if (level != scoreManager.Level)
        {
            autoActiveShapeSpeed -= Mathf.Clamp((((float)scoreManager.Level - 1) * 0.01f), 0.01f, 1f);
        }
        if (soundManager.FxEnabled && soundManager.DropSound)
        {
            AudioSource.PlayClipAtPoint(soundManager.DropSound, Camera.main.transform.position, soundManager.FxVolume);
        }
        if (holder)
        {
            holder.canRelease = true;
        }
        
    }

    //Obsolete method
    public void RotateShape()
    {
        if (rotateClockwise)
        {
            activeShape.RotateRight();
            if(!gameBoard.IsValidPosition(activeShape))
            {
                if (activeShape.transform.position.x < gameBoard.transform.position.x + (gameBoard.Width/2))
                {
                    activeShape.MoveShape(MoveDirection.RIGHT);
                }
                else
                {
                    activeShape.MoveShape(MoveDirection.RIGHT);
                }
            }
        }
        else
        {
            activeShape.RotateLeft();
        }
    }

    private void RotateAndCheck()
    {
        activeShape.RotateRight();
        if (!gameBoard.IsValidPosition(activeShape))
        {
            if (activeShape.transform.position.x < gameBoard.transform.position.x + (gameBoard.Width / 2))
            {
                CheckValidPosition(MoveDirection.LEFT);
            }
            else
            {
                CheckValidPosition(MoveDirection.RIGHT);
            }
        }

    }

    public void ReverseRotate()
    {
        //rotateClockwise = !rotateClockwise;
        forceDown = !forceDown;
    }

    public void ChangeForceDown()
    {

    }

    public void Restart()
    {
        Time.timeScale = 1;
        Debug.Log("Restart");
        SceneManager.LoadScene(0);
    }

    public void TooglePause()
    {
        if (gameOver)
        {
            return;
        }

        isPaused = !isPaused;

        if (pausePanel)
        {
            pausePanel.SetActive(isPaused);
        }

        Time.timeScale = (isPaused ? 0 : 1);
    }


    public void Hold()
    {
        if (!gameOver)
        {
            if (!holder.heldShape)
            {
                holder.Catch(activeShape);
                activeShape = gameSpawner.SpawnShape();
            }

            else if (holder.canRelease)
            {
                Shape temp = activeShape;
                activeShape = holder.Release();
                activeShape.transform.position = gameSpawner.transform.position;
                holder.Catch(temp);
            }
            else
            {
                Debug.LogWarning("HOLDER WARNING! Wait for cool down!");
            }

            if (ghostShape)
            {
                ghostShape.Killghost();
            }
        }
    }

    private bool TouchWithin()
    {
        return controls.Touch.TouchPosition.ReadValue<Vector2>().x >= gameBoard.getCorner(Corner.BotLeft).x - 0.5f &&
            controls.Touch.TouchPosition.ReadValue<Vector2>().x >= gameBoard.getCorner(Corner.TopRight).x + 0.5f;
    }

}