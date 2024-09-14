﻿using System;
using System.Text;
using UnityEngine;

namespace FHFramework
{
    public enum LogLevel
    {
        Log,
        Warning,
        Error,
        Exception
    }

    public class LogHelper
    {
        private static readonly StringBuilder m_StringBuilder = new StringBuilder(1024);

        public static void Log(LogLevel logLevel, string message)
        {
            m_StringBuilder.Clear();
            switch (logLevel)
            {
                case LogLevel.Log:
                    m_StringBuilder.AppendFormat($"<color=#C0C0C0><b>[{LogLevel.Log}] ► </b></color><color=gray>{message}</color>");
                    Debug.Log(m_StringBuilder.ToString());
                    break;
                case LogLevel.Warning:
                    m_StringBuilder.AppendFormat($"<color=#CC9A06><b>[{LogLevel.Warning}] ► </b></color><color=gray>{message}</color>");
                    Debug.LogWarning(m_StringBuilder.ToString());
                    break;
                case LogLevel.Error:
                    m_StringBuilder.AppendFormat($"<color=#CC423B><b>[{LogLevel.Error}] ► </b></color><color=gray>{message}</color>");
                    Debug.LogError(m_StringBuilder.ToString());
                    break;
                default:
                    m_StringBuilder.AppendFormat($"<color=#CC423B><b>[{LogLevel.Exception}] ► </b></color><color=gray>{message}</color>");
                    throw new Exception(m_StringBuilder.ToString());
            }
        }
    }
}