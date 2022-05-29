using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerTouchInput : MonoBehaviour
{
    public delegate void StartTouchEvent(Vector2 position, float time);
    public event StartTouchEvent OnStartTouch;

    public delegate void EndTouchEvent(Vector2 position, float time);
    public event EndTouchEvent OnEndTouch;
    
    private BasicControls control;

    private void Awake()
    {
        if(Application.isMobilePlatform || Application.isEditor)
        {
            control = new BasicControls();
        }
    }

    //private void OnEnable()
    //{
    //    control.Enable();
    //}

    //private void OnDisable()
    //{
    //    control.Disable();
    //}

    // Start is called before the first frame update
    void Start()
    {
        control.Touch.TouchPress.started += ctx => StartTouch(ctx);
        control.Touch.TouchPress.canceled += ctx => EndTouch(ctx);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void StartTouch(InputAction.CallbackContext context)
    {
        Debug.Log("Touch started" + control.Touch.TouchPosition.ReadValue<Vector2>());
        if (OnStartTouch != null)
        {
            OnStartTouch(control.Touch.TouchPosition.ReadValue<Vector2>(), (float)context.startTime);
        }
    }

    private void EndTouch(InputAction.CallbackContext context)
    {
        Debug.Log("Touch ended" + control.Touch.TouchPosition.ReadValue<Vector2>());
        if (OnEndTouch != null)
        {
            OnEndTouch(control.Touch.TouchPosition.ReadValue<Vector2>(), (float)context.time);
        }
    }

}
