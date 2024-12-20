using System.Collections;
using System.Collections.Generic;
using DitzelGames.FastIK;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.TextCore;
using Vector3 = UnityEngine.Vector3;

public class Attacking : MonoBehaviour
{
	[SerializeField] LayerMask m_CoalLayer;
	[SerializeField] LayerMask m_mineCartLayer;
	[SerializeField] GameObject m_CoalPrefab;
	[SerializeField] Transform m_RaycastPoint;

	[SerializeField] Animator m_Animator;

	[SerializeField] private FastIKFabric h1;
	[SerializeField] private FastIKFabric h2;
	[SerializeField] private Transform g1;
	[SerializeField] private Transform g2;
	
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

		if (Input.GetKeyDown(KeyCode.E))
		{
			Ray ray = new()
			{
				origin = m_RaycastPoint.position,
				direction = m_RaycastPoint.forward
			};
			if (!Physics.Raycast(ray, out RaycastHit hit, 2, m_mineCartLayer, QueryTriggerInteraction.Collide))
			{
				Debug.Log("No hit");
				return;
			}

			print("Attach to minecart");
			CubicInterpolation minecart = hit.transform.GetComponent<CubicInterpolation>();
			minecart.IsPlayerRiding = true;
			gameObject.GetComponent<PlayerController>().enabled = false;
			gameObject.GetComponent<CharacterController>().enabled = false;
			gameObject.GetComponent<PlayerLook>().enabled = false;
			
			transform.SetParent(minecart.transform);
			transform.localPosition = new Vector3(-0.0004f, 0.02392f, 0.00024f);
			//transform.localRotation = Quaternion.Euler();
			transform.localRotation = Quaternion.identity;
			transform.GetChild(0).localRotation = Quaternion.Euler(90, 0, 0);

			h1.enabled = true;
			h2.enabled = true;

			h1.Target = g1;
			h2.Target = g2;
		}
	}

	void RideMineCart()
	{
		
	}
}
