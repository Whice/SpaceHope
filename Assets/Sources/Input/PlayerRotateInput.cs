using SpaceHope.View.Components;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace SpaceHope.View.Input
{
    [RequireComponent(typeof(Mover))]
    public class PlayerRotateInput : MonoBehaviour
    {
        [SerializeField] private Mover mover=null;

        private PlayerInputActions inputActions;

        private Vector2 CorrectAxis(Vector2 axis)
        {
            return new Vector2(axis.y, axis.x);
        }
        private void PlayerRotateCanceled(InputAction.CallbackContext context)
        {
            Vector2 direction = context.ReadValue<Vector2>();
            mover.rotateAxis = CorrectAxis(direction);
        }

        private void PlayerRotateStarted(InputAction.CallbackContext context)
        {
            Vector2 direction = context.ReadValue<Vector2>();
            mover.rotateAxis = CorrectAxis(direction);
        }

        private void Awake()
        {
            inputActions = new PlayerInputActions();
            inputActions.Player.MoveButtons.performed += PlayerRotateStarted;
            inputActions.Player.MoveButtons.canceled += PlayerRotateCanceled;
        }

        private void OnEnable()
        {
            inputActions.Enable();
        }
        private void OnDisable()
        {
            inputActions.Disable();
        }
    }
}