using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

namespace MyVR
{
    /// <summary>
    /// 잡히는 오브젝트의 잡히는 위치가 왼쪽과 오른쪽 다른게 있는 경우
    /// </summary>
    public class TwoAttachGrabInteractable : XRGrabInteractable
    {
        #region Variables
        //잡히는 위치(왼손, 오른손)
        public Transform leftAttackTransform;
        public Transform rightAttackTransform;
        #endregion

        #region Unity Event Method
        protected override void OnSelectEntered(SelectEnterEventArgs args)
        {
            if(args.interactorObject.transform.CompareTag("LeftHand"))
            {
                attachTransform = leftAttackTransform;
            }
            else if(args.interactorObject.transform.CompareTag("RightHand"))
            {
                attachTransform = rightAttackTransform;
            }

            base.OnSelectEntered(args);
        }
        #endregion
    }
}