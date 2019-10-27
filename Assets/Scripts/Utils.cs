using System;

class Utils {
	public static void SafelyCallEvent (Action e) {
		if (e != null) {
			e ();
		}
	}
}