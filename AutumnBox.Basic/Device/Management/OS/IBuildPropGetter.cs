﻿/*************************************************
** auth： zsh2401@163.com
** date:  2018/8/29 4:31:40 (UTC +8:00)
** desc： ...
*************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutumnBox.Basic.Device.Management.OS
{
    /// <summary>
    /// BuildProp获取器
    /// </summary>
    public interface IBuildPropGetter
    {

        string this[string key] { get; }
        void Reload();
    }
}