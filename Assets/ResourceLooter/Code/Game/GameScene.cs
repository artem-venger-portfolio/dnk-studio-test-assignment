﻿using UnityEngine;

namespace ResourceLooter
{
    public class GameScene : MonoBehaviour
    {
        [SerializeField]
        private InputReceiver _inputReceiver;

        [SerializeField]
        private Camera _camera;

        private MovePositionProvider _movePositionProvider;

        private void Start()
        {
            StartGame();
        }

        public void StartGame()
        {
            _movePositionProvider = new MovePositionProvider(_inputReceiver, _camera);
            _movePositionProvider.Enable();
        }
    }
}