using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

namespace StoryboardTable
{
	public class Application
	{
		// This is the main entry point of the application.
		static void Main (string[] args)
		{
			// if you want to use a different Application Delegate class from "AppDelegate"
			// you can specify it here.
			UIApplication.Main (args, null, "AppDelegate");
		}
	}
}

//System.Reflection.TargetInvocationException: Exception has been thrown by the target of an invocation. ---> System.Exception: Object reference not set to an instance of an object
//at StoryboardTable.MasterViewController..ctor (IntPtr handle) [0x00390] in /Users/keeganc/Projects/monotouch-samples/StoryboardTable/StoryboardTable/MasterViewController.cs:164
//at at (wrapper managed-to-native) System.Reflection.MonoCMethod:InternalInvoke (System.Reflection.MonoCMethod,object,object[],System.Exception&)
//at System.Reflection.MonoCMethod.InternalInvoke (System.Object obj, System.Object[] parameters) [0x00002] in /Users/builder/data/lanes/1962/8b265d64/source/mono/mcs/class/corlib/System.Reflection/MonoMethod.cs:535
//--- End of inner exception stack trace ---
//at System.Reflection.MonoCMethod.InternalInvoke (System.Object obj, System.Object[] parameters) [0x00016] in /Users/builder/data/lanes/1962/8b265d64/source/mono/mcs/class/corlib/System.Reflection/MonoMethod.cs:541
//at System.Reflection.MonoCMethod.DoInvoke (System.Object obj, BindingFlags invokeAttr, System.Reflection.Binder binder, System.Object[] parameters, System.Globalization.CultureInfo culture) [0x00095] in /Users/builder/data/lanes/1962/8b265d64/source/mono/mcs/class/corlib/System.Reflection/MonoMethod.cs:526
//at System.Reflection.MonoCMethod.Invoke (BindingFlags invokeAttr, System.Reflection.Binder binder, System.Object[] parameters, System.Globalization.CultureInfo culture) [0x00000] in /Users/builder/data/lanes/1962/8b265d64/source/mono/mcs/class/corlib/System.Reflection/MonoMethod.cs:554
//at System.Reflection.ConstructorInfo.Invoke (System.Object[] parameters) [0x00000] in /Users/builder/data/lanes/1962/8b265d64/source/mono/mcs/class/corlib/System.Reflection/ConstructorInfo.cs:62
//at ObjCRuntime.Runtime.ConstructNSObject[NSObject] (IntPtr ptr, System.Type type, MissingCtorResolution missingCtorResolution) [0x00000] in <filename unknown>:0
//at ObjCRuntime.Runtime.ConstructNSObject (IntPtr ptr, IntPtr klass, MissingCtorResolution missingCtorResolution) [0x00013] in /Users/builder/data/lanes/1962/8b265d64/source/maccore/src/ObjCRuntime/Runtime.cs:666
//at ObjCRuntime.Runtime.GetNSObject (IntPtr ptr, MissingCtorResolution missingCtorResolution, Boolean evenInFinalizerQueue) [0x00022] in /Users/builder/data/lanes/1962/8b265d64/source/maccore/src/ObjCRuntime/Runtime.cs:764
//at ObjCRuntime.Runtime.TryGetOrConstructNSObjectWrapped (IntPtr ptr) [0x00000] in /Users/builder/data/lanes/1962/8b265d64/source/maccore/src/ObjCRuntime/Runtime.cs:355
//at ObjCRuntime.Runtime.try_get_or_construct_nsobject (IntPtr obj) [0x00000] in <filename unknown>:0
//at at (wrapper native-to-managed) ObjCRuntime.Runtime:try_get_or_construct_nsobject (intptr)
//at at (wrapper managed-to-native) UIKit.UIApplication:UIApplicationMain (int,string[],intptr,intptr)
//at UIKit.UIApplication.Main (System.String[] args, IntPtr principal, IntPtr delegate) [0x00005] in /Users/builder/data/lanes/1962/8b265d64/source/maccore/src/UIKit/UIApplication.cs:63
//at UIKit.UIApplication.Main (System.String[] args, System.String principalClassName, System.String delegateClassName) [0x0001c] in /Users/builder/data/lanes/1962/8b265d64/source/maccore/src/UIKit/UIApplication.cs:46
//at StoryboardTable.Application.Main (System.String[] args) [0x00008] in /Users/keeganc/Projects/monotouch-samples/StoryboardTable/StoryboardTable/Main.cs:17
