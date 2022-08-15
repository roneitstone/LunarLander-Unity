// GENERATED AUTOMATICALLY FROM 'Assets/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Jogar"",
            ""id"": ""82ea67c5-4a03-4fa5-a278-99f229245af8"",
            ""actions"": [
                {
                    ""name"": ""Right"",
                    ""type"": ""Button"",
                    ""id"": ""df91c989-9795-4836-b54b-821f05619863"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Left"",
                    ""type"": ""Button"",
                    ""id"": ""fc209de1-c19b-4256-acd1-eff5235c0e75"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Acelerar"",
                    ""type"": ""Button"",
                    ""id"": ""4ca1ab65-0f09-4a34-85d9-9cd4e5d01636"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Restart"",
                    ""type"": ""Button"",
                    ""id"": ""37448fac-d482-4038-8c0b-1db15eb03d5c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""3c7aa821-74be-44b5-8fd3-d16af469dc1e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""7e6cf178-a260-4aec-bb5c-b90aa38f7a75"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c2341d7a-3131-4fcc-9cc7-4b1590a5970c"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""12b4baf7-6af5-435e-8054-510c970341e7"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Acelerar"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""61f8d961-2cda-496f-99dc-bf24da4b20d8"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7da87dfe-6a33-4c48-98b9-f6900f68cf96"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Restart"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Jogar
        m_Jogar = asset.FindActionMap("Jogar", throwIfNotFound: true);
        m_Jogar_Right = m_Jogar.FindAction("Right", throwIfNotFound: true);
        m_Jogar_Left = m_Jogar.FindAction("Left", throwIfNotFound: true);
        m_Jogar_Acelerar = m_Jogar.FindAction("Acelerar", throwIfNotFound: true);
        m_Jogar_Restart = m_Jogar.FindAction("Restart", throwIfNotFound: true);
        m_Jogar_Pause = m_Jogar.FindAction("Pause", throwIfNotFound: true);
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

    // Jogar
    private readonly InputActionMap m_Jogar;
    private IJogarActions m_JogarActionsCallbackInterface;
    private readonly InputAction m_Jogar_Right;
    private readonly InputAction m_Jogar_Left;
    private readonly InputAction m_Jogar_Acelerar;
    private readonly InputAction m_Jogar_Restart;
    private readonly InputAction m_Jogar_Pause;
    public struct JogarActions
    {
        private @PlayerControls m_Wrapper;
        public JogarActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Right => m_Wrapper.m_Jogar_Right;
        public InputAction @Left => m_Wrapper.m_Jogar_Left;
        public InputAction @Acelerar => m_Wrapper.m_Jogar_Acelerar;
        public InputAction @Restart => m_Wrapper.m_Jogar_Restart;
        public InputAction @Pause => m_Wrapper.m_Jogar_Pause;
        public InputActionMap Get() { return m_Wrapper.m_Jogar; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(JogarActions set) { return set.Get(); }
        public void SetCallbacks(IJogarActions instance)
        {
            if (m_Wrapper.m_JogarActionsCallbackInterface != null)
            {
                @Right.started -= m_Wrapper.m_JogarActionsCallbackInterface.OnRight;
                @Right.performed -= m_Wrapper.m_JogarActionsCallbackInterface.OnRight;
                @Right.canceled -= m_Wrapper.m_JogarActionsCallbackInterface.OnRight;
                @Left.started -= m_Wrapper.m_JogarActionsCallbackInterface.OnLeft;
                @Left.performed -= m_Wrapper.m_JogarActionsCallbackInterface.OnLeft;
                @Left.canceled -= m_Wrapper.m_JogarActionsCallbackInterface.OnLeft;
                @Acelerar.started -= m_Wrapper.m_JogarActionsCallbackInterface.OnAcelerar;
                @Acelerar.performed -= m_Wrapper.m_JogarActionsCallbackInterface.OnAcelerar;
                @Acelerar.canceled -= m_Wrapper.m_JogarActionsCallbackInterface.OnAcelerar;
                @Restart.started -= m_Wrapper.m_JogarActionsCallbackInterface.OnRestart;
                @Restart.performed -= m_Wrapper.m_JogarActionsCallbackInterface.OnRestart;
                @Restart.canceled -= m_Wrapper.m_JogarActionsCallbackInterface.OnRestart;
                @Pause.started -= m_Wrapper.m_JogarActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_JogarActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_JogarActionsCallbackInterface.OnPause;
            }
            m_Wrapper.m_JogarActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Right.started += instance.OnRight;
                @Right.performed += instance.OnRight;
                @Right.canceled += instance.OnRight;
                @Left.started += instance.OnLeft;
                @Left.performed += instance.OnLeft;
                @Left.canceled += instance.OnLeft;
                @Acelerar.started += instance.OnAcelerar;
                @Acelerar.performed += instance.OnAcelerar;
                @Acelerar.canceled += instance.OnAcelerar;
                @Restart.started += instance.OnRestart;
                @Restart.performed += instance.OnRestart;
                @Restart.canceled += instance.OnRestart;
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
            }
        }
    }
    public JogarActions @Jogar => new JogarActions(this);
    public interface IJogarActions
    {
        void OnRight(InputAction.CallbackContext context);
        void OnLeft(InputAction.CallbackContext context);
        void OnAcelerar(InputAction.CallbackContext context);
        void OnRestart(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
    }
}
