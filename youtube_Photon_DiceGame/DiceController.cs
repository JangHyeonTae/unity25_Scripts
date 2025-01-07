using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceController : MonoBehaviour
{
    public Rigidbody rb;
    public Transform[] nums;
    public int num;

    public IEnumerator Roll()
    {
        transform.position = new Vector3(0, 3, 0);
        transform.localEulerAngles = new Vector3(Random.Range(-90, 90), Random.Range(-90, 90), Random.Range(-90, 90));
        //angularVelocity -> ȸ���ӵ� , insideUnitSphere -> Vector3��ȯ(���� x,y,z �� ��ȯ)
        rb.angularVelocity = Random.insideUnitSphere * Random.Range(-1000, 1000);

        yield return new WaitForSeconds(3);

        while (true)
        {
            yield return null;
            if (rb.velocity.sqrMagnitude < 0.001f) break; //sqrMagnitude ��� magnitude ����ص������� ��귮 ���
        }

        //�ֻ����� �׸𿡼� 1�̻��� ���� �� �����̶� �����ϰ� �� ���� �����ͼ� num�� ����
        for(int i =0; i < nums.Length; i++)
        {
            if (nums[i].position.y > 1)
            {
                num = i + 1;
                break;
            }
        }
    }
}
