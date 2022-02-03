using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace AngerFootVR
{
    public class VRHandController : MonoBehaviour
    {
        private Player _player;
        private HandType _handType;

        [SerializeField] private Vector3 _leftHandOffset = new Vector3(-0.1f, 0f, 0.25f);
        [SerializeField] private Vector3 _rightHandOffset = new Vector3(0.1f, 0f, 0.25f);
        [SerializeField] private Vector3 _scale = new Vector3(0.95f, 0.95f, 0.95f);
        [SerializeField] private Vector3 _leftHandRotation = new Vector3(0, 15, 45) * 0;
        [SerializeField] private Vector3 _rightHandRotation = new Vector3(0, 15, -45) * 0;

        public void Initialize(Player player, HandType handType)
        {
            _player = player;
            _handType = handType;
        }

        void LateUpdate() 
        {
            transform.parent = _player.transform;
            transform.localPosition = _handType == HandType.LEFT ? _leftHandOffset + Controllers.LeftControllerPosition() : _rightHandOffset + Controllers.RightControllerPosition();
            transform.localEulerAngles = _handType == HandType.LEFT ? _leftHandRotation + Controllers.LeftControllerRotation().eulerAngles : _rightHandRotation + Controllers.RightControllerRotation().eulerAngles;
            //transform.localScale = Vector3.Magnitude(_player.Movement.Velocity) > 1f ? Vector3.zero : Vector3.Lerp(transform.localScale, _scale, 15f * Time.deltaTime);

            if (_player.HandRig.CanShoot && _handType == HandType.RIGHT)
            {
                //transform.localScale = new Vector3(0, 0, 0);
            }
        }
    }
}
