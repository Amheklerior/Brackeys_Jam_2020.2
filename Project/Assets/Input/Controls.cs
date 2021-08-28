// GENERATED AUTOMATICALLY FROM 'Assets/Input/Controls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace Amheklerior.Rewind
{
    public class @Controls : IInputActionCollection, IDisposable
    {
        public InputActionAsset asset { get; }
        public @Controls()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""Actions"",
            ""id"": ""d460e3e3-bf85-4fda-aaaa-b24de8f9792f"",
            ""actions"": [
                {
                    ""name"": ""Move Left"",
                    ""type"": ""Button"",
                    ""id"": ""0a331127-5549-4122-9cf9-839fe586b64b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Move Right"",
                    ""type"": ""Button"",
                    ""id"": ""a9391cc0-7163-43b6-aec7-a67c0c85b75e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Move Up"",
                    ""type"": ""Button"",
                    ""id"": ""78e78d81-48c8-496f-8fbf-1f6dea6e3e97"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Move Down"",
                    ""type"": ""Button"",
                    ""id"": ""b9cbd125-6159-46ec-8ced-54e05db98e13"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Rewind"",
                    ""type"": ""Button"",
                    ""id"": ""e321e1f3-9a36-4def-b5c8-00da903a7deb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""2277b897-ed37-44dc-9c39-618a76ca3d59"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""427f2a71-74f8-4640-a0c1-4380eeff2653"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ae34e26f-e55d-48fd-9609-24431caba704"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ac77c18c-a51f-43e0-9b67-45fae8f89c09"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1ec3cc10-fe23-4301-a7b4-7fa4bcf4c079"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a2a4d004-f4e4-4574-afef-8bcaffff6cf4"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e79ee350-e678-468a-9d3c-17f133327df8"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c96022ca-ed57-4129-8ee2-27128e5c414e"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f4631815-d345-47e8-baeb-1dc1c4408dc0"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rewind"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""95bb0a39-bb48-4c66-ac0c-b2607854deec"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rewind"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // Actions
            m_Actions = asset.FindActionMap("Actions", throwIfNotFound: true);
            m_Actions_MoveLeft = m_Actions.FindAction("Move Left", throwIfNotFound: true);
            m_Actions_MoveRight = m_Actions.FindAction("Move Right", throwIfNotFound: true);
            m_Actions_MoveUp = m_Actions.FindAction("Move Up", throwIfNotFound: true);
            m_Actions_MoveDown = m_Actions.FindAction("Move Down", throwIfNotFound: true);
            m_Actions_Rewind = m_Actions.FindAction("Rewind", throwIfNotFound: true);
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

        // Actions
        private readonly InputActionMap m_Actions;
        private IActionsActions m_ActionsActionsCallbackInterface;
        private readonly InputAction m_Actions_MoveLeft;
        private readonly InputAction m_Actions_MoveRight;
        private readonly InputAction m_Actions_MoveUp;
        private readonly InputAction m_Actions_MoveDown;
        private readonly InputAction m_Actions_Rewind;
        public struct ActionsActions
        {
            private @Controls m_Wrapper;
            public ActionsActions(@Controls wrapper) { m_Wrapper = wrapper; }
            public InputAction @MoveLeft => m_Wrapper.m_Actions_MoveLeft;
            public InputAction @MoveRight => m_Wrapper.m_Actions_MoveRight;
            public InputAction @MoveUp => m_Wrapper.m_Actions_MoveUp;
            public InputAction @MoveDown => m_Wrapper.m_Actions_MoveDown;
            public InputAction @Rewind => m_Wrapper.m_Actions_Rewind;
            public InputActionMap Get() { return m_Wrapper.m_Actions; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(ActionsActions set) { return set.Get(); }
            public void SetCallbacks(IActionsActions instance)
            {
                if (m_Wrapper.m_ActionsActionsCallbackInterface != null)
                {
                    @MoveLeft.started -= m_Wrapper.m_ActionsActionsCallbackInterface.OnMoveLeft;
                    @MoveLeft.performed -= m_Wrapper.m_ActionsActionsCallbackInterface.OnMoveLeft;
                    @MoveLeft.canceled -= m_Wrapper.m_ActionsActionsCallbackInterface.OnMoveLeft;
                    @MoveRight.started -= m_Wrapper.m_ActionsActionsCallbackInterface.OnMoveRight;
                    @MoveRight.performed -= m_Wrapper.m_ActionsActionsCallbackInterface.OnMoveRight;
                    @MoveRight.canceled -= m_Wrapper.m_ActionsActionsCallbackInterface.OnMoveRight;
                    @MoveUp.started -= m_Wrapper.m_ActionsActionsCallbackInterface.OnMoveUp;
                    @MoveUp.performed -= m_Wrapper.m_ActionsActionsCallbackInterface.OnMoveUp;
                    @MoveUp.canceled -= m_Wrapper.m_ActionsActionsCallbackInterface.OnMoveUp;
                    @MoveDown.started -= m_Wrapper.m_ActionsActionsCallbackInterface.OnMoveDown;
                    @MoveDown.performed -= m_Wrapper.m_ActionsActionsCallbackInterface.OnMoveDown;
                    @MoveDown.canceled -= m_Wrapper.m_ActionsActionsCallbackInterface.OnMoveDown;
                    @Rewind.started -= m_Wrapper.m_ActionsActionsCallbackInterface.OnRewind;
                    @Rewind.performed -= m_Wrapper.m_ActionsActionsCallbackInterface.OnRewind;
                    @Rewind.canceled -= m_Wrapper.m_ActionsActionsCallbackInterface.OnRewind;
                }
                m_Wrapper.m_ActionsActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @MoveLeft.started += instance.OnMoveLeft;
                    @MoveLeft.performed += instance.OnMoveLeft;
                    @MoveLeft.canceled += instance.OnMoveLeft;
                    @MoveRight.started += instance.OnMoveRight;
                    @MoveRight.performed += instance.OnMoveRight;
                    @MoveRight.canceled += instance.OnMoveRight;
                    @MoveUp.started += instance.OnMoveUp;
                    @MoveUp.performed += instance.OnMoveUp;
                    @MoveUp.canceled += instance.OnMoveUp;
                    @MoveDown.started += instance.OnMoveDown;
                    @MoveDown.performed += instance.OnMoveDown;
                    @MoveDown.canceled += instance.OnMoveDown;
                    @Rewind.started += instance.OnRewind;
                    @Rewind.performed += instance.OnRewind;
                    @Rewind.canceled += instance.OnRewind;
                }
            }
        }
        public ActionsActions @Actions => new ActionsActions(this);
        public interface IActionsActions
        {
            void OnMoveLeft(InputAction.CallbackContext context);
            void OnMoveRight(InputAction.CallbackContext context);
            void OnMoveUp(InputAction.CallbackContext context);
            void OnMoveDown(InputAction.CallbackContext context);
            void OnRewind(InputAction.CallbackContext context);
        }
    }
}
