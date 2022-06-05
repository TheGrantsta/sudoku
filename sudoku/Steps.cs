using System.Collections.Concurrent;

namespace sudoku
{
    public interface ISteps
    {
        void Add(string coordinate, int value, bool isGuess);

        void RemoveGuesses();

        ConcurrentQueue<Step> Get();
    }

    public class Steps : ISteps
    {
        private ConcurrentQueue<Step> _queue;

        public Steps()
        {
            _queue = new ConcurrentQueue<Step>();
        }

        public void Add(string coordinate, int value, bool isGuess)
        {
            _queue.Enqueue(new Step { Coordinate = coordinate, Value = value, IsGuess = isGuess });
        }

        public void RemoveGuesses()
        {
            var tempQueue = new ConcurrentQueue<Step>();

            foreach(var step in _queue)
            {
                if (!step.IsGuess)
                {
                    tempQueue.Enqueue(step);
                }
            }

            _queue = tempQueue;
        }

        public ConcurrentQueue<Step> Get()
        {
            return _queue;
        }
    }

    public struct Step
    {
        public string Coordinate { get; set; }

        public int Value { get; set; }

        public bool IsGuess { get; set; }
    }
}

