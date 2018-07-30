using System;
namespace XF1.Core.Common.Session
{
    public interface ISessionManager
    {
        void Set<T>(string key, T data);
        T Get<T>(string key);
        void Remove(string key);
        bool IsSet(string key);
        void Clear();
    }
}
