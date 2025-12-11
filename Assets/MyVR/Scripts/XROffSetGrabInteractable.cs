using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

namespace MyVR
{
    /// <summary>
    /// 잡히는 오브젝트의 잡히는 위치 지정
    /// </summary>
    public class XROffsetGrabInteractable : XRGrabInteractable
    {
        #region Variables
        private GameObject attachPoint; //잡히는 위치를 가진 오브젝트
        #endregion

        #region Unity Event Method
        private void Start()
        {
            //잡히는 위치를 가진 오브젝트 생성
            if(attachTransform == null)
            {
                attachPoint = new GameObject("Offset Grab Pivot");
                attachPoint.transform.SetParent(transform, false);
                attachTransform = attachPoint.transform;
            }            
        }

        protected override void OnSelectEntering(SelectEnterEventArgs args)
        {
            attachTransform.position = args.interactorObject.transform.position;
            attachTransform.rotation = args.interactorObject.transform.rotation;

            base.OnSelectEntering(args);
        }
        #endregion
    }
}