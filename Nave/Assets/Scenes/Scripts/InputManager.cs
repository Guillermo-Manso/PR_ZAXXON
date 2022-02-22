// GENERATED AUTOMATICALLY FROM 'Assets/Scenes/Scripts/InputManager.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputManager : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputManager()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputManager"",
    ""maps"": [
        {
            ""name"": ""Hola"",
            ""id"": ""9cc2c514-20d4-43a7-88ab-f5fd83969636"",
            ""actions"": [
                {
                    ""name"": ""MoverNave"",
                    ""type"": ""Value"",
                    ""id"": ""51093846-6048-4914-94bc-aa7bee74b9d7"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""BotonConfirmacion"",
                    ""type"": ""Button"",
                    ""id"": ""df1afd16-e36f-4860-ad73-8b5fabad3b69"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Pausa"",
                    ""type"": ""Button"",
                    ""id"": ""0ae39aa7-5da9-4c1d-9765-cf723b8d438b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""R1"",
                    ""type"": ""Button"",
                    ""id"": ""35b0e5a4-908a-44d2-9d74-be89d53cd1f1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""L1"",
                    ""type"": ""Button"",
                    ""id"": ""331d8fe8-ace9-4320-977d-cedaf8edd656"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""c6015f2a-a7dc-45bd-a1d6-bf9f82060546"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoverNave"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d1aa9880-1b5f-4cbf-ad9e-9e0332898a90"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""BotonConfirmacion"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""15d960fd-2322-4f36-a083-e4de27f44f6d"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""BotonConfirmacion"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9d95d6b1-c6fe-4a85-a620-a30fc958eac9"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pausa"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3dc887b0-20a7-4185-90e6-69929e384b20"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""R1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""79f03d3f-7856-4067-9a8e-328f0f7cdc05"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""L1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Hola
        m_Hola = asset.FindActionMap("Hola", throwIfNotFound: true);
        m_Hola_MoverNave = m_Hola.FindAction("MoverNave", throwIfNotFound: true);
        m_Hola_BotonConfirmacion = m_Hola.FindAction("BotonConfirmacion", throwIfNotFound: true);
        m_Hola_Pausa = m_Hola.FindAction("Pausa", throwIfNotFound: true);
        m_Hola_R1 = m_Hola.FindAction("R1", throwIfNotFound: true);
        m_Hola_L1 = m_Hola.FindAction("L1", throwIfNotFound: true);
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

    // Hola
    private readonly InputActionMap m_Hola;
    private IHolaActions m_HolaActionsCallbackInterface;
    private readonly InputAction m_Hola_MoverNave;
    private readonly InputAction m_Hola_BotonConfirmacion;
    private readonly InputAction m_Hola_Pausa;
    private readonly InputAction m_Hola_R1;
    private readonly InputAction m_Hola_L1;
    public struct HolaActions
    {
        private @InputManager m_Wrapper;
        public HolaActions(@InputManager wrapper) { m_Wrapper = wrapper; }
        public InputAction @MoverNave => m_Wrapper.m_Hola_MoverNave;
        public InputAction @BotonConfirmacion => m_Wrapper.m_Hola_BotonConfirmacion;
        public InputAction @Pausa => m_Wrapper.m_Hola_Pausa;
        public InputAction @R1 => m_Wrapper.m_Hola_R1;
        public InputAction @L1 => m_Wrapper.m_Hola_L1;
        public InputActionMap Get() { return m_Wrapper.m_Hola; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(HolaActions set) { return set.Get(); }
        public void SetCallbacks(IHolaActions instance)
        {
            if (m_Wrapper.m_HolaActionsCallbackInterface != null)
            {
                @MoverNave.started -= m_Wrapper.m_HolaActionsCallbackInterface.OnMoverNave;
                @MoverNave.performed -= m_Wrapper.m_HolaActionsCallbackInterface.OnMoverNave;
                @MoverNave.canceled -= m_Wrapper.m_HolaActionsCallbackInterface.OnMoverNave;
                @BotonConfirmacion.started -= m_Wrapper.m_HolaActionsCallbackInterface.OnBotonConfirmacion;
                @BotonConfirmacion.performed -= m_Wrapper.m_HolaActionsCallbackInterface.OnBotonConfirmacion;
                @BotonConfirmacion.canceled -= m_Wrapper.m_HolaActionsCallbackInterface.OnBotonConfirmacion;
                @Pausa.started -= m_Wrapper.m_HolaActionsCallbackInterface.OnPausa;
                @Pausa.performed -= m_Wrapper.m_HolaActionsCallbackInterface.OnPausa;
                @Pausa.canceled -= m_Wrapper.m_HolaActionsCallbackInterface.OnPausa;
                @R1.started -= m_Wrapper.m_HolaActionsCallbackInterface.OnR1;
                @R1.performed -= m_Wrapper.m_HolaActionsCallbackInterface.OnR1;
                @R1.canceled -= m_Wrapper.m_HolaActionsCallbackInterface.OnR1;
                @L1.started -= m_Wrapper.m_HolaActionsCallbackInterface.OnL1;
                @L1.performed -= m_Wrapper.m_HolaActionsCallbackInterface.OnL1;
                @L1.canceled -= m_Wrapper.m_HolaActionsCallbackInterface.OnL1;
            }
            m_Wrapper.m_HolaActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MoverNave.started += instance.OnMoverNave;
                @MoverNave.performed += instance.OnMoverNave;
                @MoverNave.canceled += instance.OnMoverNave;
                @BotonConfirmacion.started += instance.OnBotonConfirmacion;
                @BotonConfirmacion.performed += instance.OnBotonConfirmacion;
                @BotonConfirmacion.canceled += instance.OnBotonConfirmacion;
                @Pausa.started += instance.OnPausa;
                @Pausa.performed += instance.OnPausa;
                @Pausa.canceled += instance.OnPausa;
                @R1.started += instance.OnR1;
                @R1.performed += instance.OnR1;
                @R1.canceled += instance.OnR1;
                @L1.started += instance.OnL1;
                @L1.performed += instance.OnL1;
                @L1.canceled += instance.OnL1;
            }
        }
    }
    public HolaActions @Hola => new HolaActions(this);
    public interface IHolaActions
    {
        void OnMoverNave(InputAction.CallbackContext context);
        void OnBotonConfirmacion(InputAction.CallbackContext context);
        void OnPausa(InputAction.CallbackContext context);
        void OnR1(InputAction.CallbackContext context);
        void OnL1(InputAction.CallbackContext context);
    }
}
