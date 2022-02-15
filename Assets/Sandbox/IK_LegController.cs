using DG.Tweening;
using UnityEngine;


public class IK_LegController : MonoBehaviour
{
    [Header("LEGS IK TARGETS")]
    [SerializeField] Transform bodyTransform = default;
    [SerializeField] Transform moveTargetIK = default;
    [SerializeField] Transform aimTargetIK = default;
    [SerializeField] Vector3 idleLegPos = default;
    [SerializeField] float raycastMaxLength = default;
    [SerializeField] float stepDistance = default;
    [SerializeField] float stepYDelta = default;
    [SerializeField] float stepDuration = default;
    [SerializeField] LayerMask groundLayer = default;

    private Vector3 currentMoveTargetPos;
    private Vector3 currentAimTargetPos;
    private Vector3 currentLegTargetPos;
    private bool isMoving = false;

    void Start()
    {
        currentMoveTargetPos = moveTargetIK.position;
        currentAimTargetPos = aimTargetIK.position;      
    }

    public void Update()
    {
        currentLegTargetPos = bodyTransform.TransformPoint(idleLegPos);
        var ray = new Ray(currentLegTargetPos, Vector3.down);
        Debug.DrawRay(ray.origin, ray.direction, Color.red);
        RaycastHit raycastHit;
        if(Physics.Raycast(ray, out raycastHit, raycastMaxLength, groundLayer))
        {
            Debug.DrawLine(raycastHit.point, raycastHit.point + Vector3.up, Color.green);
            if (Vector3.Distance(raycastHit.point, currentMoveTargetPos) > stepDistance)
            {
                Debug.Log($"DISTANCE IN {this.name} is {Vector3.Distance(currentLegTargetPos, currentMoveTargetPos)}");
                MoveIKTarget(raycastHit.point);
            }
        }      
    }

    private void MoveIKTarget(Vector3 worldPos)
    {
        //ADD LERP TO MOVE AND MOVE SPEED THEN ZIG ZAG
        isMoving = true;
        currentAimTargetPos = worldPos;
        currentMoveTargetPos = worldPos;
        moveTargetIK.DOJump(worldPos, stepYDelta, 1, stepDuration).SetEase(Ease.InOutSine).OnComplete(() => { isMoving = false; });
        aimTargetIK.DOJump(worldPos, stepYDelta, 1, stepDuration).SetEase(Ease.InOutSine);
    }

    public void LateUpdate()
    {
        if (!isMoving)
        {
            moveTargetIK.position = currentMoveTargetPos;
            aimTargetIK.position = currentAimTargetPos;
        }
    }

}
