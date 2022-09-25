using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{

    private BossStateMachine stateMachine;



    // Start is called before the first frame update
    private IEnumerator Start()
    {
        stateMachine = GetComponent<BossStateMachine>();
        stateMachine.SetState(0);

        var state = 0;

        while (!stateMachine.isDead)
        {

            if (state == 0)
            {
                yield return new WaitForSeconds(5f);
                stateMachine.SetState(1);

                while (!stateMachine.playerReached)
                {
                    yield return new WaitForEndOfFrame();
                }

                yield return new WaitForSeconds(0.05f);
                stateMachine.InvokeStateAttack();

                yield return new WaitForSeconds(.8f);
                stateMachine.InvokeStateAttack();

                yield return new WaitForSeconds(.8f);
                stateMachine.InvokeStateAttack();

                yield return new WaitForSeconds(1f);
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
    }
}
