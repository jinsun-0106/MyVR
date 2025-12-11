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

        public InputActionProperty leftActivate;        //왼손 컨트롤러 트리거 버튼
        public InputActionProperty rightActivate;       //오른손 컨트롤러 트리거 버튼

        public InputActionProperty leftSelect;          //왼손 컨트롤러 그랍 버튼
        public InputActionProperty rightSelect;          //오른손 컨트롤러 그랍 버튼
        #endregion

        #region Unity Event Method
        private void Update()
        {
            //트리거 버튼 값 받아오기
            float leftValue = leftActivate.action.ReadValue<float>();
            float rightValue = rightActivate.action.ReadValue<float>();

            //셀렉 버튼 값 받아오기
            float leftSelectValue = leftSelect.action.ReadValue<float>();
            float rightSelectValue = rightSelect.action.ReadValue<float>();

            //텔리포트 레이 활성화
            leftTeleportRay.SetActive(leftSelectValue == 0f && leftValue > 0.1f);
            rightTeleportRay.SetActive(rightSelectValue == 0f && rightValue > 0.1f);
        }
        #endregion
    }
}