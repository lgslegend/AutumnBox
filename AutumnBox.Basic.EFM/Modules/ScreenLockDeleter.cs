/* =============================================================================*\
*
* Filename: ScreenLockDeleter.cs
* Description: 
*
* Version: 1.0
* Created: 9/22/2017 03:13:12(UTC+8:00)
* Compiler: Visual Studio 2017
* 
* Author: zsh2401
* Company: I am free man
*
\* =============================================================================*/
using AutumnBox.Basic.Executer;
using AutumnBox.Basic.Function.Bundles;
using System.Threading;

namespace AutumnBox.Basic.Function.Modules
{
    public sealed class ScreenLockDeleter : FunctionModule
    {
        protected override Output MainMethod(BundleForTools bundle)
        {
            AndroidShell _shell = new AndroidShell(bundle.Args.DeviceBasicInfo.Serial);
            var builder = new OutputBuilder();
            builder.Register(_shell);
            _shell.Connect();
            _shell.Switch2Su();
            _shell.SafetyInput("rm /data/system/gesture.key");
            _shell.SafetyInput("adb shell rm /data/system/password.key");
            new Thread(_shell.Disconnect).Start();
            bundle.Ae("reboot");
            return builder.ToOutput();
        }
    }
}
