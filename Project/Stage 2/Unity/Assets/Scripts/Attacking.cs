using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Attacking : MonoBehaviour
{
	[SerializeField] LayerMask m_CoalLayer;
	[SerializeField] GameObject m_CoalPrefab;
	[SerializeField] Transform m_RaycastPoint;

	[SerializeField] Animator m_Animator;

	void Awake()
	{
		Assert.IsNotNull(m_Animator);
	}

	void Update()
	{
		if (Input.GetButtonDown("Fire1"))
		{
			m_Animator.SetTrigger("Attack");

			Ray ray = new()
			{
				origin = m_RaycastPoint.position,
				direction = m_RaycastPoint.forward
			};
			if (!Physics.Raycast(ray, out RaycastHit hit, 2, m_CoalLayer, QueryTriggerInteraction.Collide))
			{
				Debug.Log("No hit");
				return;
			}

			Debug.Log("Hit");

			GameObject coal = Instantiate(m_CoalPrefab);
			coal.transform.position = hit.point;
		}
	}
}
