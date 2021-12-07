using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace CMF {
    public class CharacterGlobalInput : CharacterInput {
        public System.Action OnDrink;

        [SerializeField] private InputActionReference movementInputAxis, jumpInput, sprintInput, drinkInput;


        private void Awake() {
            jumpInput.action.performed += _ => isJumpKeyPressed = true;
            jumpInput.action.canceled += _ => isJumpKeyPressed = false;
            sprintInput.action.performed += _ => isSprintKeyPressed = true;
            sprintInput.action.canceled += _ => isSprintKeyPressed = false;
            drinkInput.action.performed += Drink;
        }

        private void OnEnable() {
            movementInputAxis.action.Enable();
            jumpInput.action.Enable();
            sprintInput.action.Enable();
            drinkInput.action.Enable();
        }

        private void OnDisable() {
            movementInputAxis.action.Disable();
            jumpInput.action.Disable();
            sprintInput.action.Disable();
            drinkInput.action.Disable();
        }

        public override float GetHorizontalMovementInput() {
            return movementInputAxis.action.ReadValue<Vector2>().x;
        }

        public override float GetVerticalMovementInput() {
            return movementInputAxis.action.ReadValue<Vector2>().y;
        }

        private void Drink(InputAction.CallbackContext obj) {
            OnDrink?.Invoke();
        }
    }
}
