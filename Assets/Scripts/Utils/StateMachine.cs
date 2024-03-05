using System;
using System.Collections.Generic;

namespace Utils
{
    public class StateMachine
    {
        private Dictionary<Type, IState> _states;
        private IState _currentState;

        public StateMachine()
        {
            _states = new Dictionary<Type, IState>();
        }

        public void AddState(IState state)
        {
            _states ??= new Dictionary<Type, IState>();

            _states.Add(state.GetType(), state);
        }

        public void SwitchState<TState>() where TState : IState
        {
            var type = typeof(TState);

            if (_currentState?.GetType() == type)
                return;

            if (_states.TryGetValue(type, out var newState))
            {
                _currentState?.Exit();
                newState.Enter();
                _currentState = newState;
            }
        }
    }
}
