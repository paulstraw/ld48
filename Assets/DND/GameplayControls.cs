// GENERATED AUTOMATICALLY FROM 'Assets/DND/GameplayControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @GameplayControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @GameplayControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""GameplayControls"",
    ""maps"": [
        {
            ""name"": ""Digger"",
            ""id"": ""b7ac9a39-6509-4b56-9505-320d4a419a4f"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""fa492fff-747f-4893-9aaa-5b64dc4056b1"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""5a5e4466-3cb2-4de6-a059-47f3bf22d00f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""DigAction"",
                    ""type"": ""Button"",
                    ""id"": ""7a81f391-7c57-4088-964b-35214bceb939"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""86e85d7b-8dba-4f1c-a71d-2a23fda45762"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""044720cc-1e3f-4050-acf8-27f5881fb5d3"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""4c7bc8b6-738f-4b20-a9b2-eba705cb2db5"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""2535870b-c768-49e0-9cd6-15cd6bb40b4e"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""36ef9816-1ea7-4388-b6d1-7ecc6cd9824a"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""f78bfd81-34cd-4c11-9b53-5f227b939548"",
                    ""path"": ""<Joystick>/stick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""31262666-5473-4f60-9cd1-cdf190fda37d"",
                    ""path"": ""<Gamepad>/dpad"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4010fc09-8210-476b-801f-5756bd29e071"",
                    ""path"": ""<HID::Unknown DUALSHOCK 4 Wireless Controller>/hat"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ea50c394-cb31-48fd-b504-f39c291a579d"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": ""InvertVector2(invertX=false)"",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d4e174b3-2f79-48a3-b26d-366533dbb523"",
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
                    ""id"": ""317a76e1-02ea-4db4-a1e1-c4b3cfa4bc6d"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""58b22b62-3df0-4d8d-ab45-ab460982a088"",
                    ""path"": ""<HID::Unknown DUALSHOCK 4 Wireless Controller>/button7"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0cc8c442-7fa1-4232-ba98-89c5334324bd"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DigAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fb03f7b3-19a3-4799-b712-a7c21c5d8723"",
                    ""path"": ""<HID::Unknown DUALSHOCK 4 Wireless Controller>/button5"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DigAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5949c68f-1fb6-46d6-b296-83fb45ee99e8"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DigAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Fighter"",
            ""id"": ""93dc14d7-763c-47c9-88c0-396524b5f46c"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""6fea2af5-255c-4cc0-a6f8-1fc0e7260368"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""a7f693a2-abbb-475e-94e5-9faf5c988eb7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""DuelAction"",
                    ""type"": ""Button"",
                    ""id"": ""23599016-7dfc-4e21-a063-9d650442747b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""IJKL"",
                    ""id"": ""91581e15-79dc-4248-b321-5a36d618ae68"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""168b3669-5078-4d10-aed0-acf4618f27ff"",
                    ""path"": ""<Keyboard>/i"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""7895199b-84e0-42ea-9728-e99a2940417f"",
                    ""path"": ""<Keyboard>/k"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""373571dd-8d52-4543-935a-44851c629e4e"",
                    ""path"": ""<Keyboard>/j"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""fc81de4e-6699-4404-a7c9-d3f51a3c71de"",
                    ""path"": ""<Keyboard>/l"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""PS4Stick"",
                    ""id"": ""62490fcc-a755-4e05-8417-81015abb7b00"",
                    ""path"": ""2DVector(mode=2)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""down"",
                    ""id"": ""49f780b4-7c5b-4620-ba68-bedf2fb7ac06"",
                    ""path"": ""<Joystick>/rz"",
                    ""interactions"": """",
                    ""processors"": ""Normalize(min=-1,max=1)"",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""d74990ba-9ff0-4f7a-b9e3-ef0be2cf471c"",
                    ""path"": ""<Joystick>/z"",
                    ""interactions"": """",
                    ""processors"": ""Normalize(min=-1,max=1)"",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""GamepadButtons"",
                    ""id"": ""87ab3ad2-f65d-4a2e-bb20-8fe96205e7ae"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""cef90773-a8c8-4e84-94cf-dcda5a75f8ef"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""c069233a-0a27-478d-a114-4961503f4cfb"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""4fe1a7b4-9b22-47a4-baa4-72d2e116855d"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""ea6528cc-8efc-464f-b382-8430aa6cd2d6"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""PS4Buttons"",
                    ""id"": ""8a946aeb-7e5f-482c-a8c1-9e4844f27e36"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""a49c84d6-bb82-4a13-9a8a-c08001518b42"",
                    ""path"": ""<HID::Unknown DUALSHOCK 4 Wireless Controller>/button4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""25bcb516-96e2-4f17-9ed8-15f8e6424fda"",
                    ""path"": ""<HID::Unknown DUALSHOCK 4 Wireless Controller>/button2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""d79f8312-7739-4be5-8bf0-a85004e79f9d"",
                    ""path"": ""<Joystick>/trigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""54277ae4-ad74-43e8-a9e5-8815d9a045e2"",
                    ""path"": ""<HID::Unknown DUALSHOCK 4 Wireless Controller>/button3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""621cdea7-fdc7-4967-ab03-6c0a511984dd"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""69a437b8-3e54-47fe-ab84-87e8fedb094e"",
                    ""path"": ""<Keyboard>/semicolon"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""afd66edb-450b-457d-b313-3b762a92ed1e"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""79327d93-e958-4280-a909-c621cdc5f374"",
                    ""path"": ""<HID::Unknown DUALSHOCK 4 Wireless Controller>/button8"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6cb55167-f735-4de6-b999-e8188142b9da"",
                    ""path"": ""<Keyboard>/h"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DuelAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f0a2e264-b7c5-48df-aacd-2ebc39b1febc"",
                    ""path"": ""<HID::Unknown DUALSHOCK 4 Wireless Controller>/button6"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DuelAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""beb3a71b-b0a7-4691-aa2a-afa69c8b1f89"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DuelAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Digger
        m_Digger = asset.FindActionMap("Digger", throwIfNotFound: true);
        m_Digger_Move = m_Digger.FindAction("Move", throwIfNotFound: true);
        m_Digger_Jump = m_Digger.FindAction("Jump", throwIfNotFound: true);
        m_Digger_DigAction = m_Digger.FindAction("DigAction", throwIfNotFound: true);
        // Fighter
        m_Fighter = asset.FindActionMap("Fighter", throwIfNotFound: true);
        m_Fighter_Move = m_Fighter.FindAction("Move", throwIfNotFound: true);
        m_Fighter_Jump = m_Fighter.FindAction("Jump", throwIfNotFound: true);
        m_Fighter_DuelAction = m_Fighter.FindAction("DuelAction", throwIfNotFound: true);
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

    // Digger
    private readonly InputActionMap m_Digger;
    private IDiggerActions m_DiggerActionsCallbackInterface;
    private readonly InputAction m_Digger_Move;
    private readonly InputAction m_Digger_Jump;
    private readonly InputAction m_Digger_DigAction;
    public struct DiggerActions
    {
        private @GameplayControls m_Wrapper;
        public DiggerActions(@GameplayControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Digger_Move;
        public InputAction @Jump => m_Wrapper.m_Digger_Jump;
        public InputAction @DigAction => m_Wrapper.m_Digger_DigAction;
        public InputActionMap Get() { return m_Wrapper.m_Digger; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(DiggerActions set) { return set.Get(); }
        public void SetCallbacks(IDiggerActions instance)
        {
            if (m_Wrapper.m_DiggerActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_DiggerActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_DiggerActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_DiggerActionsCallbackInterface.OnMove;
                @Jump.started -= m_Wrapper.m_DiggerActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_DiggerActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_DiggerActionsCallbackInterface.OnJump;
                @DigAction.started -= m_Wrapper.m_DiggerActionsCallbackInterface.OnDigAction;
                @DigAction.performed -= m_Wrapper.m_DiggerActionsCallbackInterface.OnDigAction;
                @DigAction.canceled -= m_Wrapper.m_DiggerActionsCallbackInterface.OnDigAction;
            }
            m_Wrapper.m_DiggerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @DigAction.started += instance.OnDigAction;
                @DigAction.performed += instance.OnDigAction;
                @DigAction.canceled += instance.OnDigAction;
            }
        }
    }
    public DiggerActions @Digger => new DiggerActions(this);

    // Fighter
    private readonly InputActionMap m_Fighter;
    private IFighterActions m_FighterActionsCallbackInterface;
    private readonly InputAction m_Fighter_Move;
    private readonly InputAction m_Fighter_Jump;
    private readonly InputAction m_Fighter_DuelAction;
    public struct FighterActions
    {
        private @GameplayControls m_Wrapper;
        public FighterActions(@GameplayControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Fighter_Move;
        public InputAction @Jump => m_Wrapper.m_Fighter_Jump;
        public InputAction @DuelAction => m_Wrapper.m_Fighter_DuelAction;
        public InputActionMap Get() { return m_Wrapper.m_Fighter; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(FighterActions set) { return set.Get(); }
        public void SetCallbacks(IFighterActions instance)
        {
            if (m_Wrapper.m_FighterActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_FighterActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_FighterActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_FighterActionsCallbackInterface.OnMove;
                @Jump.started -= m_Wrapper.m_FighterActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_FighterActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_FighterActionsCallbackInterface.OnJump;
                @DuelAction.started -= m_Wrapper.m_FighterActionsCallbackInterface.OnDuelAction;
                @DuelAction.performed -= m_Wrapper.m_FighterActionsCallbackInterface.OnDuelAction;
                @DuelAction.canceled -= m_Wrapper.m_FighterActionsCallbackInterface.OnDuelAction;
            }
            m_Wrapper.m_FighterActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @DuelAction.started += instance.OnDuelAction;
                @DuelAction.performed += instance.OnDuelAction;
                @DuelAction.canceled += instance.OnDuelAction;
            }
        }
    }
    public FighterActions @Fighter => new FighterActions(this);
    public interface IDiggerActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnDigAction(InputAction.CallbackContext context);
    }
    public interface IFighterActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnDuelAction(InputAction.CallbackContext context);
    }
}
