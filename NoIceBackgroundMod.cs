using System;
using ScrollsModLoader.Interfaces;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using Mono.Cecil;
namespace NoIceBackgroundMod
{
	public class NoIceBackgroundMod : BaseMod
	{
		int desiredBackgroundID;
		string desiredBackgroundName = "IceCave";
		public NoIceBackgroundMod ()
		{
			FieldInfo f = typeof(BackgroundData).GetField ("bgs", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
			IList bgs = f.GetValue (null) as IList;
			for(int i = 0; i < bgs.Count; i++) {
				object o = bgs [i];
				if (o is BackgroundData) {
					BackgroundData bg = o as BackgroundData;
					if (bg.name.Equals (desiredBackgroundName)) {
						desiredBackgroundID = i;
						break;
					}
				}
			}
		}

		public static MethodDefinition[] GetHooks(TypeDefinitionCollection scrollsTypes, int version) {
			MethodDefinition[] m = scrollsTypes ["BackgroundData"].Methods.GetMethod ("getBackgroundIdFor");
			if (m.Length == 1)
				return m;
			return new MethodDefinition[] {};
		}
		public static string GetName() {
			return "OnlyIceBackground";
		}
		public static int GetVersion() {
			return 4;
		}

		public override void BeforeInvoke (InvocationInfo info) {
		}

		public override void AfterInvoke (InvocationInfo info, ref object returnValue) {
			if (returnValue.GetType().Equals(typeof(int))) {
				returnValue = desiredBackgroundID; 
			}
		}
	}
}

