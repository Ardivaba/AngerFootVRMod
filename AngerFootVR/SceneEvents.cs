using MelonLoader;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace AngerFootVR
{
    [Obsolete]
    public class SceneEvents
    {
        public void Initialize()
        {
            SceneManager.sceneLoaded += OnAnySceneLoaded;
        }

        public void OnAnySceneLoaded(Scene scene, LoadSceneMode mode)
        {
            DisableEffectsCamera();
            DisableBloodCamera();

            MelonLogger.Msg("Scene loaded!");
            var player = GameObject.FindObjectOfType<Player>();
            if (player)
            {
                OnPlayerSceneLoaded(player, scene, mode);
            }
        }

        public void OnPlayerSceneLoaded(Player player, Scene scene, LoadSceneMode mode)
        {
            FixCameraHeight();
            FixHandsRendering();
            DisableFPSSleeves();
            HandsManager.ApplyIK();
        }

        private void FixCameraHeight()
        {
            foreach (var camera in GameObject.FindObjectsOfType<Camera>())
            {
                var newParent = new GameObject();
                newParent.transform.parent = camera.transform.parent;
                newParent.transform.position = camera.transform.position;
                newParent.transform.rotation = camera.transform.rotation;
                newParent.transform.localPosition = camera.transform.localPosition += new Vector3(0, -Controllers.DevicePosition().y * 0.85f, 0);
                newParent.transform.localRotation = camera.transform.localRotation;
                camera.transform.parent = newParent.transform;
            }
        }

        private void DisableEffectsCamera()
        {
            var effectsCamera = GameObject.Find("Effects Camera");
            effectsCamera.SetActive(false);
        }

        private void DisableBloodCamera()
        {
            GameObject.FindObjectOfType<BloodCamera>().enabled = false;
        }

        private void DisableFPSSleeves()
        {
            var leftSleeve = GameObject.Find("FPS_Hands_02_RigSkin:LeftSleeve");
            if (leftSleeve)
            {
                leftSleeve.SetActive(false);
            }
            var rightSleeve = GameObject.Find("FPS_Hands_02_RigSkin:RightSleeve");
            if (rightSleeve)
            {
                rightSleeve.SetActive(false);
            }
        }

        private void FixHandsRendering()
        {
            var fpsHands = GameObject.Find("fpsHands_V02");
            foreach (var renderer in fpsHands.GetComponentsInChildren<SkinnedMeshRenderer>())
            {
                renderer.allowOcclusionWhenDynamic = false;
                renderer.forceRenderingOff = false;
                renderer.updateWhenOffscreen = true;
                renderer.gameObject.isStatic = false;
            }
        }
    }
}
