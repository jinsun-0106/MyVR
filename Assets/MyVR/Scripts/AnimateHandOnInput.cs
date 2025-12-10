using UnityEngine;
using UnityEngine.InputSystem;

namespace MyVR
{
    /// <summary>
    /// 인풋에 따라 손 모델 애니메이션 실행
    /// </summary>
    public class AnimateHandOnInput : MonoBehaviour
    {
        #region Variables
        public InputActionProperty pinchAction;     //컨트롤러 입력값
        public InputActionProperty gripAction;      //컨트롤러 입력값

        private Animator handAnimator;

        //애니메이터 파라미터
        private const string Grip = "Grip";
        private const string Trigger = "Trigger";
        #endregion

        #region Unity Event Method
        private void Awake()
        {
            //참조
            handAnimator = GetComponent<Animator>();
        }

        private void Update()
        {
            //입력값 받기
            float gripValue = gripAction.action.ReadValue<float>();
            float triggerValue = pinchAction.action.ReadValue<float>();

            //애니메이터 파라미터 적용
            handAnimator.SetFloat(Grip, gripValue);
            handAnimator.SetFloat(Trigger, triggerValue);
        }
        #endregion
    }
}