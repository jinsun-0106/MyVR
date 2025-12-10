using UnityEngine;
using UnityEngine.InputSystem;

namespace MyVR
{
    /// <summary>
    /// 컨트롤러 입력에 따른 TeleportRay 활성화
    /// </summary>
    public class ActivateTeleportRay : MonoBehaviour
    {
        #region Variables
        public GameObject leftTeleportRay;
        public GameObject rightTeleportRay;

        public InputActionProperty leftActivate;          //왼손 컨트롤러 트리거 버튼
        public InputActionProperty rightActivate;         //오른손 컨츠롤러 트리거 버튼

        #endregion

        #region Unity Event Method
        private void Update()
        {
            //트리거 버튼 값
            float leftValue = leftActivate.action.ReadValue<float>();
            float rightValue = rightActivate.action.ReadValue<float>();

            //텔레포트 레이 활성화
            leftTeleportRay.SetActive(leftValue > 0.1f);
            rightTeleportRay.SetActive(rightValue > 0.1f);
        }
        #endregion

        #region Custom Method

        #endregion
    }
}
