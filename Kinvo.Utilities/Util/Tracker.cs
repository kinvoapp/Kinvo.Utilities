using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Kinvo.Utilities.Util
{
    public class Tracker<TResult>
    {
        private Tracker(TimeSpan timeSpan, TResult result)
        {
            this.Elapsed = timeSpan;
            this.Result = result;
        }

        public TimeSpan Elapsed { get; set; }
        public TResult Result { get; set; }

        public static Tracker<TResult> Track(Func<TResult> func)
        {
            var stopWatch = Stopwatch.StartNew();
            var result = func.Invoke();
            stopWatch.Stop();

            var tracker = new Tracker<TResult>(stopWatch.Elapsed, result);
            return tracker;
        }

        public static async Task<Tracker<TResult>> TrackAsync(Func<Task<TResult>> func)
        {
            var stopWatch = Stopwatch.StartNew();
            var result = await func.Invoke();
            stopWatch.Stop();

            var tracker = new Tracker<TResult>(stopWatch.Elapsed, result);
            return tracker;
        }
    }
}