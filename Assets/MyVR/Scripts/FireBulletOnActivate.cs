using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using System.Collections;

namespace MyVR
{
    /// <summary>
    /// 피스톨 탄환 발사
    /// </summary>
    public class FireBulletOnActivate : MonoBehaviour
    {
        #region Variables
        //참조
        private XRGrabInteractable grabInteractable;

        public GameObject bulletPrefab;     //탄환
        public Transform firePoint;         //총구

        //연사 방지
        private bool isFire = false;
        [SerializeField]
        private float delayTime = 0.5f;     //발사 딜레이 시간
        #endregion

        #region Unity Event Method
        private void Awake()
        {
            //참조
            grabInteractable = GetComponent<XRGrabInteractable>();

            //이벤트 등록
            grabInteractable.activated.AddListener(Fire);
        }
        #endregion

        #region Custom Method
        //이벤트 발생시 호출 되는 함수
        public void Fire(ActivateEventArgs args)
        {
            if (isFire)
                return;

            StartCoroutine(Shoot());
        }

        IEnumerator Shoot()
        {
            isFire = true;

            //발사 처리 - 탄환 발생
            GameObject bulletGo = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Destroy(bulletGo, 3f);

            //지연
            yield return new WaitForSeconds(delayTime);

            isFire = false;
        }
        #endregion
    }
}