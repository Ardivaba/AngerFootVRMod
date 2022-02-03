using AngerFootVR;
using AngerFootVR.Util;
using MelonLoader;
using System;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;

[assembly: MelonInfo(typeof(Bootstrap), "Angry Foot VR Mod", "0.02", "Ardi Vaba", "https://github.com/ardivaba/AngryFootVRMod")]
[assembly: MelonGame]

namespace AngerFootVR
{
    [Obsolete]
    public class Bootstrap : MelonMod
    {
        private SceneEvents _sceneEvents = new SceneEvents();
        private bool _vrInputInitialized = false;

        public override void OnApplicationLateStart()
        {
            LoadedPrefabs.Initialize();
            _sceneEvents.Initialize();
            UseLowerQuality();
        }

        public override void OnLateUpdate()
        {
            if (XRDevice.isPresent && !_vrInputInitialized) ChangeToVRInput();
            HandleDebugInput();
            HandsManager.UpdateIK();
            DisableCrosshair();
        }

        private void UseLowerQuality()
        {
            PlayerPrefs.SetInt("QualityLevel", 0);
        }

        private void ChangeToVRInput()
        {
            ReflectionUtils.ChangeStaticValue(typeof(GameSettings), "_inputProvider", new VRInputProvider());
        }

        private void HandleDebugInput()
        {
            if (Controllers.LeftControllerPrimaryButtonPressed() || Input.GetKeyDown(KeyCode.F1))
            {
                SceneManager.LoadScene(SceneNames.SewerShotgunIntro, LoadSceneMode.Single);
            }
        }

        private void DisableCrosshair()
        {
            var crosshair = GameObject.Find("Crosshair");
            if (crosshair)
            {
                crosshair.SetActive(false);
            }
        }
    }
}
