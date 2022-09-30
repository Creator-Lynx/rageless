using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{

    private BossStateMachine stateMachine;

    public int fase = 0;

    // Start is called before the first frame update
    private IEnumerator Start()
    {
        stateMachine = GetComponent<BossStateMachine>();
        stateMachine.SetState(0);

        var state = 0;
        fase = 0;

        while (!stateMachine.isDead)
        {
            if (fase == 0)
            {
                if (state == 0)
                {
                    //yield return new WaitForSeconds(5f);
                    //stateMachine.SetState(1);
                    //
                    //while (!stateMachine.playerReached)
                    //{
                    //    yield return new WaitForEndOfFrame();
                    //}

                    yield return new WaitForSeconds(2f);
                    stateMachine.InvokeStateAttack(0);

                    yield return new WaitForSeconds(1f);
                    stateMachine.InvokeStateAttack(1);

                    yield return new WaitForSeconds(1f);
                    stateMachine.InvokeStateAttack(1);

                    yield return new WaitForSeconds(1f);
                    //=============================
                    yield return new WaitForSeconds(2f);
                    stateMachine.InvokeStateAttack(1);

                    yield return new WaitForSeconds(0.7f);
                    stateMachine.InvokeStateAttack(0);

                    yield return new WaitForSeconds(0.7f);
                    stateMachine.InvokeStateAttack(1);

                    state = 1;
                }
                else if (state == 1)
                {
                    yield return new WaitForSeconds(5f);
                    stateMachine.isShooting = true;
                    yield return new WaitForSeconds(8f);
                    stateMachine.isShooting = false;

                    state = 0;
                }
            }
            else
            {
                if (state == 0)
                {
                    yield return new WaitForSeconds(3f);
                    stateMachine.InvokeStateAttack(0);
                    yield return new WaitForSeconds(0.7f);
                    stateMachine.InvokeStateAttack(1);
                    yield return new WaitForSeconds(1f);
                    stateMachine.InvokeStateAttack(2);
                    yield return new WaitForSeconds(1f);
                    state = 1;
                }
                else if (state == 1)
                {
                    stateMachine.SetState(3);
                    yield return new WaitForSeconds(2f);
                    stateMachine.SetState(4);
                    stateMachine.isShooting = true;
                    yield return new WaitForSeconds(8f);
                    stateMachine.isShooting = false;
                    stateMachine.SetState(0);
                    stateMachine.animator.SetBool("IsShooting", false);
                    yield return new WaitForSeconds(2f);
                    state = 2;
                }
                else if (state == 2)
                {
                    stateMachine.SetState(1);
                    yield return new WaitForSeconds(0.2f);
                    stateMachine.SetState(0);

                    yield return new WaitForSeconds(2f);
                    stateMachine.InvokeStateAttack(2);
                    yield return new WaitForSeconds(0.7f);
                    stateMachine.InvokeStateAttack(2);
                    yield return new WaitForSeconds(1f);
                    stateMachine.InvokeStateAttack(2);
                    yield return new WaitForSeconds(1f);
                    stateMachine.InvokeStateAttack(2);
                    yield return new WaitForSeconds(1f);
                    stateMachine.InvokeStateAttack(2);
                    yield return new WaitForSeconds(1f);
                    stateMachine.InvokeStateAttack(2);
                    yield return new WaitForSeconds(1f);
                    stateMachine.InvokeStateAttack(2);
                    yield return new WaitForSeconds(3f);
                    state = 3;
                }
                else if (state == 3)
                {
                    stateMachine.SetState(3);
                    yield return new WaitForSeconds(2f);
                    stateMachine.SetState(4);
                    stateMachine.isShooting = true;
                    yield return new WaitForSeconds(8f);
                    stateMachine.isShooting = false;
                    stateMachine.animator.SetBool("IsShooting", false);
                    stateMachine.SetState(0);
                    state = 0;
                }

            }

        }
    }
}
