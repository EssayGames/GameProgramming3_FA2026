using System.Collections;
using UnityEngine;

public class CageTimer : MonoBehaviour
{
    private MeshRenderer m_MR;
    private MeshCollider m_MC;

    public void Start()
    {
        m_MR = GetComponent<MeshRenderer>();
        m_MC = GetComponent<MeshCollider>();
    }
    public void cageEnter()
    {
        StartCoroutine(cageOff());
    }

    public IEnumerator cageOff()
    {
        m_MR.enabled = false;
        m_MC.enabled = false;
        yield return new WaitForSeconds(5);
        m_MR.enabled = true;
        m_MC.enabled = true;


    }
}
