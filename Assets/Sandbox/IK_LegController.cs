using DG.Tweening;
using UnityEngine;


public class IK_LegController : MonoBehaviour
{
    [Header("IK TARGETS:")]
    [SerializeField] Transform moveTargetIK = default;
    [SerializeField] Transform aimTargetIK = default;
    
    private Vector3 currentMoveTargetPos;
    private Vector3 currentAimTargetPos;
    private bool isMoving = false;

   
    public void MoveIKTarget(Vector3 moveTargetWorldPos, float stepYDelta, float stepDuration)
    {
        isMoving = true;
        //currentAimTargetPos = moveTargetWorldPos;
        //currentMoveTargetPos = moveTargetWorldPos;
        moveTargetIK.DOJump(moveTargetWorldPos, stepYDelta, 1, stepDuration).SetEase(Ease.InOutSine).OnComplete(() => { isMoving = false; });
        aimTargetIK.DOJump(moveTargetWorldPos, stepYDelta, 1, stepDuration).SetEase(Ease.InOutSine);
    }

    //public void LateUpdate()
    //{
    //    if (!isMoving)
    //    {
    //        moveTargetIK.position = currentMoveTargetPos;
    //        aimTargetIK.position = currentAimTargetPos;
    //    }
    //}

}
