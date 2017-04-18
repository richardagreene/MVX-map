using System;
namespace MVXmap.Core.Messages
{
	// For each message add one 
	// TODO: should make this a factory.
	public enum AppMessage 
	{ 	
		InitDatabase, 
		Alert,
		Reload,
		ShowPins
	}
}
