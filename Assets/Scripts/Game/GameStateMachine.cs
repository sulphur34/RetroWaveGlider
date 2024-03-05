using System;
using UnityEngine;
using Utils;

namespace Game
{
    public class GameStateMachine : MonoBehaviour
    {
        [SerializeField] private IState[] _states;
        
        private StateMachine _stateMachine;

        public void Initialize()
        {
            _stateMachine = new StateMachine();

            foreach (IState state in _states)
            {
                _stateMachine.AddState(state);
            }
        }

        public void SwichState()
        {
            
        }
    }
}
