using System;
using UnityEngine;
using Utils;

namespace Game.GameStates
{
    public class GameState : MonoBehaviour, IState
    {
        public event Action Entered;
        public event Action Exited;
        
        public virtual void Enter()
        {
            Entered?.Invoke();
        }

        public virtual void Exit()
        {
            Exited?.Invoke();
        }
    }
}
