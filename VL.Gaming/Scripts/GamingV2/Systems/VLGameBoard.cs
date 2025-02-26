using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using VL.Gaming.Scripts.Gaming.Tools;
using VL.Gaming.Scripts.GamingV2.Entities;
using VL.Gaming.Scripts.Utils;

namespace VL.Gaming.Scripts.GamingV2.Systems
{
    internal class VLGameBoard : VLBaseSystemV2
    {
        public VLGameBoard()
        {
        }

        void Start()
        {
            //StartGame
            var gameObject = VLResourceHelper.FindGameObjectByName(VLDictionaries.VLButtonsDic[VLButtons.StartGame]);
            gameObject.GetComponent<Button>().onClick.AddListener(() => StartGame());
            //Load
            //Config
            //Quit
            gameObject = VLResourceHelper.FindGameObjectByName(VLDictionaries.VLButtonsDic[VLButtons.Quit]);
            gameObject.GetComponent<Button>().onClick.AddListener(() => QuitGame());
        }

        public void StartGame()
        {
            SceneManager.LoadScene("Scene_StartGame");
        }
        public void QuitGame()
        {
            Application.Quit();
        }
    }
}
