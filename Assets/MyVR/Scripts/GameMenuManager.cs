using UnityEngine;
using UnityEngine.InputSystem;

namespace MyVR
{
    /// <summary>
    /// 게임메뉴 UI를 관리하는 클래스
    /// </summary>
    public class GameMenuManager : MonoBehaviour
    {
        #region Variables
        public GameObject gameMenu; //게임메뉴 UI 오브젝트

        public InputActionProperty toggleButton;  //게임메뉴 UI 토글 버튼

        //UI 위치 지정
        public Transform head;

        [SerializeField]
        private float distance = 1.5f;
        #endregion

        #region Unity Event Method
        private void Update()
        {
            //토글 버튼 인풋 처리
            if(toggleButton.action.WasPressedThisFrame())
            {
                Toggle();
            }
        }
        #endregion

        #region Custom Method
        private void Toggle()
        {
            gameMenu.SetActive(!gameMenu.activeSelf);

            //UI 보인다
            if(gameMenu.activeSelf)
            {
                gameMenu.transform.position = head.position 
                    + new Vector3(head.forward.x, 0f, head.forward.z).normalized * distance;
                gameMenu.transform.LookAt(new Vector3(head.position.x, gameMenu.transform.position.y,
                    head.position.z));
                gameMenu.transform.forward *= -1;   //반대방향으로 뒤집기
            }

        }
        #endregion
    }
}