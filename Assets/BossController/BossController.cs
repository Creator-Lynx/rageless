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
                    stateMachine.InvokeStateAttack();

                    yield return new WaitForSeconds(1.5f);
                    stateMachine.InvokeStateAttack();

                    yield return new WaitForSeconds(1f);
                    stateMachine.InvokeStateAttack();

                    yield return new WaitForSeconds(2f);
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
                yield return new WaitForSeconds(5f);
            }

        }
    }
}
