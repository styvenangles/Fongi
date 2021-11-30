// GENERATED AUTOMATICALLY FROM 'Assets/playerFongi/fongiControls.inputactions'

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
    public struct MovemementActions
    {
        private @FongiControls m_Wrapper;
        public MovemementActions(@FongiControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Horizontal => m_Wrapper.m_Movemement_Horizontal;
        public InputAction @Jump => m_Wrapper.m_Movemement_Jump;
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
            }
        }
    }
    public MovemementActions @Movemement => new MovemementActions(this);
    public interface IMovemementActions
    {
        void OnHorizontal(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
    }
}
