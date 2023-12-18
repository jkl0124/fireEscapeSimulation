﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SojaExiles

{
	public class opencloseDoor : MonoBehaviour
	{

		public Animator openandclose;
		public bool open;
		public Transform Player;

		void Start()
		{
			open = false;
		}

        void Update() //이거나중에빼야함
        {

			if(Input.GetKey(KeyCode.Space))
							{
				StartCoroutine(opening());
			}
			if (Input.GetKey(KeyCode.A))
			{
				StartCoroutine(closing());
			}
		}
        void OnMouseOver()
		{
			{
				if (Player)
				{
					//float dist = Vector3.Distance(Player.position, transform.position);
					//if (dist < 15)
					//{
						if (open == false)
						{
							if (Input.GetKey(KeyCode.Space))
							{
								StartCoroutine(opening());
							}
						}
						else
						{
							if (open == true)
							{
								if (Input.GetKey(KeyCode.Space))
								{
									//StartCoroutine(closing());
								}
							}

						//}

					}
				}

			}

		}

		IEnumerator opening()
		{
			print("you are opening the door");
			openandclose.Play("Opening");
			open = true;
			yield return new WaitForSeconds(.5f);
		}

		IEnumerator closing()
		{
			print("you are closing the door");
			openandclose.Play("Closing");
			open = false;
			yield return new WaitForSeconds(.5f);
		}


	}
}