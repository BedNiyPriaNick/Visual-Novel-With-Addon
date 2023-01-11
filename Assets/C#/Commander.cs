using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Data;
using Game.View;
using ViewBG = Game.View.BG;
using CommandBG = Game.Data.BG;

public class Commander : MonoBehaviour
{
    [SerializeField] private ListCommand _listCommands;
    [SerializeField] private ViewBG _commandBG;
    [SerializeField] private Say _commandSay;

    private int _indexCommand = 0;

    private void Start()
    {
        ExecuteCommand();
    }

    public void ExecuteCommand()
    {
        if (_indexCommand == _listCommands.Commands.Length) return;

        switch (_listCommands.Commands[_indexCommand])
        {
            case CommandBG bg:
                _indexCommand++;

                if (bg.Type == BgType.show) _commandBG.Show(bg.Sprite);
                else _commandBG.Hide();

                ExecuteCommand();
                break;

            case Dialogs dialogs:
                _indexCommand++;

                _commandSay.Dialogs = dialogs;
                _commandSay.NextDialog();
                break;
        }
    }
}
