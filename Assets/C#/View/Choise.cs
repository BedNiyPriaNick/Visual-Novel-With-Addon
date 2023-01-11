using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyDialogs = Game.Data.Dialogs;

namespace Game.View
{
    public class Choise : MonoBehaviour
    {
        [SerializeField] private Canvas _self;
        [SerializeField] private Transform _parent;
        [SerializeField] private ChoiseButton _prefab;

        private ChoiseButton tmp;

        public void Show() => _self.enabled = true;

        public void Add(MyDialogs.ChoiseElement choiseElement, Say say)
        {
            tmp = Instantiate(_prefab, _parent);
            tmp.Say = say;
            tmp.Show(choiseElement);
        }

        public void Hide() => _self.enabled = false;
    }
}
