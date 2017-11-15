/* =============================================================================*\
*
* Filename: BreventServiceActivator.cs
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
namespace AutumnBox.Basic.Function.Modules
{
    using AutumnBox.Basic.Executer;
    using AutumnBox.Basic.Function.Args;
    using AutumnBox.Support.CstmDebug;

    /// <summary>
    /// 黑域服务激活器
    /// </summary>
    public sealed class BreventServiceActivator : FunctionModule
    {
        private static readonly string DEFAULT_SHELL_COMMAND = "sh /data/data/me.piebridge.brevent/brevent.sh";
        private bool _exitResult;
        protected override OutputData MainMethod()
        {
            OutputData o = new OutputData
            {
                OutSender = Executer
            };
            Logger.D("start brevent activity");
            FunctionModuleProxy.Create<ActivityLauncher>(new ActivityLaunchArgs(Args.DeviceBasicInfo)
            { PackageName = "me.piebridge.brevent", ActivityName = ".ui.BreventActivity" }).FastRun();
            Logger.D("try to execute command with quicklyshell ");
            Executer.QuicklyShell(DeviceID, DEFAULT_SHELL_COMMAND, out _exitResult);
            return o;
        }
        protected override void AnalyzeOutput(ref ExecuteResult result)
        {
            base.AnalyzeOutput(ref result);
            Logger.D($"shell exitResult?? {_exitResult}");
            if (result.OutputData.Error != null) result.Level = ResultLevel.Unsuccessful;
            if (result.OutputData.All.ToString().ToLower().Contains("warning")) result.Level = ResultLevel.Unsuccessful;
            if (result.OutputData.All.ToString().ToLower().Contains("started")) result.Level = ResultLevel.Successful;
        }
    }
}
