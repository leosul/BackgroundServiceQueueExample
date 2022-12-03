namespace BackgroundServiceQueueExample.Interfaces;

public interface IBackgroundQueue<T>
{
    void Enqueue(T item);
    T Dequeue();
}
