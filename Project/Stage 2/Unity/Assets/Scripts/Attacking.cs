using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacking : MonoBehaviour
{
	[SerializeField] LayerMask m_CoalLayer;
	[SerializeField] GameObject m_CoalPrefab;
	[SerializeField] Transform m_RaycastPoint;

	void Update()
	{
		if (Input.GetButtonDown("Fire1"))
		{
			Debug.Log("Attack");

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
