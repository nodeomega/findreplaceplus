using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Configuration;
using System.Threading;
using System.Windows.Forms;

namespace FindReplacePlus.Classes
{
    public class RetinaTask
    {
        private bool _retinaProcessStopped;

        private readonly SynchronizationContext _syncContext;

        public event EventHandler<RetinaTaskResponse> CallbackLog;
        public event EventHandler<RetinaTaskResponse> CallbackTree;

        private readonly Queue<RetinaTaskResponse> _queue = new Queue<RetinaTaskResponse>();

        public int QueueCount => _queue.Count;

        private Thread _thread;

        public RetinaTask()
        {
            _syncContext = AsyncOperationManager.SynchronizationContext;
        }

        public void Start()
        {
            //Thread thread = new Thread(Run) {IsBackground = true};
            _thread = new Thread(Run) { IsBackground = true };
            _thread.Start();
            _retinaProcessStopped = false;
        }

        public void Stop()
        {
            _retinaProcessStopped = true;
        }

        public void ChangeData(string message, TreeNode node)
        {
            _queue.Enqueue(new RetinaTaskResponse(message, node));
        }

        private void Run()
        {
            while (!_retinaProcessStopped)
            {
                if (_queue.Count > 0)
                {
                    try
                    {
                        RetinaTaskResponse currentResponse = _queue.Dequeue();
                        if (!string.IsNullOrWhiteSpace(currentResponse?.Message))
                            _syncContext.Post(e => TriggerLogCallback(currentResponse), null);
                        else if (currentResponse?.Node != null)
                            _syncContext.Post(e => TriggerTreeCallback(currentResponse), null);
                    }
                    catch
                    {
                        // suppress
                    }
                }
                //Thread.Sleep(500);
            }
        }

        private void TriggerLogCallback(RetinaTaskResponse response) => CallbackLog?.Invoke(this, response);

        private void TriggerTreeCallback(RetinaTaskResponse response) => CallbackTree?.Invoke(this, response);
    }
}
