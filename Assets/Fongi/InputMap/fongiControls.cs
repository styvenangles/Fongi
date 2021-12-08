// GENERATED AUTOMATICALLY FROM 'Assets/Fongi/InputMap/fongiControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @FongiControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @FongiControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""fongiControls"",
    ""maps"": [
        {
            ""name"": ""Movemement"",
            ""id"": ""01e29c72-9ba5-4da6-ae57-8f813ea8186b"",
            ""actions"": [
                {
                    ""name"": ""Horizontal"",
                    ""type"": ""Value"",
                    ""id"": ""4d85c645-8c10-4fe9-a1fd-97d6e96e4914"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""ae35063c-ed2f-427a-85c7-9237e708de4a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Dash"",
                    ""type"": ""Button"",
                    ""id"": ""971ad8eb-945d-4f9e-a98c-757993710cfd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""90185880-ea80-4a5c-82f2-67b122b16b1b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""1D Axis Keyboard"",
                    ""id"": ""52e2a519-9030-4645-963e-533dfd9114df"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Horizontal"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""f08a32b6-48e4-4157-a4e1-597624fa3fd0"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Horizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""6834e2d5-ce0b-4029-8499-7b2c1fc18647"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Horizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""1D Axis Controller"",
                    ""id"": ""5775fcfa-76fa-43e2-a9cb-27446083c857"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Horizontal"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""6d4f0636-c3e5-4e04-81c5-41a800b25f61"",
                    ""path"": ""<XInputController>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Horizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""091c300b-37ee-4ec3-814e-7fc9e45f385e"",
                    ""path"": ""<XInputController>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Horizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""4e86d172-c830-4129-b780-19414dc4672b"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fb60c145-5105-4fc7-a5a1-08b82dedf74d"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""20e77130-81da-4ac4-a2b3-64361386e4a5"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2333eed7-a071-439d-97bd-9bbcbd9bfc18"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""65ea4222-501d-4b83-8fcf-9ae0e325b57c"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Menu"",
            ""id"": ""96e1171f-1433-4d11-8527-b81c4036cfd9"",
            ""actions"": [
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""68f87365-d83c-4978-9494-c2fa54ffcb08"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""d2a1cdcc-2fba-4601-9a97-8b1d9687ab29"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Movemement
        m_Movemement = asset.FindActionMap("Movemement", throwIfNotFound: true);
        m_Movemement_Horizontal = m_Movemement.FindAction("Horizontal", throwIfNotFound: true);
        m_Movemement_Jump = m_Movemement.FindAction("Jump", throwIfNotFound: true);
        m_Movemement_Dash = m_Movemement.FindAction("Dash", throwIfNotFound: true);
        m_Movemement_Attack = m_Movemement.FindAction("Attack", throwIfNotFound: true);
        // Menu
        m_Menu = asset.FindActionMap("Menu", throwIfNotFound: true);
        m_Menu_Pause = m_Menu.FindAction("Pause", throwIfNotFound: true);
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

    // Movemement
    private readonly InputActionMap m_Movemement;
    private IMovemementActions m_MovemementActionsCallbackInterface;
    private readonly InputAction m_Movemement_Horizontal;
    private readonly InputAction m_Movemement_Jump;
    private readonly InputAction m_Movemement_Dash;
    private readonly InputAction m_Movemement_Attack;
    public struct MovemementActions
    {
        private @FongiControls m_Wrapper;
        public MovemementActions(@FongiControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Horizontal => m_Wrapper.m_Movemement_Horizontal;
        public InputAction @Jump => m_Wrapper.m_Movemement_Jump;
        public InputAction @Dash => m_Wrapper.m_Movemement_Dash;
        public InputAction @Attack => m_Wrapper.m_Movemement_Attack;
        public InputActionMap Get() { return m_Wrapper.m_Movemement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MovemementActions set) { return set.Get(); }
        public void SetCallbacks(IMovemementActions instance)
        {
            if (m_Wrapper.m_MovemementActionsCallbackInterface != null)
            {
                @Horizontal.started -= m_Wrapper.m_MovemementActionsCallbackInterface.OnHorizontal;
                @Horizontal.performed -= m_Wrapper.m_MovemementActionsCallbackInterface.OnHorizontal;
                @Horizontal.canceled -= m_Wrapper.m_MovemementActionsCallbackInterface.OnHorizontal;
                @Jump.started -= m_Wrapper.m_MovemementActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_MovemementActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_MovemementActionsCallbackInterface.OnJump;
                @Dash.started -= m_Wrapper.m_MovemementActionsCallbackInterface.OnDash;
                @Dash.performed -= m_Wrapper.m_MovemementActionsCallbackInterface.OnDash;
                @Dash.canceled -= m_Wrapper.m_MovemementActionsCallbackInterface.OnDash;
                @Attack.started -= m_Wrapper.m_MovemementActionsCallbackInterface.OnAttack;
                @Attack.performed -= m_Wrapper.m_MovemementActionsCallbackInterface.OnAttack;
                @Attack.canceled -= m_Wrapper.m_MovemementActionsCallbackInterface.OnAttack;
            }
            m_Wrapper.m_MovemementActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Horizontal.started += instance.OnHorizontal;
                @Horizontal.performed += instance.OnHorizontal;
                @Horizontal.canceled += instance.OnHorizontal;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Dash.started += instance.OnDash;
                @Dash.performed += instance.OnDash;
                @Dash.canceled += instance.OnDash;
                @Attack.started += instance.OnAttack;
                @Attack.performed += instance.OnAttack;
                @Attack.canceled += instance.OnAttack;
            }
        }
    }
    public MovemementActions @Movemement => new MovemementActions(this);

    // Menu
    private readonly InputActionMap m_Menu;
    private IMenuActions m_MenuActionsCallbackInterface;
    private readonly InputAction m_Menu_Pause;
    public struct MenuActions
    {
        private @FongiControls m_Wrapper;
        public MenuActions(@FongiControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Pause => m_Wrapper.m_Menu_Pause;
        public InputActionMap Get() { return m_Wrapper.m_Menu; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MenuActions set) { return set.Get(); }
        public void SetCallbacks(IMenuActions instance)
        {
            if (m_Wrapper.m_MenuActionsCallbackInterface != null)
            {
                @Pause.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnPause;
            }
            m_Wrapper.m_MenuActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
            }
        }
    }
    public MenuActions @Menu => new MenuActions(this);
    public interface IMovemementActions
    {
        void OnHorizontal(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnDash(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
    }
    public interface IMenuActions
    {
        void OnPause(InputAction.CallbackContext context);
    }
}
