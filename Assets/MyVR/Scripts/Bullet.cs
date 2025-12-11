using UnityEngine;
using MyFps;

namespace MyVR
{
    /// <summary>
    /// 탄환 관리 클래스
    /// </summary>
    public class Bullet : MonoBehaviour
    {
        #region Variables
        //참조
        private Rigidbody rb;

        [SerializeField]
        private float attackDamage = 5f;

        //임팩트 효과
        public GameObject hitImpactPrefabs;

        //이동속도
        [SerializeField]
        private float bulletSpeed = 20f;
        #endregion

        #region Unity Event Method
        private void Awake()
        {
            //참조
            rb = GetComponent<Rigidbody>();
        }

        private void Start()
        {
            //초기화 
            rb.linearVelocity = transform.forward * bulletSpeed;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.transform.tag == "LeftHand" || collision.transform.tag == "RightHand"
                || collision.transform.tag == "Weapon")
                return;

            //효과
            GameObject effectGo = Instantiate(hitImpactPrefabs, transform.position, Quaternion.identity);
            Destroy(effectGo, 2f);

            //데미지 입는 오브젝트에 데미지 주기
            IDamageable damageable = collision.transform.GetComponent<IDamageable>();
            if (damageable != null)
            {
                damageable.TakeDamage(attackDamage);
            }

            //킬
            Destroy(gameObject);
        }
        #endregion
    }
}