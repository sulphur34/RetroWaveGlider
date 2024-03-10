﻿using UnityEngine;

namespace UI.Menus
{
    public class MenuSwitcher : MonoBehaviour
    {
        [SerializeField] private Menu _activatedMenu;
        [SerializeField] private Menu _deactivatedMenu;

        public void Switch()
        {
            _deactivatedMenu?.Close();
            _activatedMenu?.Open();
        }
    }
}