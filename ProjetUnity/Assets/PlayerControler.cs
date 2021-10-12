// GENERATED AUTOMATICALLY FROM 'Assets/PlayerControler.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControler : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControler()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControler"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""36930b20-5f0a-41dd-bf94-6195d665fbca"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""ecba9fd3-27d9-437a-b13f-0cab76d2be1a"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Value"",
                    ""id"": ""5e2eaa88-9ed9-48c1-950f-8879f66e59df"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""FrappeFaible"",
                    ""type"": ""Value"",
                    ""id"": ""15fac36c-56fc-4053-8f4c-715131fac39a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""FrappeForte"",
                    ""type"": ""Value"",
                    ""id"": ""2f2321a6-536e-476d-b271-33bc85ac3b45"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Blocage"",
                    ""type"": ""Value"",
                    ""id"": ""8ee104bf-df97-4c51-ac90-d434a5350914"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Deblocage"",
                    ""type"": ""Value"",
                    ""id"": ""3a7b86cd-67a8-4ba5-aed8-63580e8e1104"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)""
                },
                {
                    ""name"": ""ElementSuivent"",
                    ""type"": ""Value"",
                    ""id"": ""c1e8a4fe-a2df-4d2e-80bb-63a7f0320bd2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ElementPrecedent"",
                    ""type"": ""Value"",
                    ""id"": ""928a616b-0a46-4da9-a059-49475d19ff3f"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""AttaqueSp"",
                    ""type"": ""Value"",
                    ""id"": ""b4d39c8d-e1a9-4a69-ab26-322b1fef36c9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Value"",
                    ""id"": ""6bed80f8-cac6-4b12-ace6-fcc0ed30db1a"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""8c149015-b823-4933-8e76-e5f91338ac9e"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1d93969b-0773-4b89-867a-a4a444b4d97f"",
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
                    ""id"": ""5cc80a56-3d87-4de2-b9fb-e84b56d52924"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FrappeFaible"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e53a77bd-3e9f-45e0-9d48-e413030bb2ab"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FrappeForte"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0e6c027a-a143-43ac-b1c3-806e14a1eae3"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Blocage"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""80b09bc3-7046-4f63-9da2-8766e1ff504d"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ElementSuivent"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8a111c4e-15a3-4fc9-a364-c9e8fbf85893"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ElementPrecedent"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4d7f0f7e-d204-4b95-807b-0ff12fc8fe45"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AttaqueSp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""343317bb-6dbc-4db8-922d-83f4291d34e4"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Deblocage"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""22d38551-2da4-48c0-83c9-3a8565ebd591"",
                    ""path"": ""<Gamepad>/start"",
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
        // Gameplay
        m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
        m_Gameplay_Move = m_Gameplay.FindAction("Move", throwIfNotFound: true);
        m_Gameplay_Jump = m_Gameplay.FindAction("Jump", throwIfNotFound: true);
        m_Gameplay_FrappeFaible = m_Gameplay.FindAction("FrappeFaible", throwIfNotFound: true);
        m_Gameplay_FrappeForte = m_Gameplay.FindAction("FrappeForte", throwIfNotFound: true);
        m_Gameplay_Blocage = m_Gameplay.FindAction("Blocage", throwIfNotFound: true);
        m_Gameplay_Deblocage = m_Gameplay.FindAction("Deblocage", throwIfNotFound: true);
        m_Gameplay_ElementSuivent = m_Gameplay.FindAction("ElementSuivent", throwIfNotFound: true);
        m_Gameplay_ElementPrecedent = m_Gameplay.FindAction("ElementPrecedent", throwIfNotFound: true);
        m_Gameplay_AttaqueSp = m_Gameplay.FindAction("AttaqueSp", throwIfNotFound: true);
        m_Gameplay_Pause = m_Gameplay.FindAction("Pause", throwIfNotFound: true);
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

    // Gameplay
    private readonly InputActionMap m_Gameplay;
    private IGameplayActions m_GameplayActionsCallbackInterface;
    private readonly InputAction m_Gameplay_Move;
    private readonly InputAction m_Gameplay_Jump;
    private readonly InputAction m_Gameplay_FrappeFaible;
    private readonly InputAction m_Gameplay_FrappeForte;
    private readonly InputAction m_Gameplay_Blocage;
    private readonly InputAction m_Gameplay_Deblocage;
    private readonly InputAction m_Gameplay_ElementSuivent;
    private readonly InputAction m_Gameplay_ElementPrecedent;
    private readonly InputAction m_Gameplay_AttaqueSp;
    private readonly InputAction m_Gameplay_Pause;
    public struct GameplayActions
    {
        private @PlayerControler m_Wrapper;
        public GameplayActions(@PlayerControler wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Gameplay_Move;
        public InputAction @Jump => m_Wrapper.m_Gameplay_Jump;
        public InputAction @FrappeFaible => m_Wrapper.m_Gameplay_FrappeFaible;
        public InputAction @FrappeForte => m_Wrapper.m_Gameplay_FrappeForte;
        public InputAction @Blocage => m_Wrapper.m_Gameplay_Blocage;
        public InputAction @Deblocage => m_Wrapper.m_Gameplay_Deblocage;
        public InputAction @ElementSuivent => m_Wrapper.m_Gameplay_ElementSuivent;
        public InputAction @ElementPrecedent => m_Wrapper.m_Gameplay_ElementPrecedent;
        public InputAction @AttaqueSp => m_Wrapper.m_Gameplay_AttaqueSp;
        public InputAction @Pause => m_Wrapper.m_Gameplay_Pause;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                @Jump.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                @FrappeFaible.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnFrappeFaible;
                @FrappeFaible.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnFrappeFaible;
                @FrappeFaible.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnFrappeFaible;
                @FrappeForte.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnFrappeForte;
                @FrappeForte.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnFrappeForte;
                @FrappeForte.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnFrappeForte;
                @Blocage.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnBlocage;
                @Blocage.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnBlocage;
                @Blocage.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnBlocage;
                @Deblocage.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDeblocage;
                @Deblocage.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDeblocage;
                @Deblocage.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDeblocage;
                @ElementSuivent.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnElementSuivent;
                @ElementSuivent.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnElementSuivent;
                @ElementSuivent.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnElementSuivent;
                @ElementPrecedent.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnElementPrecedent;
                @ElementPrecedent.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnElementPrecedent;
                @ElementPrecedent.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnElementPrecedent;
                @AttaqueSp.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAttaqueSp;
                @AttaqueSp.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAttaqueSp;
                @AttaqueSp.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAttaqueSp;
                @Pause.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPause;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @FrappeFaible.started += instance.OnFrappeFaible;
                @FrappeFaible.performed += instance.OnFrappeFaible;
                @FrappeFaible.canceled += instance.OnFrappeFaible;
                @FrappeForte.started += instance.OnFrappeForte;
                @FrappeForte.performed += instance.OnFrappeForte;
                @FrappeForte.canceled += instance.OnFrappeForte;
                @Blocage.started += instance.OnBlocage;
                @Blocage.performed += instance.OnBlocage;
                @Blocage.canceled += instance.OnBlocage;
                @Deblocage.started += instance.OnDeblocage;
                @Deblocage.performed += instance.OnDeblocage;
                @Deblocage.canceled += instance.OnDeblocage;
                @ElementSuivent.started += instance.OnElementSuivent;
                @ElementSuivent.performed += instance.OnElementSuivent;
                @ElementSuivent.canceled += instance.OnElementSuivent;
                @ElementPrecedent.started += instance.OnElementPrecedent;
                @ElementPrecedent.performed += instance.OnElementPrecedent;
                @ElementPrecedent.canceled += instance.OnElementPrecedent;
                @AttaqueSp.started += instance.OnAttaqueSp;
                @AttaqueSp.performed += instance.OnAttaqueSp;
                @AttaqueSp.canceled += instance.OnAttaqueSp;
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);
    public interface IGameplayActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnFrappeFaible(InputAction.CallbackContext context);
        void OnFrappeForte(InputAction.CallbackContext context);
        void OnBlocage(InputAction.CallbackContext context);
        void OnDeblocage(InputAction.CallbackContext context);
        void OnElementSuivent(InputAction.CallbackContext context);
        void OnElementPrecedent(InputAction.CallbackContext context);
        void OnAttaqueSp(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
    }
}
