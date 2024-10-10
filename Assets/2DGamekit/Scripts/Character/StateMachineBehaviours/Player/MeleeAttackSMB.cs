using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gamekit2D
{
    public class MeleeAttackSMB : SceneLinkedSMB<PlayerCharacter>
    {
        int m_HashAirborneMeleeAttackState = Animator.StringToHash ("AirborneMeleeAttack");
    
        public override void OnSLStatePostEnter (Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            m_MonoBehaviour.ForceNotHoldingGun();
            m_MonoBehaviour.EnableMeleeAttack();

            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Debug.Log(mousePos);
            Debug.Log((Vector2)Player.instance.transform.position);
            Vector2 dir = (mousePos - (Vector2)Player.instance.transform.position).normalized;
            Debug.Log(dir);
            m_MonoBehaviour.SetMoveVector(m_MonoBehaviour.meleeAttackDashSpeed * dir);
            Player.instance.StopTime(m_MonoBehaviour);
        }

        public override void OnSLStateNoTransitionUpdate (Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (!m_MonoBehaviour.CheckForGrounded ())
                animator.Play (m_HashAirborneMeleeAttackState, layerIndex, stateInfo.normalizedTime);
        
            m_MonoBehaviour.GroundedHorizontalMovement (false);
        }

        public override void OnSLStateExit (Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            m_MonoBehaviour.DisableMeleeAttack();
        }
    }
}