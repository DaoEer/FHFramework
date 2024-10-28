using System;
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
        private static StringBuilder _stringBuilder = new(1024);

        public static void Log(LogLevel logLevel, string message)
        {
            _stringBuilder.Clear();
            switch (logLevel)
            {
                case LogLevel.Log:
                    _stringBuilder.AppendFormat($"<color=#C0C0C0><b>[{LogLevel.Log}] ► </b></color><color=gray>{message}</color>");
                    Debug.Log(_stringBuilder.ToString());
                    break;
                case LogLevel.Warning:
                    _stringBuilder.AppendFormat($"<color=#CC9A06><b>[{LogLevel.Warning}] ► </b></color><color=gray>{message}</color>");
                    Debug.LogWarning(_stringBuilder.ToString());
                    break;
                case LogLevel.Error:
                    _stringBuilder.AppendFormat($"<color=#CC423B><b>[{LogLevel.Error}] ► </b></color><color=gray>{message}</color>");
                    Debug.LogError(_stringBuilder.ToString());
                    break;
                case LogLevel.Exception:
                default:
                    _stringBuilder.AppendFormat($"<color=#CC423B><b>[{LogLevel.Exception}] ► </b></color><color=gray>{message}</color>");
                    throw new Exception(_stringBuilder.ToString());
            }
        }

        public static void LogInfo(string message)
        {
            Log(LogLevel.Log, message);
        }

        public static void LogWarning(string message)
        {
            Log(LogLevel.Warning, message);
        }

        public static void LogError(string message)
        {
            Log(LogLevel.Error, message);
        }

        public static void LogException(string message)
        {
            Log(LogLevel.Exception, message);
        }
    }
}
