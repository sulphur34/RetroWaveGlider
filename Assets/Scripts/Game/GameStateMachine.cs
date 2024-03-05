using UnityEngine;
using Utils;

namespace Game
{
    public class GameStateMachine : MonoBehaviour
    {
        private StateMachine _stateMachine;

        public void Initialize()
        {
            _stateMachine = new StateMachine();
        }


    }
}
