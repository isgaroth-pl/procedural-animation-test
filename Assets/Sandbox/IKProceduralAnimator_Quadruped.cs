using NaughtyAttributes;
using UnityEngine;

public class IKProceduralAnimator_Quadruped : MonoBehaviour
{
    #region IK CONTROLLERS REFERENCES
    [Foldout("IK CONTROLLERS REFERENCES:")]
    [SerializeField] IK_LegController FL_IKController = default;
    [Foldout("IK CONTROLLERS REFERENCES:")]
    [SerializeField] IK_LegController FR_IKController = default;
    [Foldout("IK CONTROLLERS REFERENCES:")]
    [SerializeField] IK_LegController RL_IKController = default;
    [Foldout("IK CONTROLLERS REFERENCES:")]
    [SerializeField] IK_LegController RR_IKController = default;
    [Space]
    #endregion
    [Header("IDLE LEG POS MODIFIER:")]
    [SerializeField] Vector3 FL_IdleLegPosModifier = default;
    [Space] 
    [Header("MOVEMENT SETTINGS:")]
    [SerializeField] float raycastMaxLength = default;
    [SerializeField] float stepDistance = default;
    [SerializeField] float stepYDelta = default;
    [SerializeField] float stepDuration = default;
    [SerializeField] LayerMask groundLayer = default;


    private Vector3 FL_IdleLegPos = default;
    private Vector3 FR_IdleLegPos = default;
    private Vector3 RL_IdleLegPos = default;
    private Vector3 RR_IdleLegPos = default;

    private void InitIdleLegPositions()
    {
        FL_IdleLegPos = transform.TransformPoint(FL_IdleLegPosModifier);
        FR_IdleLegPos = transform.TransformPoint(new Vector3(-FL_IdleLegPosModifier.x, FL_IdleLegPosModifier.y, FL_IdleLegPosModifier.z));
        RL_IdleLegPos = transform.TransformPoint(new Vector3(FL_IdleLegPosModifier.x, FL_IdleLegPosModifier.y, -FL_IdleLegPosModifier.z));
        RR_IdleLegPos = transform.TransformPoint(new Vector3(-FL_IdleLegPosModifier.x, FL_IdleLegPosModifier.y, -FL_IdleLegPosModifier.z));
    }

    [Button]
    private void DebugShowIdleLegLocalPositions()
    {
        InitIdleLegPositions();
        Debug.DrawLine(transform.position, transform.position + Vector3.up * 2f, Color.green, 10f);
        Debug.DrawLine(FL_IdleLegPos, FL_IdleLegPos + Vector3.up, Color.red, 10f);
        Debug.DrawLine(FR_IdleLegPos, FR_IdleLegPos + Vector3.up, Color.red, 10f);
        Debug.DrawLine(RL_IdleLegPos, RL_IdleLegPos + Vector3.up, Color.red, 10f);
        Debug.DrawLine(RR_IdleLegPos, RR_IdleLegPos + Vector3.up, Color.red, 10f);
    }

    void Start()
    {
   
            //currentMoveTargetPos = moveTargetIK.position;
            //currentAimTargetPos = aimTargetIK.position;
        
    }


    void Update()
    {
        //currentLegTargetPos = bodyTransform.TransformPoint(idleLegPos);
        //var ray = new Ray(currentLegTargetPos, Vector3.down);
        //Debug.DrawRay(ray.origin, ray.direction, Color.red);
        //RaycastHit raycastHit;
        //if (Physics.Raycast(ray, out raycastHit, raycastMaxLength, groundLayer))
        //{
        //    Debug.DrawLine(raycastHit.point, raycastHit.point + Vector3.up, Color.green);
        //    if (Vector3.Distance(raycastHit.point, currentMoveTargetPos) > stepDistance)
        //    {
        //        Debug.Log($"DISTANCE IN {this.name} is {Vector3.Distance(currentLegTargetPos, currentMoveTargetPos)}");
        //        MoveIKTarget(raycastHit.point);
        //    }
        //}
    }
}
