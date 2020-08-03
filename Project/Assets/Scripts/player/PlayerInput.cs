
namespace Amheklerior.Rewind {

    public enum Action { NONE, MOVE_UP, MOVE_DOWN, MOVE_LEFT, MOVE_RIGHT, REWIND }

    public class PlayerInput {

        private Controls _controls;

        public Action Action { get; private set; }

        public void EnableInput() => _controls.Actions.Enable();

        public void DisableInput() => _controls.Actions.Disable();

        public bool IsInputGiven => Action != Action.NONE;

        public void ClearInput() => Action = Action.NONE;

        public PlayerInput() {
            _controls = new Controls();

            _controls.Actions.MoveUp.performed += ctx => Action = Action.MOVE_UP;
            _controls.Actions.MoveUp.canceled += ctx => Action = Action == Action.MOVE_UP ? Action.NONE : Action;

            _controls.Actions.MoveDown.performed += ctx => Action = Action.MOVE_DOWN;
            _controls.Actions.MoveDown.canceled += ctx => Action = Action == Action.MOVE_DOWN ? Action.NONE : Action;

            _controls.Actions.MoveLeft.performed += ctx => Action = Action.MOVE_LEFT;
            _controls.Actions.MoveLeft.canceled += ctx => Action = Action == Action.MOVE_LEFT ? Action.NONE : Action;

            _controls.Actions.MoveRight.performed += ctx => Action = Action.MOVE_RIGHT;
            _controls.Actions.MoveRight.canceled += ctx => Action = Action == Action.MOVE_RIGHT ? Action.NONE : Action;

            _controls.Actions.Rewind.performed += ctx => Action = Action.REWIND;
            _controls.Actions.Rewind.canceled += ctx => Action = Action == Action.REWIND ? Action.NONE : Action;
        }

    }
}