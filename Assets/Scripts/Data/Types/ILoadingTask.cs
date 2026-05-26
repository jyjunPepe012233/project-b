using System;
using System.Collections;

namespace ProjectB.Data.Types
{
    public interface ILoadingTask
    {
        bool IsDone { get; }
        
        float Progress { get; }

        // 로딩이 여러 프레임에 걸쳐 진행되는 작업일 수 있으므로 IEnumerator를 반환하는 Func를 사용
        Func<IEnumerator> LoadFunc { get; }
    }
}