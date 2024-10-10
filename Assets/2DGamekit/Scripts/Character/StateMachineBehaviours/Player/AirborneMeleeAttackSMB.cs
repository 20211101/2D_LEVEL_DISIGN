using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gamekit2D
{
    public class AirborneMeleeAttackSMB : SceneLinkedSMB<PlayerCharacter>
    {
        public override void OnSLStateEnter (Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            m_MonoBehaviour.ForceNotHoldingGun();
        }
        
        public override void OnSLStatePostEnter (Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            m_MonoBehaviour.EnableMeleeAttack();
            if (m_MonoBehaviour.dashWhileAirborne)
            {
                Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Debug.Log(mousePos);
                Debug.Log((Vector2)Player.instance.transform.position);
                Vector2 dir = (mousePos- (Vector2)Player.instance.transform.position).normalized;
                Debug.Log(dir);
                m_MonoBehaviour.SetMoveVector(m_MonoBehaviour.meleeAttackDashSpeed * dir);
                Player.instance.StopTime(m_MonoBehaviour);
            }
//                m_MonoBehaviour.SetHorizontalMovement(m_MonoBehaviour.meleeAttackDashSpeed * m_MonoBehaviour.GetFacing());
        }

        public override void OnSLStateNoTransitionUpdate (Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            m_MonoBehaviour.UpdateJump();
            m_MonoBehaviour.AirborneHorizontalMovement();
            m_MonoBehaviour.AirborneVerticalMovement();
            m_MonoBehaviour.CheckForGrounded();
        }

        public override void OnSLStateExit (Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            m_MonoBehaviour.DisableMeleeAttack();
        }
    }
}