using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using static System.Console;

public class Udpnetwork : MonoBehaviour
{
	private static Udpnetwork instance;
	public static Udpnetwork Instance
	{
		get
		{
			return instance;
		}
		set
		{
			instance = null;
		}
	}
	// 1. Declare Variables

	public String Key;

	Thread receiveThread;
	UdpClient client;
	public int myPort = 7777;

	public String targetip = "127.0.0.1";
	public int targetport = 8090;

	public string text;

	IPEndPoint anyIP;


	void Awake()
	{
		InitUDP();

		if (instance != null)
			Destroy(gameObject);
		else
			instance = this;
		DontDestroyOnLoad(gameObject);


	}
	// 2. Initialize variables
	private void Start()
	{
		//InitUDP();
	}

	// 3. InitUDP
	private void InitUDP()
	{
		client = new UdpClient(myPort); //1
		anyIP = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 0);
		Debug.Log("UDP Initialized");
		receiveThread = new Thread(new ThreadStart(ReceiveData));
		receiveThread.IsBackground = true;
		receiveThread.Start();
	}

	// 4. Receive Data
	private void ReceiveData()
	{
		while (true) //2
		{
			try
			{
				//3
				byte[] data = client.Receive(ref anyIP); //4
				text = Encoding.UTF8.GetString(data); //5
				Debug.Log(text);

				if (text == "0")
				{
					moveinput.state = 0;
				}
				else if (text == "1")
				{
					moveinput.state = 1;
				}
				else if (text == "2")
				{
					moveinput.state = 2;
				}
				else if (text == "3")
				{
					moveinput.state = 3;
				}
			}
			catch (Exception e)
			{
				print(e.ToString()); //7
			}
		}
	}

	void Update()
	{

	}

	public void Sendmsg(String msg)
	{
		byte[] datagram = Encoding.UTF8.GetBytes(msg);
		Debug.Log(msg);
		client.Send(datagram, datagram.Length, targetip, targetport);
	}

	void OnApplicationQuit()
	{
		client.Close();
		receiveThread.Suspend();
	}
}