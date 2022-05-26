//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.2.0
//     from Assets/InputManager/BasicControls.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @BasicControls : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @BasicControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""BasicControls"",
    ""maps"": [
        {
            ""name"": ""Base"",
            ""id"": ""00b91559-d06a-4972-abc3-b14253c5e8c0"",
            ""actions"": [
                {
                    ""name"": ""Rotate"",
                    ""type"": ""Button"",
                    ""id"": ""aea2676b-fd5e-4573-94c2-f62b062d91d4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Horizontal"",
                    ""type"": ""Button"",
                    ""id"": ""af3b40f7-13ca-4def-ab87-4ddacb8a59a7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Vertical"",
                    ""type"": ""Button"",
                    ""id"": ""132c231a-47db-42bf-94ad-fa8f28782f2a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Submit"",
                    ""type"": ""Button"",
                    ""id"": ""32831bf9-52aa-4ada-9f59-4bffdb0eb909"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Cancel"",
                    ""type"": ""Button"",
                    ""id"": ""f683b0b7-5c79-4fd4-b98e-cb172a0a0ce7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""2b3933d9-2e16-4b1c-a4e7-7111a6cdd0d6"",
                    ""expectedControlType"": ""Dpad"",
                    ""processors"": """",
                    ""interactions"": ""Hold(duration=0.15,pressPoint=0.2)"",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""ece77385-4a75-4a4b-afcf-8d26b8ee4f20"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Hold"",
                    ""type"": ""Button"",
                    ""id"": ""06f04437-5fe7-4db6-b088-a8d1ef4ef3b6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""d2daf2dd-6284-427e-b0e1-7108cd1c86da"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4549abe7-6cc3-493e-9731-96a7f6b53d66"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Horizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a0297a59-b43c-41f0-88ee-ac4eccc27fe1"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Vertical"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""58ad959f-be9c-4bfe-88ca-79463a4a2575"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Submit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b1aeea3e-caad-407c-ba44-c97e2023554e"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Cancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""80f1b852-566e-4e54-b6ee-02413cd4a63e"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""down"",
                    ""id"": ""0efa86d3-048b-4b82-a1fc-8dc578181e71"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""bc53f167-4ba0-4cad-be2f-681ffe0c90a4"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""061e9f77-2304-4000-9582-28fd51b382a4"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""89318cb1-b256-4832-9510-a09de6d778ef"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""down"",
                    ""id"": ""54d58e6b-4033-4bd3-be6d-859f791b9f1f"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""607a73b8-c9cc-4eeb-bf2f-47a281a0fd6d"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""0180d6cf-9a69-4d9f-9b07-efb557ec8443"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""c0acfcee-b066-4007-8491-e384e10e8a79"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""9b42bc6c-a5fa-448c-9384-e15b757c9a7c"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Touchscreen"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""b35d94d1-93bb-4aef-9e18-14acb65bbe40"",
                    ""path"": ""<Touchscreen>/position/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Touchscreen"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""8c8dc8e3-5e5f-4733-b602-e6a6fc096e96"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Touchscreen"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""770fa1e8-214e-4dc7-86f1-e9b6919ff36e"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Touchscreen"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""ceb7e15b-291a-4b43-8d01-411d86805a26"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e4a4aaee-7982-446e-990a-d2126e4824f6"",
                    ""path"": ""<Keyboard>/h"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Hold"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""KeyboardMouse"",
            ""bindingGroup"": ""KeyboardMouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""XboxGamepad"",
            ""bindingGroup"": ""XboxGamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<XInputController>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Touchscreen"",
            ""bindingGroup"": ""Touchscreen"",
            ""devices"": [
                {
                    ""devicePath"": ""<Touchscreen>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Base
        m_Base = asset.FindActionMap("Base", throwIfNotFound: true);
        m_Base_Rotate = m_Base.FindAction("Rotate", throwIfNotFound: true);
        m_Base_Horizontal = m_Base.FindAction("Horizontal", throwIfNotFound: true);
        m_Base_Vertical = m_Base.FindAction("Vertical", throwIfNotFound: true);
        m_Base_Submit = m_Base.FindAction("Submit", throwIfNotFound: true);
        m_Base_Cancel = m_Base.FindAction("Cancel", throwIfNotFound: true);
        m_Base_Movement = m_Base.FindAction("Movement", throwIfNotFound: true);
        m_Base_Pause = m_Base.FindAction("Pause", throwIfNotFound: true);
        m_Base_Hold = m_Base.FindAction("Hold", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Base
    private readonly InputActionMap m_Base;
    private IBaseActions m_BaseActionsCallbackInterface;
    private readonly InputAction m_Base_Rotate;
    private readonly InputAction m_Base_Horizontal;
    private readonly InputAction m_Base_Vertical;
    private readonly InputAction m_Base_Submit;
    private readonly InputAction m_Base_Cancel;
    private readonly InputAction m_Base_Movement;
    private readonly InputAction m_Base_Pause;
    private readonly InputAction m_Base_Hold;
    public struct BaseActions
    {
        private @BasicControls m_Wrapper;
        public BaseActions(@BasicControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Rotate => m_Wrapper.m_Base_Rotate;
        public InputAction @Horizontal => m_Wrapper.m_Base_Horizontal;
        public InputAction @Vertical => m_Wrapper.m_Base_Vertical;
        public InputAction @Submit => m_Wrapper.m_Base_Submit;
        public InputAction @Cancel => m_Wrapper.m_Base_Cancel;
        public InputAction @Movement => m_Wrapper.m_Base_Movement;
        public InputAction @Pause => m_Wrapper.m_Base_Pause;
        public InputAction @Hold => m_Wrapper.m_Base_Hold;
        public InputActionMap Get() { return m_Wrapper.m_Base; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(BaseActions set) { return set.Get(); }
        public void SetCallbacks(IBaseActions instance)
        {
            if (m_Wrapper.m_BaseActionsCallbackInterface != null)
            {
                @Rotate.started -= m_Wrapper.m_BaseActionsCallbackInterface.OnRotate;
                @Rotate.performed -= m_Wrapper.m_BaseActionsCallbackInterface.OnRotate;
                @Rotate.canceled -= m_Wrapper.m_BaseActionsCallbackInterface.OnRotate;
                @Horizontal.started -= m_Wrapper.m_BaseActionsCallbackInterface.OnHorizontal;
                @Horizontal.performed -= m_Wrapper.m_BaseActionsCallbackInterface.OnHorizontal;
                @Horizontal.canceled -= m_Wrapper.m_BaseActionsCallbackInterface.OnHorizontal;
                @Vertical.started -= m_Wrapper.m_BaseActionsCallbackInterface.OnVertical;
                @Vertical.performed -= m_Wrapper.m_BaseActionsCallbackInterface.OnVertical;
                @Vertical.canceled -= m_Wrapper.m_BaseActionsCallbackInterface.OnVertical;
                @Submit.started -= m_Wrapper.m_BaseActionsCallbackInterface.OnSubmit;
                @Submit.performed -= m_Wrapper.m_BaseActionsCallbackInterface.OnSubmit;
                @Submit.canceled -= m_Wrapper.m_BaseActionsCallbackInterface.OnSubmit;
                @Cancel.started -= m_Wrapper.m_BaseActionsCallbackInterface.OnCancel;
                @Cancel.performed -= m_Wrapper.m_BaseActionsCallbackInterface.OnCancel;
                @Cancel.canceled -= m_Wrapper.m_BaseActionsCallbackInterface.OnCancel;
                @Movement.started -= m_Wrapper.m_BaseActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_BaseActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_BaseActionsCallbackInterface.OnMovement;
                @Pause.started -= m_Wrapper.m_BaseActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_BaseActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_BaseActionsCallbackInterface.OnPause;
                @Hold.started -= m_Wrapper.m_BaseActionsCallbackInterface.OnHold;
                @Hold.performed -= m_Wrapper.m_BaseActionsCallbackInterface.OnHold;
                @Hold.canceled -= m_Wrapper.m_BaseActionsCallbackInterface.OnHold;
            }
            m_Wrapper.m_BaseActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Rotate.started += instance.OnRotate;
                @Rotate.performed += instance.OnRotate;
                @Rotate.canceled += instance.OnRotate;
                @Horizontal.started += instance.OnHorizontal;
                @Horizontal.performed += instance.OnHorizontal;
                @Horizontal.canceled += instance.OnHorizontal;
                @Vertical.started += instance.OnVertical;
                @Vertical.performed += instance.OnVertical;
                @Vertical.canceled += instance.OnVertical;
                @Submit.started += instance.OnSubmit;
                @Submit.performed += instance.OnSubmit;
                @Submit.canceled += instance.OnSubmit;
                @Cancel.started += instance.OnCancel;
                @Cancel.performed += instance.OnCancel;
                @Cancel.canceled += instance.OnCancel;
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
                @Hold.started += instance.OnHold;
                @Hold.performed += instance.OnHold;
                @Hold.canceled += instance.OnHold;
            }
        }
    }
    public BaseActions @Base => new BaseActions(this);
    private int m_KeyboardMouseSchemeIndex = -1;
    public InputControlScheme KeyboardMouseScheme
    {
        get
        {
            if (m_KeyboardMouseSchemeIndex == -1) m_KeyboardMouseSchemeIndex = asset.FindControlSchemeIndex("KeyboardMouse");
            return asset.controlSchemes[m_KeyboardMouseSchemeIndex];
        }
    }
    private int m_XboxGamepadSchemeIndex = -1;
    public InputControlScheme XboxGamepadScheme
    {
        get
        {
            if (m_XboxGamepadSchemeIndex == -1) m_XboxGamepadSchemeIndex = asset.FindControlSchemeIndex("XboxGamepad");
            return asset.controlSchemes[m_XboxGamepadSchemeIndex];
        }
    }
    private int m_TouchscreenSchemeIndex = -1;
    public InputControlScheme TouchscreenScheme
    {
        get
        {
            if (m_TouchscreenSchemeIndex == -1) m_TouchscreenSchemeIndex = asset.FindControlSchemeIndex("Touchscreen");
            return asset.controlSchemes[m_TouchscreenSchemeIndex];
        }
    }
    public interface IBaseActions
    {
        void OnRotate(InputAction.CallbackContext context);
        void OnHorizontal(InputAction.CallbackContext context);
        void OnVertical(InputAction.CallbackContext context);
        void OnSubmit(InputAction.CallbackContext context);
        void OnCancel(InputAction.CallbackContext context);
        void OnMovement(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
        void OnHold(InputAction.CallbackContext context);
    }
}
